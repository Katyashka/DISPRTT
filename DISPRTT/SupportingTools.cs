using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DISPRTT
{
    public partial class SupportingTools : Form
    {
        SqlDataAdapter dataAdapter;
        DataSet ds;
        public SupportingTools()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (listView1.SelectedIndices.)
            {
                case 0: GetNastroyky(); break;
                case 1: GetVidTestirovaniya(); break;
                case 2: GetVidChasti(); break;
            }
        }
        private void GetNastroyky()
        {
            try
            {
                dataAdapter = new SqlDataAdapter("GetNastroyky", Requests.R_sqlConnection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (SqlException)
            {
                MessageBox.Show("Возможно вы не правильно выбрали БД для подключения");
            }
        }
        private void GetVidTestirovaniya()
        {
            try
            {
                dataAdapter = new SqlDataAdapter("GetVidTestirovaniya", Requests.R_sqlConnection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (SqlException)
            {
                MessageBox.Show("Возможно вы не правильно выбрали БД для подключения");
            }
        }
        private void GetVidChasti()
        {
            try
            {
                dataAdapter = new SqlDataAdapter("GetVidChasti", Requests.R_sqlConnection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (SqlException)
            {
                MessageBox.Show("Возможно вы не правильно выбрали БД для подключения");
            }
        }
    }
}
