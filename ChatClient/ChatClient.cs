using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.IO;

namespace ChatClient
{
    [ServiceContract(CallbackContract = typeof(IChatService))]
    public interface IChatService
    {
        [OperationContract(IsOneWay = true)]
        void Join(string memberName);
        [OperationContract(IsOneWay = true)]
        void Leave(string memberName);
        [OperationContract(IsOneWay = true)]
        void SendMessage(string memberName, string message);
    }

    public interface IChatChannel : IChatService, IClientChannel
    {
    }

    public partial class ChatClient : Form, IChatService
    {
        private delegate void UserJoined(string name);
        private delegate void UserSendMessage(string name, string message);
        private delegate void UserLeft(string name);

        private static event UserJoined NewJoin;
        private static event UserSendMessage MessageSent;
        private static event UserLeft RemoveUser;
                
        private string userName;
        private IChatChannel channel;
        private DuplexChannelFactory<IChatChannel> factory;


        public ChatClient()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin;
        }

        public ChatClient(string userName)
        {
            this.userName = userName;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserName.Text.Trim()) && !checkUsersFromList(txtUserName.Text))
            {
                try
                {
                    NewJoin += new UserJoined(ChatClient_NewJoin);
                    MessageSent += new UserSendMessage(ChatClient_MessageSent);
                    RemoveUser += new UserLeft(ChatClient_RemoveUser);

                    channel = null;
                    this.userName = txtUserName.Text.Trim();
                    InstanceContext context = new InstanceContext(
                        new ChatClient(txtUserName.Text.Trim()));
                    factory =
                        new DuplexChannelFactory<IChatChannel>(context, "ChatEndPoint");
                    channel = factory.CreateChannel();
                    IOnlineStatus status = channel.GetProperty<IOnlineStatus>();

                    //status.Offline += new EventHandler(Offline);
                    //status.Online += new EventHandler(Online);                    
                    channel.Open();                  
                    channel.Join(this.userName);
                    grpWiadomosci.Enabled = true;
                    grpUserList.Enabled = true;                    
                    grpLogowanie.Enabled = false;                    
                    this.AcceptButton = btnWyslij;
                    rtbOknoRozmowy.AppendText("***************************** Dzieñ dobry! *****************************\r\n");
                    textBoxWiadomosc.Select();
                    textBoxWiadomosc.Focus();
                    AddToUserList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        void ChatClient_RemoveUser(string name)
        {
            try
            {
                rtbOknoRozmowy.AppendText("\r\n");
                rtbOknoRozmowy.AppendText(name + " opuœci³ czat o " + DateTime.Now.ToString());
                listaUserList.Items.Remove(name);
                RemoveFromUserList(name);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.ToString());
            }
        }

        void ChatClient_MessageSent(string name, string message)
        {
            if (!listaUserList.Items.Contains(name))
            {
                //listaUserList.Items.Add(name);
                ReadUserList();
            }
            rtbOknoRozmowy.AppendText("\r\n");
            rtbOknoRozmowy.AppendText(name + " mówi: " + message);
        }

        void ChatClient_NewJoin(string name)
        {
            rtbOknoRozmowy.AppendText("\r\n");
            rtbOknoRozmowy.AppendText(name + " do³¹czy³/a o [" + DateTime.Now.ToString() + "]");
            //listaUserList.Items.Add(name);
            ReadUserList();
        }

        void Online(object sender, EventArgs e)
        {            
            rtbOknoRozmowy.AppendText("\r\nOnline: " + this.userName);
        }

        void Offline(object sender, EventArgs e)
        {
            rtbOknoRozmowy.AppendText("\r\nOffline: " + this.userName);
        }

        #region IChatService Members

        public void Join(string memberName)
        {            
            if (NewJoin != null)
            {
                NewJoin(memberName);
            }
        }

        public new void Leave(string memberName)
        {
            if (RemoveUser != null)
            {
                RemoveUser(memberName);
            }
        }

        public void SendMessage(string memberName, string message)
        {
            if (MessageSent != null)
            {
                MessageSent(memberName, message);
            }
        }

        #endregion

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (textBoxWiadomosc.TextLength > 0)
            {
                channel.SendMessage(this.userName, textBoxWiadomosc.Text.Trim());
            }
            textBoxWiadomosc.Clear();
            textBoxWiadomosc.Select();
            textBoxWiadomosc.Focus();
        }

        private void ChatClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (channel != null)
                {
                    channel.Leave(this.userName);
                    channel.Close();
                }
                if (factory != null)
                {
                    factory.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void ReadUserList()
        {
            int counter = 0;
            string line;
            listaUserList.Items.Clear();

            System.IO.StreamReader file =
               new System.IO.StreamReader(@"C:\Users\kamil\Desktop\s\userlist.txt");
            while ((line = file.ReadLine()) != null)
            {
                listaUserList.Items.Add(line);
                counter++;
            }

            file.Close();
        }

        public void AddToUserList()
        {
            StreamWriter file = File.AppendText(@"C:\Users\kamil\Desktop\s\userlist.txt");
            file.WriteLine(userName);
            file.Close();
        }

        public void RemoveFromUserList(string strLineToDelete)
        {
            string strFilePath = @"C:\Users\kamil\Desktop\s\userlist.txt";
            string strSearchText = strLineToDelete;
            string strOldText;
            string n = "";
            StreamReader sr = File.OpenText(strFilePath);
            while ((strOldText = sr.ReadLine()) != null)
            {
                if (!strOldText.Contains(strSearchText))
                {
                    n += strOldText + Environment.NewLine;
                }
            }
            sr.Close();
            File.WriteAllText(strFilePath, n);
        }

        public bool checkUsersFromList(string username)
        {
            string strFilePath = @"C:\Users\kamil\Desktop\s\userlist.txt";
            string strSearchText = username;
            string strOldText;
            StreamReader sr = File.OpenText(strFilePath);
            while ((strOldText = sr.ReadLine()) != null)
            {
                if (strOldText.Contains(strSearchText))
                {
                    MessageBox.Show("Nazwa uzytkownika jest zajêta.\nWybierz inn¹.");
                    return true;
                }
            }
            sr.Close();

            return false;
        }
    }
}