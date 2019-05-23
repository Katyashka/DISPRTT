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
                comboBox1.Text = prd.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox1.Text = prd.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox2.Text = prd.dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox3.Text = prd.dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox4.Text = prd.dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                textBox5.Text = prd.dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                comboBox2.Text = prd.dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
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
                prd.dataAdapter.UpdateCommand = new SqlCommand("UpdatePredmet");
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                prd.dataAdapter.UpdateCommand.Parameters.Add(idParam);
                SqlParameter fk = new SqlParameter
                {
                    ParameterName = "@fk_vt",
                    Value = comboBox2.Text
                };
                prd.dataAdapter.UpdateCommand.Parameters.Add(fk);
                SqlParameter kod = new SqlParameter
                {
                    ParameterName = "@kod",
                    Value = textBox1.Text
                };
                prd.dataAdapter.UpdateCommand.Parameters.Add(kod);
                SqlParameter nazvanie = new SqlParameter
                {
                    ParameterName = "@nazvanie",
                    Value = textBox2.Text
                };
                prd.dataAdapter.UpdateCommand.Parameters.Add(nazvanie);
                SqlParameter kodprint = new SqlParameter
                {
                    ParameterName = "@kodprint",
                    Value = textBox3.Text
                };
                prd.dataAdapter.UpdateCommand.Parameters.Add(kodprint);
                SqlParameter name = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = textBox4.Text
                };
                prd.dataAdapter.UpdateCommand.Parameters.Add(name);
                SqlParameter ball = new SqlParameter
                {
                    ParameterName = "@minball",
                    Value = textBox5.Text
                };
                prd.dataAdapter.UpdateCommand.Parameters.Add(ball);
                SqlParameter prj = new SqlParameter
                {
                    ParameterName = "@projectfile",
                    Value = comboBox1.Text
                };
                prd.dataAdapter.UpdateCommand.Parameters.Add(prj);
                prd.dataAdapter.UpdateCommand.Connection = prd.dataAdapter.SelectCommand.Connection;
                prd.dataAdapter.UpdateCommand.CommandType = CommandType.StoredProcedure;             
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
