namespace Students
{
    partial class StudentsApplication
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentsApplication));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelPhoneNumber = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxPhoneNumber = new System.Windows.Forms.TextBox();
            this.textLastName = new System.Windows.Forms.TextBox();
            this.buttonAddStudent = new System.Windows.Forms.Button();
            this.labelLastName = new System.Windows.Forms.Label();
            this.buttonDeleteStudent = new System.Windows.Forms.Button();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.buttonUpdateStudent = new System.Windows.Forms.Button();
            this.textFirstName = new System.Windows.Forms.TextBox();
            this.buttonClearFields = new System.Windows.Forms.Button();
            this.dataGridViewStudents = new System.Windows.Forms.DataGridView();
            this.appLayout = new System.Windows.Forms.TableLayoutPanel();
            this.inputLayout = new System.Windows.Forms.TableLayoutPanel();
            this.buttonsLayout2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonsLayout1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonImport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).BeginInit();
            this.appLayout.SuspendLayout();
            this.inputLayout.SuspendLayout();
            this.buttonsLayout2.SuspendLayout();
            this.buttonsLayout1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxEmail
            // 
            resources.ApplyResources(this.textBoxEmail, "textBoxEmail");
            this.textBoxEmail.Name = "textBoxEmail";
            // 
            // labelPhoneNumber
            // 
            resources.ApplyResources(this.labelPhoneNumber, "labelPhoneNumber");
            this.labelPhoneNumber.Name = "labelPhoneNumber";
            // 
            // labelEmail
            // 
            resources.ApplyResources(this.labelEmail, "labelEmail");
            this.labelEmail.Name = "labelEmail";
            // 
            // textBoxPhoneNumber
            // 
            resources.ApplyResources(this.textBoxPhoneNumber, "textBoxPhoneNumber");
            this.textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            // 
            // textLastName
            // 
            resources.ApplyResources(this.textLastName, "textLastName");
            this.textLastName.Name = "textLastName";
            // 
            // buttonAddStudent
            // 
            resources.ApplyResources(this.buttonAddStudent, "buttonAddStudent");
            this.buttonAddStudent.Name = "buttonAddStudent";
            this.buttonAddStudent.UseVisualStyleBackColor = true;
            this.buttonAddStudent.Click += new System.EventHandler(this.buttonAddStudent_Click);
            // 
            // labelLastName
            // 
            resources.ApplyResources(this.labelLastName, "labelLastName");
            this.labelLastName.Name = "labelLastName";
            // 
            // buttonDeleteStudent
            // 
            resources.ApplyResources(this.buttonDeleteStudent, "buttonDeleteStudent");
            this.buttonDeleteStudent.Name = "buttonDeleteStudent";
            this.buttonDeleteStudent.UseVisualStyleBackColor = true;
            this.buttonDeleteStudent.Click += new System.EventHandler(this.buttonDeleteStudent_Click);
            // 
            // labelFirstName
            // 
            resources.ApplyResources(this.labelFirstName, "labelFirstName");
            this.labelFirstName.Name = "labelFirstName";
            // 
            // buttonUpdateStudent
            // 
            resources.ApplyResources(this.buttonUpdateStudent, "buttonUpdateStudent");
            this.buttonUpdateStudent.Name = "buttonUpdateStudent";
            this.buttonUpdateStudent.UseVisualStyleBackColor = true;
            this.buttonUpdateStudent.Click += new System.EventHandler(this.buttonUpdateStudent_Click);
            // 
            // textFirstName
            // 
            resources.ApplyResources(this.textFirstName, "textFirstName");
            this.textFirstName.Name = "textFirstName";
            // 
            // buttonClearFields
            // 
            resources.ApplyResources(this.buttonClearFields, "buttonClearFields");
            this.buttonClearFields.Name = "buttonClearFields";
            this.buttonClearFields.UseVisualStyleBackColor = true;
            this.buttonClearFields.Click += new System.EventHandler(this.buttonClearFields_Click);
            // 
            // dataGridViewStudents
            // 
            this.dataGridViewStudents.AllowUserToAddRows = false;
            this.dataGridViewStudents.AllowUserToDeleteRows = false;
            this.dataGridViewStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewStudents.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridViewStudents.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dataGridViewStudents, "dataGridViewStudents");
            this.dataGridViewStudents.Name = "dataGridViewStudents";
            this.dataGridViewStudents.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewStudents.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStudents.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStudents_CellClick);
            this.dataGridViewStudents.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridViewStudents_KeyUp);
            // 
            // appLayout
            // 
            resources.ApplyResources(this.appLayout, "appLayout");
            this.appLayout.Controls.Add(this.dataGridViewStudents, 0, 0);
            this.appLayout.Controls.Add(this.inputLayout, 1, 0);
            this.appLayout.Name = "appLayout";
            // 
            // inputLayout
            // 
            resources.ApplyResources(this.inputLayout, "inputLayout");
            this.inputLayout.Controls.Add(this.textFirstName, 1, 0);
            this.inputLayout.Controls.Add(this.labelFirstName, 0, 0);
            this.inputLayout.Controls.Add(this.textBoxEmail, 1, 2);
            this.inputLayout.Controls.Add(this.labelLastName, 0, 1);
            this.inputLayout.Controls.Add(this.textLastName, 1, 1);
            this.inputLayout.Controls.Add(this.textBoxPhoneNumber, 1, 3);
            this.inputLayout.Controls.Add(this.labelEmail, 0, 2);
            this.inputLayout.Controls.Add(this.labelPhoneNumber, 0, 3);
            this.inputLayout.Controls.Add(this.buttonsLayout2, 1, 4);
            this.inputLayout.Controls.Add(this.buttonsLayout1, 0, 4);
            this.inputLayout.Name = "inputLayout";
            // 
            // buttonsLayout2
            // 
            resources.ApplyResources(this.buttonsLayout2, "buttonsLayout2");
            this.buttonsLayout2.Controls.Add(this.buttonAddStudent, 0, 0);
            this.buttonsLayout2.Controls.Add(this.buttonClearFields, 1, 1);
            this.buttonsLayout2.Controls.Add(this.buttonUpdateStudent, 1, 0);
            this.buttonsLayout2.Controls.Add(this.buttonDeleteStudent, 0, 1);
            this.buttonsLayout2.Name = "buttonsLayout2";
            // 
            // buttonsLayout1
            // 
            resources.ApplyResources(this.buttonsLayout1, "buttonsLayout1");
            this.buttonsLayout1.Controls.Add(this.buttonExport, 0, 1);
            this.buttonsLayout1.Controls.Add(this.buttonImport, 0, 0);
            this.buttonsLayout1.Name = "buttonsLayout1";
            // 
            // buttonExport
            // 
            resources.ApplyResources(this.buttonExport, "buttonExport");
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonImport
            // 
            resources.ApplyResources(this.buttonImport, "buttonImport");
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // StudentsApplication
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.appLayout);
            this.Name = "StudentsApplication";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StudentsApplication_FormClosed);
            this.Load += new System.EventHandler(this.StudentsApplication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).EndInit();
            this.appLayout.ResumeLayout(false);
            this.inputLayout.ResumeLayout(false);
            this.inputLayout.PerformLayout();
            this.buttonsLayout2.ResumeLayout(false);
            this.buttonsLayout1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelPhoneNumber;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxPhoneNumber;
        private System.Windows.Forms.TextBox textLastName;
        private System.Windows.Forms.Button buttonAddStudent;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.Button buttonDeleteStudent;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.Button buttonUpdateStudent;
        private System.Windows.Forms.TextBox textFirstName;
        private System.Windows.Forms.Button buttonClearFields;
        private System.Windows.Forms.DataGridView dataGridViewStudents;
        private System.Windows.Forms.TableLayoutPanel appLayout;
        private System.Windows.Forms.TableLayoutPanel inputLayout;
        private System.Windows.Forms.TableLayoutPanel buttonsLayout2;
        private System.Windows.Forms.TableLayoutPanel buttonsLayout1;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonImport;
    }
}

