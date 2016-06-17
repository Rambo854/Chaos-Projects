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
            //open a connection to the database and return it to the calling method
            string theConnString = "server=223.27.22.124;UserId=cosi121;password=darkSoulsFan5193;database=041114567DB";
            //Set up a MYSQL connection using the Db and username/password
            MySqlConnection conn = new MySqlConnection(theConnString);
            // Set up the dataset to hold the data
            DataSet ds = new DataSet();
            try
            {
                //open the connection
                conn.Open();
                //create a new adapter to talk to the database and pull back the info
                MySqlDataAdapter myAdapter = new MySqlDataAdapter("select * from account", theConnString);
                // with the data from the query populate the dataset so we can use it
                myAdapter.Fill(ds);

                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    //go into the first table[0] and loop down the rows and output the content of the first column
                    MessageBox.Show(ds.Tables[0].Rows[i].ItemArray[0].ToString());

                    Menu firstLink = new Menu();
                    firstLink.Show();
                    this.Hide();
                    MessageBox.Show("Welcome User!");
                }

            }
            catch (Exception)
            {
                //catch and throw an exception if we can't connect to the database
                throw;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);  //Exits application
        }
    }
}


//string username = textBox1.Text;    //username input
//string password = textBox2.Text;    //password input
//string error = "Username or password is incorrect"; //Wrong input error

//string correctUsername = "darkSoulsFan";
//string correctPassword = "apple12";

//if (username == correctUsername && password == correctPassword) //CORRECT INPUT
//{
//    Menu firstLink = new Menu();
//    firstLink.Show();
//    this.Hide();
//    MessageBox.Show("Welcome User!");
//}             

//else //WRONG INPUT
//{
//    MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//}  