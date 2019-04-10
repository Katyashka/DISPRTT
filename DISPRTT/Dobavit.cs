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
            prd.dataAdapter.InsertCommand = new SqlCommand("AddPredmet");
            prd.dataAdapter.InsertCommand.Connection = prd.dataAdapter.SelectCommand.Connection;
            prd.dataAdapter.InsertCommand.CommandType = CommandType.StoredProcedure;
            prd.dataAdapter.InsertCommand = new SqlCommand("GetNastroyky");
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


    }
}
