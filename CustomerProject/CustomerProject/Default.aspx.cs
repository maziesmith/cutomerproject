using CustomerProject.db;
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

            using (var db = new Custdb())
            {
         
                foreach(CustomerTableModel ctm in db.Customers)
                {
                   
                    Create_Customer_Row(new Customer(ctm));
                }

               

            }
   
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
            cellGender.Text = customer.CustomerGender.ToString();
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
            CustomerTableModel ctm = new CustomerTableModel();
            ctm.Name = TBName.Text;
            ctm.Age = Convert.ToInt16(TBAge.Text);
            ctm.Address = TBAddress.Text;
            ctm.PhoneNumber = TBNumber.Text;
            int gender = Convert.ToInt32(DDLGender.SelectedValue);

            if (gender == 0)
                ctm.Gender = true;
            else
                ctm.Gender = false;


            using (var db = new Custdb())
            {

                db.Customers.Add(ctm);
                db.SaveChanges();
                


            }

        }


    }
}