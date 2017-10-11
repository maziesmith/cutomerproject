using System;

namespace CustomerProject.User_Controls
{
    public partial class FormModals : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (String.IsNullOrEmpty(Title))
                {
                    modalTitle.Text = "Default Title";
                }
            }
        }

        public string Title
        {
            get { return modalTitle.Text; }
            set { modalTitle.Text = value; }
        }
    }
}