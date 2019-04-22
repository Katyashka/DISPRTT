using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DISPRTT
{
    public partial class Predmet : Form
    {
        public Predmet()
        {
            InitializeComponent();
        }
        public SqlDataAdapter dataAdapter;
        public DataSet ds;
        Dobavit dob;

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dob = new Dobavit();
            dob.ShowDialog();
        }
        private void GetNastroyky()
        {
            try
            {
                dataAdapter = new SqlDataAdapter("GetPredmet", Requests.R_sqlConnection);
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

        private void Predmet_Load(object sender, EventArgs e)
        {
            //GetNastroyky();
        }
    }
}
