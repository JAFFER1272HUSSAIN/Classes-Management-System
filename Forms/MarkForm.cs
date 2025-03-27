using class_management_system;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1.Forms
{
    public partial class MarkForm : Form
    {
        // list
        private List<string> deletedStudentIdMark = new List<string>();
        public MarkForm()
        {
            InitializeComponent();
            MarkForm_Load(null, null);
            LoadDeletedStudentIdMark();

        }


        private void MarkForm_Load(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Student", con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "Id";
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM AssessmentComponent", con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "Id";
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM RubricLevel", con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                comboBox3.DataSource = dt;
                comboBox3.DisplayMember = "Id";
                reader.Close();
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM StudentResult", con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
                reader.Close();

                foreach (string id in deletedStudentIdMark)
                {
                    DataRow[] rowsToDelete = dt.Select($"StudentId = '{id}'");
                    foreach (DataRow rowToDelete in rowsToDelete)
                    {
                        dt.Rows.Remove(rowToDelete);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Width = 250;
            }
        }

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("If not exists (select * from StudentResult where StudentId = @StudentId and AssessmentComponentId = @AssessmentComponentId ) " +
                    "begin " +
                    "insert into StudentResult(StudentId,AssessmentComponentId,RubricMeasurementId,EvaluationDate) values(@StudentId,@AssessmentComponentId,@RubricMeasurementId,@EvaluationDate) end", con);
                cmd.Parameters.AddWithValue("@StudentId", comboBox1.Text);
                cmd.Parameters.AddWithValue("@AssessmentComponentId", comboBox2.Text);
                cmd.Parameters.AddWithValue("@RubricMeasurementId", comboBox3.Text);
                cmd.Parameters.AddWithValue("@EvaluationDate", dtEvaluation.Value);
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
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("UPDATE StudentResult SET RubricMeasurementId = @RubricMeasurementId, EvaluationDate = @EvaluationDate WHERE StudentId = @StudentId AND AssessmentComponentId = @AssessmentComponentId", con);
                cmd.Parameters.AddWithValue("@StudentId", comboBox1.Text);
                cmd.Parameters.AddWithValue("@AssessmentComponentId", comboBox2.Text);
                cmd.Parameters.AddWithValue("@RubricMeasurementId", comboBox3.Text);
                cmd.Parameters.AddWithValue("@EvaluationDate", dtEvaluation.Value);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadBtn_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this?", "Delete", MessageBoxButtons.YesNo);
            try
            {
                if (dialogResult == DialogResult.Yes)
                {
                    if (dataGridView1.SelectedCells.Count > 0)
                    {
                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            string id = row.Cells["StudentId"].Value.ToString();
                            if (!deletedStudentIdMark.Contains(id))
                            {
                                 deletedStudentIdMark.Add(id);
                            }
                        }
                        SaveDeletedStudentIdMark();
                        MessageBox.Show("Data Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadBtn_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Please select a row to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void LoadDeletedStudentIdMark()
        {
            string filePath = "deletedStudentIdMark.txt";
            if (File.Exists(filePath))
            {
                deletedStudentIdMark = File.ReadAllLines(filePath).ToList();
            }
        }

        private void SaveDeletedStudentIdMark()
        {
            string filePath = "deletedStudentIdMark.txt";
            File.WriteAllLines(filePath, deletedStudentIdMark);
        }


        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
