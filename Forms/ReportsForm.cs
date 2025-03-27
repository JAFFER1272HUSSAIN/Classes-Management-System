using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using class_management_system;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace WindowsFormsApp1.Forms
{
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
            // Add items to the combo box drop-down menu
            comboBox2.Items.AddRange(new object[] {
                "CLO wise class result",
                "Assessment wise class result",
                "Attendance Report",
                "Top performing students",
                "Student Attendance Summary"

            });
            comboBox2.SelectedIndex = 0;
        }

        private void checkComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReportData();
        }

        private void LoadReportData()
        {
            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Please select a report type.");
                return;
            }

            string reportType = comboBox2.SelectedItem.ToString();

            switch (reportType)
            {
                case "CLO wise class result":
                    cloWiseResult();
                    break;
                case "Assessment wise class result":
                    assessmentWiseResult();
                    break;
                case "Attendance Report":
                    classAttendance();
                    break;
                case "Top performing students":
                    topPerformingStudents();
                    break;
                case "Student Attendance Summary":
                    studentAttendanceSummary();
                    break;
                default:
                    MessageBox.Show("Invalid report type selected.");
                    break;
            }
        }
    



        public void ExportToPdf(DataGridView dgv, string fileName, string heading)
        {
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("No data available to generate a report.");
                return;
            }

            Document document = new Document();

            try
            {
                PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));
                document.Open();

                Paragraph paragraph = new Paragraph(heading, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18));
                paragraph.SpacingAfter = 10f;
                document.Add(paragraph);

                PdfPTable table = new PdfPTable(dgv.Columns.Count);

                // Add headers from data grid
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    table.AddCell(new Phrase(column.HeaderText));
                }

                // Add data from data grid
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {   
                        table.AddCell(new Phrase(cell.Value.ToString()));
                    }
                }


                document.Add(table);

            }


            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while exporting to PDF: " + ex.Message);
            }
            finally
            {
                document.Close();
                MessageBox.Show("PDF exported successfully");
            }



        }

        private void genReportBtn_Click(object sender, EventArgs e)
        {
            ExportToPdf(dataGridView1, $"{comboBox2.Text}.pdf", comboBox2.Text);
        }

        public void cloWiseResult()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand(@"SELECT s.Id AS StudentId, s.FirstName, s.LastName, c.Name AS CLOName, a.Title AS AssessmentTitle, ac.Name AS ComponentName, ac.TotalMarks AS ComponentTotalMarks, 
                                                rl.MeasurementLevel AS ObtainedRubricLevel, rl.RubricId, r.Details AS RubricDetails, r.CloId, a.TotalWeightage,
                                                (rl.MeasurementLevel / MAX(rl.MeasurementLevel) OVER(PARTITION BY ac.Id)) * ac.TotalMarks AS ObtainedMarks
                                                FROM Student s
                                                INNER JOIN StudentResult sr ON s.Id = sr.StudentId
                                                INNER JOIN AssessmentComponent ac ON sr.AssessmentComponentId = ac.Id
                                                INNER JOIN RubricLevel rl ON sr.RubricMeasurementId = rl.Id
                                                INNER JOIN Rubric r ON rl.RubricId = r.Id
                                                INNER JOIN Clo c ON r.CloId = c.Id
                                                INNER JOIN Assessment a ON ac.AssessmentId = a.Id
                                                WHERE s.Status = 5
                                                ORDER BY s.Id, c.Id, a.Id, ac.Id, r.Id, rl.Id", con);

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Width = 100;
            }
        }

        public void assessmentWiseResult()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT S.FirstName + ' ' + S.LastName AS [Student Name], S.RegistrationNumber AS [Registration Number], Assessment.Title AS [Assessment Title], " +
                " SUM(AssessmentComponent.TotalMarks) AS [Total Marks]," +
                " SUM((CAST(RubricLevel.MeasurementLevel AS FLOAT) / [MaximumMeasurementLevel].maximum) * AssessmentComponent.TotalMarks) AS [Obtained Marks]," +
                " ((SUM((CAST(RubricLevel.MeasurementLevel AS FLOAT) / [MaximumMeasurementLevel].maximum) * AssessmentComponent.TotalMarks)) / SUM(AssessmentComponent.TotalMarks)) * 100 AS [Percentage] " +
                " FROM Student AS S " +
                " INNER JOIN StudentResult ON S.Id = StudentResult.StudentId " +
                " INNER JOIN RubricLevel ON StudentResult.RubricMeasurementId = RubricLevel.Id " +
                " INNER JOIN AssessmentComponent ON AssessmentComponent.Id = StudentResult.AssessmentComponentId " +
                " INNER JOIN Assessment ON Assessment.Id = AssessmentComponent.AssessmentId " +
                " INNER JOIN Rubric ON Rubric.Id = RubricLevel.RubricId " +
                " INNER JOIN (SELECT RubricId, MAX(MeasurementLevel) AS maximum FROM RubricLevel GROUP BY RubricId) AS [MaximumMeasurementLevel] " +
                " ON [MaximumMeasurementLevel].RubricId = Rubric.Id GROUP BY S.FirstName, S.LastName, S.RegistrationNumber, Assessment.Title", con);

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;

            // Set columns AutoSizeMode to allow them to resize based on content
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        public void classAttendance()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT Student.FirstName + ' ' + Student.LastName AS [Student Name], Student.RegistrationNumber AS [Registration Number], Lookup.Name AS [Attendance Status], ClassAttendance.AttendanceDate" +
                " FROM Student " +
                " INNER JOIN StudentAttendance ON Student.Id = StudentAttendance.StudentId " +
                " INNER JOIN ClassAttendance ON ClassAttendance.Id = StudentAttendance.AttendanceId " +
                " INNER JOIN Lookup ON Lookup.LookupId = StudentAttendance.AttendanceStatus " +
                " ORDER BY AttendanceDate", con);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            dataGridView1.DataSource = dt;

            // Set columns AutoSizeMode to allow them to resize based on content
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }


        // Top performing Students
        public void topPerformingStudents()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT TOP 3 Student.FirstName + ' ' + Student.LastName AS [Student Name], SUM(AssessmentComponent.TotalMarks) AS [Total Marks] " +
                "FROM Student " +
                "INNER JOIN StudentResult ON Student.Id = StudentResult.StudentId " +
                "INNER JOIN AssessmentComponent ON AssessmentComponent.Id = StudentResult.AssessmentComponentId " +
                "GROUP BY Student.Id, Student.FirstName, Student.LastName " +
                "ORDER BY [Total Marks] DESC", con);

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;

            // Set columns AutoSizeMode to allow them to resize based on content
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }


        // Student Attendance Summary
        public void studentAttendanceSummary()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT Student.FirstName + ' ' + Student.LastName AS [Student Name], " +
                "COUNT(CASE WHEN Lookup.Name = 'Present' THEN 1 END) AS [Total Classes Attended], " +
                "COUNT(ClassAttendance.Id) AS [Total Classes Held], " +
                "(CAST(COUNT(CASE WHEN Lookup.Name = 'Present' THEN 1 END) AS FLOAT) / NULLIF(COUNT(ClassAttendance.Id), 0)) * 100 AS [Attendance Percentage] " +
                "FROM Student " +
                "INNER JOIN StudentAttendance ON Student.Id = StudentAttendance.StudentId " +
                "INNER JOIN ClassAttendance ON StudentAttendance.AttendanceId = ClassAttendance.Id " +
                "INNER JOIN Lookup ON StudentAttendance.AttendanceStatus = Lookup.LookupId " +
                "GROUP BY Student.Id, Student.FirstName, Student.LastName", con);

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;

            // Set columns AutoSizeMode to allow them to resize based on content
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            LoadReportData();
        }
    }
}