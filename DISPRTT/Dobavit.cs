using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DISPRTT
{
    public partial class Dobavit : Form
    {
        Predmet prd;
        int id;
        public Dobavit(Predmet predmet, int id)
        {
            InitializeComponent();
            prd = predmet;
            this.id = id;
            if (prd.Tag.ToString() == "Add")
                button2.Visible = false;
            if (prd.Tag.ToString() == "Edit")
            {
                button1.Visible = false;
                comboBox1.Text = prd.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox1.Text = prd.dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox2.Text = prd.dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox3.Text = prd.dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                textBox4.Text = prd.dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                textBox5.Text = prd.dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                comboBox2.Text = prd.dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                prd.dataAdapter.InsertCommand = new SqlCommand("AddPredmet");
                prd.dataAdapter.InsertCommand.Connection = prd.dataAdapter.SelectCommand.Connection;
                prd.dataAdapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter fkParameter = new SqlParameter
                {                    
                    ParameterName = "@fk_vt",
                    Value = Convert.ToInt32(s)
                };
                prd.dataAdapter.InsertCommand.Parameters.Add(fkParameter);
                SqlParameter kodParameter = new SqlParameter
                {
                    ParameterName = "@kod",
                    Value = Convert.ToInt32(textBox1.Text)
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
                    Value = Convert.ToInt32(textBox3.Text)
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
                    Value = Convert.ToInt32(textBox5.Text)
                };
                prd.dataAdapter.InsertCommand.Parameters.Add(minballParameter);
                SqlParameter projectfileParameter = new SqlParameter
                {
                    ParameterName = "@projectfile",
                    Value = comboBox1.Text
                };
                prd.dataAdapter.InsertCommand.Parameters.Add(projectfileParameter);
                var p = prd.dataAdapter.InsertCommand.ExecuteScalar();
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Возможно, вы не правильно выбрали БД для подключения");
            }
        }
        string s = "";
        public void FindId()
        {
            DataSet myDS = new DataSet();
            SqlDataAdapter dAdapt = new SqlDataAdapter("Select * from VidTestirovaniya", Requests.R_sqlConnection);
            dAdapt.Fill(myDS, "VidTestirovaniya");
                for (int i = 0; i<myDS.Tables["VidTestirovaniya"].Rows.Count; i++)
                {
                    if (myDS.Tables["VidTestirovaniya"].Rows[i][1].ToString() == comboBox2.Text)
                    {
                      s = myDS.Tables["VidTestirovaniya"].Rows[i][0].ToString();
                    }
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            FindId();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter idParam = new SqlParameter { };
                SqlParameter text = new SqlParameter { };
                //Запрос на обновление позиции в бд настройки и создание параметров
                prd.dataAdapter.UpdateCommand = new SqlCommand("UpdateNastroyky");
            }
            catch (SqlException)
            {
                MessageBox.Show("Возможно вы не правильно выбрали БД для подключения");
            }
        }                       
    }
}
