using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ThesisWindowsFormsApplication
{
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (fpsecretQAnswer.Text == "" || fpusernameTxtbox.Text == "" || fproleCmb.Text == "-SELECT-" || fpsecretQuestionCmb.Text == "-SELECT-")
                MessageBox.Show("Please fill-up all the forms");

            else
            {
                MySqlConnection con = new MySqlConnection("server=127.0.0.1;user id=root;database=thesisdb_sample;allowuservariables=True");
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `user_register` WHERE `username` = @usn and `role` = @role and `secret_question` = @sq and `secret_answer` = @sqa", con);

                cmd.Parameters.Add("@usn", MySqlDbType.VarChar).Value = fpusernameTxtbox.Text;
                cmd.Parameters.Add("@role", MySqlDbType.Int16).Value = fproleCmb.SelectedIndex;
                cmd.Parameters.Add("@sq", MySqlDbType.VarChar).Value = fpsecretQuestionCmb.Text;
                cmd.Parameters.Add("@sqa", MySqlDbType.VarChar).Value = fpsecretQAnswer.Text;

                try
                {
                    con.Open();
                    if (con.State == ConnectionState.Open)
                    {
                        MySqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            MessageBox.Show("Your Password is ''" + dr.GetValue(7).ToString() + "'' Please save and dont forget it again Thank You! ^_^");
                        }
                        else
                        {
                            MessageBox.Show("PLEASE CHECK: Input does not match from the database", "PLEASE CHECK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Close();
            menu.Show();
        }
    }
}
