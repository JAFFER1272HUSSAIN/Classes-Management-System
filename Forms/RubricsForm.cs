using FontAwesome.Sharp;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using class_management_system;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Linq;

namespace WindowsFormsApp1.Forms
{
    public partial class RubricsForm : Form
    {
        // list
        private List<string> deletedIdRubric = new List<string>();
        public RubricsForm()
        {
            InitializeComponent();
            LoadDeletedIdRubric();
        }

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            string details = Interaction.InputBox("Enter the details of the Rubric", "Rubric Details");
            if (string.IsNullOrEmpty(details))
            {
                MessageBox.Show("Please fill the Rubric details");
                return;
            }

            int cloId;
            if (!int.TryParse(Interaction.InputBox("Enter the CLO ID for the Rubric", "CLO ID"), out cloId))
            {
                MessageBox.Show("Please enter a valid CLO ID");
                return;
            }

            int rubricId;
            if (!int.TryParse(Interaction.InputBox("Enter the Rubric ID", "Rubric ID"), out rubricId))
            {
                MessageBox.Show("Please enter a valid Rubric ID");
                return;
            }

            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("IF NOT EXISTS (SELECT * FROM Rubric WHERE details = @details AND CLOId = @CLOId) " +
                                                 "BEGIN " +
                                                 "INSERT INTO Rubric (details, CLOId, Id) VALUES (@details, @CLOId, @RubricId) " +
                                                 "SELECT SCOPE_IDENTITY() AS NewRubricID " +
                                                 "END", con);
                cmd.Parameters.AddWithValue("@details", details);
                cmd.Parameters.AddWithValue("@CLOId", cloId);
                cmd.Parameters.AddWithValue("@RubricId", rubricId);
                int newRubricID = Convert.ToInt32(cmd.ExecuteScalar());

                if (newRubricID > 0)
                {
                    MessageBox.Show("Rubric record added successfully");
                }
                else
                {
                    MessageBox.Show("Rubric record already exists for CLO");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

            LoadData();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            string details = Interaction.InputBox("Enter the updated details of the Rubric", "Update Rubric Details");
            if (string.IsNullOrEmpty(details))
            {
                MessageBox.Show("Please fill the updated Rubric details");
                return;
            }

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE Rubric SET details = @details WHERE Id = @Id", con);
            cmd.Parameters.AddWithValue("@details", details);
            cmd.Parameters.AddWithValue("@Id", dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Id"].Value);

            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Rubric record updated successfully");
            }
            else
            {
                MessageBox.Show("Failed to update Rubric record");
            }

            LoadData();
        }

        private void LoadData()
        {
            var con = Configuration.getInstance().getConnection();
            var cmd = new SqlCommand("SELECT * FROM Rubric", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            foreach (string id in deletedIdRubric)
            {
                DataRow[] rowsToDelete = dt.Select($"Id = '{id}'");
                foreach (DataRow rowToDelete in rowsToDelete)
                {
                    dt.Rows.Remove(rowToDelete);
                }
            }

            // Adjust column widths
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Width = 200;
            }
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this Rubric?", "Delete Rubric", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    string id = row.Cells["Id"].Value.ToString();
                    if (!deletedIdRubric.Contains(id))
                    {
                        deletedIdRubric.Add(id);
                    }
                }
                SaveDeletedIdRubric();
                MessageBox.Show("Rubric record deleted successfully");
                LoadData();
            }
        }


        private void LoadDeletedIdRubric()
        {
            string filePath = "deletedIdRubric.txt";
            if (File.Exists(filePath))
            {
                deletedIdRubric = File.ReadAllLines(filePath).ToList();
            }
        }

        private void SaveDeletedIdRubric()
        {
            string filePath = "deletedIdRubric.txt";
            File.WriteAllLines(filePath, deletedIdRubric);
        }
    }
}
