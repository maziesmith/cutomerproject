using CustomerProject.DAL;
using CustomerProject.Functions;
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
            using (var db = new CustomerViewerEntities())
            {
                List<CustomerDetail> customers = db.CustomerDetails.ToList();

                foreach (CustomerDetail customerEntity in customers)
                {
                    CustomerModelMapper cmp = new CustomerModelMapper();
                    Customer c = cmp.convertEntityToCustomer(customerEntity);
                    Create_Customer_Row(c);
                }
            }
        }

        public void Create_Customer_Row(Customer customer)
        {
            TableRow row = new TableRow();

            TableCell cell1 = new TableCell();
            TableCell cell2 = new TableCell();
            TableCell cell3 = new TableCell();
            TableCell cell4 = new TableCell();
            TableCell cell5 = new TableCell();
            TableCell cell6 = new TableCell();
            TableCell cell7 = new TableCell();

            cell1.Text = customer.Name;
            cell2.Text = customer.Gender;
            cell3.Text = customer.PhoneNumber.ToString();
            cell4.Text = customer.Age.ToString();
            cell5.Text = customer.Address;
            cell6.Text = "<button class='btn btn-sm' runat='server' id='editBtn'>" +
                                "<span class='glyphicon glyphicon-pencil spinning'></span>" +
                          "</button>";
            cell7.Text = "<button class='btn btn-sm' runat='server' id='deleteBtn'>" +
                                "<span class='glyphicon glyphicon-trash spinning'></span>" +
                          "</button>";


            row.Cells.Add(cell1);
            row.Cells.Add(cell2);
            row.Cells.Add(cell3);
            row.Cells.Add(cell4);
            row.Cells.Add(cell5);
            row.Cells.Add(cell6);
            row.Cells.Add(cell7);

            Table1.Rows.Add(row);
        }

        public void On_Add_Button_Clicked(Object sender, EventArgs e)
        {
         //open a dialog, add a new customer to the gui and insert it to the db
        }
       
    }
}