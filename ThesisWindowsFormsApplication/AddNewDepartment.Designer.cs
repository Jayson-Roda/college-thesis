namespace ThesisWindowsFormsApplication
{
    partial class AddNewDepartment
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
            this.addNewDeptButton = new System.Windows.Forms.Button();
            this.acronymTxtbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.deptNameTextBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addNewDeptButton
            // 
            this.addNewDeptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewDeptButton.Location = new System.Drawing.Point(111, 148);
            this.addNewDeptButton.Name = "addNewDeptButton";
            this.addNewDeptButton.Size = new System.Drawing.Size(109, 31);
            this.addNewDeptButton.TabIndex = 0;
            this.addNewDeptButton.Text = "ADD";
            this.addNewDeptButton.UseVisualStyleBackColor = true;
            this.addNewDeptButton.Click += new System.EventHandler(this.addNewDeptButton_Click);
            // 
            // acronymTxtbox
            // 
            this.acronymTxtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acronymTxtbox.Location = new System.Drawing.Point(15, 34);
            this.acronymTxtbox.Name = "acronymTxtbox";
            this.acronymTxtbox.Size = new System.Drawing.Size(296, 22);
            this.acronymTxtbox.TabIndex = 1;
            this.acronymTxtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(102, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 16);
            this.label6.TabIndex = 29;
            this.label6.Text = "Acronym (Ex. DCST): ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(100, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 16);
            this.label1.TabIndex = 30;
            this.label1.Text = "Department Name: ";
            // 
            // deptNameTextBox
            // 
            this.deptNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deptNameTextBox.Location = new System.Drawing.Point(16, 100);
            this.deptNameTextBox.Name = "deptNameTextBox";
            this.deptNameTextBox.Size = new System.Drawing.Size(296, 22);
            this.deptNameTextBox.TabIndex = 31;
            this.deptNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(111, 200);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 31);
            this.button2.TabIndex = 32;
            this.button2.Text = "CLEAR TEXT";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // AddNewDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(327, 249);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.deptNameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.acronymTxtbox);
            this.Controls.Add(this.addNewDeptButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddNewDepartment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "                                       Add New Department";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addNewDeptButton;
        private System.Windows.Forms.TextBox acronymTxtbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox deptNameTextBox;
        private System.Windows.Forms.Button button2;
    }
}