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
        public Login loginForm;
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
            UpdateCustomer UpdateCustomer = new UpdateCustomer();
            UpdateCustomer.Show();

        }

        private void deleteCustomerButton_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            loginForm.Close();
        }
    }
}
