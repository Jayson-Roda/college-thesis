using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Management;
using System.Threading;

namespace ThesisWindowsFormsApplication
{
    class GSMsms
    {
       // private SerialPort gsmPort = null;
        public bool IsDeviceFound { get; set; } = false;
        public string deviceName { get; set; } = "";

        public GSMsms()
        {
            //gsmPort = new SerialPort();
        }

        //This is for Listing the moodem thats been connected in the Laptop
        public GSMcom[] List()
        {
            List<GSMcom> gsmCom = new List<GSMcom>();
            ConnectionOptions options = new ConnectionOptions();
            options.Impersonation = ImpersonationLevel.Impersonate;
            options.EnablePrivileges = true;
            string connString = $@"\\{Environment.MachineName}\root\cimv2";
            ManagementScope scope = new ManagementScope(connString, options);
            scope.Connect();

            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_POTSModem");
            ManagementObjectSearcher search = new ManagementObjectSearcher(scope, query);
            ManagementObjectCollection collection = search.Get();

            foreach (ManagementObject obj in collection)
            {
                string portName = obj["AttachedTo"].ToString();
                string portDescription = obj["Description"].ToString();

                if (portName != "")
                {
                    GSMcom com = new GSMcom();
                    com.Name = portName;
                    com.Description = portDescription;
                    gsmCom.Add(com);
                }
            }

            return gsmCom.ToArray();
        }

        //To search the listed array of GSMcom
        public GSMcom Search()
        {

            IEnumerator enumerator = List().GetEnumerator();
            GSMcom com = enumerator.MoveNext() ? (GSMcom)enumerator.Current : null;

            if (com == null)
            {
                IsDeviceFound = false;
            }
            else
            {
                IsDeviceFound = true;
                deviceName = (com.ToString());
            }
            return com;
        }
    }
}