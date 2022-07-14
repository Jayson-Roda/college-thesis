namespace ThesisWindowsFormsApplication
{
    partial class CreateAccount
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
            this.fName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lName = new System.Windows.Forms.TextBox();
            this.roleCmb = new System.Windows.Forms.ComboBox();
            this.secretQuestionCmb = new System.Windows.Forms.ComboBox();
            this.secretQAnswer = new System.Windows.Forms.TextBox();
            this.usernameTxtbox = new System.Windows.Forms.TextBox();
            this.passwordTxtbox = new System.Windows.Forms.TextBox();
            this.confirmPasswortTxtbox = new System.Windows.Forms.TextBox();
            this.submitBtn = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.mName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // fName
            // 
            this.fName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fName.Location = new System.Drawing.Point(189, 25);
            this.fName.Margin = new System.Windows.Forms.Padding(4);
            this.fName.Name = "fName";
            this.fName.Size = new System.Drawing.Size(271, 22);
            this.fName.TabIndex = 0;
            this.fName.TextChanged += new System.EventHandler(this.fName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(73, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "First Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(18, 297);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(495, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "_____________________________________________________________";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(71, 110);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 19);
            this.label3.TabIndex = 12;
            this.label3.Text = "Last Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(121, 157);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 19);
            this.label4.TabIndex = 13;
            this.label4.Text = "Role:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(33, 210);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 19);
            this.label5.TabIndex = 14;
            this.label5.Text = "Secret Question:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(76, 342);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 19);
            this.label6.TabIndex = 15;
            this.label6.Text = "Username:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(82, 392);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 19);
            this.label7.TabIndex = 16;
            this.label7.Text = "Password:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(17, 442);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(149, 19);
            this.label8.TabIndex = 17;
            this.label8.Text = "Confirm Password:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(56, 257);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 19);
            this.label9.TabIndex = 19;
            this.label9.Text = "Secret Answer:";
            // 
            // lName
            // 
            this.lName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lName.Location = new System.Drawing.Point(189, 110);
            this.lName.Margin = new System.Windows.Forms.Padding(4);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(271, 22);
            this.lName.TabIndex = 3;
            this.lName.TextChanged += new System.EventHandler(this.lName_TextChanged);
            // 
            // roleCmb
            // 
            this.roleCmb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.roleCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roleCmb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roleCmb.FormattingEnabled = true;
            this.roleCmb.Items.AddRange(new object[] {
            "ADMIN",
            "OFFICE STAFF"});
            this.roleCmb.Location = new System.Drawing.Point(189, 158);
            this.roleCmb.Margin = new System.Windows.Forms.Padding(4);
            this.roleCmb.Name = "roleCmb";
            this.roleCmb.Size = new System.Drawing.Size(271, 24);
            this.roleCmb.TabIndex = 4;
            // 
            // secretQuestionCmb
            // 
            this.secretQuestionCmb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.secretQuestionCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.secretQuestionCmb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secretQuestionCmb.FormattingEnabled = true;
            this.secretQuestionCmb.Items.AddRange(new object[] {
            "what is your favorite movie?",
            "what was your first pet`s name?",
            "what is your favorit beverage?",
            "what is your favorite place?",
            "what is your favorite country?",
            "what is your favorite song?",
            "who is your favorite singer?"});
            this.secretQuestionCmb.Location = new System.Drawing.Point(189, 210);
            this.secretQuestionCmb.Margin = new System.Windows.Forms.Padding(4);
            this.secretQuestionCmb.Name = "secretQuestionCmb";
            this.secretQuestionCmb.Size = new System.Drawing.Size(271, 24);
            this.secretQuestionCmb.TabIndex = 23;
            // 
            // secretQAnswer
            // 
            this.secretQAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secretQAnswer.Location = new System.Drawing.Point(189, 257);
            this.secretQAnswer.Margin = new System.Windows.Forms.Padding(4);
            this.secretQAnswer.Name = "secretQAnswer";
            this.secretQAnswer.Size = new System.Drawing.Size(271, 22);
            this.secretQAnswer.TabIndex = 24;
            // 
            // usernameTxtbox
            // 
            this.usernameTxtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTxtbox.Location = new System.Drawing.Point(189, 338);
            this.usernameTxtbox.Margin = new System.Windows.Forms.Padding(4);
            this.usernameTxtbox.Name = "usernameTxtbox";
            this.usernameTxtbox.Size = new System.Drawing.Size(271, 22);
            this.usernameTxtbox.TabIndex = 25;
            // 
            // passwordTxtbox
            // 
            this.passwordTxtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTxtbox.Location = new System.Drawing.Point(189, 390);
            this.passwordTxtbox.Margin = new System.Windows.Forms.Padding(4);
            this.passwordTxtbox.Name = "passwordTxtbox";
            this.passwordTxtbox.Size = new System.Drawing.Size(271, 22);
            this.passwordTxtbox.TabIndex = 26;
            // 
            // confirmPasswortTxtbox
            // 
            this.confirmPasswortTxtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmPasswortTxtbox.Location = new System.Drawing.Point(189, 442);
            this.confirmPasswortTxtbox.Margin = new System.Windows.Forms.Padding(4);
            this.confirmPasswortTxtbox.Name = "confirmPasswortTxtbox";
            this.confirmPasswortTxtbox.Size = new System.Drawing.Size(271, 22);
            this.confirmPasswortTxtbox.TabIndex = 27;
            // 
            // submitBtn
            // 
            this.submitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.submitBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.submitBtn.Location = new System.Drawing.Point(361, 495);
            this.submitBtn.Margin = new System.Windows.Forms.Padding(4);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(100, 28);
            this.submitBtn.TabIndex = 28;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(469, 342);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 25);
            this.label10.TabIndex = 28;
            this.label10.Text = "*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(469, 392);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 25);
            this.label11.TabIndex = 29;
            this.label11.Text = "*";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(469, 447);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(20, 25);
            this.label12.TabIndex = 30;
            this.label12.Text = "*";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(189, 495);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 29;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.Control;
            this.label13.Location = new System.Drawing.Point(46, 71);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(120, 19);
            this.label13.TabIndex = 32;
            this.label13.Text = "Middle Name:";
            // 
            // mName
            // 
            this.mName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mName.Location = new System.Drawing.Point(189, 71);
            this.mName.Margin = new System.Windows.Forms.Padding(4);
            this.mName.Name = "mName";
            this.mName.Size = new System.Drawing.Size(271, 22);
            this.mName.TabIndex = 2;
            this.mName.TextChanged += new System.EventHandler(this.mName_TextChanged);
            // 
            // CreateAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(529, 573);
            this.ControlBox = false;
            this.Controls.Add(this.mName);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.confirmPasswortTxtbox);
            this.Controls.Add(this.passwordTxtbox);
            this.Controls.Add(this.usernameTxtbox);
            this.Controls.Add(this.secretQAnswer);
            this.Controls.Add(this.secretQuestionCmb);
            this.Controls.Add(this.roleCmb);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fName);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CreateAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "                                                                      User Regist" +
    "ration Or Sign Up";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox lName;
        private System.Windows.Forms.ComboBox roleCmb;
        private System.Windows.Forms.ComboBox secretQuestionCmb;
        private System.Windows.Forms.TextBox secretQAnswer;
        private System.Windows.Forms.TextBox usernameTxtbox;
        private System.Windows.Forms.TextBox passwordTxtbox;
        private System.Windows.Forms.TextBox confirmPasswortTxtbox;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox mName;
    }
}