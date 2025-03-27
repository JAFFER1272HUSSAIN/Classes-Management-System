using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Data;
using class_management_system;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace WindowsFormsApp1.Forms
{
    public partial class StudentManagementForm : Form
    {
        //Flags
        private bool isCreateButtonClicked = false;
        private bool isUpdatedButtonClicked = false;
        private bool isDeleteButtonClicked = false;
        private bool isReadButtonClicked = false;
        //Fields
        private string fname = "";
        private string lname = "";
        private string contact = "";
        private string email = "";
        private string registrationNumber = "";
        private string status = "";

        // List to store deleted registration numbers
        private List<string> deletedRegistrationNumbers = new List<string>();

        //Constructor
        public StudentManagementForm()
        {
            InitializeComponent();
            LoadDeletedRegistrationNumbers();
            LoadGrid();
            colorChange();
        }

        private void CreateBtn_Click_1(object sender, EventArgs e)
        {
            InputBox1_Click(sender, e);
            InputBox2_Click(sender, e);
            InputBox3_Click(sender, e);
            InputBox4_Click(sender, e);
            InputBox5_Click(sender, e);
            InputBox6_Click(sender, e);
            CreateBtn_Click(sender, e);
        }
        // Validations on InputBoxes
        private void CreateBtn_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            isCreateButtonClicked = true;
            colorChange();
            if (string.IsNullOrEmpty(fname) || string.IsNullOrEmpty(lname) || string.IsNullOrEmpty(contact) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(registrationNumber) || string.IsNullOrEmpty(status))
            {
                MessageBox.Show("Please fill all the fields");
                return;
            }
            else
            {
                MessageBox.Show("Click on 'Save In DB' button to save into the DataBase");

            }
        }
        

        // InputBox1 Creation
        private void InputBox1_Click(object sender, EventArgs e)
        {
            fname = Interaction.InputBox("Enter the First name of the student", "InputBox1");
            // Validations on InputBox1
            if (string.IsNullOrEmpty(fname))
            {
                MessageBox.Show("Please fill the First name");
                InputBox1_Click(sender, e);
            }
        }

        // InputBox2 Creation
        private void InputBox2_Click(object sender, EventArgs e)
        {
            lname = Interaction.InputBox("Enter the Last name of the student", "InputBox2");
            // Validations on InputBox2
            if (string.IsNullOrEmpty(lname))
            {
                MessageBox.Show("Please fill the Last name");
                InputBox2_Click(sender, e);
            }
        }
        // InputBox3 Creation
        private void InputBox3_Click(object sender, EventArgs e)
        {
            contact = Interaction.InputBox("Enter the Contact of the student", "InputBox3");
            // Validations on InputBox3
            if (string.IsNullOrEmpty(contact))
            {
                MessageBox.Show("Please fill the Contact");
                InputBox3_Click(sender, e);
            }
            else if (contact.Length != 11 && contact[0] != 0 && contact[1] != 3)
            {
                MessageBox.Show("Please enter a valid contact number");
                InputBox3_Click(sender, e);
            }
        }
        // InputBox4 Creation
        private void InputBox4_Click(object sender, EventArgs e)
        {
            email = Interaction.InputBox("Enter the Email of the student", "InputBox4");
            // Validations on InputBox4
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please fill the Email");
                InputBox4_Click(sender, e);
            }
            else if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Please enter a valid email");
                InputBox4_Click(sender, e);
            }
            
        }
        // InputBox5 Creation
        private void InputBox5_Click(object sender, EventArgs e)
        {
            registrationNumber = Interaction.InputBox("Enter the Registration Number of the student", "InputBox5");
            // Validations on InputBox5
            if (string.IsNullOrEmpty(registrationNumber))
            {
                MessageBox.Show("Please fill the Registration Number");
                InputBox5_Click(sender, e);
            }
            else if (!registrationNumber.Contains("-"))
            {
                MessageBox.Show("Please enter a valid registration number");
                InputBox5_Click(sender, e);
            }
        }
        // InputBox6 Creation
        private void InputBox6_Click(object sender, EventArgs e)
        {
            status = Interaction.InputBox("Enter the Status of the student (Active or Inactive)", "InputBox6");
            // Validations on InputBox6
            if (string.IsNullOrEmpty(status))
            {
                MessageBox.Show("Please fill the Status");
                InputBox6_Click(sender, e);
            }
            else if (status != "Active" && status != "Inactive")
            {
                MessageBox.Show("Please enter a valid status");
                InputBox6_Click(sender, e);
            }
        }



        // Update Button

        private void UpdateBtn_Click_1(object sender, EventArgs e)
        {
            ResetButtonColors();
            isUpdatedButtonClicked = true;
            colorChange();
            registrationNumber = Interaction.InputBox("Enter the Registration Number of the student you want to update", "UpdateBtn");
            if (string.IsNullOrEmpty(registrationNumber))
            {
                MessageBox.Show("Please fill the Registration Number");
                UpdateBtn_Click_1(sender, e);
            }
            else if (!registrationNumber.Contains("-"))
            {
                MessageBox.Show("Please enter a valid registration number");
                UpdateBtn_Click_1(sender, e);
            }
            else
            {
                InputBox1_Click(sender, e);
                InputBox2_Click(sender, e);
                InputBox3_Click(sender, e);
                InputBox4_Click(sender, e);
                InputBox5_Click(sender, e);
                InputBox6_Click(sender, e);
                MessageBox.Show("Press 'Update In DB' button to update into the DataBase");
            }
        }

        // SAVE STUDENT BUTTON
        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            // Validation and adding to grid
            if (string.IsNullOrEmpty(fname) || string.IsNullOrEmpty(lname) || string.IsNullOrEmpty(contact) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(registrationNumber) || string.IsNullOrEmpty(status))
            {
                MessageBox.Show("Please fill all the fields");
                return;
            }

            int sta = (status == "Active") ? 5 : 6;


            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into Student values (@FirstName, @LastName,@Contact,@Email,@RegisterationNumber,@Status)", con);
            cmd.Parameters.AddWithValue("@FirstName", fname);
            cmd.Parameters.AddWithValue("@LastName", lname);
            cmd.Parameters.AddWithValue("@Contact", contact);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@RegisterationNumber", registrationNumber);
            cmd.Parameters.AddWithValue("@Status", sta); 
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved...");
            emptyTextBoxes();
            LoadGrid();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        // empty the textboxes
        private void emptyTextBoxes()
        {
            fname = "";
            lname = "";
            contact = "";
            email = "";
            registrationNumber = "";
            status = "";
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            isDeleteButtonClicked = true;
            colorChange();

            // validation
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete");
                return;
            }

            // Mark the selected rows as deleted
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                string registrationNumber = row.Cells["RegistrationNumber"].Value.ToString();
                if (!deletedRegistrationNumbers.Contains(registrationNumber))
                {
                    deletedRegistrationNumbers.Add(registrationNumber);
                }
            }

            SaveDeletedRegistrationNumbers(); 
            LoadGrid(); 
        }

        private void LoadGrid()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Student", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            // Remove rows with deleted registration numbers from DataTable
            foreach (string registrationNumber in deletedRegistrationNumbers)
            {
                DataRow[] rowsToDelete = dt.Select($"RegistrationNumber = '{registrationNumber}'");
                foreach (DataRow rowToDelete in rowsToDelete)
                {
                    dt.Rows.Remove(rowToDelete);
                }
            }

            dataGridView1.DataSource = dt;

            // Adjust column widths
            dataGridView1.Columns["FirstName"].Width = 150;
            dataGridView1.Columns["LastName"].Width = 150;
            dataGridView1.Columns["Contact"].Width = 150;
            dataGridView1.Columns["Email"].Width = 200;
            dataGridView1.Columns["RegistrationNumber"].Width = 200;
            dataGridView1.Columns["Status"].Width = 100;
        }

        private void LoadDeletedRegistrationNumbers()
        {
            // Load deleted registration numbers from a file
            string filePath = "deletedRegistrationNumbers.txt";
            if (File.Exists(filePath))
            {
                deletedRegistrationNumbers = File.ReadAllLines(filePath).ToList();
            }
        }

        private void SaveDeletedRegistrationNumbers()
        {
            // Save deleted registration numbers to a file
            string filePath = "deletedRegistrationNumbers.txt";
            File.WriteAllLines(filePath, deletedRegistrationNumbers);
        }

        private void ReadBtn_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            isReadButtonClicked = true;
            colorChange();
            LoadGrid();
        }
        // Buttons colors set on the bases of the flag is true of that button or not
        private void colorChange()
        {
            if (isCreateButtonClicked)
            {
                CreateBtn.BackColor = Color.FromArgb(37, 36, 81);
                CreateBtn.ForeColor = Color.FromArgb(0, 126, 249);
            }
            else if (isDeleteButtonClicked)
            {
                deleteBtn.BackColor = Color.FromArgb(37, 36, 81);
                deleteBtn.ForeColor = Color.FromArgb(0, 126, 249);
            }
            else if (isUpdatedButtonClicked)
            {
                UpdateBtn.BackColor = Color.FromArgb(37, 36, 81);
                UpdateBtn.ForeColor = Color.FromArgb(0, 126, 249);
            }
            else if (isReadButtonClicked)
            {
                ReadBtn.BackColor = Color.FromArgb(37, 36, 81);
                ReadBtn.ForeColor = Color.FromArgb(0, 126, 249);
            }
        }

        private void ResetButtonColors()
        {
            isCreateButtonClicked = false;
            isUpdatedButtonClicked = false;
            isDeleteButtonClicked = false;
            isReadButtonClicked = false;

            CreateBtn.BackColor = Color.FromArgb(0, 126, 249);
            UpdateBtn.BackColor = Color.FromArgb(0, 126, 249);
            deleteBtn.BackColor = Color.FromArgb(0, 126, 249);
            ReadBtn.BackColor = Color.FromArgb(0, 126, 249);

            CreateBtn.ForeColor = Color.Black;
            UpdateBtn.ForeColor = Color.Black;
            deleteBtn.ForeColor = Color.Black;
            ReadBtn.ForeColor = Color.Black;
        }
        private void iconButton2_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrEmpty(fname) || string.IsNullOrEmpty(lname) || string.IsNullOrEmpty(contact) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(registrationNumber) || string.IsNullOrEmpty(status))
            {
                MessageBox.Show("Please fill all the fields");
                return;
            }

            int sta = (status == "Active") ? 5 : 6;


            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE Student SET FirstName=@FirstName, LastName=@LastName,Contact=@Contact,Email=@Email,Status=@Status WHERE RegistrationNumber=@RegistrationNumber", con);
            con.Close();
            con.Open();
            cmd.Parameters.AddWithValue("@FirstName", fname);
            cmd.Parameters.AddWithValue("@LastName", lname);
            cmd.Parameters.AddWithValue("@Contact", contact);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@RegistrationNumber", registrationNumber);
            cmd.Parameters.AddWithValue("@Status", sta);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Updated...");
            emptyTextBoxes();
            LoadGrid();
        }
    }
}
