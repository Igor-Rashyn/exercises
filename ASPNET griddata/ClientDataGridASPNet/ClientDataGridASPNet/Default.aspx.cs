using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientDataGridASPNet
{
    public partial class _Default : Page
    {
       static bool loaded;
       //static DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if(!Page.IsPostBack)
            {
                Connect("127.0.0.1", 1000);
                loaded = true;

            }
        }

        static TcpClient client;
        static NetworkStream netStream;
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
                client.Connect("127.0.0.1", 1000);
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
                string message = type + " " + req;
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
        /// <summary>
        /// Handling a response from the server
        /// </summary>
        /// <param name="e"></param>
        private void RecieveFromServer(object e)
        {
            byte[] receiveMessage = new byte[64];
            string allmessage = null;
            int bytesRead = 64;

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
            BindToData(allmessage);
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
        public void BindToData(string response)
        {
            bool done = true;
            string[] strArr = response.Split(',');
            DataTable dt = new DataTable("Table");
            
            int i = 0;
            DataRow dr = null;
            dt.Columns.Add("ID", System.Type.GetType("System.String"));
            dt.Columns.Add("Name", System.Type.GetType("System.String"));
            dt.Columns.Add("Strength", System.Type.GetType("System.String"));
            dt.Columns.Add("Age", System.Type.GetType("System.String"));
            dt.Columns.Add("Stamina", System.Type.GetType("System.String"));
            dt.Columns.Add("Beauty", System.Type.GetType("System.String"));
            dt.Columns.Add("EyeColor", System.Type.GetType("System.String"));
            dt.Columns.Add("Smile", System.Type.GetType("System.String"));
            dt.Columns.Add("Gender",System.Type.GetType("System.String"));
            while (done)
            {
                dr = dt.NewRow();
                if (strArr[i] == "Person.Man")
                {
                  dr["ID"] = strArr[i + 1];
                  dr["Name"] = strArr[i + 2];
                  dr["Strength"] = strArr[i + 3];
                  dr["Age"] = strArr[i + 4];
                  dr["Stamina"] = strArr[i + 5];
                  dr["Beauty"] = "";
                  dr["EyeColor"] = "";
                  dr["Smile"] = "";
                  dr["Gender"] = strArr[i].Replace("Person.", string.Empty);
                  dt.Rows.Add(dr);
                }
                else if (strArr[i] == "Person.Woman")
                {
                  dr["ID"] = strArr[i + 1];
                  dr["Name"] = strArr[i + 2];
                  dr["Strength"] = "";
                  dr["Age"] = "";
                  dr["Stamina"] = "";
                  dr["Beauty"] = strArr[i + 3];
                  dr["EyeColor"] = strArr[i + 4];
                  dr["Smile"] = strArr[i + 5];
                  dr["Gender"] = strArr[i].Replace("Person.", string.Empty);
                  dt.Rows.Add(dr);
                }
               

                if (i + 6 > strArr.Length)
                {
                    done = false;
                }
                else
                {
                    i = i + 6;
                }

            }
            dt.AcceptChanges();
            GridView1.DataSource = dt;
            Session["Table"] = dt;
            GridView1.DataBind();
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridView gv = (GridView)sender;
            DataTable dt = (DataTable)Session["Table"];
            if (e.CommandName == "Delete")
            {
                // get the categoryID of the clicked row
                int categoryID = Convert.ToInt32(e.CommandArgument);
                dt.Rows.RemoveAt(categoryID);
                SendToServer("<Delete>,", (string)gv.Rows[categoryID].Cells[0].Text);
                GridView1.DeleteRow(categoryID);
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridView1.DataSource = Session["Table"];
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataSource = Session["Table"];
            GridView1.DataBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridView gv = (GridView)sender;

            DataTable dt = (DataTable)Session["Table"];

            //Update the values.
            GridViewRow row = gv.Rows[e.RowIndex];
            dt.Rows[row.DataItemIndex]["ID"] = ((TextBox)(row.Cells[0].Controls[0])).Text;
            dt.Rows[row.DataItemIndex]["Name"] = ((TextBox)(row.Cells[1].Controls[0])).Text;
            dt.Rows[row.DataItemIndex]["Strength"] = ((TextBox)(row.Cells[2].Controls[0])).Text;
            dt.Rows[row.DataItemIndex]["Age"] = ((TextBox)(row.Cells[3].Controls[0])).Text;
            dt.Rows[row.DataItemIndex]["Stamina"] = ((TextBox)(row.Cells[4].Controls[0])).Text;
            dt.Rows[row.DataItemIndex]["Beauty"] = ((TextBox)(row.Cells[5].Controls[0])).Text;
            dt.Rows[row.DataItemIndex]["EyeColor"] = ((TextBox)(row.Cells[6].Controls[0])).Text;
            dt.Rows[row.DataItemIndex]["Smile"] = ((TextBox)(row.Cells[7].Controls[0])).Text;
            dt.Rows[row.DataItemIndex]["Gender"] = ((TextBox)(row.Cells[8].Controls[0])).Text;
            //Reset the edit index.
            gv.EditIndex = -1;

            string message = null;
            for (int i = 0; i < 9; i++)
            {
                message = message + "," + ((TextBox)row.Cells[i].Controls[0]).Text;
            }
            Session["Table"] = dt;

            GridView1.DataSource = Session["Table"];
            GridView1.DataBind();
            SendToServer("<Update>", message);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)Session["Table"];
            DataRow dr = dt.NewRow();
            dr[0] = this.TextBoxID.Text;
            dr[1] = this.TextBoxName.Text;
            dr[2] = this.TextBoxStrength.Text;
            dr[3] = this.TextBoxAge.Text;
            dr[4] = this.TextBoxStamina.Text;
            dr[5] = this.TextBoxBeauty.Text;
            dr[6] = this.TextBoxEyeColor.Text;
            dr[7] = this.TextBoxSmile.Text;
            
            if (dr[2]!="")
                dr[8]="Man";
            else
                dr[8]="Woman";

            dt.Rows.Add(dr);

            Session["Table"] = dt;
            GridView1.DataSource = Session["Table"];
            GridView1.DataBind();
            string message = null;
            for (int i = 0; i < 9; i++)
            {
                message = message + "," + dr[i];
            }

            SendToServer("<Add>", message);

        }

   }
}