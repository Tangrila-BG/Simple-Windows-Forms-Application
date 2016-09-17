using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;

namespace Students
{
    class ImportExport : StudentsApplication
    {
        public static void ExportMain()
        {
            if (Table.Rows.Count == 0)
            {
                MessageBox.Show(@"Nothing to export", @"Export failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = @"Text files (*.txt)|*.txt|Excel files (*.xlsx)|*.xlsx",
                FilterIndex = 2,
                RestoreDirectory = true,
                AddExtension = true,
                AutoUpgradeEnabled = true,
                CheckPathExists = true,
                OverwritePrompt = true,
            };


            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            FileStream stream = (FileStream) saveFileDialog.OpenFile();
            var extension = Path.GetExtension(stream.Name);
            
            //
            // Export to Excel
            //
            if (extension != ".xlsx" && extension != ".txt")
            {
                MessageBox.Show(@"Incorrect file format. Please use .xlsx or .txt format.", @"Incorrect file format",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                stream.Close();
                return;
            }

            if (extension.Equals(".xlsx"))
            {
                ExcelPackage pck = new ExcelPackage(stream);
                var ws = pck.Workbook.Worksheets;
                
                //
                // Enrolled students sheet
                //
                var enrolledStudentSheet = ws.Add("Enrolled Students");

                // Style the cells
                enrolledStudentSheet.Cells["A1:E1"].Style.Font.Bold = true;

                // Load data onto excel table from DataTable
                enrolledStudentSheet.Cells["A1"].LoadFromDataTable(Table, true);

                // Create a table out of the inserted data
                var enrolledStudentRange = enrolledStudentSheet.Cells[1, 1, Table.Rows.Count + 1, Table.Columns.Count];
                var enrolledStudentExcelTable = enrolledStudentSheet.Tables.Add(enrolledStudentRange, "EnrolledStudents");
                
                // Style the table
                enrolledStudentExcelTable.TableStyle = TableStyles.Light2;
                enrolledStudentExcelTable.ShowHeader = true;
               
                // Align text to center of the cell
                enrolledStudentSheet.Cells
                    [1, 1, Table.Rows.Count + 1, Table.Columns.Count]
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;

                enrolledStudentSheet.DefaultColWidth = 20;
                enrolledStudentSheet.Cells.AutoFitColumns();
                
                //
                // Student record sheet
                //

                // Sheet that holds all the student that have ever enrolled
                var studentRecordSheet = ws.Add("Student Record");
                // Style the sheet
                studentRecordSheet.Cells["A1:F1"].Style.Font.Bold = true;
                // Load data onto excel table from DataTable
                var studentRecordTable = CollectionToDataTable(StudentRecord);
                studentRecordSheet.Cells["A1"].LoadFromDataTable(studentRecordTable, true);
                
                // Create table out of the inserted data
                var studenRecordSheetRange = studentRecordSheet.Cells[1, 1, studentRecordTable.Rows.Count + 1, studentRecordTable.Columns.Count];
                var studentRecordExcelTable = studentRecordSheet.Tables.Add(studenRecordSheetRange, "StudentRecord");
                
                // Style the table
                studentRecordExcelTable.TableStyle = TableStyles.Light2;
                
                
                // Align text to center of the cell
                studentRecordSheet.Cells
                    [1, 1, studentRecordTable.Rows.Count + 1, studentRecordTable.Columns.Count]
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;

                studentRecordSheet.DefaultColWidth = 20;
                studentRecordSheet.Cells.AutoFitColumns();

                // Save & dispose
                pck.Save();
                pck.Dispose();
                enrolledStudentSheet.Dispose();
                studentRecordTable.Dispose();
            }

            //
            // Export to text file
            //
            else if (extension.Equals(".txt"))
            {

                var enrolledStudentsTable = Table;

                StreamWriter writer = new StreamWriter(stream);
                writer.Write(Environment.NewLine);

                //
                // Write enrolled students table
                //

                // Table name
                writer.WriteLine(enrolledStudentsTable.TableName);
                writer.WriteLine();

                // Initialize the columns
                foreach (DataColumn col in enrolledStudentsTable.Columns)
                {
                    writer.Write($@"    {col.ColumnName}    |");
                }
                writer.WriteLine();

                // Start writing the rows
                foreach (DataRow row in enrolledStudentsTable.Rows)
                {
                    object[] rowData = row.ItemArray;
                    int i;
                    for (i = 0; i < rowData.Length - 1; i++)
                    {
                        writer.Write($"    {rowData[i]}    | ");
                    }
                    writer.WriteLine(rowData[i].ToString());
                }
                writer.Write($"********** END OF {enrolledStudentsTable.TableName} DATA **********");
                writer.WriteLine();

                //
                //  Write student record table
                //

                writer.WriteLine();
                var studentRecordTable = CollectionToDataTable(StudentRecord);

                // Table name
                writer.WriteLine(studentRecordTable.TableName);
                writer.WriteLine();

                // Initialize the columns
                foreach (DataColumn col in studentRecordTable.Columns)
                {
                    writer.Write($@"    {col.ColumnName}    |");
                }
                writer.WriteLine();

                // Start writing the rows

                foreach (DataRow row in studentRecordTable.Rows)
                {
                    object[] rowData = row.ItemArray;
                    int i;
                    for (i = 0; i < rowData.Length - 1; i++)
                    {
                        writer.Write($"    {rowData[i]}    |");
                    }
                    writer.WriteLine($@"    {rowData[i]}    ");
                }
                writer.Write($"********** END OF {studentRecordTable.TableName} DATA **********");

                // Dispose
                writer.Dispose();
            }

            // Dispose
            saveFileDialog.Dispose();
        }

        public static bool ImportMain()
        {
            var check = MessageBox.Show(@"Are you sure you want to load this file ?" + "\n" +
                @"This will remove your currently loaded table", @"Confirm import",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.No) return false;

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = @"Text files (*.txt)|*.txt|Excel files (*.xlsx)|*.xlsx",
                FilterIndex = 2,
                RestoreDirectory = true,
                AddExtension = true,
                AutoUpgradeEnabled = true,
                CheckPathExists = true,
                CheckFileExists = true,
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK) return false;
            var stream = File.OpenRead(openFileDialog.FileName);

            //
            // IMPORT from Excel
            //
            var extension = stream.Name.Substring(stream.Name.LastIndexOf("."));
            
            // Simple file format validation
            if (extension != ".xlsx" && extension != ".txt")
            {
                MessageBox.Show(@"Incorrect file format. Please use .xlsx or .txt format.", @"Incorrect file format",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                stream.Close();
                return false;
            }

            if (extension == ".xlsx")
            {
                
                var pck = new ExcelPackage(stream);

                var ws = pck.Workbook.Worksheets.First();

                DataTable table = new DataTable {TableName = ws.Name};

                foreach (var firstRow in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                {
                    table.Columns.Add(firstRow.Text);
                }

                for (int i = 1; i < ws.Dimension.End.Row; i++)
                {
                    var wsRow = ws.Cells[i + 1, 1, i, ws.Dimension.End.Column];
                    // Doesn't add rows that have empty first name, last name or email
                    if (ws.Cells[i+1, 1, i, ws.Dimension.End.Column-1].Any(x => x.Text == "")) continue;

                    DataRow row = table.Rows.Add();
                    foreach (var cell in wsRow)
                    {
                        row[cell.Start.Column - 1] = cell.Text;
                    }
                }
                
                Table = table;
                return true;
            }
            else
            {
                StreamReader reader = new StreamReader(stream);
                DataTable table = new DataTable();
                while (true)
                {
                    var line = reader.ReadLine();
                    if (line == "") continue;
                    if (line == $"********** END OF {table.TableName} DATA **********") break;

                    if (char.IsLetter(line[0]))
                    {
                        // Assumes that the line holds the table name,
                        // because of the way the data has been previously exported.
                        table.TableName = line.Trim();
                        continue;
                    }
                    var splited = line.Split(new char[] {'|'}, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Trim()).ToArray();

                    if (splited[0].ToUpper().Equals("ID"))
                    {
                        foreach (string colName in splited)
                        {
                            table.Columns.Add(colName);
                        }
                        continue;
                    }
                    table.Rows.Add(splited);
                    
                }
                Table = table;
                stream.Dispose();
                return true;
            }
        }

        private static DataTable CollectionToDataTable(List<Student> collection)
        {
            var table = new DataTable {TableName = "Student Record"};

            var props = typeof(Student).GetProperties().TakeWhile(x => x.Name != "AcceptButton");

            foreach (var prop in props)
            {
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            
            foreach (var student in collection)
            {
                var row = new object[]
                {
                    student.Id,
                    student.FirstName,
                    student.LastName,
                    student.FullName,
                    student.Email,
                    student.PhoneNumber
                };
                
                table.Rows.Add(row);
            }
            return table;
        }
    }
}
