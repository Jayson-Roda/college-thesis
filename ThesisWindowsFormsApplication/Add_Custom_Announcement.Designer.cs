namespace ThesisWindowsFormsApplication
{
    partial class Add_Custom_Announcement
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
            this.annTextbox1 = new System.Windows.Forms.TextBox();
            this.annLabel1 = new System.Windows.Forms.Label();
            this.addCDABtn = new System.Windows.Forms.Button();
            this.annLabel2 = new System.Windows.Forms.Label();
            this.annLabel3 = new System.Windows.Forms.Label();
            this.clearCDABtn = new System.Windows.Forms.Button();
            this.editCDABtn = new System.Windows.Forms.Button();
            this.exportCDABtn = new System.Windows.Forms.Button();
            this.exitCDABtn = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.msgLengthLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // annTextbox1
            // 
            this.annTextbox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.annTextbox1.Enabled = false;
            this.annTextbox1.Location = new System.Drawing.Point(12, 57);
            this.annTextbox1.MaxLength = 160;
            this.annTextbox1.Multiline = true;
            this.annTextbox1.Name = "annTextbox1";
            this.annTextbox1.Size = new System.Drawing.Size(383, 101);
            this.annTextbox1.TabIndex = 0;
            this.annTextbox1.TextChanged += new System.EventHandler(this.annTextbox1_TextChanged);
            // 
            // annLabel1
            // 
            this.annLabel1.AutoSize = true;
            this.annLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.annLabel1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.annLabel1.Location = new System.Drawing.Point(153, 21);
            this.annLabel1.Name = "annLabel1";
            this.annLabel1.Size = new System.Drawing.Size(121, 16);
            this.annLabel1.TabIndex = 1;
            this.annLabel1.Text = "Announcement 1";
            this.annLabel1.Visible = false;
            // 
            // addCDABtn
            // 
            this.addCDABtn.BackColor = System.Drawing.Color.White;
            this.addCDABtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addCDABtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addCDABtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addCDABtn.Location = new System.Drawing.Point(12, 173);
            this.addCDABtn.Name = "addCDABtn";
            this.addCDABtn.Size = new System.Drawing.Size(91, 23);
            this.addCDABtn.TabIndex = 2;
            this.addCDABtn.Text = "ADD";
            this.addCDABtn.UseVisualStyleBackColor = false;
            this.addCDABtn.Click += new System.EventHandler(this.AddCDABtn_Click);
            // 
            // annLabel2
            // 
            this.annLabel2.AutoSize = true;
            this.annLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.annLabel2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.annLabel2.Location = new System.Drawing.Point(147, 21);
            this.annLabel2.Name = "annLabel2";
            this.annLabel2.Size = new System.Drawing.Size(121, 16);
            this.annLabel2.TabIndex = 3;
            this.annLabel2.Text = "Announcement 2";
            this.annLabel2.Visible = false;
            // 
            // annLabel3
            // 
            this.annLabel3.AutoSize = true;
            this.annLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.annLabel3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.annLabel3.Location = new System.Drawing.Point(147, 21);
            this.annLabel3.Name = "annLabel3";
            this.annLabel3.Size = new System.Drawing.Size(121, 16);
            this.annLabel3.TabIndex = 6;
            this.annLabel3.Text = "Announcement 3";
            this.annLabel3.Visible = false;
            // 
            // clearCDABtn
            // 
            this.clearCDABtn.BackColor = System.Drawing.Color.White;
            this.clearCDABtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearCDABtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearCDABtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearCDABtn.Location = new System.Drawing.Point(159, 191);
            this.clearCDABtn.Name = "clearCDABtn";
            this.clearCDABtn.Size = new System.Drawing.Size(97, 23);
            this.clearCDABtn.TabIndex = 7;
            this.clearCDABtn.Text = "CLEAR TEXT";
            this.clearCDABtn.UseVisualStyleBackColor = false;
            this.clearCDABtn.Visible = false;
            this.clearCDABtn.Click += new System.EventHandler(this.clearCDABtn_Click);
            // 
            // editCDABtn
            // 
            this.editCDABtn.BackColor = System.Drawing.Color.White;
            this.editCDABtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.editCDABtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editCDABtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editCDABtn.Location = new System.Drawing.Point(12, 211);
            this.editCDABtn.Name = "editCDABtn";
            this.editCDABtn.Size = new System.Drawing.Size(91, 23);
            this.editCDABtn.TabIndex = 8;
            this.editCDABtn.Text = "EDIT";
            this.editCDABtn.UseVisualStyleBackColor = false;
            this.editCDABtn.Click += new System.EventHandler(this.editCDABtn_Click);
            // 
            // exportCDABtn
            // 
            this.exportCDABtn.BackColor = System.Drawing.Color.White;
            this.exportCDABtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exportCDABtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportCDABtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportCDABtn.Location = new System.Drawing.Point(304, 173);
            this.exportCDABtn.Name = "exportCDABtn";
            this.exportCDABtn.Size = new System.Drawing.Size(91, 23);
            this.exportCDABtn.TabIndex = 9;
            this.exportCDABtn.Text = "EXPORT";
            this.exportCDABtn.UseVisualStyleBackColor = false;
            this.exportCDABtn.Click += new System.EventHandler(this.exportCDABtn_Click);
            // 
            // exitCDABtn
            // 
            this.exitCDABtn.BackColor = System.Drawing.Color.White;
            this.exitCDABtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitCDABtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitCDABtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitCDABtn.Location = new System.Drawing.Point(304, 211);
            this.exitCDABtn.Name = "exitCDABtn";
            this.exitCDABtn.Size = new System.Drawing.Size(91, 23);
            this.exitCDABtn.TabIndex = 10;
            this.exitCDABtn.Text = "EXIT";
            this.exitCDABtn.UseVisualStyleBackColor = false;
            this.exitCDABtn.Click += new System.EventHandler(this.exitCDABtn_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label21.Location = new System.Drawing.Point(200, 173);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(13, 13);
            this.label21.TabIndex = 97;
            this.label21.Text = "/";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label20.Location = new System.Drawing.Point(210, 173);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(28, 13);
            this.label20.TabIndex = 96;
            this.label20.Text = "160";
            // 
            // msgLengthLabel
            // 
            this.msgLengthLabel.AutoSize = true;
            this.msgLengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msgLengthLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.msgLengthLabel.Location = new System.Drawing.Point(174, 173);
            this.msgLengthLabel.Name = "msgLengthLabel";
            this.msgLengthLabel.Size = new System.Drawing.Size(14, 13);
            this.msgLengthLabel.TabIndex = 95;
            this.msgLengthLabel.Text = "0";
            // 
            // Add_Custom_Announcement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(407, 246);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.msgLengthLabel);
            this.Controls.Add(this.exitCDABtn);
            this.Controls.Add(this.exportCDABtn);
            this.Controls.Add(this.editCDABtn);
            this.Controls.Add(this.clearCDABtn);
            this.Controls.Add(this.annLabel3);
            this.Controls.Add(this.annLabel2);
            this.Controls.Add(this.addCDABtn);
            this.Controls.Add(this.annLabel1);
            this.Controls.Add(this.annTextbox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Add_Custom_Announcement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "                           Add or Edit Customized Default Announcements";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button addCDABtn;
        public System.Windows.Forms.TextBox annTextbox1;
        public System.Windows.Forms.Label annLabel1;
        public System.Windows.Forms.Label annLabel2;
        public System.Windows.Forms.Label annLabel3;
        private System.Windows.Forms.Button clearCDABtn;
        private System.Windows.Forms.Button editCDABtn;
        private System.Windows.Forms.Button exportCDABtn;
        private System.Windows.Forms.Button exitCDABtn;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label msgLengthLabel;
    }
}