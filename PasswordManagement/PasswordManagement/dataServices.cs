using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using System.Collections;

namespace PasswordManagement
{
    public class dataServices
    {
        private MySqlConnection openTheConnection()
        {
            //Open a connection to the database and return it
            string theConnString = "server=223.27.22.124;UserId=cosi121;password=darkSoulsFan5193;database=041114567DB";
            MySqlConnection conn = new MySqlConnection(theConnString);
            conn.Open();
            return conn;
        }

        public void loadGridView(String aQuery, DataGridView aGrid)
        {
            //Place the grid view into a sorted list so it can be passed through the accessDB method
            SortedList aList = new SortedList();
            aList.Add("DataGridView", aGrid);
            accessDB(aQuery, aList);
        }

        public void accessDB(String aQuery, SortedList aList)
        {
            //Open a connection to the database
            MySqlConnection conn = openTheConnection();

            try
            {
                //Create a command and plug in the query
                MySqlCommand commandAccess = conn.CreateCommand();
                commandAccess.CommandText = aQuery;

                //Explicitly conver the value to a DataGridView
                String firstKey = (String) aList.GetKey(0);

                if (firstKey == "DataGridView")
                {
                    //Explicitly conver the value to a DataGridView
                    DataGridView aGrid = (DataGridView)aList.GetByIndex(0);

                    //Call a method to get the data from the database
                    getFromDB(commandAccess, aGrid);
                }

                else
                {
                    alterDB(commandAccess, aList);
                }
            }

            catch (Exception e)
            {
                //Show the error message
                MessageBox.Show(e.Message);
            }

            finally
            {
                //Close the connnection if it remains open
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void getFromDB(MySqlCommand cmd, DataGridView aGridControl)
        {
            //Setup the new adapter and dataset
            MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            //Fill the adapter & connect datasource to the gridview
            adapt.Fill(ds);
            aGridControl.DataSource = ds.Tables[0].DefaultView;
        }

        private void alterDB(MySqlCommand cmd, SortedList dataList)
        {
            //Iterate through list and fill parameters
            for (int aCounter = 0; aCounter < dataList.Count; aCounter++)
            {
                cmd.Parameters.AddWithValue(Convert.ToString(dataList.GetKey(aCounter)), dataList.GetByIndex(aCounter));
            }

            //Run the Query
            cmd.ExecuteNonQuery();
        }
    }

    public class passwordServices : dataServices
    {
        public void loadAccountsData(DataGridView aGridControl)
        {            //Call a generic method to load a grid control from the results of a query
            loadGridView("Select * From Details", aGridControl);
        }

        public void updateAccountsData(SortedList dataList)
        {
            accessDB("Update Details Set acctPassword=@mAcctPassword, accountType=@mAcctType, acctUsername=@mAcctUsername, "
                + "email=@mEmail, phone=@mPhone, websiteURL=@mURL Where accountTypeID=@mAcctTypeID", dataList);
        }

        public void insertAccountsData(SortedList dataList)
        {
            accessDB("Insert into Details (acctPassword, accountType, accountTypeID, acctUsername, email, phone, websiteURL)"
                + "values(@mAcctPassword, @mAcctType, @mAcctTypeID, @mAcctUsername, @mEmail, @mPhone, @mURL)", dataList);
        }

        public void deleteAccountsData(SortedList dataList)
        {
            accessDB("Delete From Details Where accountTypeID=@mAcctTypeID", dataList);
        }
    }
}
