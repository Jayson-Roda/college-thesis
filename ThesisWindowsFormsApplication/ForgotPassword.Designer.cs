namespace ThesisWindowsFormsApplication
{
    partial class ForgotPassword
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
            this.fpusernameTxtbox = new System.Windows.Forms.TextBox();
            this.fproleCmb = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.fpsecretQAnswer = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.submitBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.fpsecretQuestionCmb = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // fpusernameTxtbox
            // 
            this.fpusernameTxtbox.Location = new System.Drawing.Point(133, 46);
            this.fpusernameTxtbox.MaxLength = 50;
            this.fpusernameTxtbox.Name = "fpusernameTxtbox";
            this.fpusernameTxtbox.Size = new System.Drawing.Size(242, 20);
            this.fpusernameTxtbox.TabIndex = 0;
            // 
            // fproleCmb
            // 
            this.fproleCmb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.fproleCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fproleCmb.FormattingEnabled = true;
            this.fproleCmb.Items.AddRange(new object[] {
            "ADMIN",
            "MEMBER"});
            this.fproleCmb.Location = new System.Drawing.Point(133, 90);
            this.fproleCmb.Name = "fproleCmb";
            this.fproleCmb.Size = new System.Drawing.Size(242, 21);
            this.fproleCmb.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(10, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 16);
            this.label5.TabIndex = 27;
            this.label5.Text = "Secret Question:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(87, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 26;
            this.label4.Text = "Role:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(48, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 16);
            this.label6.TabIndex = 28;
            this.label6.Text = "Username:";
            // 
            // fpsecretQAnswer
            // 
            this.fpsecretQAnswer.Location = new System.Drawing.Point(133, 174);
            this.fpsecretQAnswer.MaxLength = 50;
            this.fpsecretQAnswer.Name = "fpsecretQAnswer";
            this.fpsecretQAnswer.Size = new System.Drawing.Size(242, 20);
            this.fpsecretQAnswer.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label9.Location = new System.Drawing.Point(20, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 16);
            this.label9.TabIndex = 30;
            this.label9.Text = "Secret Answer:";
            // 
            // submitBtn
            // 
            this.submitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.submitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitBtn.Location = new System.Drawing.Point(189, 214);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(132, 29);
            this.submitBtn.TabIndex = 4;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.Location = new System.Drawing.Point(189, 268);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(132, 29);
            this.exitBtn.TabIndex = 5;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // fpsecretQuestionCmb
            // 
            this.fpsecretQuestionCmb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.fpsecretQuestionCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fpsecretQuestionCmb.FormattingEnabled = true;
            this.fpsecretQuestionCmb.Items.AddRange(new object[] {
            "what is your favorite movie?",
            "what was your first pet`s name?",
            "what is your favorit beverage?",
            "what is your favorite place?",
            "what is your favorite country?",
            "what is your favorite song?",
            "who is your favorite singer?"});
            this.fpsecretQuestionCmb.Location = new System.Drawing.Point(133, 134);
            this.fpsecretQuestionCmb.Name = "fpsecretQuestionCmb";
            this.fpsecretQuestionCmb.Size = new System.Drawing.Size(242, 21);
            this.fpsecretQuestionCmb.TabIndex = 2;
            // 
            // ForgotPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(434, 311);
            this.ControlBox = false;
            this.Controls.Add(this.fpsecretQuestionCmb);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.fpsecretQAnswer);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fproleCmb);
            this.Controls.Add(this.fpusernameTxtbox);
            this.Name = "ForgotPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "                                                              Forgot Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fpusernameTxtbox;
        private System.Windows.Forms.ComboBox fproleCmb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox fpsecretQAnswer;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.ComboBox fpsecretQuestionCmb;
    }
}