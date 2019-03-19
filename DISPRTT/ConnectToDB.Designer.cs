namespace DISPRTT
{
    partial class ConnectToDB
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
            this.label = new System.Windows.Forms.Label();
            this.Ok = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.connect = new System.Windows.Forms.Button();
            this.serverName = new System.Windows.Forms.TextBox();
            this.dbName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(16, 59);
            this.label.Margin = new System.Windows.Forms.Padding(10000, 0, 0, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(106, 20);
            this.label.TabIndex = 1;
            this.label.Text = "Имя сервера";
            // 
            // Ok
            // 
            this.Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Ok.Location = new System.Drawing.Point(367, 204);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(81, 36);
            this.Ok.TabIndex = 1;
            this.Ok.Text = "OK";
            this.Ok.UseVisualStyleBackColor = true;
            this.Ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // Cancel
            // 
            this.Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(463, 204);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(81, 36);
            this.Cancel.TabIndex = 3;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // connect
            // 
            this.connect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.connect.Location = new System.Drawing.Point(426, 90);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(118, 34);
            this.connect.TabIndex = 0;
            this.connect.Text = "Соединить";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.ConnectToServer);
            // 
            // serverName
            // 
            this.serverName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serverName.Location = new System.Drawing.Point(214, 56);
            this.serverName.Name = "serverName";
            this.serverName.Size = new System.Drawing.Size(330, 26);
            this.serverName.TabIndex = 6;
            this.serverName.Text = "DESKTOP-33SD3ML\\SQL";
            // 
            // dbName
            // 
            this.dbName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dbName.FormattingEnabled = true;
            this.dbName.Location = new System.Drawing.Point(216, 151);
            this.dbName.Name = "dbName";
            this.dbName.Size = new System.Drawing.Size(330, 28);
            this.dbName.TabIndex = 7;
            this.dbName.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 155);
            this.label1.Margin = new System.Windows.Forms.Padding(10000, 0, 0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Название базы данных";
            this.label1.Visible = false;
            // 
            // ConnectToDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 265);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dbName);
            this.Controls.Add(this.serverName);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ConnectToDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConnectToDB";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.TextBox serverName;
        private System.Windows.Forms.ComboBox dbName;
        private System.Windows.Forms.Label label1;
    }
}