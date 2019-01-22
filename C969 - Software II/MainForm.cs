using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969___Software_II
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void createCustomerButton_Click(object sender, EventArgs e)
        {
            CreateCustomer CreateCustomer = new CreateCustomer();
            CreateCustomer.Show();
        }

        private void updateCustomerButton_Click(object sender, EventArgs e)
        {

        }

        private void deleteCustomerButton_Click(object sender, EventArgs e)
        {

        }
    }
}
