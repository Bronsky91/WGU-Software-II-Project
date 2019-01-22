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

        public int createCountry(string timestamp, string userName)
        {
            // Take country text and create a country record - return id that was created for country for next insert\
            int countryId = DataHelper.createID("country");
            string countryInsert = $"INSERT INTO country VALUES ('{countryId}', '{countryTextbox.Text}', '{timestamp}', '{userName}', '{timestamp}', '{userName}')";

            MySqlConnection c = new MySqlConnection(DataHelper.conString);
            c.Open();
            MySqlCommand cmd = new MySqlCommand(countryInsert, c);
            cmd.ExecuteNonQuery();
            c.Close();
            return countryId;
        }

        public int createCity(int countryId, string timestamp, string userName)
        {
            // Take city and create a city record using country id - return city id for next insert
            int cityId = DataHelper.createID("city");
            string cityInsert = $"INSERT INTO city VALUES ('{cityId}', '{cityTextbox.Text}', '{countryId}', '{timestamp}', '{userName}', '{timestamp}', '{userName}')";

            MySqlConnection c = new MySqlConnection(DataHelper.conString);
            c.Open();
            MySqlCommand cmd = new MySqlCommand(cityInsert, c);
            cmd.ExecuteNonQuery();
            c.Close();
            return cityId;
        }

        public int createAddress(int cityId, string timestamp, string userName)
        {
            // Take address, zip, phone, cityId, and countryID to create an address record - return address id for next insert
            int addressId = DataHelper.createID("address");
            string addressInsert = $"INSERT INTO address" +
                $" VALUES ('{addressId}', '{addressTextbox.Text}', '', '{cityId}', '{zipTextbox.Text}', '{phoneTextbox.Text}', '{timestamp}', '{userName}', '{timestamp}', '{userName}')";

            MySqlConnection c = new MySqlConnection(DataHelper.conString);
            c.Open();
            MySqlCommand cmd = new MySqlCommand(addressInsert, c);
            cmd.ExecuteNonQuery();
            c.Close();
            return addressId;
        }

        public void createCustomer(int addressId, string timestamp, string userName)
        {
            // Take the name, active bool, and addressID to create a customer record
            int customerId = DataHelper.createID("customer");
            string customerInsert = $"INSERT INTO customer" +
                $" VALUES ('{customerId}', '{nameTextbox.Text}', '{addressId}', '{(activeYes.Checked ? 1 : 0)}', '{timestamp}', '{userName}', '{timestamp}', '{userName}')";

            MySqlConnection c = new MySqlConnection(DataHelper.conString);
            c.Open();
            MySqlCommand cmd = new MySqlCommand(customerInsert, c);
            cmd.ExecuteNonQuery();
            c.Close();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            string timestamp = DataHelper.createTimestamp();
            string userName = DataHelper.getCurrentUserName();

            int countryId = createCountry(timestamp, userName);
            int cityId = createCity(countryId, timestamp, userName);
            int addressId = createAddress(cityId, timestamp, userName);
            createCustomer(addressId, timestamp, userName);
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
