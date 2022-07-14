using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThesisWindowsFormsApplication
{
    public partial class AddNewDepartment : Form
    {
        MySqlConnection con = new MySqlConnection("server = 127.0.0.1; user id = root; database = thesisdb_sample; allowuservariables = True");

        public AddNewDepartment()
        {
            InitializeComponent();
        }

        private void addNewDeptButton_Click(object sender, EventArgs e)
        {
            AnnouncementForm aform = new AnnouncementForm();
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    if (MessageBox.Show(this, "Do you really want to add this Department?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        MySqlCommand cmd = new MySqlCommand("INSERT INTO department (acronym, dept) VALUES (@Acronym,@Dept)", con);
                        cmd.Parameters.AddWithValue("@Acronym", acronymTxtbox.Text);
                        cmd.Parameters.AddWithValue("@Dept", deptNameTextBox.Text);


                        int i = cmd.ExecuteNonQuery();
                        if (i != 0)
                            MessageBox.Show(this, "Department added Successfully!", "Congrats", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
            aform.Show();
        }
    }
}
