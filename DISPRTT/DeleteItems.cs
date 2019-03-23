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
            switch (i)
            {
                case 0:
                    try
                    {
                        //Удаление позиции из бд настройки
                        form.dataAdapter.DeleteCommand = new SqlCommand("DeleteNastroyky");
                        form.dataAdapter.DeleteCommand.Connection = form.dataAdapter.SelectCommand.Connection;
                        form.dataAdapter.DeleteCommand.CommandType = CommandType.StoredProcedure;
                        SqlParameter idParam = new SqlParameter
                        {
                            ParameterName = "@id",
                            Value = textBox1.Text
                        };
                        form.dataAdapter.InsertCommand.Parameters.Add(idParam);
                        var x = form.dataAdapter.InsertCommand.Connection;
                        var y = form.dataAdapter.InsertCommand.ExecuteScalar();
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Возможно вы не правильно выбрали БД для подключения");
                    }
                    break;
            //    case 1:
            //        try
            //        {
            //            //Добавление новой позиции в таблицу вид тестирования
            //            form.dataAdapter.InsertCommand = new SqlCommand("AddVidTestirovaniya");
            //            form.dataAdapter.InsertCommand.Connection = form.dataAdapter.SelectCommand.Connection;
            //            form.dataAdapter.InsertCommand.CommandType = CommandType.StoredProcedure;
            //            SqlParameter nameParam = new SqlParameter
            //            {
            //                ParameterName = "@nazvanie",
            //                Value = textBox3.Text
            //            };
            //            form.dataAdapter.InsertCommand.Parameters.Add(nameParam);
            //            form.dataAdapter.InsertCommand.ExecuteNonQuery();
            //        }
            //        catch (SqlException)
            //        {
            //            MessageBox.Show("Возможно вы не правильно выбрали БД для подключения");
            //        }
            //        break;
            //    case 2:
            //        try
            //        {
            //            //Добавление новой позиции в таблицу вид тестирования
            //            form.dataAdapter.InsertCommand = new SqlCommand("AddVidChasti");
            //            form.dataAdapter.InsertCommand.Connection = form.dataAdapter.SelectCommand.Connection;
            //            form.dataAdapter.InsertCommand.CommandType = CommandType.StoredProcedure;
            //            SqlParameter nameParam = new SqlParameter
            //            {
            //                ParameterName = "@nazvanie",
            //                Value = textBox3.Text
            //            };
            //            form.dataAdapter.InsertCommand.Parameters.Add(nameParam);
            //            form.dataAdapter.InsertCommand.ExecuteNonQuery();
            //        }
            //        catch (SqlException)
            //        {
            //            MessageBox.Show("Возможно вы не правильно выбрали БД для подключения");
            //        }
            //        break;
            //}
        }
    }
}

