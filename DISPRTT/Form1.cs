using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DISPRTT
{
    public partial class Form1 : Form
    {
        SupportingTools directory;
        ConnectToDB connectTo;
        Predmet pr;

        public Form1()
        {
            InitializeComponent();
            подключитьсяКСерверуToolStripMenuItem.ToolTipText = "Подключение к серверу";
            предметыToolStripMenuItem.ToolTipText = "Предметы тестирования";
        }

        private void OpenDirectory_Click(object sender, EventArgs e)
        {
            if (Requests.R_sqlConnection == null)
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
            directory.Show();
        }

        private void ShowConnectToDB(object sender, EventArgs e)
        {
            connectTo = new ConnectToDB();
            connectTo.ShowDialog();
            //смена картинок в зависимости от подключения
            if (Requests.R_sqlConnection == null)
                подключитьсяКСерверуToolStripMenuItem.Image = ((System.Drawing.Image)(Properties.Resources.delete_database));
            else
                подключитьсяКСерверуToolStripMenuItem.Image = ((System.Drawing.Image)(Properties.Resources.database_check));
        }

        private void ShowSubjects(object sender, EventArgs e)
        {
            if (Requests.R_sqlConnection == null)
            {
                MessageBox.Show("Вы не подключены к серверу");
                return;
            }
            if (pr != null && !pr.IsDisposed)
                return;

            pr = new Predmet
            {
                MdiParent = this
            };
            pr.Show();
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
