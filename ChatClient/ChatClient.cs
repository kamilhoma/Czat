using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using System.ServiceModel.Channels;

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
            if (!string.IsNullOrEmpty(txtUserName.Text.Trim()))
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
                    status.Offline += new EventHandler(Offline);
                    status.Online += new EventHandler(Online);                    
                    channel.Open();                    
                    channel.Join(this.userName);
                    grpWiadomosci.Enabled = true;
                    grpUserList.Enabled = true;                    
                    grpLogowanie.Enabled = false;                    
                    this.AcceptButton = btnWyslij;
                    rtbWiadomosci.AppendText("***************************** Dzie� dobry! *****************************\r\n");
                    txtWyslijWiadomosc.Select();
                    txtWyslijWiadomosc.Focus();
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
                rtbWiadomosci.AppendText("\r\n");
                rtbWiadomosci.AppendText(name + " opu�ci� czat o " + DateTime.Now.ToString());
                listaUserList.Items.Remove(name);
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
                listaUserList.Items.Add(name);
            }
            rtbWiadomosci.AppendText("\r\n");
            rtbWiadomosci.AppendText(name + " m�wi: " + message);
        }

        void ChatClient_NewJoin(string name)
        {
            rtbWiadomosci.AppendText("\r\n");
            rtbWiadomosci.AppendText(name + " do��czy�/a o [" + DateTime.Now.ToString() + "]");            
            listaUserList.Items.Add(name);       
        }

        void Online(object sender, EventArgs e)
        {            
            rtbWiadomosci.AppendText("\r\nOnline: " + this.userName);
        }

        void Offline(object sender, EventArgs e)
        {
            rtbWiadomosci.AppendText("\r\nOffline: " + this.userName);
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
            channel.SendMessage(this.userName, txtWyslijWiadomosc.Text.Trim());
            txtWyslijWiadomosc.Clear();
            txtWyslijWiadomosc.Select();
            txtWyslijWiadomosc.Focus();
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
    }
}