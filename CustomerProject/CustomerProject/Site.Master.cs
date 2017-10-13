using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;

namespace CustomerProject
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Language_MenuItemClick(Object sender, MenuEventArgs e)
        {
            switch_language(e.Item.Text);
        }

        void switch_language(String language)
        {
            switch (language)
            {
                case " German":
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("gr");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("gr");
                    break;

                case " English":
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-uk");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-uk");
                    break;

                default:
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-uk");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-uk");
                    break;
            };
        }
    }
}