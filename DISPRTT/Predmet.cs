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
        //Razbalovka razb;

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dob = new Dobavit(this);
            dob.ShowDialog();
        }
        private void GetPredmet()
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
            GetPredmet();
        }

        private void разбаловкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //    razb = new Razbalovka(this);
            //    razb.ShowDialog();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void удалитьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить выделенную строку из базы данных?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Delete(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            GetPredmet();
        }
        private void Delete(int id)
        {
            try
            {
                dataAdapter.DeleteCommand = new SqlCommand("DeletePredmet"); 
                dataAdapter.DeleteCommand.Connection = Requests.R_sqlConnection;
                dataAdapter.DeleteCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                dataAdapter.DeleteCommand.Parameters.Add(idParam);
                var y = dataAdapter.DeleteCommand.ExecuteScalar();
            }
            catch (SqlException)
            {
                MessageBox.Show("Возможно вы не правильно выбрали БД для подключения");
            }
        }
    }
}
