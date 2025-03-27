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
    public partial class CLOsForm : Form
    {
        private string name = "";
        private DateTime dateCreated;
        private DateTime dateUpdated;

        // list
        private List<string> deletedIdCLO = new List<string>();

        public CLOsForm()
        {
            InitializeComponent();
            LoadDeletedIdCLO();
        }

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                name = Interaction.InputBox("Enter the name of the CLO", "CLO Name");
                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Please fill the CLO name");
                    return;
                }

                dateCreated = dateTimePicker1.Value;
                dateUpdated = dateTimePicker2.Value;

                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("IF NOT EXISTS (SELECT * FROM CLO WHERE name = @name) " +
                                                 "BEGIN " +
                                                 "INSERT INTO CLO (name, DateCreated, DateUpdated) VALUES (@name, @DateCreated, @DateUpdated) " +
                                                 "SELECT SCOPE_IDENTITY() AS NewCLOID " +
                                                 "END", con);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@DateCreated", dateCreated);
                cmd.Parameters.AddWithValue("@DateUpdated", dateUpdated);
                int newCLOID = Convert.ToInt32(cmd.ExecuteScalar());

                if (newCLOID > 0)
                {
                    MessageBox.Show("CLO record added successfully");
                }
                else
                {
                    MessageBox.Show("CLO record already exists for name: " + name);
                }

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            string newName = Interaction.InputBox("Enter the updated name of the CLO", "Update CLO Name");

            if (string.IsNullOrEmpty(newName))
            {
                MessageBox.Show("Please fill the updated CLO name");
                return;
            }

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE CLO SET name = @newName, DateUpdated = @DateUpdated WHERE ID = @ID", con);

            cmd.Parameters.AddWithValue("@newName", newName);
            cmd.Parameters.AddWithValue("@DateUpdated", dateTimePicker2.Value);
            cmd.Parameters.AddWithValue("@ID", dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value);

            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                MessageBox.Show("CLO record updated successfully");
            }
            else
            {
                MessageBox.Show("Failed to update CLO record");
            }

            LoadData();
        }

        private void LoadData()
        {
            var con = Configuration.getInstance().getConnection();
            var cmd = new SqlCommand("SELECT * FROM CLO", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            foreach (string id in deletedIdCLO)
            {
                DataRow[] rowsToDelete = dt.Select($"Id = '{id}'");
                foreach (DataRow rowToDelete in rowsToDelete)
                {
                    dt.Rows.Remove(rowToDelete);
                }
            }

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
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a row to delete");
                    return;
                }

                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    string id = row.Cells["ID"].Value.ToString();
                    if (!deletedIdCLO.Contains(id))
                    {
                        deletedIdCLO.Add(id);
                    }
                }

                SaveDeletedIdCLO();
                MessageBox.Show("Data Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadBtn_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void LoadDeletedIdCLO()
        {
            string filePath = "deletedIdCLO.txt";
            if (File.Exists(filePath))
            {
                deletedIdCLO = File.ReadAllLines(filePath).ToList();
            }
        }

        private void SaveDeletedIdCLO()
        {
            string filePath = "deletedIdCLO.txt";
            File.WriteAllLines(filePath, deletedIdCLO);
        }
    }
}
