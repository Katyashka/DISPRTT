using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DISPRTT
{
    public partial class ChangeItems : Form
    {
        int i = 0;
        SupportingTools form;
        public ChangeItems(SupportingTools supportingTools)
        {
            InitializeComponent();
            form = supportingTools;
            i = form.listBox1.SelectedIndex;
            switch (i)
            {
                case 0: panel0.Visible = true; break;
                case 1: panel1.Visible = true; break;
                case 2: panel1.Visible = true; break;
            }
        }
        private void change_Click(object sender, System.EventArgs e)
        {
            var con = form.dataAdapter.SelectCommand.Connection;
            try
            {
                SqlParameter idParam = new SqlParameter { };
                SqlParameter text = new SqlParameter { };
                if (textBox4.Text == "" & textBox5.Text.ToString() == "")
                {
                    MessageBox.Show("Поле Id не может быть пустым");
                    return;
                }
                else
                    switch (i)
                    {
                        case 0:
                            //Запрос на обновление позиции в бд настройки и создание параметров
                            form.dataAdapter.UpdateCommand = new SqlCommand("UpdateNastroyky");
                            idParam = new SqlParameter
                            {
                                ParameterName = "@id",
                                Value = textBox5.Text
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
                                Value = textBox4.Text
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
                                Value = textBox4.Text
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

        private void Id_Leave(object sender, EventArgs e)
        {
            var con = form.dataAdapter.SelectCommand.Connection;
            try
            {
                if (textBox4.Text == "" & textBox5.Text.ToString() == "")
                    return;
                switch (i)
                {
                    case 0:
                        //Существование id позиции в бд настройки
                        form.dataAdapter.SelectCommand = new SqlCommand("SELECT Pk_N FROM Nastroyky WHERE Pk_N = " + textBox5.Text);
                        break;
                    case 1:
                        //Существование id позиции в бд вид тестирования
                        form.dataAdapter.SelectCommand = new SqlCommand("SELECT Pk_VT FROM VidTestirovaniya WHERE Pk_VT = " + textBox4.Text);
                        break;
                    case 2:
                        //Существование id позиции в бд вид тестирования
                        form.dataAdapter.SelectCommand = new SqlCommand("SELECT Pk_VCh FROM VidChastiTesta WHERE Pk_VCh = " + textBox4.Text);
                        break;
                }
                //Проверка на существование записи с введенным id
                form.dataAdapter.SelectCommand.Connection = con;
                var x = form.dataAdapter.SelectCommand.ExecuteScalar().ToString();
            }
            catch (SqlException)
            {
                MessageBox.Show("Возможно вы не правильно выбрали БД для подключения");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Запись с таким Id не существует");
            }
        }
    }
}
