using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*
namespace CustomerProject.UserControls.Dialogs
{
    public partial class ConfirmationDialogControl : System.Web.UI.UserControl
    {
        public string Title = "TITLE";
        public string Message = "MESSAGE";

        //private static OkAction OnOkAction;



        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void initDialog(string CancelButtonText, string Title, string Message, String CancelButtonClass, String OkButtonClass)
        {
            CancelButton.Text = CancelButtonText;
            this.Title = Title;
            this.Message = Message;
            CancelButton.CssClass = CancelButtonClass;
            OkButton.CssClass = OkButtonClass;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);

        }

        public void initInfoDialog(string CancelButtonText, string Title, string Message)
        {
            initDialog(CancelButtonText, Title, Message, "btn btn-info", "hidden");
        }

        public void initConfirmDialog(string CancelButtonText, string OkButtonText, string Title, string Message, string script)//OkAction OnOkAction)
        {
            //  UserControls_DialogControl.OnOkAction = OnOkAction;
            initDialog(CancelButtonText, Title, Message, "btn btn-info", "btn btn-primary");
            OkButton.OnClientClick = script;
            OkButton.Text = OkButtonText;
        }

        public void initWarningDialog(string CancelButtonText, string OkButtonText, string Title, string Message, string script)//OkAction OnOkAction)
        {
            //  UserControls_DialogControl.OnOkAction = OnOkAction;
            initDialog(CancelButtonText, Title, Message, "btn btn-info", "btn btn-danger");
            OkButton.OnClientClick = script;
            OkButton.Text = OkButtonText;
        }
        
        protected void OnOkClicked(object sender, EventArgs e)
        {


            if (UserControls_DialogControl.OnOkAction != null)
                OnOkAction.OnOkButtonClicked();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal('toggle');", true);

        }

    }
}*/