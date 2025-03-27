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
    public partial class AssessmentForm : Form
    {
        private List<string> deletedIdAssessment = new List<string>();
        public AssessmentForm()
        {
            InitializeComponent();
            LoadDeletedIdAssessment();
        }

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string title = Interaction.InputBox("Enter the Title", "Assessment Title");
                string totalMarks = Interaction.InputBox("Enter the Total Marks", "Total Marks");
                string totalWeightage = Interaction.InputBox("Enter the Total Weightage", "Total Weightage");
                DateTime dateCreated = dtDateCreated.Value; // Use selected date from DateTimePicker

                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("IF NOT EXISTS (SELECT * FROM Assessment WHERE Title = @Title) " +
                                                 "BEGIN " +
                                                 "INSERT INTO Assessment (Title, TotalMarks, TotalWeightage, DateCreated) VALUES (@Title, @TotalMarks, @TotalWeightage, @DateCreated) " +
                                                 "END " +
                                                 "ELSE " +
                                                 "BEGIN " +
                                                 "UPDATE Assessment SET TotalMarks = @TotalMarks, TotalWeightage = @TotalWeightage WHERE Title = @Title " +
                                                 "END", con);
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@TotalMarks", int.Parse(totalMarks));
                cmd.Parameters.AddWithValue("@TotalWeightage", int.Parse(totalWeightage));
                cmd.Parameters.AddWithValue("@DateCreated", dateCreated);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Saved Successfully");
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
                string title = Interaction.InputBox("Enter the Title", "Assessment Title");
                string totalMarks = Interaction.InputBox("Enter the Total Marks", "Total Marks");
                string totalWeightage = Interaction.InputBox("Enter the Total Weightage", "Total Weightage");


                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("UPDATE Assessment SET Title = @Title, TotalMarks = @TotalMarks, TotalWeightage = @TotalWeightage WHERE Id = @ID", con);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@TotalMarks", int.Parse(totalMarks));
                cmd.Parameters.AddWithValue("@TotalWeightage", int.Parse(totalWeightage));
                cmd.ExecuteNonQuery();
                loadBtn_Click(sender, e);
                MessageBox.Show("Data Updated Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
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
                    string id = row.Cells["Id"].Value.ToString();
                    if (!deletedIdAssessment.Contains(id))
                    {
                        deletedIdAssessment.Add(id);
                    }
                }

                SaveDeletedIdAssessment();
                MessageBox.Show("Data Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadBtn_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Assessment", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

                foreach (string id in deletedIdAssessment)
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

        private void LoadDeletedIdAssessment()
        {
            string filePath = "deletedIdAssessment.txt";
            if (File.Exists(filePath))
            {
                deletedIdAssessment = File.ReadAllLines(filePath).ToList();
            }
        }

        private void SaveDeletedIdAssessment()
        {
            string filePath = "deletedIdAssessment.txt";
            File.WriteAllLines(filePath, deletedIdAssessment);
        }
    }
}
