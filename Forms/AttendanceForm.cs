using class_management_system;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1.Forms
{
    public partial class AttendanceForm : Form
    {
        private readonly SqlConnection connection;

        public AttendanceForm()
        {
            InitializeComponent();
            InitializeDataGridView();

            // Initialize database connection using Configuration class
            connection = Configuration.getInstance().getConnection();
        }

        private void viewBtn_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            DateTime selectTime = dateTimePicker1.Value;

            try
            {
                SqlCommand cmd = new SqlCommand("SELECT S.RegistrationNumber AS RegNo, CONCAT(S.FirstName, ' ', S.LastName) AS Name, Lookup.Name AS status FROM " +
                            "Lookup INNER JOIN StudentAttendance AS SA ON SA.AttendanceStatus = Lookup.LookupId " +
                            "INNER JOIN ClassAttendance AS CA ON CA.Id = SA.AttendanceId " +
                            "INNER JOIN Student AS S ON S.Id = SA.StudentId " +
                          "WHERE CONVERT(date, CA.AttendanceDate) = @selectedDate", connection);

                cmd.Parameters.AddWithValue("@selectedDate", selectTime.Date);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dataGridView1.Rows.Clear();

                    while (reader.Read())
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(dataGridView1);
                        row.Cells[0].Value = reader["RegNo"].ToString();
                        row.Cells[1].Value = reader["Name"].ToString();
                        row.Cells[2].Value = reader["status"].ToString();
                        dataGridView1.Rows.Add(row);
                    }
                }

                dataGridView1.Columns[1].ReadOnly = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void InitializeDataGridView()
        {
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("RegNo", "Registration Number");
            dataGridView1.Columns.Add("Name", "Name");

            // Add dropdown column for status
            DataGridViewComboBoxColumn statusColumn = new DataGridViewComboBoxColumn();
            statusColumn.Name = "Status";
            statusColumn.HeaderText = "Status";
            statusColumn.Items.AddRange("Present", "Absent", "Leave", "Late"); 
            dataGridView1.Columns.Add(statusColumn);

            // Increase column widths
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Width = 200;
            }
        }


        private void SaveBtn_Click(object sender, EventArgs e)
        {
            bool missingStatus = false; 

            try
            {
                SqlCommand cmdInsertClassStudent = new SqlCommand("INSERT INTO Classattendance (AttendanceDate) VALUES (@attendanceDate); SELECT SCOPE_IDENTITY();", connection);
                cmdInsertClassStudent.Parameters.AddWithValue("@attendanceDate", dateTimePicker1.Value.Date);
                int classStudentId = Convert.ToInt32(cmdInsertClassStudent.ExecuteScalar());

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    string registrationNumber = row.Cells[0].Value?.ToString();

                    if (string.IsNullOrEmpty(registrationNumber))
                    {
                        MessageBox.Show("Registration number is empty.");
                        continue;
                    }

                    DataGridViewComboBoxCell comboBoxCell = row.Cells["Status"] as DataGridViewComboBoxCell;

                    if (comboBoxCell == null)
                    {
                        MessageBox.Show($"No status selected for registration number {registrationNumber}");
                        missingStatus = true;
                        break;
                    }

                    string statusString = comboBoxCell.Value?.ToString();

                    if (string.IsNullOrEmpty(statusString))
                    {
                        MessageBox.Show($"No status selected for registration number {registrationNumber}");
                        missingStatus = true; 
                        break; 
                    }

                    int status = 0;

                    switch (statusString.ToLower())
                    {
                        case "present":
                            status = 1;
                            break;
                        case "absent":
                            status = 2;
                            break;
                        case "leave":
                            status = 3;
                            break;
                        case "late":
                            status = 4;
                            break;
                        default:
                            MessageBox.Show($"Invalid status '{statusString}' for registration number {registrationNumber}");
                            continue;
                    }

                    SqlCommand cmdInsertStudentAttendance = new SqlCommand("INSERT INTO StudentAttendance (AttendanceId, StudentId, AttendanceStatus) " +
                                                                           "SELECT @classStudentId, Id, @status FROM Student WHERE RegistrationNumber = @registrationNumber", connection);
                    cmdInsertStudentAttendance.Parameters.AddWithValue("@classStudentId", classStudentId);
                    cmdInsertStudentAttendance.Parameters.AddWithValue("@status", status);
                    cmdInsertStudentAttendance.Parameters.AddWithValue("@registrationNumber", registrationNumber);

                    cmdInsertStudentAttendance.ExecuteNonQuery();
                }

                if (!missingStatus) 
                    MessageBox.Show("Attendance saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void loadBtn_Click_1(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT RegistrationNumber AS RegNo, CONCAT(FirstName, ' ', LastName) AS Name FROM Student", connection);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dataGridView1.Rows.Clear();
                    dataGridView1.AllowUserToAddRows = false;

                    while (reader.Read())
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(dataGridView1);
                        row.Cells[0].Value = reader["RegNo"].ToString();
                        row.Cells[1].Value = reader["Name"].ToString();

                        if (dataGridView1.Columns[2] is DataGridViewComboBoxColumn comboBoxColumn)
                        {
                            if (!comboBoxColumn.Items.Contains("Present"))
                            {
                                comboBoxColumn.Items.Add("Present");
                            }
                        }
                        dataGridView1.Rows.Add(row);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
