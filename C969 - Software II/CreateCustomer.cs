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
        
        private void createButton_Click(object sender, EventArgs e)
        {
            string timestamp = DataHelper.createTimestamp();
            string userName = DataHelper.getCurrentUserName();

            // TODO: Create checks to see if fields are blank before running these creates.
            int countryId = DataHelper.createRecord(timestamp, userName, "country", $"'{countryTextbox.Text}'");
            int cityId = DataHelper.createRecord(timestamp, userName, "city", $"'{cityTextbox.Text}', '{countryId}'");
            int addressId = DataHelper.createRecord(timestamp, userName, "address", $"'{addressTextbox.Text}', '', '{cityId}', '{zipTextbox.Text}', '{phoneTextbox.Text}'");
            DataHelper.createRecord(timestamp, userName, "customer", $"'{nameTextbox.Text}', '{addressId}', '{(activeYes.Checked ? 1 : 0)}'");

            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
