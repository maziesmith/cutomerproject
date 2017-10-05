using CustomerProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerProject
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Customer c = new Customer("Tom", 2, "Nuernberg", 123456, "M");
 

            Create_Customer_Row(c);
        }

        public void Create_Customer_Row(Customer customer)
        {
            TableRow row = new TableRow();

            TableCell cellName = new TableCell();
            TableCell cellAddress = new TableCell();
            TableCell cellAge = new TableCell();
            TableCell cellGender = new TableCell();
            TableCell cellPhoneNumber = new TableCell();

            cellName.Text = customer.Name;
            cellAddress.Text = customer.Address;
            cellAge.Text = customer.Age.ToString();
            cellGender.Text = customer.Gender;
            cellPhoneNumber.Text = customer.PhoneNumber.ToString();

            row.Cells.Add(cellName);
            row.Cells.Add(cellGender);
            row.Cells.Add(cellPhoneNumber);
            row.Cells.Add(cellAge);
            row.Cells.Add(cellAddress);


            Table1.Rows.Add(row);
        }

        public void On_Add_Button_Clicked(Object sender, EventArgs e)
        {
         //open a dialog, add a new customer to the gui and insert it to the db
        }
       
    }
}