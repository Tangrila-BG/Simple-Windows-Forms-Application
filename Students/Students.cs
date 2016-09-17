using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;

namespace Students
{
    public partial class StudentsApplication: Form
    {
        public StudentsApplication()
        {
            InitializeComponent();
        }

        public static DataTable Table = new DataTable();
        private int _indexRow;
        // keeps data of every enrolled student ever
        protected static List<Student> StudentRecord = new List<Student>();
        
        //
        // SAMPLE DATA
        //
        protected virtual void AddDummies()
        {
            Table.Rows.Add(
                Table.NewRow().ItemArray = new object[]
                {
                    -4, "John", "Doe", "john@doe.com", "12345"
                });
            Table.Rows.Add(
                Table.NewRow().ItemArray = new object[]
                {
                    -3, "Adam", "Doe", "adam@doe.com", "12345"
                });
            Table.Rows.Add(
                Table.NewRow().ItemArray = new object[]
                {
                    -2, "Doe", "John", "does@john.com", "12345"
                });
            Table.Rows.Add(
                Table.NewRow().ItemArray = new object[]
                {
                    -1, "Eve", "Doe", "Eve@doe.com", "12345"
                });
            Table.Rows.Add(
                Table.NewRow().ItemArray = new object[]
                {
                    0, "Doe", "Eve", "doe@eve.com", "12345"
                });
        }

        private void StudentsApplication_Load(object sender, EventArgs e)
        {
            Table.TableName = "Enrolled Students";
            Table.Columns.Add("ID", typeof(int));
            Table.Columns.Add("First name", typeof(string));
            Table.Columns.Add("Last name", typeof(string));
            Table.Columns.Add("Email", typeof(string));
            Table.Columns.Add("Phone number", typeof(string));
            Table.PrimaryKey = new[] { Table.Columns["ID"] };

            // adds sample entries to the table
            AddDummies();

            dataGridViewStudents.DataSource = Table;
            dataGridViewStudents.AllowUserToAddRows = false;
            dataGridViewStudents.AllowUserToDeleteRows = false;
        }
        
        //
        // CREATE
        //
        private void buttonAddStudent_Click(object sender, EventArgs e)
        {
            if (!ValidateStudentInformation(textFirstName.Text, textLastName.Text, textBoxEmail.Text, textBoxPhoneNumber.Text))
                return;

            var student = new Student
            {
                FirstName = textFirstName.Text,
                LastName = textLastName.Text,
                FullName = textFirstName.Text + " " + textLastName.Text,
                Email = textBoxEmail.Text,
                PhoneNumber = textBoxPhoneNumber.Text == @" "
                    ? "-"
                    : textBoxPhoneNumber.Text
            };

            // keeps a copy of the student in case of data loss
            StudentRecord.Add(student);
            // adds the student to the table
            AddStudentToTable(student);
        }
        public void AddStudentToTable(Student student)
        {
            var row = Table.NewRow();
            row.ItemArray = new object[]
            {
                student.Id,
                student.FirstName,
                student.LastName,
                student.Email,
                student.PhoneNumber
            };
            
            Table.Rows.Add(row);

        }
        
        //
        // UPDATE
        //
        private void dataGridViewStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _indexRow = e.RowIndex;
            if (e.RowIndex == -1) return;
            DataGridViewRow row = dataGridViewStudents.Rows[_indexRow];

            textFirstName.Text = row.Cells["First name"].Value.ToString();
            textLastName.Text = row.Cells["Last name"].Value.ToString();
            textBoxEmail.Text = row.Cells["Email"].Value.ToString();
            textBoxPhoneNumber.Text = row.Cells["Phone number"].Value.ToString();
        }

