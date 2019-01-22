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
using System.Globalization;

namespace C969___Software_II
{
    public partial class Login : Form
    {
        public string errorMessage = "The username and password did not match.";

        public Login()
        {
            InitializeComponent();
       
            if (CultureInfo.CurrentCulture.LCID == 2058)
            {
                titleLabel.Text = "Por favor inicie sesión abajo";
                usernameLabel.Text = "Nombre de usuario";
                passwordLabel.Text = "Contraseña";
                loginButton.Text = "Iniciar sesión";
                cancelButton.Text = "Cancelar";
                errorMessage = "El nombre de usuario y la contraseña no coinciden.";
            }
        }

        static public int UserFound(string userName, string password)
        {
            string connectionString = "server=52.206.157.109 ;database=U05jyp;uid=U05jyp;pwd=53688524521;";
            MySqlConnection c = new MySqlConnection(connectionString);
            c.Open();
            MySqlCommand cmd = new MySqlCommand($"SELECT userId FROM user WHERE userName = '{userName}' AND password = '{password}'", c);
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                rdr.Read();
                DataHelper.setCurrentUserId(Convert.ToInt32(rdr[0]));
                DataHelper.setCurrentUserName(userName);
                rdr.Close(); c.Close();
                return DataHelper.getCurrentUserId();
            }
            return 0;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (UserFound(username.Text, password.Text) != 0)
            {
                this.Hide();
                MainForm MainForm = new MainForm();
                MainForm.Show();
            }
            else
            {
                MessageBox.Show(errorMessage);
                password.Text = "";
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
