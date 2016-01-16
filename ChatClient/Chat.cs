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
            
            getOnlineUsers();
        }

        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\projekty\Repos\Czat\ChatServer\Database.mdf;Integrated Security=True";

        private void getOnlineUsers()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string q1 = "select login from users where online = 1";
                SqlCommand com1 = new SqlCommand(q1, connection);

                using (SqlDataReader reader = com1.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var myString = reader["login"].ToString(); ;
                        usersOnline.Items.Add(myString);
                    }
                }

                connection.Close();
            }
        }

        private void btnWyslij_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //string q1 = "insert into Messages(user id, tresc, data) VALUES('" + userName + "','" + textBoxWiadomosc.Text + "','" + DateTime.Now.ToString("ddMMyyyy HH:MM:SS");
                string q2 = "select top 25 * from Messages";
                
                connection.Open();
                // Do stuff here
                connection.Close();
            }
        }
    }
}
