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
using System.Collections;

namespace PasswordManagement
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            loadDataGrid();
        }

        private void loadDataGrid()
        {
            passwordServices ds = new passwordServices();
            ds.loadAccountsData(dgvAccounts);
            ds = null;

            DataGridViewColumn column0 = dgvAccounts.Columns[0];
            column0.Width = 90;

            DataGridViewColumn column1 = dgvAccounts.Columns[1];
            column1.Width = 90;

            DataGridViewColumn column2 = dgvAccounts.Columns[2];
            column2.Width = 120;

            DataGridViewColumn column3 = dgvAccounts.Columns[3];
            column3.Width = 120;

            DataGridViewColumn column4 = dgvAccounts.Columns[4];
            column4.Width = 250;

            DataGridViewColumn column5 = dgvAccounts.Columns[5];
            column5.Width = 120;

            DataGridViewColumn column6 = dgvAccounts.Columns[6];
            column6.Width = 200;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //Create a SortedList containing the data
            SortedList dataList = new SortedList();

            //Add the Key Values pairs from the form
            dataList.Add("@mAcctTypeID", this.LabelAcctID.Text);
            dataList.Add("@mAcctType", this.txtAcctType.Text);
            dataList.Add("@mAcctUsername", this.txtUsername.Text);
            dataList.Add("@mAcctPassword", this.txtPassword.Text);
            dataList.Add("@mEmail", this.txtEmail.Text);
            dataList.Add("@mPhone", this.txtPhone.Text);
            dataList.Add("@mURL", this.txtUrl.Text);

            //Create a new dataservice object, update the movie details and destroy the object
            passwordServices ds = new passwordServices();
            ds.updateAccountsData(dataList);
            ds = null;

            //Call the load method to update the data in the table
            loadDataGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Create a SortedList containing the data
            SortedList dataList = new SortedList();

            //Add the Key Values pairs from the form
            dataList.Add("@mAcctTypeID", this.LabelAcctID.Text);
            dataList.Add("@mAcctType", this.txtAcctType.Text);
            dataList.Add("@mAcctUsername", this.txtUsername.Text);
            dataList.Add("@mAcctPassword", this.txtPassword.Text);
            dataList.Add("@mEmail", this.txtEmail.Text);
            dataList.Add("@mPhone", this.txtPhone.Text);
            dataList.Add("@mURL", this.txtUrl.Text);

            //Create a new dataservice object, update the movie details and destroy the object
            passwordServices ds = new passwordServices();
            ds.insertAccountsData(dataList);
            ds = null;

            //Call the load method to update the data in the table
            loadDataGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {   
            
            MessageBox.Show
            (
                "Do you want to delete this account?",
                "Delete Account?",
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question
            );

            //Create a SortedList containing the data
            SortedList dataList = new SortedList();

            //Add the key value ID pair from the form that will link to the query
            dataList.Add("@mAcctTypeID", this.LabelAcctID.Text);

            //Create a new dataservives object, update the movie details and destroy the object
            passwordServices ds = new passwordServices();
            ds.deleteAccountsData(dataList);
            ds = null;

            //Call the load method to update the data in the table
            loadDataGrid();
            
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            
        }

        private void dgvAccounts_SelectionChanged(object sender, EventArgs e)
        {
            int rowIndex = dgvAccounts.CurrentCell.RowIndex;
            LabelAcctID.Text = dgvAccounts.Rows[rowIndex].Cells["accountTypeID"].Value.ToString();
            txtAcctType.Text = dgvAccounts.Rows[rowIndex].Cells["accountType"].Value.ToString();
            txtUsername.Text = dgvAccounts.Rows[rowIndex].Cells["acctUsername"].Value.ToString();
            txtPassword.Text = dgvAccounts.Rows[rowIndex].Cells["acctPassword"].Value.ToString();
            txtEmail.Text = dgvAccounts.Rows[rowIndex].Cells["email"].Value.ToString();
            txtPhone.Text = dgvAccounts.Rows[rowIndex].Cells["phone"].Value.ToString();
            txtUrl.Text = dgvAccounts.Rows[rowIndex].Cells["websiteURL"].Value.ToString();
        }
    }
}
