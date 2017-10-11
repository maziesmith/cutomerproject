using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomerProject.ViewModels;

namespace CustomerProject.User_Controls
{
    public partial class FormModals : System.Web.UI.UserControl
    {
        //public string Title = null;
        public string buttonValue = null;
        public string Name = null;
        public int Age = 0;
        public string Address = null;
        public int PhoneNumber = 0;
        public string Gender = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Title == null || Title == "")
                    modalTitle.Text = "Default Title";
            }
        }

        public Customer Customer
        {
            get; set;
        }

        public string Title
        {
            get { return modalTitle.Text; }
            set { modalTitle.Text = value; }
        }
    }
}