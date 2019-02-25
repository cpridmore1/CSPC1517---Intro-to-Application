using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class FirstPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this method is executed on each and every pass of the page.
            //this method is executed before any of your event methods
        }

        protected void PressMe_Click(object sender, EventArgs e)
        {
            output.Text = "hello there " + yourname.Text;
        }
    }
}