using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Net;

namespace WebApp_A6
{
    public partial class About : Page
    {
        string pageUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            string saveToLocation = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, @"..\WebApp_A6\App_Data\Members.xml");

            // On load, check if a user is logged in currently
            // If they arent, ask for a username and a password
            // then check the XML file

            XDocument xmlDoc;

            // If there is no user, we are here
            // Display the login control and wait for postback?
            if (pageUser == null)
            {
                MultiView.SetActiveView(LoginControlWindow);
                CheckCookie.Text = "Please Login";
            } else
            {
                // Search XML File, read username, populate page

                if (!File.Exists(Server.MapPath("~/App_Data/Members.xml")))
                {
                    File.CreateText(Server.MapPath("~/App_Data/Members.xml"));
                    // Add XML to file
                    xmlDoc = XDocument.Load(Server.MapPath("~/App_Data/Members.xml"));

                    //// Structure:
                    //// Member
                    ////  Username
                    ////  Password
                    ////  Since
                    XElement MEMBER = new XElement("MEMBER");
                    XElement USERNAME = new XElement("Username", LoginTable.Attributes["uName"]);
                    XElement PASSWORD = new XElement("Password", Attributes["uPass"]);
                    XElement SINCE = new XElement("Since", DateTime.Now.ToString());

                    MEMBER.Add(USERNAME);
                    MEMBER.Add(PASSWORD);
                    MEMBER.Add(SINCE);

                    XElement rootElement = xmlDoc.Element("Members");
                    rootElement.Add(MEMBER);
                    // Read new modified XDocument and save it to a new file in App_Data
                    if (File.Exists(Server.MapPath("~/App_Data/Members.xml")))
                    {
                        File.Delete(Server.MapPath("~/App_Data/Members.xml"));
                    }
                    else
                    {
                        File.Create(Server.MapPath("~/App_Data/Members.xml")).Close();
                    }
                    xmlDoc.Save(Server.MapPath("~/App_Data/Members.xml"));

                    return;
                }

                // Load and Read XML
                xmlDoc = XDocument.Load(Server.MapPath("~/App_Data/Members.xml"));
                foreach (XElement member in xmlDoc.Root.Elements())
                {
                    if (member.Name == pageUser)
                    {
                        CheckCookie.Text = "Page User has been set - Hello, " + pageUser;
                        MultiView.SetActiveView(AccountManagement);
                        return;
                    }
                }
                CheckCookie.Text = "Welcome, New User!";
                MultiView.SetActiveView(AccountManagement);
            }
        }

        protected void LogOutButton_Click(object sender, EventArgs e)
        {
            // Delete cookie and reload page
            Request.Cookies.Remove("User");
            Response.Cookies.Remove("User");
            pageUser = null;
            Page_Load(this, null);
        }
    }
}