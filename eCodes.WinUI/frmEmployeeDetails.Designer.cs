namespace eCodes.WinUI
{
    partial class frmEmployeeDetails
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
            this.components = new System.ComponentModel.Container();
            this.txtGender = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtJMBG = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCityName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConfirmPass = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEmployeeNumber = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.dateTimeofBirth = new System.Windows.Forms.DateTimePicker();
            this.errorProviderEmployees = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // txtGender
            // 
            this.txtGender.Location = new System.Drawing.Point(12, 153);
            this.txtGender.Name = "txtGender";
            this.txtGender.Size = new System.Drawing.Size(201, 27);
            this.txtGender.TabIndex = 32;
            this.txtGender.Validating += new System.ComponentModel.CancelEventHandler(this.txtGender_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 20);
            this.label5.TabIndex = 31;
            this.label5.Text = "Gender:";
            // 
            // txtJMBG
            // 
            this.txtJMBG.Location = new System.Drawing.Point(275, 153);
            this.txtJMBG.Name = "txtJMBG";
            this.txtJMBG.ReadOnly = true;
            this.txtJMBG.Size = new System.Drawing.Size(201, 27);
            this.txtJMBG.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(275, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 29;
            this.label4.Text = "JMBG:";
            // 
            // txtCityName
            // 
            this.txtCityName.Location = new System.Drawing.Point(275, 95);
            this.txtCityName.Name = "txtCityName";
            this.txtCityName.ReadOnly = true;
            this.txtCityName.Size = new System.Drawing.Size(201, 27);
            this.txtCityName.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(275, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 27;
            this.label3.Text = "City name:";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(12, 95);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(201, 27);
            this.txtLastName.TabIndex = 26;
            this.txtLastName.Validating += new System.ComponentModel.CancelEventHandler(this.txtLastName_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "Lastname:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(12, 37);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(201, 27);
            this.txtFirstName.TabIndex = 24;
            this.txtFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.txtFirstName_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Firstname:";
            // 
            // txtConfirmPass
            // 
            this.txtConfirmPass.Location = new System.Drawing.Point(12, 264);
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.PasswordChar = '*';
            this.txtConfirmPass.Size = new System.Drawing.Size(201, 27);
            this.txtConfirmPass.TabIndex = 42;
            this.txtConfirmPass.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfirmPass_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 241);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(132, 20);
            this.label9.TabIndex = 41;
            this.label9.Text = "Confirm password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(12, 206);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(201, 27);
            this.txtPassword.TabIndex = 40;
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassword_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 183);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 20);
            this.label8.TabIndex = 39;
            this.label8.Text = "Password:";
            // 
            // txtEmployeeNumber
            // 
            this.txtEmployeeNumber.Location = new System.Drawing.Point(275, 37);
            this.txtEmployeeNumber.Name = "txtEmployeeNumber";
            this.txtEmployeeNumber.ReadOnly = true;
            this.txtEmployeeNumber.Size = new System.Drawing.Size(201, 27);
            this.txtEmployeeNumber.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(275, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 20);
            this.label7.TabIndex = 37;
            this.label7.Text = "Employee Number:";
            // 
            // cbStatus
            // 
            this.cbStatus.AutoSize = true;
            this.cbStatus.Location = new System.Drawing.Point(277, 258);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(71, 24);
            this.cbStatus.TabIndex = 43;
            this.cbStatus.Text = "Status";
            this.cbStatus.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(180, 327);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 29);
            this.btnSave.TabIndex = 44;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(238, 188);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 20);
            this.label11.TabIndex = 46;
            this.label11.Text = "Date of birth: ";
            // 
            // dateTimeofBirth
            // 
            this.dateTimeofBirth.Location = new System.Drawing.Point(238, 211);
            this.dateTimeofBirth.Name = "dateTimeofBirth";
            this.dateTimeofBirth.Size = new System.Drawing.Size(250, 27);
            this.dateTimeofBirth.TabIndex = 45;
            // 
            // errorProviderEmployees
            // 
            this.errorProviderEmployees.ContainerControl = this;
            // 
            // frmEmployeeDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 372);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dateTimeofBirth);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.txtConfirmPass);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtEmployeeNumber);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtGender);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtJMBG);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCityName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.label1);
            this.Name = "frmEmployeeDetails";
            this.Text = "Employee Details";
            this.Load += new System.EventHandler(this.EmployeeDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderEmployees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox txtGender;
        private Label label5;
        private TextBox txtJMBG;
        private Label label4;
        private TextBox txtCityName;
        private Label label3;
        private TextBox txtLastName;
        private Label label2;
        private TextBox txtFirstName;
        private Label label1;
        private TextBox txtConfirmPass;
        private Label label9;
        private TextBox txtPassword;
        private Label label8;
        private TextBox txtEmployeeNumber;
        private Label label7;
        private CheckBox cbStatus;
        private Button btnSave;
        private Label label11;
        private DateTimePicker dateTimeofBirth;
        private ErrorProvider errorProviderEmployees;
    }
}