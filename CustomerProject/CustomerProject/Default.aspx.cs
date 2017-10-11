using CustomerProject.DAL;
using CustomerProject.Functions;
using CustomerProject.User_Controls;
using CustomerProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerProject
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            runScript("loadDataTable('CustomerTable');");
        }

        /*private bool validateCustomerDetails(
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
        }*/

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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            FormModals.Title = "Add Customer";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "openAddModal", "openAddModal();", true);
        }
    }
}