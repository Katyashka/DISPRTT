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
            GetSubject();
        }
        private void GetSubject()
        {
            try
            {
                dataAdapter = new SqlDataAdapter("GetSubject", Requests.R_sqlConnection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Вид тестирования";
                dataGridView1.Columns[2].HeaderText = "Путь к файлам";
                dataGridView1.Columns[3].HeaderText = "Код предмета";
                dataGridView1.Columns[4].HeaderText = "Название предмета";
                dataGridView1.Columns[5].HeaderText = "Код предмета для печати";
                dataGridView1.Columns[6].HeaderText = "Название предмета для печати";
                dataGridView1.Columns[7].HeaderText = "Минимальный балл";
            }
            catch (SqlException)
            {
                MessageBox.Show("Возможно вы не правильно выбрали БД для подключения");
            }
        }
        
        private void Predmet_Load(object sender, EventArgs e)
        {
            GetSubject();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Tag = "Edit";
            Dobavit change = new Dobavit(this, int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            change.ShowDialog();
            GetSubject();
        }

        private void разбаловкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            razb = new Razbalovka(this);
            razb.ShowDialog();
        }
    }
}
