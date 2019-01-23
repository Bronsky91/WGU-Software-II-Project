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
            CreateCustomer createCustomer = new CreateCustomer();
            createCustomer.Show();
        }

        private void updateCustomerButton_Click(object sender, EventArgs e)
        {
            UpdateCustomer updateCustomer = new UpdateCustomer();
            updateCustomer.Show();
        }

        private void deleteCustomerButton_Click(object sender, EventArgs e)
        {
            DeleteCustomer deleteCustomer = new DeleteCustomer();
            deleteCustomer.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            loginForm.Close();
        }
    }
}
