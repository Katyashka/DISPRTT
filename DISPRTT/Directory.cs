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

namespace DISPRTT
{
    public partial class Directory : Form
    {
        SqlDataAdapter dataAdapter;
        SqlCommandBuilder commandBuilder;
        DataSet ds;
        //List<int> deleteList;
        //List<int> addList;
        //List<int> updateList;
        public Directory()
        {
            InitializeComponent();
        }

        private void DirectorySettings_Click(object sender, EventArgs e)
        {
            dataGridView1.Tag = "Directory";
            dataGridView1.DataSource = bindingSource1;
            GetData("select * from Nastroyky");
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[0].HeaderText = "№";
            dataGridView1.Columns[1].HeaderText = "Путь";
            dataGridView1.Columns[2].HeaderText = "Комментарий";

            //deleteList = new List<int>();
            //addList = new List<int>();
            //updateList = new List<int>();
        }
        private void GetData(string selectCommand)
        {
            try
            {
                dataAdapter = new SqlDataAdapter(selectCommand, Requests.R_sqlConnection);
                ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                //commandBuilder = new SqlCommandBuilder(dataAdapter);
                //DataSet ds = new DataSet();
                //dataAdapter.Fill(ds);
                //ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
                //table = new DataTable();
                //table = ds.Tables[0];
                //object d = table.Rows[0].ItemArray;
                //bindingSource1.DataSource = table;
            }
            catch (SqlException)
            {
                MessageBox.Show("Возможно вы не правильно выбрали БД для подключения");
            }
        }

        private void dataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            //deleteList.Add(int.Parse(e.Row.Cells[0].Value.ToString()));
            commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Update(ds);
            string s = commandBuilder.GetUpdateCommand().CommandText;
            ds.Clear();
            dataAdapter.Fill(ds);
        }
    }
}
