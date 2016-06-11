using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManagement
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;    //username input
            string password = textBox2.Text;    //password input
            string error = "Username or password is incorrect"; //Wrong input error

            string correctUsername = "darkSoulsFan";
            string correctPassword = "apple12";

            if (username == correctUsername && password == correctPassword) //CORRECT INPUT
            {
                Menu firstLink = new Menu();
                firstLink.Show();
                this.Hide();
                MessageBox.Show("Welcome User!");
            }             

            else //WRONG INPUT
            {
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);  //Exits application
        }
    }
}
