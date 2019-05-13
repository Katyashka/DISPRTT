using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DISPRTT
{
    public partial class AddItems : Form
    {
        int i = 0;
        SupportingTools form;
        int id;
        public AddItems(SupportingTools supportingTools, int id)
        {
            InitializeComponent();
            this.id = id;
            form = supportingTools;
            i = form.listBox1.SelectedIndex;
            if (form.Tag.ToString() == "Add")
                save.Visible = false;
            if (form.Tag.ToString() == "Edit")
            {
                add.Visible = false;
                if (i == 0)
                {
                    textBox1.Text = form.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    textBox2.Text = form.dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                }
                else
                    textBox3.Text = form.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            }
            switch (i)
            {
                case 0: panel0.Visible = true; break;
                case 1: panel1.Visible = true; break;
                case 2: panel1.Visible = true; break;
            }

        }

        private void add_Click(object sender, System.EventArgs e)
        {
            switch (i)
            {
                case 0:
                    try
                    {
                        //Добавление новой позиции в бд настройки
                        if (!System.IO.Directory.Exists(textBox1.Text))
                            throw new System.IO.FileNotFoundException();
                        form.dataAdapter.InsertCommand = new SqlCommand("AddNastroyky");
                        form.dataAdapter.InsertCommand.Connection = form.dataAdapter.SelectCommand.Connection;
                        form.dataAdapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                        SqlParameter putParam = new SqlParameter
                        {
                            ParameterName = "@put",
                            Value = textBox1.Text
                        };
                        form.dataAdapter.InsertCommand.Parameters.Add(putParam);
                        SqlParameter commentParam = new SqlParameter
                        {
                            ParameterName = "@comment",
                            Value = textBox2.Text
                        };
                        form.dataAdapter.InsertCommand.Parameters.Add(commentParam);
                        form.dataAdapter.InsertCommand.ExecuteScalar();
                    }
                    catch (System.IO.FileNotFoundException)
                    {
                        MessageBox.Show("Возможно Вы не правильно указали путь");
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Возможно вы не правильно выбрали БД для подключения");
                    }
                    break;
                case 1:
                    try
                    {
                        //Добавление новой позиции в таблицу вид тестирования
                        form.dataAdapter.InsertCommand = new SqlCommand("AddVidTestirovaniya");
                        form.dataAdapter.InsertCommand.Connection = form.dataAdapter.SelectCommand.Connection;
                        form.dataAdapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                        SqlParameter nameParam = new SqlParameter
                        {
                            ParameterName = "@nazvanie",
                            Value = textBox3.Text
                        };
                        form.dataAdapter.InsertCommand.Parameters.Add(nameParam);
                        form.dataAdapter.InsertCommand.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Возможно вы не правильно выбрали БД для подключения");
                    }
                    break;
                case 2:
                    try
                    {
                        //Добавление новой позиции в таблицу вид тестирования
                        form.dataAdapter.InsertCommand = new SqlCommand("AddVidChasti");
                        form.dataAdapter.InsertCommand.Connection = form.dataAdapter.SelectCommand.Connection;
                        form.dataAdapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                        SqlParameter nameParam = new SqlParameter
                        {
                            ParameterName = "@nazvanie",
                            Value = textBox3.Text
                        };
                        form.dataAdapter.InsertCommand.Parameters.Add(nameParam);
                        form.dataAdapter.InsertCommand.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Возможно вы не правильно выбрали БД для подключения");
                    }
                    break;
            }
        }

        private void save_Click(object sender, System.EventArgs e)
        {
            var con = form.dataAdapter.SelectCommand.Connection;
            try
            {
                SqlParameter idParam = new SqlParameter { };
                SqlParameter text = new SqlParameter { };

                switch (i)
                {
                    case 0:
                        //Запрос на обновление позиции в бд настройки и создание параметров
                        form.dataAdapter.UpdateCommand = new SqlCommand("UpdateNastroyky");
                        idParam = new SqlParameter
                        {
                            ParameterName = "@id",
                            Value = id
                        };
                        text = new SqlParameter
                        {
                            ParameterName = "@put",
                            Value = textBox1.Text
                        };
                        SqlParameter com = new SqlParameter
                        {
                            ParameterName = "@comment",
                            Value = textBox2.Text
                        };
                        form.dataAdapter.UpdateCommand.Parameters.Add(com);
                        break;
                    case 1:
                        //Запрос на обновление позиции в бд вид тестирования и создание параметров
                        form.dataAdapter.UpdateCommand = new SqlCommand("UpdateVidTestirovaniya");
                        idParam = new SqlParameter
                        {
                            ParameterName = "@id",
                            Value = id
                        };
                        text = new SqlParameter
                        {
                            ParameterName = "@name",
                            Value = textBox3.Text
                        };
                        break;
                    case 2:
                        //Запрос на обновление позиции в бд вид тестирования и создание параметров
                        form.dataAdapter.UpdateCommand = new SqlCommand("UpdateVidChasti");
                        idParam = new SqlParameter
                        {
                            ParameterName = "@id",
                            Value = id
                        };
                        text = new SqlParameter
                        {
                            ParameterName = "@name",
                            Value = textBox3.Text
                        };
                        break;
                }
                //Обновление позиции в бд определенной выше 
                form.dataAdapter.UpdateCommand.Connection = form.dataAdapter.SelectCommand.Connection;
                form.dataAdapter.UpdateCommand.CommandType = CommandType.StoredProcedure;
                form.dataAdapter.UpdateCommand.Parameters.Add(idParam);
                form.dataAdapter.UpdateCommand.Parameters.Add(text);

                var y = form.dataAdapter.UpdateCommand.ExecuteScalar();
            }
            catch (SqlException)
            {
                MessageBox.Show("Возможно вы не правильно выбрали БД для подключения");
            }
        }
        //1111111111222222222233333333334444444444555555555566666666667777777777888888888899999999990000000000
    }
}
