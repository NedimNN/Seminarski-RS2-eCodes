namespace eCodes.WinUI
{
    partial class frmSellerDetails
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtFirstname = new System.Windows.Forms.TextBox();
            this.txtLastname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCityname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtJMBG = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGender = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtWebsite = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimeBirth = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.btnSaveSeller = new System.Windows.Forms.Button();
            this.errorProviderSellers = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtConfirmPass = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPayPalEmail = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderSellers)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Firstname: ";
            // 
            // txtFirstname
            // 
            this.txtFirstname.Location = new System.Drawing.Point(12, 32);
            this.txtFirstname.Name = "txtFirstname";
            this.txtFirstname.Size = new System.Drawing.Size(185, 27);
            this.txtFirstname.TabIndex = 1;
            this.txtFirstname.Validating += new System.ComponentModel.CancelEventHandler(this.txtFirstname_Validating);
            // 
            // txtLastname
            // 
            this.txtLastname.Location = new System.Drawing.Point(12, 85);
            this.txtLastname.Name = "txtLastname";
            this.txtLastname.Size = new System.Drawing.Size(185, 27);
            this.txtLastname.TabIndex = 3;
            this.txtLastname.Validating += new System.ComponentModel.CancelEventHandler(this.txtLastname_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Lastname: ";
            // 
            // txtCityname
            // 
            this.txtCityname.Location = new System.Drawing.Point(12, 142);
            this.txtCityname.Name = "txtCityname";
            this.txtCityname.Size = new System.Drawing.Size(185, 27);
            this.txtCityname.TabIndex = 5;
            this.txtCityname.Validating += new System.ComponentModel.CancelEventHandler(this.txtCityname_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "City Name: ";
            // 
            // txtJMBG
            // 
            this.txtJMBG.Location = new System.Drawing.Point(12, 198);
            this.txtJMBG.Name = "txtJMBG";
            this.txtJMBG.Size = new System.Drawing.Size(185, 27);
            this.txtJMBG.TabIndex = 7;
            this.txtJMBG.Validating += new System.ComponentModel.CancelEventHandler(this.txtJMBG_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "JMBG: ";
            // 
            // txtGender
            // 
            this.txtGender.Location = new System.Drawing.Point(12, 255);
            this.txtGender.Name = "txtGender";
            this.txtGender.Size = new System.Drawing.Size(185, 27);
            this.txtGender.TabIndex = 9;
            this.txtGender.Validating += new System.ComponentModel.CancelEventHandler(this.txtGender_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Gender: ";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(232, 32);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(185, 27);
            this.txtName.TabIndex = 11;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(232, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Name: ";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(232, 85);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(185, 27);
            this.txtAddress.TabIndex = 13;
            this.txtAddress.Validating += new System.ComponentModel.CancelEventHandler(this.txtAddress_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(232, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Address:";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(232, 142);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(185, 27);
            this.txtPhoneNumber.TabIndex = 15;
            this.txtPhoneNumber.Validating += new System.ComponentModel.CancelEventHandler(this.txtPhoneNumber_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(232, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Phone Number: ";
            // 
            // txtWebsite
            // 
            this.txtWebsite.Location = new System.Drawing.Point(232, 198);
            this.txtWebsite.Name = "txtWebsite";
            this.txtWebsite.Size = new System.Drawing.Size(185, 27);
            this.txtWebsite.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(232, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 20);
            this.label9.TabIndex = 16;
            this.label9.Text = "Website: ";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(232, 255);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(185, 27);
            this.txtEmail.TabIndex = 19;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(232, 232);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 20);
            this.label10.TabIndex = 18;
            this.label10.Text = "Email: ";
            // 
            // dateTimeBirth
            // 
            this.dateTimeBirth.Location = new System.Drawing.Point(97, 424);
            this.dateTimeBirth.Name = "dateTimeBirth";
            this.dateTimeBirth.Size = new System.Drawing.Size(250, 27);
            this.dateTimeBirth.TabIndex = 22;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(163, 401);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 20);
            this.label12.TabIndex = 23;
            this.label12.Text = "Date of birth: ";
            // 
            // btnSaveSeller
            // 
            this.btnSaveSeller.Location = new System.Drawing.Point(163, 472);
            this.btnSaveSeller.Name = "btnSaveSeller";
            this.btnSaveSeller.Size = new System.Drawing.Size(94, 29);
            this.btnSaveSeller.TabIndex = 24;
            this.btnSaveSeller.Text = "Save";
            this.btnSaveSeller.UseVisualStyleBackColor = true;
            this.btnSaveSeller.Click += new System.EventHandler(this.btnSaveSeller_Click);
            // 
            // errorProviderSellers
            // 
            this.errorProviderSellers.ContainerControl = this;
            // 
            // txtConfirmPass
            // 
            this.txtConfirmPass.Location = new System.Drawing.Point(232, 308);
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.PasswordChar = '*';
            this.txtConfirmPass.Size = new System.Drawing.Size(185, 27);
            this.txtConfirmPass.TabIndex = 28;
            this.txtConfirmPass.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfirmPass_Validating);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(232, 285);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(132, 20);
            this.label13.TabIndex = 27;
            this.label13.Text = "Confirm password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(12, 308);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(185, 27);
            this.txtPassword.TabIndex = 26;
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassword_Validating);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 285);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 20);
            this.label14.TabIndex = 25;
            this.label14.Text = "Password:";
            // 
            // txtPayPalEmail
            // 
            this.txtPayPalEmail.Location = new System.Drawing.Point(125, 361);
            this.txtPayPalEmail.Name = "txtPayPalEmail";
            this.txtPayPalEmail.Size = new System.Drawing.Size(185, 27);
            this.txtPayPalEmail.TabIndex = 30;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(125, 338);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 20);
            this.label11.TabIndex = 29;
            this.label11.Text = "PayPal Email:";
            // 
            // frmSellerDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 508);
            this.Controls.Add(this.txtPayPalEmail);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtConfirmPass);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnSaveSeller);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dateTimeBirth);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtWebsite);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtGender);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtJMBG);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCityname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLastname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFirstname);
            this.Controls.Add(this.label1);
            this.Name = "frmSellerDetails";
            this.Text = "Seller Details";
            this.Load += new System.EventHandler(this.frmSellerDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderSellers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox txtFirstname;
        private TextBox txtLastname;
        private Label label2;
        private TextBox txtCityname;
        private Label label3;
        private TextBox txtJMBG;
        private Label label4;
        private TextBox txtGender;
        private Label label5;
        private TextBox txtName;
        private Label label6;
        private TextBox txtAddress;
        private Label label7;
        private TextBox txtPhoneNumber;
        private Label label8;
        private TextBox txtWebsite;
        private Label label9;
        private TextBox txtEmail;
        private Label label10;
        private DateTimePicker dateTimeBirth;
        private Label label12;
        private Button btnSaveSeller;
        private ErrorProvider errorProviderSellers;
        private TextBox txtConfirmPass;
        private Label label13;
        private TextBox txtPassword;
        private Label label14;
        private TextBox txtPayPalEmail;
        private Label label11;
    }
}