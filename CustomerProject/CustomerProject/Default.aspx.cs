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
            if (IsPostBack)
            {
                /*Customer c = new Customer(
                    String.Format("{0}", Request.Form["name"]),
                    int.Parse(String.Format("{0}", Request.Form["age"])),
                    String.Format("{0}", Request.Form["address"]),
                    long.Parse(String.Format("{0}", Request.Form["number"])),
                    String.Format("{0}", Request.Form["gender"]));*/
            }

            reloadTable();
        }

        // public methods
        public void OnAddButtonClicked(Object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "AddButtonModal", "$('#AddButtonModal').modal();", true);
            upModal.Update();

            //reloadTable();
        }

        public void AddCustomer(Object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Submitted Form");
        }
       
        // private methods
        private void reloadTable()
        {
            CustomerTable.Rows.Clear();
            List<CustomerDetail> customers = DataLayer.GetCustomers();

            foreach (CustomerDetail customerEntity in customers)
            {
                Customer c = CustomerModelMapper.convertEntityToCustomer(customerEntity);
                createCustomerRow(c);
            }
        }

        private void createCustomerRow(Customer customer)
        {
            TableRow row = new TableRow();

            TableCell cell1 = new TableCell();
            TableCell cell2 = new TableCell();
            TableCell cell3 = new TableCell();
            TableCell cell4 = new TableCell();
            TableCell cell5 = new TableCell();
            TableCell cell6 = new TableCell();

            cell1.Text = customer.Name;
            cell2.Text = customer.Gender;
            cell3.Text = customer.PhoneNumber.ToString();
            cell4.Text = customer.Age.ToString();
            cell5.Text = customer.Address;
            /*cell6.Text = "<asp:LinkButton runat = \"server\" CssClass = \"btn btn-primary addbutton\" >< span class=\"glyphicon glyphicon-edit\" aria -hidden=\"true\" ></span>  Edit" +
                         "</asp:LinkButton>" +
                         "<asp:LinkButton runat = \"server\" CssClass =\"btn btn-primary addbutton\">" +
                         "<span class=\"glyphicon glyphicon-minus\" aria-hidden=\"true\"></span>  Delete" +
                         "</asp:LinkButton>";*/

            row.Cells.Add(cell1);
            row.Cells.Add(cell2);
            row.Cells.Add(cell3);
            row.Cells.Add(cell4);
            row.Cells.Add(cell5);
            row.Cells.Add(cell6);

            CustomerTable.Rows.Add(row);
        }
    }
}