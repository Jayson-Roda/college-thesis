using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ThesisWindowsFormsApplication
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            passwordTxtBox.PasswordChar = '*';
            this.AcceptButton = loginBtn;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            AnnouncementForm aform = new AnnouncementForm();
            MySqlConnection con = new MySqlConnection("server=127.0.0.1;user id=root;database=thesisdb_sample;allowuservariables=True");
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `user_register` WHERE `username` = @usn and `passwrd` = @pass", con);

            cmd.Parameters.Add("@usn", MySqlDbType.VarChar).Value = userTxtBox.Text;
            cmd.Parameters.Add("@pass", MySqlDbType.VarChar).Value = passwordTxtBox.Text;

            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        var lastName = dr.GetValue(dr.GetOrdinal("last_name"));
                        var role = dr.GetValue(dr.GetOrdinal("role"));
                        var userID = dr.GetValue(dr.GetOrdinal("user_id"));
                        dr.Close();

                        if (role.ToString() == "0")
                        {
                            aform.userLoginLabel.Text = "ADMIN " + lastName.ToString().ToUpper();
                            aform.buttonAddContactsPanel.Enabled = true;
                        }
                        else
                        {
                            aform.userLoginLabel.Text = "OFFICE STAFF " + lastName.ToString().ToUpper();
                            aform.buttonAddContactsPanel.Enabled = false;
                        }

                        MySqlCommand cmds = new MySqlCommand("INSERT INTO user_logged (last_name, logDate, role, user_id) VALUES (@Lname ,now(), @role, @userID)", con);

                        cmds.Parameters.AddWithValue("@Lname", lastName);
                        cmds.Parameters.AddWithValue("@role", role);
                        cmds.Parameters.AddWithValue("@userID", userID);
                        cmds.ExecuteNonQuery();

                        this.Hide();
                        aform.Show();
                    }
                    else
                    {
                        if (userTxtBox.Text == "" && passwordTxtBox.Text == "")
                            MessageBox.Show("Username and Password are Empty. Please Fill up Username and Password", "CHECK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else if (userTxtBox.Text == "")
                            MessageBox.Show("Username is Empty. Please Fill up Username", "CHECK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else if (passwordTxtBox.Text == "")
                            MessageBox.Show("Password is Empty. Please Fill up Password", "CHECK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                            MessageBox.Show("Log-in Failed. Wrong Input of Username or Password", "WRONG!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Database Connection Failed!");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit(); //terminates all message loops and closes all windows
            Environment.Exit(1); //kills all running threads and the process itself.
        }

        private void createAccBtn_Click(object sender, EventArgs e)
        {
            Int32 count;
            MySqlConnection con = new MySqlConnection("server=127.0.0.1;user id=root;database=thesisdb_sample;allowuservariables=True");
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM user_register", con);
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    count = Int32.Parse(cmd.ExecuteScalar().ToString());
                    if (count == 3)
                    {
                        MessageBox.Show("You can only create 3 accounts in the system with 1 admin and 2 members. Please retrieve your password in the Forgot Password", 
                            "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        CreateAccount ca = new CreateAccount();
                        this.Hide();
                        ca.ShowDialog();
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void forgotPassBtn_Click(object sender, EventArgs e)
        {
            ForgotPassword fp = new ForgotPassword();
            this.Hide();
            fp.ShowDialog();
        }
    }
}
