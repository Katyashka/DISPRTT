using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DISPRTT
{
    public partial class SupportingTools : Form
    {
        SqlDataAdapter dataAdapter;
        SqlCommandBuilder commandBuilder;
        DataSet ds;
        public SupportingTools()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (listBox1.SelectedIndex)
            {
                case 0: GetNastroyky();break;
                case 1: break;
                case 2: break;
            }
        }
        private void GetNastroyky()
        {
            try
            {
                var sqlCmd = new SqlCommand("GetNastroyky", Requests.R_sqlConnection);
                sqlCmd.CommandType = CommandType.StoredProcedure;
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
    }
}
