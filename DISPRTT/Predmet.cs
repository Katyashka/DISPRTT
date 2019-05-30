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
            dataGridView1.AutoGenerateColumns = true;
        }
        public SqlDataAdapter dataAdapter;
        public DataSet ds;
        Dobavit dob;
        Razbalovka razb;

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Tag = "Add";
            dob = new Dobavit(this, -1);
            dob.ShowDialog();
            GetPredmet();
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
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.Columns[0].Visible = false;
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

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Tag = "Edit";
            Dobavit change = new Dobavit(this, int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            change.ShowDialog();
            GetPredmet();            
        }

        private void разбаловкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            razb = new Razbalovka(this);
            razb.ShowDialog();
        }
    }
}
