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
    public partial class AssessmentComponentsForm : Form
    {
        private List<string> deletedIdAssessmentComponents = new List<string>();
        public AssessmentComponentsForm()
        {
            InitializeComponent();
            LoadDeletedIdAssessmentComponents();
        }

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string name = Interaction.InputBox("Enter the Name", "Assessment Component Name");
                string rubricId = Interaction.InputBox("Enter the Rubric ID", "Rubric ID");
                string totalMarks = Interaction.InputBox("Enter the Total Marks", "Total Marks");
                string assessmentId = Interaction.InputBox("Enter the Assessment ID", "Assessment ID");
                DateTime dateCreated = dtCreated.Value;
                DateTime dateUpdated = dtUpdated.Value;

                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("IF NOT EXISTS (SELECT * FROM AssessmentComponent WHERE Name = @Name) " +
                                                "BEGIN " +
                                                "INSERT INTO AssessmentComponent (Name, RubricId, TotalMarks, AssessmentID, DateCreated, DateUpdated) " +
                                                "VALUES (@Name, @RubricId, @TotalMarks, @AssessmentID, @DateCreated, @DateUpdated) " +
                                                "END", con);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@RubricId", int.Parse(rubricId));
                cmd.Parameters.AddWithValue("@TotalMarks", int.Parse(totalMarks));
                cmd.Parameters.AddWithValue("@AssessmentID", int.Parse(assessmentId));
                cmd.Parameters.AddWithValue("@DateCreated", dateCreated);
                cmd.Parameters.AddWithValue("@DateUpdated", dateUpdated);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Inserted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadBtn_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string id = Interaction.InputBox("Enter the ID", "Assessment Component ID");
                string name = Interaction.InputBox("Enter the Name", "Assessment Component Name");
                string totalMarks = Interaction.InputBox("Enter the Total Marks", "Total Marks");
                DateTime dateUpdated = dtUpdated.Value;

                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("UPDATE AssessmentComponent SET Name = @Name, TotalMarks = @TotalMarks, " +
                                                "DateUpdated = @DateUpdated WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@TotalMarks", int.Parse(totalMarks));
                cmd.Parameters.AddWithValue("@DateUpdated", dateUpdated);
                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated Successfully");
                loadBtn_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    if (!deletedIdAssessmentComponents.Contains(id))
                    {
                        deletedIdAssessmentComponents.Add(id);
                    }
                }

                SaveDeletedIdAssessmentComponents();
                MessageBox.Show("Data Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadBtn_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM AssessmentComponent", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;


                foreach (string id in deletedIdAssessmentComponents)
                {
                    DataRow[] rowsToDelete = dt.Select($"Id = '{id}'");
                    foreach (DataRow rowToDelete in rowsToDelete)
                    {
                        dt.Rows.Remove(rowToDelete);
                    }
                }

                // increase size of each column
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.Width = 150;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void LoadDeletedIdAssessmentComponents()
        {
            string filePath = "deletedIdAssessmentComponents.txt";
            if (File.Exists(filePath))
            {
                deletedIdAssessmentComponents = File.ReadAllLines(filePath).ToList();
            }
        }

        private void SaveDeletedIdAssessmentComponents()
        {
            string filePath = "deletedIdAssessmentComponents.txt";
            File.WriteAllLines(filePath, deletedIdAssessmentComponents);
        }
    }
}
