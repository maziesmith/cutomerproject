﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;
using System.ComponentModel;

namespace CustomerProject.UserControls.Dialogs
{
    public partial class ConfirmationDialog : System.Web.UI.UserControl
    {


        public String Titel { get; set; } = "THIS IS THE TITLE";
        public String Message { get; set; } = "THIS IS THE MESSAGE";
        public String CancelButton { get; set; }
        public String OkButton { get; set; } = "OK";

       



        protected void Page_Load(object sender, EventArgs e)
        {

        }


        
    }
}