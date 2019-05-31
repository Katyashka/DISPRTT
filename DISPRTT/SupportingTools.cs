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

        //private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (listBox1.SelectedItem == null)
        //    {
        //        MessageBox.Show("Не выбран справочник");
        //        return;
        //    }
        //    if (MessageBox.Show("Вы действительно хотите удалить выделенную строку из базы данных?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
        //        Delete(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
        //    switch (listBox1.SelectedIndex)
        //    {
        //        case 0:
        //            GetNastroyky();
        //            break;
        //        case 1:
        //            GetVidTestirovaniya();
        //            break;
        //        case 2:
        //            GetVidChasti();
        //            break;
        //    }
        //}
        //private void Delete(int id)
        //{
        //    try
        //    {//Определение таблицы, элемент которой требуется удалить
        //        switch (listBox1.SelectedIndex)
        //        {
        //            case 0:
        //                dataAdapter.DeleteCommand = new SqlCommand("DeleteNastroyky");
        //                break;
        //            case 1:
        //                dataAdapter.DeleteCommand = new SqlCommand("DeleteVidTestirovaniya");
        //                break;
        //            case 2:
        //                dataAdapter.DeleteCommand = new SqlCommand("DeleteVidChasti");
        //                break;
        //        }
        //        //Удаление позиции из бд определенной выше 
        //        dataAdapter.DeleteCommand.Connection = Requests.R_sqlConnection;
        //        dataAdapter.DeleteCommand.CommandType = CommandType.StoredProcedure;
        //        SqlParameter idParam = new SqlParameter
        //        {
        //            ParameterName = "@id",
        //            Value = id
        //        };
        //        dataAdapter.DeleteCommand.Parameters.Add(idParam);
        //        var y = dataAdapter.DeleteCommand.ExecuteScalar();
        //    }
        //    catch (SqlException e)
        //    {
        //        if (e.Number <= 2)
        //            MessageBox.Show("Возможно вы не правильно выбрали БД для подключения");
        //        if (e.Number == 547)
        //            MessageBox.Show("Этот вид тестирования используется в одном из предметов.");
        //    }
        //}

    }
}
