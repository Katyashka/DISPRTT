using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace DISPRTT
{
    public partial class Form1 : Form
    {
        SupportingTools directory ;
        ConnectToDB connectTo;

        public Form1()
        {
            InitializeComponent();
        }

        private void OpenDirectory_Click(object sender, EventArgs e)
        {
            if(Requests.R_sqlConnection==null)
            {
                MessageBox.Show("Вы не подключены к серверу");
                return;
            }
            if (directory != null && !directory.IsDisposed)
                return;

            directory = new SupportingTools
            {
                MdiParent = this
            };
            //dd
            directory.Show();
        }

        private void ShowConnectToDB(object sender, EventArgs e)
        {
            connectTo = new ConnectToDB();
            connectTo.ShowDialog();
        }

        private void ShowSubjects(object sender, EventArgs e)
        {
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Requests.R_sqlConnection != null)
                Requests.R_sqlConnection.Close();                
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Requests.R_sqlConnection == null)
            {
                MessageBox.Show("Вы не подключены к серверу");
                return;
            }
            if (directory != null && !directory.IsDisposed)
                return;
        }
    }
}
