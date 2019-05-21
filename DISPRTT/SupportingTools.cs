using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DISPRTT
{
    public partial class SupportingTools : Form
    {
        public SqlDataAdapter dataAdapter;
        public DataSet ds;
        public SupportingTools()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;
            listBox1.SelectedIndex = 0;
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (listBox1.SelectedIndex)
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
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Путь к файлам";
                dataGridView1.Columns[2].HeaderText = "Комментарий";
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
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Название вида тестирования";
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
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Название вида части";
            }
            catch (SqlException)
            {
                MessageBox.Show("Возможно вы не правильно выбрали БД для подключения");
            }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Не выбран справочник");
                return;
            }
            this.Tag = "Add";
            AddItems add = new AddItems(this, -1);
            add.Text = listBox1.SelectedItem.ToString();
            add.ShowDialog();
            switch (listBox1.SelectedIndex)
            {
                case 0:
                    GetNastroyky();
                    break;
                case 1:
                    GetVidTestirovaniya();
                    break;
                case 2:
                    GetVidChasti();
                    break;
            }
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Не выбран справочник");
                return;
            }

            this.Tag = "Edit";
            AddItems change = new AddItems(this, int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            change.Text = listBox1.SelectedItem.ToString();
            change.ShowDialog();
            switch (listBox1.SelectedIndex)
            {
                case 0:
                    GetNastroyky();
                    break;
                case 1:
                    GetVidTestirovaniya();
                    break;
                case 2:
                    GetVidChasti();
                    break;
            }
        }
                
    }
}
