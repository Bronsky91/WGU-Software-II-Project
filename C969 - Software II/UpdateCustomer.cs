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
    public partial class UpdateCustomer : Form
    {
        public UpdateCustomer()
        {
            InitializeComponent();
        }

        public static Dictionary<string, string> cForm = new Dictionary<string, string>();

        static public int FindCustomer(string search)
        {
            int customerId;
            string query;
            if (int.TryParse(search, out customerId))
            {
                query = $"SELECT customerId FROM customer WHERE customerId = '{search.ToString()}'";
            }
            else
            {
                query = $"SELECT customerId FROM customer WHERE customerName LIKE '{search}'";
            }
            MySqlConnection c = new MySqlConnection(DataHelper.conString);
            c.Open();
            MySqlCommand cmd = new MySqlCommand(query, c);
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                rdr.Read();
                customerId = Convert.ToInt32(rdr[0]);
                rdr.Close(); c.Close();
                return customerId;
            }
            return 0;
        }

        static public Dictionary<string, string> getCustomerDetails(int customerId)
        {
            string query = $"SELECT * FROM customer WHERE customerId = '{customerId.ToString()}'";
            MySqlConnection c = new MySqlConnection(DataHelper.conString);
            c.Open();
            MySqlCommand cmd = new MySqlCommand(query, c);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();

            Dictionary<string, string> customerDict = new Dictionary<string, string>();
            // Customer Table Details
            customerDict.Add("customerName", rdr[1].ToString());
            customerDict.Add("addressId", rdr[2].ToString());
            customerDict.Add("active", rdr[3].ToString());
            rdr.Close();

            query = $"SELECT * FROM address WHERE addressId = '{customerDict["addressId"]}'";
            cmd = new MySqlCommand(query, c);
            rdr = cmd.ExecuteReader();
            rdr.Read();

            // Address Table Details
            customerDict.Add("address", rdr[1].ToString());
            customerDict.Add("cityId", rdr[3].ToString());
            customerDict.Add("zip", rdr[4].ToString());
            customerDict.Add("phone", rdr[5].ToString());
            rdr.Close();

            query = $"SELECT * FROM city WHERE cityId = '{customerDict["cityId"]}'";
            cmd = new MySqlCommand(query, c);
            rdr = cmd.ExecuteReader();
            rdr.Read();

            // City Table Details
            customerDict.Add("city", rdr[1].ToString());
            customerDict.Add("countryId", rdr[2].ToString());
            rdr.Close();

            query = $"SELECT * FROM country WHERE countryId = '{customerDict["countryId"]}'";
            cmd = new MySqlCommand(query, c);
            rdr = cmd.ExecuteReader();
            rdr.Read();

            // Country Table Details
            customerDict.Add("country", rdr[1].ToString());
            rdr.Close();
            c.Close();

            return customerDict;
        }

        public bool updateCustomer(Dictionary<string, string> updatedForm)
        {
            MySqlConnection c = new MySqlConnection(DataHelper.conString);
            c.Open();

            // Updates Customer Table
            string recUpdate = $"UPDATE customer" +
                $" SET customerName = '{updatedForm["customerName"]}', active = '{updatedForm["active"]}', lastUpdate = '{DataHelper.createTimestamp()}', lastUpdateBy = '{DataHelper.getCurrentUserName()}'" +
                $" WHERE customerName = '{cForm["customerName"]}'";
            MySqlCommand cmd = new MySqlCommand(recUpdate, c);
            int customerUpdated = cmd.ExecuteNonQuery();

            // Updates Address Table
            recUpdate = $"UPDATE address" +
                $" SET address = '{updatedForm["address"]}', postalCode = '{updatedForm["zip"]}', phone = '{updatedForm["phone"]}', lastUpdate = '{DataHelper.createTimestamp()}', lastUpdateBy = '{DataHelper.getCurrentUserName()}'" +
                $" WHERE address = '{cForm["address"]}'";
            cmd = new MySqlCommand(recUpdate, c);
            int addressUpdated = cmd.ExecuteNonQuery();

            // Updates City Table
            recUpdate = $"UPDATE city" +
                $" SET city = '{updatedForm["city"]}', lastUpdate = '{DataHelper.createTimestamp()}', lastUpdateBy = '{DataHelper.getCurrentUserName()}'" +
                $" WHERE city = '{cForm["city"]}'";
            cmd = new MySqlCommand(recUpdate, c);
            int cityUpdated = cmd.ExecuteNonQuery();

            // Updates Country Table
            recUpdate = $"UPDATE country" +
                $" SET country = '{updatedForm["country"]}', lastUpdate = '{DataHelper.createTimestamp()}', lastUpdateBy = '{DataHelper.getCurrentUserName()}'" +
                $" WHERE country = '{cForm["country"]}'";
            cmd = new MySqlCommand(recUpdate, c);
            int countryUpdated = cmd.ExecuteNonQuery();

          c.Close();

            if (customerUpdated != 0 && addressUpdated != 0 && cityUpdated != 0 && countryUpdated != 0)
                return true;
            else
                return false;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            int customerId = FindCustomer(searchBar.Text);
            if (customerId != 0)
            {
                cForm = getCustomerDetails(customerId);
                nameTextbox.Text = cForm["customerName"];
                phoneTextbox.Text = cForm["phone"];
                addressTextbox.Text = cForm["address"];
                cityTextbox.Text = cForm["city"];
                zipTextbox.Text = cForm["zip"];
                countryTextbox.Text = cForm["country"];
                if (cForm["active"] == "True")
                    activeYes.Checked = true;
                else
                    activeNo.Checked = true;
            }
            else
            {
                MessageBox.Show("Unable to find a customer by that name");
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {

            Dictionary<string, string> updatedForm = new Dictionary<string, string>();
            updatedForm.Add("customerName", nameTextbox.Text);
            updatedForm.Add("phone", phoneTextbox.Text);
            updatedForm.Add("address", addressTextbox.Text);
            updatedForm.Add("city", cityTextbox.Text);
            updatedForm.Add("zip", zipTextbox.Text);
            updatedForm.Add("country", countryTextbox.Text);
            updatedForm.Add("active", activeYes.Checked ? "1" : "0");

            if (updateCustomer(updatedForm))
            {
                MessageBox.Show("Update Complete!");
            }
            else
            {
                MessageBox.Show("Update Could not complete");
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
