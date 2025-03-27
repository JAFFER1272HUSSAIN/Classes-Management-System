using class_management_system;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace WindowsFormsApp1.Forms
{
    public partial class RubricLvlForm : Form
    {
        // list
        private List<string> deletedIdRubricLvl = new List<string>();
        public RubricLvlForm()
        {
            InitializeComponent();
            LoadDeletedIdRubricLvl();
        }

        private void CreateBtn_Click_1(object sender, EventArgs e)
        {
            try
            {
                string rubricIdInput = Interaction.InputBox("Enter the Rubric ID", "Rubric ID");
                string mLevelInput = Interaction.InputBox("Enter the Measurement Level", "Measurement Level");
                string details = Interaction.InputBox("Enter the details of the Rubric Level", "Rubric Level Details");

                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("IF NOT EXISTS (SELECT * FROM RubricLevel WHERE RubricId = @RubricId AND MeasurementLevel = @MeasurementLevel) " +
                                                 "BEGIN " +
                                                 "INSERT INTO RubricLevel (RubricId, MeasurementLevel, Details) VALUES (@RubricId, @MeasurementLevel, @Details) " +
                                                 "SELECT SCOPE_IDENTITY() AS NewRubricLevelID " +
                                                 "END", con);
                cmd.Parameters.AddWithValue("@RubricId", rubricIdInput);
                cmd.Parameters.AddWithValue("@MeasurementLevel", mLevelInput);
                cmd.Parameters.AddWithValue("@Details", details);
                int newRubricLevelID = Convert.ToInt32(cmd.ExecuteScalar());

                if (newRubricLevelID > 0)
                {
                    MessageBox.Show("Rubric Level Added Successfully");
                }
                else
                {
                    MessageBox.Show("Rubric Level Already Exists");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

            loadBtn_Click(sender, e);
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string id = Interaction.InputBox("Enter the ID", "Assessment ID");
                string rubricIdInput = Interaction.InputBox("Enter the Rubric ID", "Rubric ID");
                string mLevelInput = Interaction.InputBox("Enter the Measurement Level", "Measurement Level");
                string details = Interaction.InputBox("Enter the updated details of the Rubric Level", "Update Rubric Level Details");


                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("UPDATE RubricLevel SET RubricId = @RubricId, MeasurementLevel = @MeasurementLevel, Details = @Details " +
                                                 "WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@RubricId", rubricIdInput);
                cmd.Parameters.AddWithValue("@MeasurementLevel", mLevelInput);
                cmd.Parameters.AddWithValue("@Details", details);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Rubric Level Updated Successfully");


            loadBtn_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }


        }




        private void deleteBtn_Click(object sender, EventArgs e)
        {
            // Check if there is a selected row
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex;

                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this Rubric?", "Delete Rubric", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            string id = row.Cells["Id"].Value.ToString();
                            if (!deletedIdRubricLvl.Contains(id))
                            {
                                deletedIdRubricLvl.Add(id);
                            }
                        }
                        SaveDeletedIdRubricLvl();
                        MessageBox.Show("Rubric Level Deleted Successfully");
                        loadBtn_Click(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Select * from RubricLevel", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

                foreach (string id in deletedIdRubricLvl)
                {
                    DataRow[] rowsToDelete = dt.Select($"Id = '{id}'");
                    foreach (DataRow rowToDelete in rowsToDelete)
                    {
                        dt.Rows.Remove(rowToDelete);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

            
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Width = 200;
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string rubricIdInput = Interaction.InputBox("Enter the Rubric ID", "Rubric ID");
                string mLevelInput = Interaction.InputBox("Enter the Measurement Level", "Measurement Level");
                string details = Interaction.InputBox("Enter the updated details of the Rubric Level", "Update Rubric Level Details");

                if (!int.TryParse(rubricIdInput, out int rubricId))
                {
                    MessageBox.Show("Please enter a valid Rubric ID");
                    return;
                }

                int mLevel;
                if (!int.TryParse(mLevelInput, out mLevel) || mLevel < 1 || mLevel > 4)
                {
                    MessageBox.Show("Please enter a valid Measurement Level (1-4)");
                    return;
                }

                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("UPDATE RubricLevel SET RubricId = @RubricId, MeasurementLevel = @MeasurementLevel, Details = @Details " +
                                                 "WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@RubricId", rubricId);
                cmd.Parameters.AddWithValue("@MeasurementLevel", mLevel);
                cmd.Parameters.AddWithValue("@Details", details);
                cmd.Parameters.AddWithValue("@Id", int.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString()));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Rubric Level saved Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

            loadBtn_Click(sender, e);
        }

        private void LoadDeletedIdRubricLvl()
        {
            string filePath = "deletedIdRubricLvl.txt";
            if (File.Exists(filePath))
            {
                deletedIdRubricLvl = File.ReadAllLines(filePath).ToList();
            }
        }

        private void SaveDeletedIdRubricLvl()
        {
            string filePath = "deletedIdRubricLvl.txt";
            File.WriteAllLines(filePath, deletedIdRubricLvl);
        }

    }
}
