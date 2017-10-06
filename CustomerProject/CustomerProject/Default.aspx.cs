using CustomerProject.DAL;
using CustomerProject.Functions;
using CustomerProject.ViewModels;
using System;
using System.Collections.Generic;
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
                addOrEditCustomer();
            }

            reloadTable();
        }

        // private methods
        private void reloadTable()
        {
            //CustomerTable.Rows.Clear();
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

            CustomerTable.Rows.Add(row);
        }

        private Customer getCustomerFromForm()
        {
            try
            {
                string name = String.Format("{0}", Request.Form["name"]);
                int age = int.Parse(String.Format("{0}", Request.Form["age"]));
                string address = String.Format("{0}", Request.Form["address"]);
                long phoneNumber = long.Parse(String.Format("{0}", Request.Form["number"]));
                string gender = String.Format("{0}", Request.Form["gender"]);

                string validationMessage;

                if (validateCustomerDetails(name, age, address, phoneNumber, gender, out validationMessage))
                {
                    return new Customer(name, age, address, phoneNumber, gender);
                }
                else
                {
                    displayAlert(validationMessage);
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        private bool validateCustomerDetails(
            string name,
            int age,
            string address,
            long phoneNumber,
            string gender,
            out String validationMessage)
        {
            validationMessage = "";

            if (String.IsNullOrEmpty(name))
            {
                validationMessage = "Name is empty.";
            }
            else if (String.IsNullOrEmpty(address))
            {
                validationMessage = "Address is empty.";
            }
            else if (age <= 0 || age > 100)
            {
                validationMessage = "Age is invalid.";
            }
            else if (gender != "m" && gender != "f")
            {
                validationMessage = "Gender is invalid.";
            }

            return String.IsNullOrEmpty(validationMessage);
        }

        private void displayAlert(string message)
        {
            runScript(String.Format("alert('{0}')", message));
        }

        private void runScript(string script)
        {
            ScriptManager.RegisterStartupScript(
                this,
                typeof(string),
                Guid.NewGuid().ToString(),
                String.Format(script),
                true);
        }

        private void addOrEditCustomer()
        {
            Customer c = getCustomerFromForm();

            if (c != null)
            {
                try
                {
                    DataLayer.AddCustomer(CustomerModelMapper.convertCustomerToEntity(c));
                }
                catch (Exception ex)
                {
                    displayAlert(ex.Message);
                }
            }
            else
            {
                displayAlert("Invalid Customer");
            }
        }
    }
}