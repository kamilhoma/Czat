namespace ChatClient
{
    partial class ChatClient
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
            this.grpWiadomosci = new System.Windows.Forms.GroupBox();
            this.btnWyslij = new System.Windows.Forms.Button();
            this.txtWyslijWiadomosc = new System.Windows.Forms.TextBox();
            this.rtbWiadomosci = new System.Windows.Forms.RichTextBox();
            this.grpLogowanie = new System.Windows.Forms.GroupBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblLoginName = new System.Windows.Forms.Label();
            this.grpUserList = new System.Windows.Forms.GroupBox();
            this.listaUserList = new System.Windows.Forms.ListBox();
            this.grpWiadomosci.SuspendLayout();
            this.grpLogowanie.SuspendLayout();
            this.grpUserList.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpWiadomosci
            // 
            this.grpWiadomosci.Controls.Add(this.btnWyslij);
            this.grpWiadomosci.Controls.Add(this.txtWyslijWiadomosc);
            this.grpWiadomosci.Controls.Add(this.rtbWiadomosci);
            this.grpWiadomosci.Enabled = false;
            this.grpWiadomosci.Location = new System.Drawing.Point(12, 71);
            this.grpWiadomosci.Name = "grpWiadomosci";
            this.grpWiadomosci.Size = new System.Drawing.Size(516, 296);
            this.grpWiadomosci.TabIndex = 0;
            this.grpWiadomosci.TabStop = false;
            this.grpWiadomosci.Text = "Wiadomoœci";
            // 
            // btnWyslij
            // 
            this.btnWyslij.Location = new System.Drawing.Point(435, 235);
            this.btnWyslij.Name = "btnWyslij";
            this.btnWyslij.Size = new System.Drawing.Size(75, 55);
            this.btnWyslij.TabIndex = 2;
            this.btnWyslij.Text = "&Wyœlij";
            this.btnWyslij.UseVisualStyleBackColor = true;
            this.btnWyslij.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtWyslijWiadomosc
            // 
            this.txtWyslijWiadomosc.Location = new System.Drawing.Point(9, 235);
            this.txtWyslijWiadomosc.Multiline = true;
            this.txtWyslijWiadomosc.Name = "txtWyslijWiadomosc";
            this.txtWyslijWiadomosc.Size = new System.Drawing.Size(408, 55);
            this.txtWyslijWiadomosc.TabIndex = 1;
            // 
            // rtbWiadomosci
            // 
            this.rtbWiadomosci.Location = new System.Drawing.Point(9, 33);
            this.rtbWiadomosci.Name = "rtbWiadomosci";
            this.rtbWiadomosci.ReadOnly = true;
            this.rtbWiadomosci.Size = new System.Drawing.Size(501, 190);
            this.rtbWiadomosci.TabIndex = 0;
            this.rtbWiadomosci.Text = "";
            // 
            // grpLogowanie
            // 
            this.grpLogowanie.Controls.Add(this.btnLogin);
            this.grpLogowanie.Controls.Add(this.txtUserName);
            this.grpLogowanie.Controls.Add(this.lblLoginName);
            this.grpLogowanie.Location = new System.Drawing.Point(12, 25);
            this.grpLogowanie.Name = "grpLogowanie";
            this.grpLogowanie.Size = new System.Drawing.Size(339, 40);
            this.grpLogowanie.TabIndex = 1;
            this.grpLogowanie.TabStop = false;
            this.grpLogowanie.Text = "Logowanie";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(258, 11);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "&Zaloguj";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(77, 12);
            this.txtUserName.MaxLength = 10;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(158, 20);
            this.txtUserName.TabIndex = 1;
            // 
            // lblLoginName
            // 
            this.lblLoginName.AutoSize = true;
            this.lblLoginName.Location = new System.Drawing.Point(6, 16);
            this.lblLoginName.Name = "lblLoginName";
            this.lblLoginName.Size = new System.Drawing.Size(102, 13);
            this.lblLoginName.TabIndex = 0;
            this.lblLoginName.Text = "Nazwa u¿ytkownika";
            // 
            // grpUserList
            // 
            this.grpUserList.Controls.Add(this.listaUserList);
            this.grpUserList.Enabled = false;
            this.grpUserList.Location = new System.Drawing.Point(571, 71);
            this.grpUserList.Name = "grpUserList";
            this.grpUserList.Size = new System.Drawing.Size(149, 296);
            this.grpUserList.TabIndex = 2;
            this.grpUserList.TabStop = false;
            this.grpUserList.Text = "U¿ytkownicy online";
            // 
            // listaUserList
            // 
            this.listaUserList.FormattingEnabled = true;
            this.listaUserList.Location = new System.Drawing.Point(16, 19);
            this.listaUserList.Name = "listaUserList";
            this.listaUserList.Size = new System.Drawing.Size(127, 264);
            this.listaUserList.TabIndex = 0;
            // 
            // ChatClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 398);
            this.Controls.Add(this.grpUserList);
            this.Controls.Add(this.grpLogowanie);
            this.Controls.Add(this.grpWiadomosci);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ChatClient";
            this.Text = "ChatClient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatClient_FormClosing);
            this.grpWiadomosci.ResumeLayout(false);
            this.grpWiadomosci.PerformLayout();
            this.grpLogowanie.ResumeLayout(false);
            this.grpLogowanie.PerformLayout();
            this.grpUserList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpWiadomosci;
        private System.Windows.Forms.GroupBox grpLogowanie;
        private System.Windows.Forms.GroupBox grpUserList;
        private System.Windows.Forms.Label lblLoginName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.RichTextBox rtbWiadomosci;
        private System.Windows.Forms.Button btnWyslij;
        private System.Windows.Forms.TextBox txtWyslijWiadomosc;
        private System.Windows.Forms.ListBox listaUserList;
    }
}

