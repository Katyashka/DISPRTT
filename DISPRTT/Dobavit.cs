﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DISPRTT
{
    public partial class Dobavit : Form
    {
        Predmet prd;
        int id;
        public DataTable dt, dt1;
        public Dobavit(Predmet predmet, int id)
        {
            InitializeComponent();
            prd = predmet;
            this.id = id;
            if (prd.Tag.ToString() == "Add")
                button2.Visible = false;
            if (prd.Tag.ToString() == "Edit")
            {
                prd.dataAdapter.SelectCommand = new SqlCommand("GetType_of_Test");
                prd.dataAdapter.SelectCommand.Connection = Requests.R_sqlConnection;
                prd.dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dt = new DataTable();
                prd.dataAdapter.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    comboBox2.Items.Add(dt.Rows[i][1]);
                }
                prd.dataAdapter.SelectCommand = new SqlCommand("GetFilePath");
                prd.dataAdapter.SelectCommand.Connection = Requests.R_sqlConnection;
                prd.dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dt1 = new DataTable();
                prd.dataAdapter.Fill(dt1);
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    comboBox1.Items.Add(dt1.Rows[i][1]);
                }
                button1.Visible = false;
                //comboBox2.Text = prd.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                //comboBox1.Text = prd.dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox1.Text = prd.dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox2.Text = prd.dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                textBox3.Text = prd.dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                textBox4.Text = prd.dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                textBox5.Text = prd.dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            }
            //if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == "") || (textBox5.Text == "")) button1.Enabled = false;
            //else button1.Enabled = true;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                prd.dataAdapter.InsertCommand = new SqlCommand("AddSubject");
                prd.dataAdapter.InsertCommand.Connection = prd.dataAdapter.SelectCommand.Connection;
                prd.dataAdapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter fkParameter = new SqlParameter
                {                    
                    ParameterName = "@fk_tt",
                    Value = FindId()
                };
                prd.dataAdapter.InsertCommand.Parameters.Add(fkParameter);
                SqlParameter projectfileParameter = new SqlParameter
                {
                    ParameterName = "@filepath",
                    Value = comboBox1.Text
                };
                prd.dataAdapter.InsertCommand.Parameters.Add(projectfileParameter);
                SqlParameter kodParameter = new SqlParameter
                {
                    ParameterName = "@code",
                    Value = Convert.ToInt32(textBox1.Text)
                };
                prd.dataAdapter.InsertCommand.Parameters.Add(kodParameter);
                SqlParameter nazvanieParameter = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = textBox2.Text
                };
                prd.dataAdapter.InsertCommand.Parameters.Add(nazvanieParameter);
                SqlParameter kodprintParameter = new SqlParameter
                {
                    ParameterName = "@codeprint",
                    Value = Convert.ToInt32(textBox3.Text)
                };
                prd.dataAdapter.InsertCommand.Parameters.Add(kodprintParameter);
                SqlParameter nameParameter = new SqlParameter
                {
                    ParameterName = "@nameprint",
                    Value = textBox4.Text
                };
                prd.dataAdapter.InsertCommand.Parameters.Add(nameParameter);
                SqlParameter minballParameter = new SqlParameter
                {
                    ParameterName = "@minball",
                    Value = Convert.ToInt32(textBox5.Text)
                };
                prd.dataAdapter.InsertCommand.Parameters.Add(minballParameter);
                
                var p = prd.dataAdapter.InsertCommand.ExecuteScalar();
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    if (textBox1.Text == dt.Rows[i][0].ToString())
                //    {
                //        MessageBox.Show("Данный код предмета уже существует!","!!!");
                //    }
                //}
                
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Возможно, вы не правильно выбрали БД для подключения");
            }
        }
        string s = "";
        public int FindId()
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][1].ToString() == comboBox2.SelectedItem.ToString())
                    s = dt.Rows[i][0].ToString();
            }
            return Convert.ToInt32(s);
        }
        public int FindId1()
        {
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                if (dt1.Rows[i][1].ToString() == comboBox1.SelectedItem.ToString())
                    s = dt.Rows[i][0].ToString();
            }
            return Convert.ToInt32(s);
        }
        public void Zapolnenie2()
        {
            DataSet myDS = new DataSet();
            SqlDataAdapter dAdapt = new SqlDataAdapter("Select * from Type_of_Test", Requests.R_sqlConnection);
            dAdapt.Fill(myDS, "Type_of_Test");
            comboBox2.Items.Clear();
            int i = 0;
            for (i = 0; i < myDS.Tables["Type_of_Test"].Rows.Count; i++)
            {
                comboBox2.Items.Add(myDS.Tables["Type_of_Test"].Rows[i][1].ToString());
            }
        }
        public void Zapolnenie1()
        {
            DataSet myDS = new DataSet();
            SqlDataAdapter dAdapt = new SqlDataAdapter("Select * from FilePath", Requests.R_sqlConnection);
            dAdapt.Fill(myDS, "FilePath");
            comboBox1.Items.Clear();
            int i = 0;
            for (i = 0; i < myDS.Tables["FilePath"].Rows.Count; i++)
            {
                comboBox1.Items.Add(myDS.Tables["FilePath"].Rows[i][1].ToString());
            }
        }

        private void Dobavit_Load(object sender, System.EventArgs e)
        {
            Zapolnenie1();
            Zapolnenie2();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                prd.dataAdapter.UpdateCommand = new SqlCommand("UpdateSubject");
                prd.dataAdapter.UpdateCommand.Connection = prd.dataAdapter.SelectCommand.Connection;
                prd.dataAdapter.UpdateCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                prd.dataAdapter.UpdateCommand.Parameters.Add(idParam);
                SqlParameter fk = new SqlParameter
                {
                    ParameterName = "@fk_tt",
                    Value = FindId()
                };
                prd.dataAdapter.UpdateCommand.Parameters.Add(fk);
                SqlParameter prj = new SqlParameter
                {
                    ParameterName = "@filepath",
                    Value = FindId1()
                };
                prd.dataAdapter.UpdateCommand.Parameters.Add(prj);
                SqlParameter kod = new SqlParameter
                {
                    ParameterName = "@code",
                    Value = Convert.ToInt32(textBox1.Text)
                };
                prd.dataAdapter.UpdateCommand.Parameters.Add(kod);
                SqlParameter nazvanie = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = textBox2.Text
                };
                prd.dataAdapter.UpdateCommand.Parameters.Add(nazvanie);
                SqlParameter kodprint = new SqlParameter
                {
                    ParameterName = "@codeprint",
                    Value = Convert.ToInt32(textBox3.Text)
                };
                prd.dataAdapter.UpdateCommand.Parameters.Add(kodprint);
                SqlParameter name = new SqlParameter
                {
                    ParameterName = "@nameprint",
                    Value = textBox4.Text
                };
                prd.dataAdapter.UpdateCommand.Parameters.Add(name);
                SqlParameter ball = new SqlParameter
                {
                    ParameterName = "@minball",
                    Value = Convert.ToInt32(textBox5.Text)
                };
                prd.dataAdapter.UpdateCommand.Parameters.Add(ball);
                
                var y = prd.dataAdapter.UpdateCommand.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                MessageBox.Show("Возможно вы не правильно выбрали БД для подключения");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char n = e.KeyChar;
            if (!Char.IsDigit(n) && n != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char n = e.KeyChar;
            if (!Char.IsDigit(n) && n != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char n = e.KeyChar;
            if (!Char.IsDigit(n) && n != 8) 
            {
                e.Handled = true;
            }
        }

       
    }
}
