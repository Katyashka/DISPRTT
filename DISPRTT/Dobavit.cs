﻿
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DISPRTT
{
    public partial class Dobavit : Form
    {
        Predmet prd;
        public Dobavit(Predmet predmet)
        {
            prd = predmet;
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                
                prd.dataAdapter.InsertCommand = new SqlCommand("AddPredmet");
                prd.dataAdapter.InsertCommand.Connection = prd.dataAdapter.SelectCommand.Connection;
                prd.dataAdapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                prd.dataAdapter.InsertCommand = new SqlCommand("GetVidTestirovaniya");

                SqlParameter fkParameter = new SqlParameter
                {

                    ParameterName = "@fk_vt",
                    Value = comboBox2.Text
                };
                prd.dataAdapter.InsertCommand.Parameters.Add(fkParameter);
                SqlParameter kodParameter = new SqlParameter
                {
                    ParameterName = "@kod",
                    Value = textBox1.Text
                };
                prd.dataAdapter.InsertCommand.Parameters.Add(kodParameter);
                SqlParameter nazvanieParameter = new SqlParameter
                {
                    ParameterName = "@nazvanie",
                    Value = textBox2.Text
                };
                prd.dataAdapter.InsertCommand.Parameters.Add(nazvanieParameter);
                SqlParameter kodprintParameter = new SqlParameter
                {
                    ParameterName = "@kodprint",
                    Value = textBox3.Text
                };
                prd.dataAdapter.InsertCommand.Parameters.Add(kodprintParameter);
                SqlParameter nameParameter = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = textBox4.Text
                };
                prd.dataAdapter.InsertCommand.Parameters.Add(nameParameter);
                SqlParameter minballParameter = new SqlParameter
                {
                    ParameterName = "@minball",
                    Value = textBox5.Text
                };
                prd.dataAdapter.InsertCommand.Parameters.Add(minballParameter);
                SqlParameter projectfileParameter = new SqlParameter
                {
                    ParameterName = "@projectfile",
                    Value = comboBox1.Text
                };
                prd.dataAdapter.InsertCommand.Parameters.Add(projectfileParameter);
                prd.dataAdapter.InsertCommand.ExecuteScalar();
            }
            catch (SqlException)
            {
                MessageBox.Show("Возможно, вы не правильно выбрали БД для подключения");
            }
        }

        public void Zapolnenie2()
        {
            DataSet myDS = new DataSet();
            SqlDataAdapter dAdapt = new SqlDataAdapter("Select * from VidTestirovaniya", Requests.R_sqlConnection);
            dAdapt.Fill(myDS, "VidTestirovaniya");
            comboBox2.Items.Clear();
            int i = 0;
            for (i = 0; i < myDS.Tables["VidTestirovaniya"].Rows.Count; i++)
            {
                comboBox2.Items.Add(myDS.Tables["VidTestirovaniya"].Rows[i][1].ToString());
            }
        }
        public void Zapolnenie1()
        {
            DataSet myDS = new DataSet();
            SqlDataAdapter dAdapt = new SqlDataAdapter("Select * from Nastroyky", Requests.R_sqlConnection);
            dAdapt.Fill(myDS, "Nastroyky");
            comboBox1.Items.Clear();
            int i = 0;
            for (i = 0; i < myDS.Tables["Nastroyky"].Rows.Count; i++)
            {
                comboBox1.Items.Add(myDS.Tables["Nastroyky"].Rows[i][1].ToString());
            }
        }

        private void Dobavit_Load(object sender, System.EventArgs e)
        {
            Zapolnenie1();
            Zapolnenie2();
        }
    }
}