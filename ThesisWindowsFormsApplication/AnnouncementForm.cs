using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using GsmComm.GsmCommunication;
using GsmComm.PduConverter;
using GsmComm.PduConverter.SmartMessaging;
using MySql.Data.MySqlClient;
using System.Threading;

namespace ThesisWindowsFormsApplication
{
    public partial class AnnouncementForm : Form
    {
        GsmCommMain comm;
        bool comConnected = false;
        bool addContactClicked = false;
        GSMsms sms = new GSMsms();
        MySqlConnection con = new MySqlConnection("server = 127.0.0.1; user id = root; database = thesisdb_sample; allowuservariables = True");

        public AnnouncementForm()
        {
            InitializeComponent();
            insertDepartment();
            searchTimer.Start();
            panel2ReadMessage.Hide();
            panel3AddContacts.Hide();
        }

        //Function that Search the Connected GSM Device
        private void searchDevice()
        {
            addContactsCheckerTimer();

            sms.Search();
            if (sms.IsDeviceFound)
            {
                connectBtn.Enabled = true;
                label1.Text = "Device Name: " + sms.deviceName.Remove(23) + " ";
                comPortTxtBox.Text = sms.deviceName.Remove(0, 23);
                if (comConnected)
                {
                    if (cpNumberTxtBox.Text != "")
                        sendButton.Enabled = true;
                    else
                        sendButton.Enabled = false;
                    //signalStrength();
                }
            }
            else
            {
                comPortTxtBox.Text = "NOT DETECTED";
                connectionLabel.BackColor = Color.Red;
                connectionLabel.Text = "DEVICE NOT FOUND!";
                connectBtn.Enabled = false;
                DisableButtons();
            }
        }

        //Timer that search the device connected in computer
        private void searchTimer_Tick(object sender, EventArgs e)
        {
            searchDevice();
        }

        #region "Send Message Panel"
        //Button to show the Send Message Panel
        private void buttonSendMessagePanel_Click(object sender, EventArgs e)
        {
            addContactClicked = false;
            panelLeft.Height = buttonSendMessagePanel.Height;
            panelLeft.Top = buttonSendMessagePanel.Top;
            panel1SendMessage.Show();
            panel2ReadMessage.Hide();
            panel3AddContacts.Hide();
        }