        private void buttonUpdateStudent_Click(object sender, EventArgs e)
        {

            if (!ValidateStudentInformation(textFirstName.Text, textLastName.Text, textBoxEmail.Text, textBoxPhoneNumber.Text))
                return;

            DataGridViewRow newDataRow = dataGridViewStudents.Rows[_indexRow];
            newDataRow.Cells["First name"].Value = textFirstName.Text;
            newDataRow.Cells["Last name"].Value = textLastName.Text;
            newDataRow.Cells["Email"].Value = textBoxEmail.Text;
            newDataRow.Cells["Phone number"].Value = textBoxPhoneNumber.Text;

            var i = StudentRecord.FindIndex(x => x.Id == int.Parse(newDataRow.Cells["ID"].Value.ToString()));
            
            StudentRecord[i].FirstName = newDataRow.Cells["First name"].Value.ToString();
            StudentRecord[i].LastName = newDataRow.Cells["Last name"].Value.ToString();
            StudentRecord[i].Email = newDataRow.Cells["Email"].Value.ToString();
            StudentRecord[i].PhoneNumber = newDataRow.Cells["Phone number"].Value.ToString();
        }
        
        //
        // DELETE
        //
        private void buttonDeleteStudent_Click(object sender, EventArgs e)
        {
            DeleteStudent();
        }
        private void dataGridViewStudents_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode & Keys.Delete) != Keys.Delete)
                return;
            DeleteStudent();
        }
        private void DeleteStudent()
        {
            var validate =
                MessageBox.Show(@"Are you sure you want to delete the selected student(s) ?", @"Confirm deletion",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (validate == DialogResult.No)
                return;
            var selected = dataGridViewStudents.SelectedRows;
            if (selected.Count == 0) return;
            int i = 0;
            for (; i < selected.Count; i++)
            {
                DataGridViewRow row = selected[i];
                dataGridViewStudents.Rows.Remove(row);
            }
            
            MessageBox.Show($@"Deleted {i} student(s)", @"Deletion completed",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void buttonClearFields_Click(object sender, EventArgs e)
        {
            textFirstName.Text = "";
            textLastName.Text = "";
            textBoxEmail.Text = "";
            textBoxPhoneNumber.Text = "";
        }
        
        //
        // VALIDATE INPUT
        //
        private bool ValidateStudentInformation(string firstName, string lastName, string email, string phoneNumber)
        {
            // Empty entry
            
            if (firstName == "" &&
                lastName == "" &&
                email == "")
            {
                MessageBox.Show(@"The student must have First name, Last name and Email !", @"Insufficient student data",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (firstName == "")
            {
                MessageBox.Show(@"First name field cannot be empty !", @"Empty first name field",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (lastName == "")
            {
                MessageBox.Show(@"Last name field cannot be empty !", @"Empty last name field",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (email == "")
            {
                MessageBox.Show(@"Email field cannot be empty !", @"Empty email field",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // invalid email format
            try
            {
                new MailAddress(email);

            }
            catch (Exception)
            {
                
                MessageBox.Show(@"Entered email is in invalid format !", @"Invalid email format",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            // invalid phone number
            if (phoneNumber.Length != phoneNumber.Count(char.IsDigit) || phoneNumber.Length > 13)
            {
                MessageBox.Show(@"Entered phone number is in invalid format !", @"Invalid phone number",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // duplicate entry
            
            var rows = dataGridViewStudents.Rows;

            for (int i = 0; i < rows.Count; i++)
            {
                if (rows[i].Cells["Email"].Value.ToString() != email ||
                    (rows[i].State & DataGridViewElementStates.Selected) != 0) continue;

                MessageBox.Show(@"Student with such email already exists !", @"Student already exists",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }   
            

            return true;
        }
        
        //
        // EXPORT
        //
        private void buttonExport_Click(object sender, EventArgs e)
        {
            ImportExport.ExportMain();
        }

        //
        // IMPORT
        //
        private void buttonImport_Click(object sender, EventArgs e)
        {
            if (!ImportExport.ImportMain())
                return;
            dataGridViewStudents.Columns.Clear();
            dataGridViewStudents.DataSource = Table;
        }

        private void StudentsApplication_FormClosed(object sender, FormClosedEventArgs e)
        {
            Table.Dispose();
            dataGridViewStudents.Dispose();
        }

    }
}
