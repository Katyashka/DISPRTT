using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DISPRTT
{
    public partial class AddItems : Form
    {
        int i = 0;
        SupportingTools form;
        public AddItems(SupportingTools supportingTools)
        {
            InitializeComponent();
            form = supportingTools;
            i = form.listBox1.SelectedIndex;
            switch (i)
            {
                case 0:panel0.Visible = true;break;
                case 1:panel1.Visible = true; break;
                case 2:panel1.Visible = true;break;
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
                        var x = form.dataAdapter.InsertCommand.Connection;
                        var y = form.dataAdapter.InsertCommand.ExecuteScalar();
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
    }
}
