namespace ChatClient
{
    partial class Chat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grpUserList = new System.Windows.Forms.GroupBox();
            this.usersOnline = new System.Windows.Forms.ListBox();
            this.grpWiadomosci = new System.Windows.Forms.GroupBox();
            this.messagesList = new System.Windows.Forms.ListBox();
            this.btnWyslij = new System.Windows.Forms.Button();
            this.textBoxWiadomosc = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.grpUserList.SuspendLayout();
            this.grpWiadomosci.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpUserList
            // 
            this.grpUserList.Controls.Add(this.button1);
            this.grpUserList.Controls.Add(this.usersOnline);
            this.grpUserList.Location = new System.Drawing.Point(571, 12);
            this.grpUserList.Name = "grpUserList";
            this.grpUserList.Size = new System.Drawing.Size(149, 296);
            this.grpUserList.TabIndex = 4;
            this.grpUserList.TabStop = false;
            this.grpUserList.Text = "Użytkownicy online";
            // 
            // usersOnline
            // 
            this.usersOnline.FormattingEnabled = true;
            this.usersOnline.Location = new System.Drawing.Point(16, 19);
            this.usersOnline.Name = "usersOnline";
            this.usersOnline.Size = new System.Drawing.Size(127, 238);
            this.usersOnline.TabIndex = 0;
            // 
            // grpWiadomosci
            // 
            this.grpWiadomosci.Controls.Add(this.messagesList);
            this.grpWiadomosci.Controls.Add(this.btnWyslij);
            this.grpWiadomosci.Controls.Add(this.textBoxWiadomosc);
            this.grpWiadomosci.Location = new System.Drawing.Point(12, 12);
            this.grpWiadomosci.Name = "grpWiadomosci";
            this.grpWiadomosci.Size = new System.Drawing.Size(516, 296);
            this.grpWiadomosci.TabIndex = 3;
            this.grpWiadomosci.TabStop = false;
            this.grpWiadomosci.Text = "Wiadomości";
            // 
            // messagesList
            // 
            this.messagesList.FormattingEnabled = true;
            this.messagesList.Location = new System.Drawing.Point(9, 27);
            this.messagesList.Name = "messagesList";
            this.messagesList.Size = new System.Drawing.Size(501, 225);
            this.messagesList.TabIndex = 3;
            // 
            // btnWyslij
            // 
            this.btnWyslij.Location = new System.Drawing.Point(437, 265);
            this.btnWyslij.Name = "btnWyslij";
            this.btnWyslij.Size = new System.Drawing.Size(75, 22);
            this.btnWyslij.TabIndex = 2;
            this.btnWyslij.Text = "&Wyślij";
            this.btnWyslij.UseVisualStyleBackColor = true;
            this.btnWyslij.Click += new System.EventHandler(this.btnWyslij_Click);
            // 
            // textBoxWiadomosc
            // 
            this.textBoxWiadomosc.Location = new System.Drawing.Point(9, 266);
            this.textBoxWiadomosc.Name = "textBoxWiadomosc";
            this.textBoxWiadomosc.Size = new System.Drawing.Size(422, 20);
            this.textBoxWiadomosc.TabIndex = 1;
            this.textBoxWiadomosc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxWiadomosc_KeyPress);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(530, 290);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 264);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Wyloguj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 600000;
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 312);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grpUserList);
            this.Controls.Add(this.grpWiadomosci);
            this.Name = "Chat";
            this.Text = "Czat";
            this.grpUserList.ResumeLayout(false);
            this.grpWiadomosci.ResumeLayout(false);
            this.grpWiadomosci.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpUserList;
        private System.Windows.Forms.ListBox usersOnline;
        private System.Windows.Forms.GroupBox grpWiadomosci;
        private System.Windows.Forms.Button btnWyslij;
        private System.Windows.Forms.TextBox textBoxWiadomosc;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListBox messagesList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer2;
    }
}