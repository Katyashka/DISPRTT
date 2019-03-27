using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DISPRTT
{
    public partial class DeleteItems : Form
    {
        int i = 0;
        SupportingTools form;
        public DeleteItems(SupportingTools supportingTools)
        {
            InitializeComponent();
            form = supportingTools;
            i = form.listBox1.SelectedIndex;
        }

        private void delete_Click(object sender, System.EventArgs e)
        {
                var con = form.dataAdapter.SelectCommand.Connection;
            try
            {
                switch (i)
                {
                    case 0:
                        //Удаление позиции из бд настройки
                        form.dataAdapter.SelectCommand = new SqlCommand("SELECT Pk_N FROM Nastroyky WHERE Pk_N = " + textBox1.Text);
                        form.dataAdapter.DeleteCommand = new SqlCommand("DeleteNastroyky");
                        break;
                    case 1:
                        //Удаление позиции из бд вид тестирования
                        form.dataAdapter.SelectCommand = new SqlCommand("SELECT Pk_VT FROM VidTestirovaniya WHERE Pk_VT = " + textBox1.Text);
                        form.dataAdapter.DeleteCommand = new SqlCommand("DeleteVidTestirovaniya");
                        break;
                    case 2:
                        //Удаление позиции из бд вид тестирования
                        form.dataAdapter.SelectCommand = new SqlCommand("SELECT Pk_VCh FROM VidChastiTesta WHERE Pk_VCh = " + textBox1.Text);
                        form.dataAdapter.DeleteCommand = new SqlCommand("DeleteVidChasti");
                        break;
                }
                //Проверка на существование записи с введенным id
                form.dataAdapter.SelectCommand.Connection = con;
                var x = form.dataAdapter.SelectCommand.ExecuteScalar().ToString();
                //Удаление позиции из бд определенной выше 
                form.dataAdapter.DeleteCommand.Connection = form.dataAdapter.SelectCommand.Connection;
                form.dataAdapter.DeleteCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = textBox1.Text
                };
                form.dataAdapter.DeleteCommand.Parameters.Add(idParam);
                var y = form.dataAdapter.DeleteCommand.ExecuteScalar();
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

