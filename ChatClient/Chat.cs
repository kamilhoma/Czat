using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class Chat : Form
    {
        public Chat(string userName)
        {
            InitializeComponent();
            label1.Text = userName;
            updateChat();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();

            timer2.Tick += new EventHandler(timer2_Tick);
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            updateChat();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string q1 = "select data from Messages join Users on Messages.user_id = Users.Id where login = '" + label1.Text + "';";
                SqlCommand com1 = new SqlCommand(q1, connection);

                connection.Open();
                using (SqlDataReader reader = com1.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var data = reader["data"];
                        if (DateTime.Now - (DateTime)data > TimeSpan.FromMinutes(10))
                        {
                            logout();
                            MessageBox.Show("Zostałeś wylogowany z powodu nieaktywnosci.");
                            this.Close();
                        }
                    }
                }
                connection.Close();
            }
        }

        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\projekty\Repos\Czat\ChatServer\Database.mdf;Integrated Security=True";

        private void btnWyslij_Click(object sender, EventArgs e)
        {
            sendMsg();
        }

        private void sendMsg()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string q1 = "insert into Messages(user_id, tresc, data) VALUES((select Id from Users where login = '" + label1.Text + "'),'" + textBoxWiadomosc.Text + "',CAST('" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "' as datetime2));";
                string q2 = "select top 25 * from Messages";
                SqlCommand com1 = new SqlCommand(q1, connection);
                SqlCommand com2 = new SqlCommand(q2, connection);

                connection.Open();
                com1.ExecuteNonQuery();
                com2.ExecuteNonQuery();
                connection.Close();
                textBoxWiadomosc.Text = "";
                updateMessages();
            }
        }

        private void getOnlineUsers()
        {
            usersOnline.Items.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string q1 = "select login, kolor from users where online = 1";
                SqlCommand com1 = new SqlCommand(q1, connection);

                using (SqlDataReader reader = com1.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var myString = reader["login"].ToString();
                        var color = reader["kolor"].ToString();
                        usersOnline.Items.Add(myString);

                    }
                }
                connection.Close();
            }
        }

        private void updateMessages()
        {
            messagesList.Items.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string q1 = "select data, login, tresc from( select top 25 Messages.Id, data, login, tresc from Messages join Users on Messages.user_id = Users.Id ORDER BY Messages.data desc) as a order by a.Id asc";
                SqlCommand com1 = new SqlCommand(q1, connection);
                connection.Open();
                using (SqlDataReader reader = com1.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateTime data = (DateTime)reader["data"];
                        var myString = data.ToString("dd-MM-yyyy HH:MM:ss") + "   " + reader["login"].ToString() + " :  " + reader["tresc"].ToString();
                        List<string> wiadomosci = new List<string>();
                        wiadomosci.Add(myString);
                        wiadomosci.Reverse();
                        foreach (var item in wiadomosci)
                        {
                            messagesList.Items.Add(item);
                        }
                    }
                    
                }
                connection.Close();
            }
        }

        private void updateChat()
        {
            updateMessages();
            getOnlineUsers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            logout();
            this.Close();
        }

        private void logout()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string q1 = "update Users set online = 0 where login = '" + label1.Text + "';";
                string q2 = "INSERT into Logs(user_id,data,zdarzenie) VALUES ((select Id from Users where login = '" + label1.Text + "'), CAST('" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "' as datetime2), 'logout');";
                SqlCommand com1 = new SqlCommand(q1, connection);
                SqlCommand com2 = new SqlCommand(q2, connection);

                connection.Open();
                com1.ExecuteNonQuery();
                com2.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void textBoxWiadomosc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                sendMsg();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            logout();
        }
    }
}
