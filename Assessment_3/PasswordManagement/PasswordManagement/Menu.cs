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

            //Edit Edit_Form = new Edit();
            //Edit_Form.parent = this;
            //Edit_Form.ShowDialog();
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
            
            //Add Add_Form = new Add();
            //Add_Form.parent = this;
            //Add_Form.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
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
            MessageBox.Show
                (
                    "Do you want to delete this account?",
                    "Delete Account?",
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question
                );
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            int rowIndex = dgvAccounts.CurrentCell.RowIndex;
            LabelAcctID.Text = dgvAccounts.Rows[rowIndex].Cells["typeID"].Value.ToString();
            txtAcctType.Text = dgvAccounts.Rows[rowIndex].Cells["accountType"].Value.ToString();
            txtUsername.Text = dgvAccounts.Rows[rowIndex].Cells["acctUsername"].Value.ToString();
            txtPassword.Text = dgvAccounts.Rows[rowIndex].Cells["acctPassword"].Value.ToString();
            txtEmail.Text = dgvAccounts.Rows[rowIndex].Cells["email"].Value.ToString();
            txtPhone.Text = dgvAccounts.Rows[rowIndex].Cells["phone"].Value.ToString();
            txtUrl.Text = dgvAccounts.Rows[rowIndex].Cells["websiteURL"].Value.ToString();
        }
    }
}
