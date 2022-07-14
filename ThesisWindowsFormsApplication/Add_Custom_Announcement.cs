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
    public partial class Add_Custom_Announcement : Form
    {
        AnnouncementForm af = new AnnouncementForm();
        bool editClicked = false;
        MySqlConnection con = new MySqlConnection("server = 127.0.0.1; user id = root; database = thesisdb_sample; allowuservariables = True");
        public Add_Custom_Announcement()
        {
            InitializeComponent();
        }

        private void AddCDABtn_Click(object sender, EventArgs e)
        {
            if (editClicked)
            {
                try
                {
                    if (annLabel1.Visible == true && annTextbox1.Text != "" && annTextbox1.TextLength <= 160)
                    {
                        con.Open();
                        if (con.State == ConnectionState.Open)
                        {
                            MySqlCommand cmd = new MySqlCommand("UPDATE custom_default_announcement SET announcement_Text = @annText WHERE id = 1", con);

                            cmd.Parameters.AddWithValue("@annText", annTextbox1.Text);

                            int i = cmd.ExecuteNonQuery();
                            if (i != 0)
                                MessageBox.Show(this, "New Customize Default Announcement 1 has been Added to the Database", "Congrats", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if (annLabel2.Visible == true && annTextbox1.Text != "" && annTextbox1.TextLength <= 160)
                    {
                        con.Open();
                        if (con.State == ConnectionState.Open)
                        {
                            MySqlCommand cmd = new MySqlCommand("UPDATE custom_default_announcement SET announcement_Text = @annText WHERE id = 2", con);
                            cmd.Parameters.AddWithValue("@annText", annTextbox1.Text);
                            int i = cmd.ExecuteNonQuery();
                            if (i != 0)
                                MessageBox.Show(this, "New Customize Default Announcement 1 has been Added to the Database", "Congrats", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if (annLabel3.Visible == true && annTextbox1.Text != "" && annTextbox1.TextLength <= 160)
                    {
                        con.Open();
                        if (con.State == ConnectionState.Open)
                        {
                            MySqlCommand cmd = new MySqlCommand("UPDATE custom_default_announcement SET announcement_Text = @annText WHERE id = 3", con);
                            cmd.Parameters.AddWithValue("@annText", annTextbox1.Text);
                            int i = cmd.ExecuteNonQuery();
                            if (i != 0)
                                MessageBox.Show(this, "New Customize Default Announcement 1 has been Added to the Database", "Congrats", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                        MessageBox.Show("Can't add Announcement if Message Text Box is Empty or Text Character Length is Greather than 160", "CHECK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Adding Customized Default Announcement Failed: " + ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                clearCDABtn.Visible = false;
                annTextbox1.Cursor = Cursors.Default;
                editClicked = false;
                exportCDABtn.Enabled = true;
            }
            else
                MessageBox.Show("You can't add new default announcement if you dont click edit button", "CHECK!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void editCDABtn_Click(object sender, EventArgs e)
        {
            clearCDABtn.Visible = true;
            annTextbox1.Enabled = true;
            editClicked = true;
            exportCDABtn.Enabled = false;
        }

        private void clearCDABtn_Click(object sender, EventArgs e)
        {
            annTextbox1.Text = "";
        }

        private void exportCDABtn_Click(object sender, EventArgs e)
        {
            af.messageTxtBox.Text = annTextbox1.Text;
            this.Dispose();
            this.Close();
            af.Show();
        }

        private void exitCDABtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void annTextbox1_TextChanged(object sender, EventArgs e)
        {
            msgLengthLabel.Text = annTextbox1.TextLength.ToString();
        }
    }
}
 