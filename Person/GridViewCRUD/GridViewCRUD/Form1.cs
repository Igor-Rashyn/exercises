using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridViewCRUD
{
    /// <summary>
    /// DataGridView which is connected with server via TCP.
    /// </summary>
    public partial class Form1 : Form
    {
        static string usr;
        static TcpClient client;
        static NetworkStream netStream;
        bool added = false;
        bool change = false;
        string indexRowAdded;
        string indexRowChanged;

        public Form1()
        {
            InitializeComponent();
            Connect("127.0.0.1", 1000);
        }
        /// <summary>
        /// Connection to the server
        /// </summary>
        /// <param name="ip">ip address</param>
        /// <param name="port">port</param>
        private void Connect(string ip, int port)
        {
            client = new TcpClient();
            try
            {
                client.Connect("127.0.0.1", 2000);
                netStream = client.GetStream();
                Thread receiveThread = new Thread(new ParameterizedThreadStart(RecieveFromServer));
                receiveThread.Start();
            }
            catch
            {
                Connect(ip, port);
            }
            SendToServer("<All data>", null);
        }
     
        /// <summary>
        /// Send a request to the server
        /// </summary>
        /// <param name="type"></param>
        /// <param name="req"></param>
       static void SendToServer(string type, string req)
        {
            try
            {
                string message =type + " " + req;
                byte[] toSend = new byte[64];
                toSend = Encoding.ASCII.GetBytes(message);
                netStream.Write(toSend, 0, toSend.Length);
                netStream.Flush();
                for (int i = 0; i < toSend.Length; i++)
                {
                    toSend[i] = 0;
                }
            }
            catch
            {

            }

        }


       #region Methods for adding Person to dataGridView
       /// <summary>
        /// Delegate for adding Person to dataGridView
        /// </summary>
        /// <param name="strArr">Array of data</param>
        /// <param name="n">row number</param>
        /// <param name="k">element number </param>
        private delegate void InvokeDelegate(string[] strArr, int n, int k);
        /// <summary>
        /// Method for adding Man to dataGridView
        /// </summary>
        /// <param name="strArr">Array of data</param>
        /// <param name="n">row number</param>
        /// <param name="k">element number</param>
        private void InvokeMethodMan (string[] strArr, int n, int k)
        {
            this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[n].Cells[0].Value = strArr[k + 1];
            this.dataGridView1.Rows[n].Cells[1].Value = strArr[k + 2];
            this.dataGridView1.Rows[n].Cells[2].Value = strArr[k + 3];
            this.dataGridView1.Rows[n].Cells[3].Value = strArr[k + 4];
            this.dataGridView1.Rows[n].Cells[4].Value = strArr[k + 5];
            this.dataGridView1.Rows[n].Cells[8].Value = true;
        }
        /// <summary>
        /// Method for adding Woman to dataGridView
        /// </summary>
        /// <param name="strArr">Array of data</param>
        /// <param name="n">row number</param>
        /// <param name="k">element number</param>
        private void InvokeMethodWoman(string[] strArr, int n, int k)
        {
            this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[n].Cells[0].Value = strArr[k + 1];
            this.dataGridView1.Rows[n].Cells[1].Value = strArr[k + 2];
            this.dataGridView1.Rows[n].Cells[5].Value = strArr[k + 3];
            this.dataGridView1.Rows[n].Cells[6].Value = strArr[k + 4];
            this.dataGridView1.Rows[n].Cells[7].Value = strArr[k + 5];
            this.dataGridView1.Rows[n].Cells[8].Value = false;
        }
       #endregion

        /// <summary>
        /// Method which  fills the table
        /// </summary>
        /// <param name="response">data from table</param>
        public void FillTable(string response)
        {
            bool done = true;
            string[] strArr = response.Split(',');
            int j = 0;
            int i = 0;
            InvokeDelegate invM = new InvokeDelegate(InvokeMethodMan);
            InvokeDelegate invW = new InvokeDelegate(InvokeMethodWoman);
            while (done)
            {               
                if (Convert.ToString(strArr[j]) == "Person.Man")
                {
                    this.dataGridView1.Invoke(invM, new Object[] {strArr,i,j});
                    i++;
                }
                else if (Convert.ToString(strArr[j]) == "Person.Woman")
                {
                    this.dataGridView1.Invoke(invW, new Object[] { strArr, i, j });
                    i++;
                }
                
                if (j+6> strArr.Length)
                {
                   done = false;
                }
                else
                {
                    j = j + 6;
                }
            }
        }

        /// <summary>
        /// Handling a response from the server
        /// </summary>
        /// <param name="e"></param>
        private void RecieveFromServer(object e)
        {
            byte[] receiveMessage = new byte[64];
            string allmessage = null;
            int bytesRead=64;

            while (bytesRead == receiveMessage.Length)
            {
                try
                {
                    bytesRead = netStream.Read(receiveMessage, 0, receiveMessage.Length);
                    string message = Encoding.ASCII.GetString(receiveMessage);
                    message = message.Replace("\0", string.Empty);
                    allmessage = allmessage + message; 
                }
                catch
                {
                    Disconnect();
                }
            }
            FillTable(allmessage);
        }

        /// <summary>
        /// Method of closing the stream and  the client
        /// </summary>
        static void Disconnect()
        {
            client.Close();//disable client
            netStream.Close();//disable stream
            Environment.Exit(0); //completion of the process
        }

        /// <summary>
        /// Adding row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            added = true;
            indexRowAdded = Convert.ToString(dgv.CurrentRow.Index);
        }
        /// <summary>
        /// Deleting a person in the table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            SendToServer("<Delete>,", (string)dgv.Rows[dgv.CurrentRow.Index].Cells[0].Value);
        }

        /// <summary>
        /// Setting the value of "change"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (change == false && added == false)
            {
                change = true;
                indexRowChanged = Convert.ToString(dgv.CurrentRow.Index);
            }
        }

        /// <summary>
        /// Updating and adding new values in the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            string message=null;
            DataGridView dgv = (DataGridView)sender;
            if (Convert.ToString(dgv.CurrentRow.Index) != indexRowChanged && change == true)
            {
                for (int i = 0; i < 9; i++)
                {
                    message = message + "," + this.dataGridView1.Rows[Convert.ToInt32(indexRowChanged)].Cells[i].Value;
                }
               SendToServer("<Update>", message);
               change = false;
               indexRowChanged = "";
            }
            else if (Convert.ToString(dgv.CurrentRow.Index) != indexRowAdded && added == true)
            {
                for (int i = 0; i < 9; i++)
                {
                    message = message + "," + this.dataGridView1.Rows[Convert.ToInt32(indexRowAdded)].Cells[i].Value;
                }
                SendToServer("<Add>",message);
                added = false;
                indexRowAdded ="";
            }
        }

    }
}
