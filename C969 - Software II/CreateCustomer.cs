using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace C969___Software_II
{
    public partial class CreateCustomer : Form
    {
        
        public CreateCustomer()
        {
            InitializeComponent();
        }
        
        public int createRecord(string timestamp, string userName, string table, string partOfQuery)
        {
            int recId = DataHelper.createID(table);
            string recInsert = $"INSERT INTO {table}" +
                $" VALUES ('{recId}', {partOfQuery}, '{timestamp}', '{userName}', '{timestamp}', '{userName}')";

            MySqlConnection c = new MySqlConnection(DataHelper.conString);
            c.Open();
            MySqlCommand cmd = new MySqlCommand(recInsert, c);
            cmd.ExecuteNonQuery();
            c.Close();

            return recId;
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            string timestamp = DataHelper.createTimestamp();
            string userName = DataHelper.getCurrentUserName();

            // TODO: Create checks to see if fields are blank before running these creates.
            int countryId = createRecord(timestamp, userName, "country", $"'{countryTextbox.Text}'");
            int cityId = createRecord(timestamp, userName, "city", $"'{cityTextbox.Text}', '{countryId}'");
            int addressId = createRecord(timestamp, userName, "address", $"'{addressTextbox.Text}', '', '{cityId}', '{zipTextbox.Text}', '{phoneTextbox.Text}'");
            createRecord(timestamp, userName, "customer", $"'{nameTextbox.Text}', '{addressId}', '{(activeYes.Checked ? 1 : 0)}'");

            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
