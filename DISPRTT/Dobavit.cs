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
            SqlParameter dob = new SqlParameter
            {
                ParameterName = "@nazvanie",
                Value = textBox1.Text
            };
            prd.dataAdapter.InsertCommand.Parameters.Add(dob);
            prd.dataAdapter.InsertCommand.ExecuteNonQuery();
        }


    }
}
