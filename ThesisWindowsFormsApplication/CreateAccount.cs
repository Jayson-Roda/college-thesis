using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ThesisWindowsFormsApplication
{
    public partial class CreateAccount : Form
    {
        Menu menu = new Menu();
        MySqlConnection con = new MySqlConnection("server=127.0.0.1;user id=root;database=thesisdb_sample;allowuservariables=True");

        public CreateAccount()
        {
            InitializeComponent();
            timer1.Start();
            passwordTxtbox.PasswordChar = '*';
            confirmPasswortTxtbox.PasswordChar = '*';
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (fName.Text == "" || lName.Text == "" || secretQAnswer.Text == "" || usernameTxtbox.Text == "" || passwordTxtbox.Text == "" || roleCmb.Text == "-SELECT-" || secretQuestionCmb.Text == "-SELECT-")
                MessageBox.Show("Please fill-up all the forms");
            else if (usernameTxtbox.TextLength < 4)
                MessageBox.Show("username needs atleast 5 characters");
            else if (passwordTxtbox.TextLength < 5)
                MessageBox.Show("password need atleast 6 characters");
            else if (passwordTxtbox.Text != confirmPasswortTxtbox.Text)
                MessageBox.Show("Password do not match");
            else
            {
                try
                {
                    con.Open();
                    if (con.State == ConnectionState.Open)
                    {
                        MySqlCommand cmd = new MySqlCommand("INSERT INTO user_register (first_name, last_name, middle_name, role, secret_question, secret_answer, username, passwrd) VALUES (@Fname,@Lname,@Mname,@role,@sq,@sqa,@user,@pass)", con);
                        cmd.Parameters.AddWithValue("@Fname", fName.Text);
                        cmd.Parameters.AddWithValue("@Lname", lName.Text);
                        cmd.Parameters.AddWithValue("@Mname", mName.Text);
                        cmd.Parameters.AddWithValue("@role", roleCmb.SelectedIndex);
                        cmd.Parameters.AddWithValue("@sq", secretQuestionCmb.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@sqa", secretQAnswer.Text);
                        cmd.Parameters.AddWithValue("@user", usernameTxtbox.Text);
                        cmd.Parameters.AddWithValue("@pass", passwordTxtbox.Text);


                        int i = cmd.ExecuteNonQuery();
                        if (i != 0)
                            MessageBox.Show(this, "Contact added Successfully!", "Congrats", MessageBoxButtons.OK);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Dispose();
                this.Close();
                menu.Show();
            }
        }

        void clear()
        {
            fName.Text = lName.Text = secretQAnswer.Text = usernameTxtbox.Text = passwordTxtbox.Text = confirmPasswortTxtbox.Text = "";
            roleCmb.SelectedIndex = secretQuestionCmb.SelectedIndex = -1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (usernameTxtbox.Text != "")
                label10.ForeColor = Color.Green;
            else
                label10.ForeColor = Color.Red;

            if (passwordTxtbox.Text != "")
                label11.ForeColor = Color.Green;
            else
                label11.ForeColor = Color.Red;

            if (passwordTxtbox.Text != confirmPasswortTxtbox.Text || passwordTxtbox.Text == "")
                label12.ForeColor = Color.Red;
            else
                label12.ForeColor = Color.Green;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
            menu.Show();
        }

        private void fName_TextChanged(object sender, EventArgs e)
        {
            if (fName.Text.Length <= 0) return;
            string s = fName.Text.Substring(0, 1);
            if (s != s.ToUpper())
            {
                int curSelStart = fName.SelectionStart;
                int curSelLength = fName.SelectionLength;
                fName.SelectionStart = 0;
                fName.SelectionLength = 1;
                fName.SelectedText = s.ToUpper();
                fName.SelectionStart = curSelStart;
                fName.SelectionLength = curSelLength;
            }
        }

        private void mName_TextChanged(object sender, EventArgs e)
        {
            if (mName.Text.Length <= 0) return;
            string s = mName.Text.Substring(0, 1);
            if (s != s.ToUpper())
            {
                int curSelStart = mName.SelectionStart;
                int curSelLength = mName.SelectionLength;
                mName.SelectionStart = 0;
                mName.SelectionLength = 1;
                mName.SelectedText = s.ToUpper();
                mName.SelectionStart = curSelStart;
                mName.SelectionLength = curSelLength;
            }
        }

        private void lName_TextChanged(object sender, EventArgs e)
        {
            if (lName.Text.Length <= 0) return;
            string s = lName.Text.Substring(0, 1);
            if (s != s.ToUpper())
            {
                int curSelStart = lName.SelectionStart;
                int curSelLength = lName.SelectionLength;
                lName.SelectionStart = 0;
                lName.SelectionLength = 1;
                lName.SelectedText = s.ToUpper();
                lName.SelectionStart = curSelStart;
                lName.SelectionLength = curSelLength;
            }
        }

        private void mySQLCount()
        {
            int usercount = 0;
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    MySqlCommand cmdc = new MySqlCommand("SELECT COUNT(*) INTO" + usercount +" FROM user_register", con);
                    MySqlDataReader drc = cmdc.ExecuteReader();
                    if (drc.Read())
                    {
                        if (usercount == 3)
                            MessageBox.Show("User registered is full");
                        else
                            MessageBox.Show(usercount.ToString());
                            
                    }
                    drc.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        private void roleCmb_Click(object sender, EventArgs e)
        {
            roleCmb.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
