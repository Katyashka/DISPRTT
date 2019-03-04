﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DISPRTT
{
    public partial class ConnectToDB : Form
    {
        public static SqlConnection sqlConnection;
        SqlConnectionStringBuilder conn;
        SqlCommand cmd;

        public ConnectToDB()
        {
            InitializeComponent();
        }

        private void ConnectToServer(object sender, EventArgs e)
        {
            //string myServer = Environment.MachineName;
            //SqlDataSourceEnumerator ser = SqlDataSourceEnumerator.Instance;
            //DataTable servers = ser.GetDataSources();
            //for (int i = 0; i < servers.Rows.Count; i++)
            //{
            //    if (myServer == servers.Rows[i]["ServerName"].ToString()) ///// used to get the servers in the local machine////
            //    {
            //        if ((servers.Rows[i]["InstanceName"] as string) != null)
            //            chooseS.Items.Add(servers.Rows[i]["ServerName"] + "\\" + servers.Rows[i]["InstanceName"]);
            //        else
            //            chooseS.Items.Add(servers.Rows[i]["ServerName"]);
            //    }
            //}
            if (String.IsNullOrEmpty(serverName.Text))
            {
                MessageBox.Show("Необходимо ввести имя сервера");
                return;
            }
            try
            {
                Requests.R_DBName = serverName.Text;
                string connection = @"Data Source=" + Requests.R_DBName + ";Integrated Security=True";
                sqlConnection = new SqlConnection(connection);
                sqlConnection.Open();
                MessageBox.Show("Соединение установлено");

                label1.Visible = true;
                dbName.Visible = true;
                cmd = new SqlCommand("SELECT name from sys.databases where name not in ('master','tempdb','model','msdb')", sqlConnection);
                IDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dbName.Items.Add(dr[0].ToString());
                }
                dbName.SelectedIndex = 0;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("Не удалось подключиться к серверу. Попробуйте ещё раз.");
                return;
            }
            catch (System.ArgumentOutOfRangeException)
            {
                MessageBox.Show("На этом сервере не обнаружено доступных баз данных");
            }
            catch
            {
            }
            sqlConnection.Close();
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnectionStringBuilder(sqlConnection.ConnectionString)
                { InitialCatalog = dbName.SelectedItem.ToString() };
                sqlConnection.ConnectionString = conn.ConnectionString;
                sqlConnection.Open();
                MessageBox.Show("Соединение установлено");
                Requests.R_sqlConnection = sqlConnection;
                this.Close();
            }
            catch
            {
                MessageBox.Show("Не удалось подключиться к базе данных");
                Requests.R_sqlConnection = null;
            }
        }
    }
}
