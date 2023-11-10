using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp_A6
{
    public partial class Login : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogInButton_Click(object sender, EventArgs e)
        {
            HttpCookie userCookie = new HttpCookie("User");
            userCookie["uName"] = usernameEntry.Text;
            userCookie["uPass"] = passwordEntry.Text;
            userCookie.Expires = DateTime.Now.AddMonths(6);
            Response.Cookies.Add(userCookie);
            /******** APP SETTINGS WRITE CODE ********/

            //System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/"); // Open Web.config file

            //// Create a new element into appSettings.
            //int index = System.Configuration.ConfigurationManager.AppSettings.Count;
            //string newKey = usernameEntry.Text; // from textbox
            //string newValue = passwordEntry.Text; // from textbox

            //// Modify the appSettings in Web.config file.
            //config.AppSettings.Settings.Add(newKey, newValue);
            //// Save the changes into the Web.config file.
            //config.Save(System.Configuration.ConfigurationSaveMode.Modified);
        }
    }
}