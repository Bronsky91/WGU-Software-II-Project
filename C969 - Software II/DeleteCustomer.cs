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
    public partial class DeleteCustomer : Form
    {
        public DeleteCustomer()
        {
            InitializeComponent();
        }

        public static Dictionary<string, string> customerDetails = new Dictionary<string, string>();

        public bool deleteCustomer()
        {
            MySqlConnection c = new MySqlConnection(DataHelper.conString);
            c.Open();

            // Deletes Customer 
            string recUpdate = $"DELETE FROM customer" +
                $" WHERE customerName = '{customerDetails["customerName"]}'";
            MySqlCommand cmd = new MySqlCommand(recUpdate, c);
            int customerUpdated = cmd.ExecuteNonQuery();

            // Deletes Address 
            recUpdate = $"DELETE FROM address" +
                $" WHERE address = '{customerDetails["address"]}'";
            cmd = new MySqlCommand(recUpdate, c);
            int addressUpdated = cmd.ExecuteNonQuery();

            // Deletes City 
            recUpdate = $"DELETE FROM city" +
                $" WHERE city = '{customerDetails["city"]}'";
            cmd = new MySqlCommand(recUpdate, c);
            int cityUpdated = cmd.ExecuteNonQuery();

            // Deletes Country 
            recUpdate = $"DELETE FROM country" +
                $" WHERE country = '{customerDetails["country"]}'";
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
            // Searches database for customer and displays data in labels
            int customerId = DataHelper.findCustomer(searchBar.Text);
            if (customerId != 0)
            {
                customerDetails = DataHelper.getCustomerDetails(customerId);
                nameLabel.Text = customerDetails["customerName"];
                phoneLabel.Text = customerDetails["phone"];
                addressLabel.Text = customerDetails["address"];
                cityLabel.Text = customerDetails["city"];
                zipLabel.Text = customerDetails["zip"];
                countryLabel.Text = customerDetails["country"];
                if (customerDetails["active"] == "True")
                    activeLabel.Text = "True";
                else
                    activeLabel.Text = "False";
            }
            else
            {
                MessageBox.Show("Unable to find a customer by that name");
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            // Gives user confirmation dialog box to confirm deletion
            DialogResult confirmDelete = MessageBox.Show("Are you sure you want to delete this contact?", "Deletion Confirm", MessageBoxButtons.YesNo);
            if (confirmDelete == DialogResult.Yes)
            {
                // Deletes customer records
                if (deleteCustomer())
                    MessageBox.Show($"Customer: {customerDetails["customerName"]} was successfully deleted");
                else
                    MessageBox.Show($"Customer: {customerDetails["customerName"]} could not be deleted");
            }
            
            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