        //Button to Connect GSM Device
        private void connectBtn_Click(object sender, EventArgs e)
        {
            bool retry;
            do
            {
                retry = false;
                try
                {
                    connectionLabel.Text = "CONNECTING...";
                    connectionLabel.BackColor = Color.Yellow;
                    comm = new GsmCommMain(comPortTxtBox.Text);
                    Cursor.Current = Cursors.WaitCursor;

                    comm.Open();
                    if (comm.IsConnected())
                    {
                        Thread.Sleep(3000);
                        connectBtn.Visible = false;
                        connectionLabel.Text = "CONNECTED!!!";
                        connectionLabel.BackColor = Color.Green;
                        comConnected = true;
                        EnableButtons();
                    }
                    else
                    {
                        connectionLabel.Text = "DISCONNECTED..";
                        connectionLabel.BackColor = Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    if (MessageBox.Show(this, ex.Message, "Check", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) == DialogResult.Retry)
                        retry = true;
                    else
                        return;
                }
            } while (retry);
        }

        //Event that selects the Contacts that save in the database
        private void contactCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            cpNumberTxtBox.Text = "";
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    ///all contacts
                    if (contactCmbBox.SelectedIndex == 0)
                    {
                        MySqlCommand cmd = new MySqlCommand("Select contact_number from vsu_contacts", con);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        importContacts(dr, cmd);
                        rbAll.Enabled = false;
                        rbNonRegular.Enabled = false;
                        rbRegular.Enabled = false;
                        employeeStatusBTN.Visible = false;
                        deptComboBox.Enabled = false;
                        deptButton.Enabled = false;
                    }
                    ///all VSU employee contacts
                    else if (contactCmbBox.SelectedIndex == 1)
                    {
                        rbAll.Enabled = true;
                        rbNonRegular.Enabled = true;
                        rbRegular.Enabled = true;
                        employeeStatusBTN.Visible = true;
                        deptComboBox.Enabled = false;
                        deptButton.Enabled = false;
                    }
                    //admin faculties
                    else if (contactCmbBox.SelectedIndex == 2)
                    {
                        rbAll.Enabled = true;
                        rbNonRegular.Enabled = true;
                        rbRegular.Enabled = true;
                        employeeStatusBTN.Visible = true;
                        deptComboBox.Enabled = false;
                        deptButton.Enabled = false;
                    }
                    //Dept. Heads
                    else if (contactCmbBox.SelectedIndex == 3)
                    {
                        MessageBox.Show("Please Select what Department", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        rbAll.Enabled = true;
                        rbAll.Checked = true;
                        rbNonRegular.Enabled = false;
                        rbRegular.Enabled = false;
                        employeeStatusBTN.Visible = false;
                        deptComboBox.Enabled = true;
                        deptButton.Enabled = true;
                        deptComboBox.SelectedIndex = 0;
                    }
                    //Dept. Faculty
                    else if (contactCmbBox.SelectedIndex == 4)
                    {
                        MessageBox.Show("Please check Employment Status and Select what Department", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        rbAll.Enabled = true;
                        rbNonRegular.Enabled = true;
                        rbRegular.Enabled = true;
                        employeeStatusBTN.Visible = false;
                        deptComboBox.Enabled = true;
                        deptButton.Enabled = true;
                        deptComboBox.SelectedIndex = 0;
                    }
                    //Students
                    else if (contactCmbBox.SelectedIndex == 5)
                    {
                        MessageBox.Show("Please Select what Department", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        rbAll.Enabled = false;
                        rbNonRegular.Enabled = false;
                        rbRegular.Enabled = false;
                        employeeStatusBTN.Visible = false;
                        deptComboBox.Enabled = true;
                        deptButton.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Please Select from Contacts", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Database Connection Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Select the status of the employee
        private void employeeStatusBTN_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    if (contactCmbBox.SelectedIndex == 1 && rbAll.Checked)
                    {
                        MySqlCommand cmd = new MySqlCommand("Select contact_number from vsu_contacts where Employment_Status = 1 or Employment_Status = 2", con);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        importContacts(dr, cmd);
                    }
                    else if (contactCmbBox.SelectedIndex == 1 && rbRegular.Checked)
                    {
                        MySqlCommand cmd = new MySqlCommand("Select contact_number from vsu_contacts where employment_status = 1", con);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        importContacts(dr, cmd);
                    }
                    else if (contactCmbBox.SelectedIndex == 1 && rbNonRegular.Checked)
                    {
                        MySqlCommand cmd = new MySqlCommand("Select contact_number from vsu_contacts where employment_status = 2", con);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        importContacts(dr, cmd);
                    }
                    else if (contactCmbBox.SelectedIndex == 2 && rbAll.Checked)
                    {
                        MySqlCommand cmd = new MySqlCommand("Select contact_number from vsu_contacts where position = 0 and Employment_Status = 1 or Employment_Status = 2", con);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        importContacts(dr, cmd);
                    }
                    else if (contactCmbBox.SelectedIndex == 2 && rbRegular.Checked)
                    {
                        MySqlCommand cmd = new MySqlCommand("Select contact_number from vsu_contacts where position = 0 and employment_status = 1", con);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        importContacts(dr, cmd);
                    }
                    else if (contactCmbBox.SelectedIndex == 2 && rbNonRegular.Checked)
                    {
                        MySqlCommand cmd = new MySqlCommand("Select contact_number from vsu_contacts where position = 0 and employment_status = 2", con);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        importContacts(dr, cmd);
                    }

                    else
                        MessageBox.Show("Please Check the Employment Status", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Database Connection Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Select which Dept you want to send the message
        private void deptButton_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    if (contactCmbBox.SelectedIndex == 4 && rbAll.Checked)
                        allEmpStatusDeptFaculty();
                    else if (contactCmbBox.SelectedIndex == 4 && rbRegular.Checked)
                        regularEmpStatusDeptFaculty();
                    else if (contactCmbBox.SelectedIndex == 4 && rbNonRegular.Checked)
                        nonRegularEmpStatusDeptFaculty();
                    else if (contactCmbBox.SelectedIndex == 3 && rbAll.Checked)
                        deptHeadsContacts();
                    else if (contactCmbBox.SelectedIndex == 5)
                        studentsContacts();
                    else
                        MessageBox.Show("Please Select Employment Status if it's a Regular or Non-Regular", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Button that inputs message in message textbox containing about the weather
        private void weatherBtn_Click_1(object sender, EventArgs e)
        {
            messageTxtBox.Text = "This is VSU Advisory. Classes will be suspended as of "
                              + dateTimePicker1.Text + " because of the Typhoon Please Disseminate. DO NOT REPLY AUTOMATED TEXT.";
             
        }

        //Button that inputs message in message textbox containing about the earthquake
        private void earthquakeBtn_Click_1(object sender, EventArgs e)
        {
            messageTxtBox.Text = "This is VSU Advisory. Classes will be suspended as of "
                              + dateTimePicker1.Text + " because of the Earthquake Please Disseminate. DO NOT REPLY AUTOMATED TEXT.";
        }

        //Button that inputs message in message textbox containing about the faculty meeting
        private void facmeetingBtn_Click_1(object sender, EventArgs e)
        {
            messageTxtBox.Text = "This is VSU Advisory. Classes will be suspended as of "
                              + dateTimePicker1.Text + " because of a Faculty Meeting Please Disseminate. DO NOT REPLY AUTOMATED TEXT.";
        }

        //Button to send the Message
        private void sendButton_Click(object sender, EventArgs e)
        {
            int ctr = 0;
            ctrLabel.Text = "0";
            finalctrLabel.Text = "0";
            Cursor.Current = Cursors.WaitCursor;
            if (cpNumberTxtBox.Text == "")
                MessageBox.Show("Please input a contact number into `Sent To:`");
            try
            {
                label19.Text = "Sending...";
                string[] lines = cpNumberTxtBox.Lines;
                if (lines.GetUpperBound(0) == 0)
                {
                    finalctrLabel.Text = "1";
                    SmsSubmitPdu pdu = new SmsSubmitPdu(messageTxtBox.Text, cpNumberTxtBox.Text, "");
                    comm.SendMessage(pdu);
                    ctr++;
                    ctrLabel.Text = ctr.ToString();
                }
                else
                {
                    finalctrLabel.Text = lines.GetUpperBound(0).ToString();
                    for (int i = 0; i < lines.GetUpperBound(0); i++)
                    {
                        SmsSubmitPdu pdu = new SmsSubmitPdu(messageTxtBox.Text, lines[i], "");
                        comm.SendMessage(pdu);
                        ctr++;
                        ctrLabel.Text = ctr.ToString();
                    }
                }
                MessageBox.Show(this, "Message Sent!", "SUCCESS!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label19.Text = "Message/s Sent!";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Message Sent Failed!: " + ex.Message, "FAILED", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label19.Text = "Message/s Sent Failed!";
            }
        }

        //Button to Clear the inputted Message
        private void clearMessageBtn_Click(object sender, EventArgs e)
        {
            messageTxtBox.Text = "";
        }

        //Button to Clear the inputted contact number
        private void clearCPnumberBtn_Click(object sender, EventArgs e)
        {
            cpNumberTxtBox.Text = "";
        }

        //Function that imports the Dept Heads contacts
        private void deptHeadsContacts()
        {
            string sqlall = "Select contact_number from vsu_contacts where position = 1";
            string sql = "Select contact_number from vsu_contacts where position = 1 and ";
            if (deptComboBox.SelectedIndex == 0)
            {
                MySqlCommand cmd = new MySqlCommand(sqlall, con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 1)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 0", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 2)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 1", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 3)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 4)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 3", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 5)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 4", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 6)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 5", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 7)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 6", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 8)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 7", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 9)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 8", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 10)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 9", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 11)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 10", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 12)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 11", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 13)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 12", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 14)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 13", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 15)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 14", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 16)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 15", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 17)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 16", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 18)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 17", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 19)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 18", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 20)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 19", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 21)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 20", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 22)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 21", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 23)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 22", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 24)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 23", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 25)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 24", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 26)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 25", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 27)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 26", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 28)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 27", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 29)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 28", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 30)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 29", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 31)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 30", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
        }

        //Function that imports the Dept Faculties with all Employee Status
        private void allEmpStatusDeptFaculty()
        {
            string sql = "Select contact_number from vsu_contacts where position = 2 and ";
            if (deptComboBox.SelectedIndex == 0)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "Employment_Status = 1 or Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 1)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 0 and Employment_Status = 1 or Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 2)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 1 and Employment_Status = 1 or Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 3)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 2 and Employment_Status = 1 or Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 4)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 3 and Employment_Status = 1 or Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 5)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 4 and Employment_Status = 1 or Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 6)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 5 and Employment_Status = 1 or Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 7)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 6 and Employment_Status = 1 or Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 8)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 7 and Employment_Status = 1 or Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 9)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 8 and Employment_Status = 1 or Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 10)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 9 and Employment_Status = 1 or Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 11)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 10 and Employment_Status = 1 or Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 12)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 11 and Employment_Status = 1 or Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 13)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 12 and Employment_Status = 1 or Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 14)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 13 and Employment_Status = 1 or Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 15)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 14 and Employment_Status = 1 or Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 16)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 15 and Employment_Status = 1 or Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 17)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 16 and Employment_Status = 1 or Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 18)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 17 and Employment_Status = 1 or Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 19)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 18 and Employment_Status = 1 or Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 20)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 19 and Employment_Status = 1 or Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 21)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 20 and Employment_Status = 1 or Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 22)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 21 and Employment_Status = 1 or Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 23)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 22 and Employment_Status = 1 or Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 24)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 23 and Employment_Status = 1 or Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 25)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 24 and Employment_Status = 1 or Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 26)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 25 and Employment_Status = 1 or Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 27)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 26 and Employment_Status = 1 or Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 28)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 27 and Employment_Status = 1 or Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 29)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 28 and Employment_Status = 1 or Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 30)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 29 and Employment_Status = 1 or Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 31)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 30 and Employment_Status = 1 or Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
        }

        ////Function that imports the Dept Faculties with Regular Employee Status
        private void regularEmpStatusDeptFaculty()
        {
            string sql = "Select contact_number from vsu_contacts where position = 2 and ";
            if (deptComboBox.SelectedIndex == 0)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "Employment_Status = 1", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 1)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 0 and Employment_Status = 1", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 2)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 1 and Employment_Status = 1", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 3)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 2 and Employment_Status = 1", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 4)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 3 and Employment_Status = 1", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 5)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 4 and Employment_Status = 1", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 6)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 5 and Employment_Status = 1", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 7)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 6 and Employment_Status = 1", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 8)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 7 and Employment_Status = 1", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 9)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 8 and Employment_Status = 1", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 10)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 9 and Employment_Status = 1", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 11)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 10 and Employment_Status = 1", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 12)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 11 and Employment_Status = 1", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 13)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 12 and Employment_Status = 1", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 14)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 13 and Employment_Status = 1", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 15)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 14 and Employment_Status = 1", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 16)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 15 and Employment_Status = 1", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 17)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 16 and Employment_Status = 1", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 18)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 17 and Employment_Status = 1", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 19)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 18 and Employment_Status = 1", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 20)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 19 and Employment_Status = 1", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 21)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 20 and Employment_Status = 1", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 22)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 21 and Employment_Status = 1", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 23)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 22 and Employment_Status = 1", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 24)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 23 and Employment_Status = 1", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 25)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 24 and Employment_Status = 1", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 26)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 25 and Employment_Status = 1", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 27)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 26 and Employment_Status = 1", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 28)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 27 and Employment_Status = 1", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 29)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 28 and Employment_Status = 1", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 30)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 29 and Employment_Status = 1", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 31)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 30 and Employment_Status = 1", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
        }

        //Function that imports the Dept Faculties with Non Regular Employee Status
        private void nonRegularEmpStatusDeptFaculty()
        {
            string sql = "Select contact_number from vsu_contacts where position = 2 and ";
            if (deptComboBox.SelectedIndex == 0)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 1)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 0 and Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 2)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 1 and Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 3)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 2 and Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 4)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 3 and Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 5)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 4 and Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 6)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 5 and Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 7)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 6 and Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 8)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 7 and Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 9)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 8 and Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 10)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 9 and Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 11)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 10 and Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 12)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 11 and Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 13)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 12 and Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 14)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 13 and Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 15)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 14 and Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 16)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 15 and Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 17)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 16 and Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 18)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 17 and Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 19)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 18 and Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 20)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 19 and Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 21)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 20 and Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 22)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 21 and Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 23)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 22 and Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 24)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 23 and Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 25)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 24 and Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 26)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 25 and Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 27)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 26 and Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 28)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 27 and Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 29)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 28 and Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 30)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 29 and Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 31)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 30 and Employment_Status = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
        }
        
        //Function that imports the Studens contacts
        private void studentsContacts()
        {
            string sqlall = "Select contact_number from vsu_contacts where position = 3";
            string sql = "Select contact_number from vsu_contacts where position = 3 AND ";
            if (deptComboBox.SelectedIndex == 0)
            {
                MySqlCommand cmd = new MySqlCommand(sqlall, con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 1)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 0", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 2)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 1", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 3)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 2", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 4)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 3", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 5)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 4", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 6)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 5", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 7)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 6", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 8)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 7", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 9)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 8", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 10)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 9", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 11)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 10", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 12)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 11", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 13)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 12", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 14)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 13", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 15)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 14", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 16)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 15", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 17)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 16", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 18)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 17", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 19)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 18", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 20)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 19", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 21)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 20", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 22)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 21", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 23)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 22", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 24)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 23", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 25)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 24", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 26)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 25", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 27)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 26", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 28)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 27", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 29)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 28", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 30)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 29", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
            else if (deptComboBox.SelectedIndex == 31)
            {
                MySqlCommand cmd = new MySqlCommand(sql + "DeptID = 30", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                importContacts(dr, cmd);
            }
        }

        //Function that imports the department from the database to the Dept Combo Box
        private void insertDepartment()
        {
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    MySqlCommand cmd = new MySqlCommand("Select Dept from department", con);
                    MySqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        deptComboBox.Items.Add(dr.GetString("Dept"));
                        addConDeptCMB.Items.Add(dr.GetString("Dept"));
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Function that imports the contacts form the database to the CP number Text Box
        private void importContacts(MySqlDataReader dr, MySqlCommand cmd)
        {
            while (dr.Read())
            {
                cpNumberTxtBox.Text += dr.GetString(0) + "\r";
            }
            if (cpNumberTxtBox.Text == "")
            {
                MessageBox.Show("No contacts has been found", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Database Contacts Connected Succesfully!");
            }
            dr.Dispose();
        }

        //Event that gets the message text length in message text box
        private void messageTxtBox_TextChanged(object sender, EventArgs e)
        {
            msgLengthLabel.Text = messageTxtBox.TextLength.ToString();
        }

        //Event that restrict the input to numbers and one '+' sign in CP number Text Box
        private void cpNumberTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '+'))
            {
                e.Handled = true;
            }

            // allow one + sign
            if ((e.KeyChar == '+') && ((sender as TextBox).Text.IndexOf('+') > -1))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region "Read Message Panel"
        //Button to show the Read Message Panel
        private void buttonReadMessagePanel_Click(object sender, EventArgs e)
        {
            addContactClicked = false;
            panelLeft.Height = buttonReadMessagePanel.Height;
            panelLeft.Top = buttonReadMessagePanel.Top;
            if (comConnected)
            {
                readmsg();
                panel2ReadMessage.Show();
                panel1SendMessage.Hide();
                panel3AddContacts.Hide();
            }
            else
            {
                MessageBox.Show("Phone Not Connected Please Connect the phone in Send Message Thank You.", "CHECK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                buttonSendMessagePanel_Click(sender, e);
            }
        }

        //Button that deletes the message of selected index
        private void delBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(this, "Do you really want to Delete this message?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int dg = dataGridView1.CurrentCell.RowIndex;
                    comm.DeleteMessage((int)dataGridView1.Rows[dg].Cells[0].Value, PhoneStorageType.Sim);
                    readmsg();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Button that deletes all the message
        private void delAllBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(this, "Do you really want to Delete All this message?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    comm.DeleteMessages(DeleteScope.All, PhoneStorageType.Sim);
                    readmsg();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Function thats reads all the message
        private void readmsg()
        {
            try
            {
                dataGridView1.Rows.Clear();
                DecodedShortMessage[] messages = comm.ReadMessages(PhoneMessageStatus.All, PhoneStorageType.Sim);
                foreach (DecodedShortMessage message in messages)
                {
                    DisplayMessage(message.Data, message.Index, message.Status);
                }
                this.dataGridView1.Sort(this.dataGridView1.Columns[2], ListSortDirection.Descending);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //function that displays the message in datagridview
        private void DisplayMessage(SmsPdu pdu, int index, PhoneMessageStatus status)
        {
            if (pdu is SmsDeliverPdu)
            {
                SmsDeliverPdu data = (SmsDeliverPdu)pdu;
                var phoneNumber = data.OriginatingAddress;
                var msg = data.UserDataText;
                var date = string.Format("{0:yyyy/MM/dd}", data.SCTimestamp.ToDateTime());
                var time = string.Format("{0:HH:mm:ss}", data.SCTimestamp.ToDateTime());

                string dt = date + " " + time;
                string stat = status.ToString().Remove(0, 8);
                
                try
                {
                    con.Open();
                    if(con.State == ConnectionState.Open)
                    {
                        MySqlCommand cmd = new MySqlCommand("SELECT Surname FROM vsu_contacts WHERE contact_number = " + phoneNumber, con);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                            dataGridView1.Rows.Add(index, stat, dt, dr.GetString("Surname") + "-" + phoneNumber.Remove(0, 10), msg);
                    }
                    con.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "FAILED", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (!phoneNumber.Contains("+63"))
                    dataGridView1.Rows.Add(index, stat, dt, phoneNumber, msg);
            }
        }

        //Event that shows the message when clicking the cell of datagridview
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int dg = dataGridView1.CurrentCell.RowIndex;
            string newLine = Environment.NewLine;
            readMsgTxtBox.Text = "Date & Time: " + dataGridView1.Rows[dg].Cells[2].Value.ToString() + newLine + "Sender: " + dataGridView1.Rows[dg].Cells[3].Value.ToString() + newLine + dataGridView1.Rows[dg].Cells[4].Value.ToString();
        }
        #endregion

        #region "Add Contacts Panel"
        //Button to show the Add Contacts Panel
        private void buttonAddContactsPanel_Click(object sender, EventArgs e)
        {
            addContactClicked = true;
            panelLeft.Height = buttonAddContactsPanel.Height;
            panelLeft.Top = buttonAddContactsPanel.Top;
            panel3AddContacts.Show();
            panel1SendMessage.Hide();
            panel2ReadMessage.Hide();
        }

        //Button that Adds the contact to the server
        private void addButton_Click(object sender, EventArgs e)
        {
            if (fName.Text == "" || lName.Text == "" || positionCmbBox.Text == "" || contactNumTxtBox.Text == "" )
                MessageBox.Show("Please fill-up all the star forms", "Check", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (positionCmbBox.SelectedIndex == 1 && addConDeptCMB.Text == "" || positionCmbBox.SelectedIndex == 2 && addConDeptCMB.Text == "" || positionCmbBox.SelectedIndex == 3 && addConDeptCMB.Text == "")
                MessageBox.Show("Please fill-up all the star forms", "Check", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (contactNumTxtBox.TextLength < 11 || contactNumTxtBox.TextLength == 12)
                MessageBox.Show("Contact Number Invalid, need 11 or 13 digits", "Check", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (contactNumTxtBox.TextLength == 11 && !contactNumTxtBox.Text.StartsWith("09"))
                MessageBox.Show("Contact Number Invalid, 11 digit number starts with 09", "Check", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (contactNumTxtBox.TextLength == 13 && !contactNumTxtBox.Text.StartsWith("+63"))
                MessageBox.Show("Contact Number Invalid, 13 digit number starts with +63", "Check", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else
            {
                try
                {
                    if (contactNumTxtBox.Text.StartsWith("09"))
                    {
                        contactNumTxtBox.Text = "+63" + contactNumTxtBox.Text.Remove(0, 1);
                        MessageBox.Show(contactNumTxtBox.Text);
                    }
                    con.Open();
                    if (con.State == ConnectionState.Open)
                    {
                        MySqlCommand cmd = new MySqlCommand("INSERT INTO vsu_contacts (Surname, Firstname, Middlename, Contact_Number, Position, Employment_Status, DeptID) VALUES ( @Fname,@Lname,@Mname,@Number,@Position,@EmpStatus,@Dept)", con);

                        cmd.Parameters.AddWithValue("@Fname", lName.Text);
                        cmd.Parameters.AddWithValue("@Lname", fName.Text);
                        cmd.Parameters.AddWithValue("@Mname", mName.Text);
                        cmd.Parameters.AddWithValue("@Number", contactNumTxtBox.Text);
                        cmd.Parameters.AddWithValue("@Position", positionCmbBox.SelectedIndex);
                        cmd.Parameters.AddWithValue("@EmpStatus", esCmbBox.SelectedIndex);
                        cmd.Parameters.AddWithValue("@Dept", addConDeptCMB.SelectedIndex) ;
                        int i = cmd.ExecuteNonQuery();
                        if (i != 0)
                            MessageBox.Show(this, "Contact added Successfully!", "Congrats", MessageBoxButtons.OK);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
                addContactsClearBtn_Click(sender, e); 
            }
        }

        //Button that clears the fill-up form in Add Contacts Panel
        private void addContactsClearBtn_Click(object sender, EventArgs e)
        {
            lName.Text = fName.Text = mName.Text = contactNumTxtBox.Text = "";
            positionCmbBox.SelectedIndex = -1;
            esCmbBox.SelectedIndex = -1;
            addConDeptCMB.SelectedIndex = -1;
        }

        //Event that restrict the input to numbers and one '+' sign in Contact Number Text Box
        private void contactNumTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '+'))
            {
                e.Handled = true;
            }

            // allow one + sign
            if ((e.KeyChar == '+') && ((sender as TextBox).Text.IndexOf('+') > -1))
            {
                e.Handled = true;
            }
        }

        //Event that change the Employement Status if the Selected Index match
        private void positionCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (positionCmbBox.SelectedIndex == 3)
            {
                addConDeptCMB.Enabled = true;
                esCmbBox.SelectedIndex = 0;
                esCmbBox.Enabled = false;
            }
            else if (positionCmbBox.SelectedIndex == 1)
            {
                addConDeptCMB.Enabled = true;
                esCmbBox.SelectedIndex = 1;
                esCmbBox.Enabled = false;
            }
            else if (positionCmbBox.SelectedIndex == 2)
            {
                addConDeptCMB.Enabled = true;
                esCmbBox.Enabled = true;
                esCmbBox.SelectedIndex = 1;
            }
            else if (positionCmbBox.SelectedIndex == 0)
            {
                addConDeptCMB.Enabled = false;
                addConDeptCMB.SelectedIndex = 31;
                esCmbBox.Enabled = true;
                esCmbBox.SelectedIndex = 1;
            }
        }

        //Event that restrict the user to choose only the regular and non regular employment status
        private void esCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (positionCmbBox.SelectedIndex == 0 || positionCmbBox.SelectedIndex == 2)
            {
                if (esCmbBox.SelectedIndex == 0)
                {
                    MessageBox.Show("Please choose only Regular or Non-Regular");
                    esCmbBox.SelectedIndex = 1;
                }
            }
        }

        private void addConDeptCMB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (positionCmbBox.SelectedIndex == 1 || positionCmbBox.SelectedIndex == 2 || positionCmbBox.SelectedIndex == 3)
            {
                if (addConDeptCMB.SelectedIndex == 31)
                {
                    MessageBox.Show("ONLY POSITION ADMIN FACULTY CAN SELECT THE NO DEPARTMENT");
                    addConDeptCMB.SelectedIndex = 0;
                }
            }
        }

        //Event timer that check if the form has been filled up
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (fName.Text != "")
                fNameChecker.ForeColor = Color.Green;
            else
                fNameChecker.ForeColor = Color.Red;

            if (lName.Text != "")
                lNameChecker.ForeColor = Color.Green;
            else
                lNameChecker.ForeColor = Color.Red;

            if (positionCmbBox.SelectedIndex != -1)
                positionChecker.ForeColor = Color.Green;
            else
                positionChecker.ForeColor = Color.Red;

            if (esCmbBox.SelectedIndex != -1)
                employmentStatusChecker.ForeColor = Color.Green;
            else
                employmentStatusChecker.ForeColor = Color.Red;

            if (contactNumTxtBox.Text != "")
                ContactNumberChecker.ForeColor = Color.Green;
            else
                ContactNumberChecker.ForeColor = Color.Red;

            if (addConDeptCMB.SelectedIndex != -1)
                departmentChecker.ForeColor = Color.Green;
            else
                departmentChecker.ForeColor = Color.Red;
        }

        //Function that starts and stops the timer of the add contact checker
        private void addContactsCheckerTimer()
        {
            if (addContactClicked)
                timer1.Start();
            else
                timer1.Stop();
        }
        #endregion

        //Button to Log Out
        private void logOutBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (comConnected)
                {
                    Thread.Sleep(3000);
                    comm.Close();
                }
                searchTimer.Stop();
                Menu newform = new Menu();
                this.Dispose();
                this.Close();
                newform.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Function that gets the signal strength
      /*  private void signalStrength()
        {
            try
            {
                if (comm.IsConnected())
                {
                    SignalQualityInfo info = comm.GetSignalQuality();
                    if (info.SignalStrength > 19 && info.SignalStrength < 31)
                    {
                        signalPictureBox1.BackColor = Color.Green;
                        signalPictureBox2.BackColor = Color.Green;
                        signalPictureBox3.BackColor = Color.Green;
                        signalPictureBox4.BackColor = Color.Green;
                        signalPictureBox1.Visible = true;
                        signalPictureBox2.Visible = true;
                        signalPictureBox3.Visible = true;
                        signalPictureBox4.Visible = true;
                    }

                    else if (info.SignalStrength > 12)
                    {
                        signalPictureBox1.BackColor = Color.Yellow;
                        signalPictureBox2.BackColor = Color.Yellow;
                        signalPictureBox3.BackColor = Color.Yellow;
                        signalPictureBox1.Visible = true;
                        signalPictureBox2.Visible = true;
                        signalPictureBox3.Visible = true;
                        signalPictureBox4.Visible = false;
                    }
                    else if (info.SignalStrength > 9)
                    {
                        signalPictureBox1.BackColor = Color.OrangeRed;
                        signalPictureBox2.BackColor = Color.OrangeRed;
                        signalPictureBox1.Visible = true;
                        signalPictureBox2.Visible = true;
                        signalPictureBox3.Visible = false;
                        signalPictureBox4.Visible = false;
                    }

                    else if (info.SignalStrength > 1)
                    {
                        signalPictureBox1.BackColor = Color.Red;
                        signalPictureBox1.Visible = true;
                        signalPictureBox2.Visible = false;
                        signalPictureBox3.Visible = false;
                        signalPictureBox4.Visible = false;
                    }
                    else
                    {
                        signalPictureBox1.Visible = false;
                        signalPictureBox2.Visible = false;
                        signalPictureBox3.Visible = false;
                        signalPictureBox4.Visible = false;
                    }
                }
            }
           catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/

        //Functions that Enabling the buttons
        public void EnableButtons()
        {
            cpNumberTxtBox.Enabled = true;
            clearCPnumberBtn.Enabled = true;
            clearMessageBtn.Enabled = true;
            weatherBtn.Enabled = true;
            earthquakeBtn.Enabled = true;
            facmeetingBtn.Enabled = true;
            messageTxtBox.Enabled = true;
            clearMessageBtn.Enabled = true;
            contactCmbBox.Enabled = true;
            customAnn1Button.Enabled = true;
            customAnn2Button.Enabled = true;
            customAnn3Button.Enabled = true;
        }

        //Functions that Disabling the buttons
        public void DisableButtons()
        {
            sendButton.Enabled = false;
            cpNumberTxtBox.Enabled = false;
            clearCPnumberBtn.Enabled = false;
            clearMessageBtn.Enabled = false;
            weatherBtn.Enabled = false;
            earthquakeBtn.Enabled = false;
            facmeetingBtn.Enabled = false;
            messageTxtBox.Enabled = false;
            clearMessageBtn.Enabled = false;
            contactCmbBox.Enabled = false;
            customAnn1Button.Enabled = false;
            customAnn2Button.Enabled = false;
            customAnn3Button.Enabled = false;
        }

        private void addNewDeptButton_Click(object sender, EventArgs e)
        {
            AddNewDepartment addDept = new AddNewDepartment();
            addDept.Show();
        }

        private void customAnn1Button_Click(object sender, EventArgs e)
        {
            Add_Custom_Announcement aca = new Add_Custom_Announcement();
            aca.Show();
            aca.annLabel1.Visible = true;
            aca.annLabel2.Visible = false;
            aca.annLabel3.Visible = false;
            try
            {
                con.Open();
                if(con.State == ConnectionState.Open)
                {
                    MySqlCommand cmd = new MySqlCommand("Select announcement_text FROM custom_default_announcement where ID = 1", con);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                        aca.annTextbox1.Text = dr.GetString("announcement_text");
                }
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Database Failed to Open: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void customAnn2Button_Click(object sender, EventArgs e)
        {
            Add_Custom_Announcement aca = new Add_Custom_Announcement();
            aca.Show();
            aca.annLabel1.Visible = false;
            aca.annLabel2.Visible = true;
            aca.annLabel3.Visible = false;
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    MySqlCommand cmd = new MySqlCommand("Select announcement_text FROM custom_default_announcement where ID = 2", con);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                        aca.annTextbox1.Text = dr.GetString("announcement_text");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Failed to Open: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void customAnn3Button_Click(object sender, EventArgs e)
        {
            Add_Custom_Announcement aca = new Add_Custom_Announcement();
            aca.Show();
            aca.annLabel1.Visible = false;
            aca.annLabel2.Visible = false;
            aca.annLabel3.Visible = true;
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    MySqlCommand cmd = new MySqlCommand("Select announcement_text FROM custom_default_announcement where ID = 3", con);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                        aca.annTextbox1.Text = dr.GetString("announcement_text");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Failed to Open: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
