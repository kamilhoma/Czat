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
            this.grpUserList = new System.Windows.Forms.GroupBox();
            this.usersOnline = new System.Windows.Forms.ListBox();
            this.grpWiadomosci = new System.Windows.Forms.GroupBox();
            this.btnWyslij = new System.Windows.Forms.Button();
            this.textBoxWiadomosc = new System.Windows.Forms.TextBox();
            this.rtbOknoRozmowy = new System.Windows.Forms.RichTextBox();
            this.grpUserList.SuspendLayout();
            this.grpWiadomosci.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpUserList
            // 
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
            this.usersOnline.Size = new System.Drawing.Size(127, 264);
            this.usersOnline.TabIndex = 0;
            // 
            // grpWiadomosci
            // 
            this.grpWiadomosci.Controls.Add(this.btnWyslij);
            this.grpWiadomosci.Controls.Add(this.textBoxWiadomosc);
            this.grpWiadomosci.Controls.Add(this.rtbOknoRozmowy);
            this.grpWiadomosci.Location = new System.Drawing.Point(12, 12);
            this.grpWiadomosci.Name = "grpWiadomosci";
            this.grpWiadomosci.Size = new System.Drawing.Size(516, 296);
            this.grpWiadomosci.TabIndex = 3;
            this.grpWiadomosci.TabStop = false;
            this.grpWiadomosci.Text = "Wiadomości";
            // 
            // btnWyslij
            // 
            this.btnWyslij.Location = new System.Drawing.Point(435, 235);
            this.btnWyslij.Name = "btnWyslij";
            this.btnWyslij.Size = new System.Drawing.Size(75, 55);
            this.btnWyslij.TabIndex = 2;
            this.btnWyslij.Text = "&Wyślij";
            this.btnWyslij.UseVisualStyleBackColor = true;
            this.btnWyslij.Click += new System.EventHandler(this.btnWyslij_Click);
            // 
            // textBoxWiadomosc
            // 
            this.textBoxWiadomosc.Location = new System.Drawing.Point(9, 235);
            this.textBoxWiadomosc.Multiline = true;
            this.textBoxWiadomosc.Name = "textBoxWiadomosc";
            this.textBoxWiadomosc.Size = new System.Drawing.Size(408, 55);
            this.textBoxWiadomosc.TabIndex = 1;
            // 
            // rtbOknoRozmowy
            // 
            this.rtbOknoRozmowy.Location = new System.Drawing.Point(9, 33);
            this.rtbOknoRozmowy.Name = "rtbOknoRozmowy";
            this.rtbOknoRozmowy.ReadOnly = true;
            this.rtbOknoRozmowy.Size = new System.Drawing.Size(501, 190);
            this.rtbOknoRozmowy.TabIndex = 0;
            this.rtbOknoRozmowy.Text = "";
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 312);
            this.Controls.Add(this.grpUserList);
            this.Controls.Add(this.grpWiadomosci);
            this.Name = "Chat";
            this.Text = "Czat";
            this.grpUserList.ResumeLayout(false);
            this.grpWiadomosci.ResumeLayout(false);
            this.grpWiadomosci.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpUserList;
        private System.Windows.Forms.ListBox usersOnline;
        private System.Windows.Forms.GroupBox grpWiadomosci;
        private System.Windows.Forms.Button btnWyslij;
        private System.Windows.Forms.TextBox textBoxWiadomosc;
        private System.Windows.Forms.RichTextBox rtbOknoRozmowy;
    }
}