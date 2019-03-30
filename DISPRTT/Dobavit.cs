using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DISPRTT
{
    public partial class Dobavit : Form
    {
        public Dobavit()
        {
            InitializeComponent();
        }
        public SqlDataAdapter data;
        private void button1_Click(object sender, System.EventArgs e)
        {
            data.InsertCommand = new SqlCommand("AddPredmet");
            data.InsertCommand.Connection = data.SelectCommand.Connection;
            data.InsertCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter dob = new SqlParameter
            {
                ParameterName = "@put",
                Value = textBox1.Text
            };
            data.InsertCommand.Parameters.Add(dob);
            data.InsertCommand.ExecuteNonQuery();
        }
    }
}
