using System;
using System.IO;
using System.Net;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Web.UI;
using System.Xml;
using System.Security.Cryptography;
using System.CodeDom;

namespace XMLService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        string memberFile = HttpContext.Current.Server.MapPath("~/App_Data/Members.xml");
        const string successMsg = "SUCCESSFUL_MEMBER_ADDITION";
        const string newFileMsg = "FILE_DNE__NEW_FILE_CREATED";
        const string foundMsg = "MEMBER_FOUND_SUCCESSFULLY";
        const string dneMsg = "MEMBER_DOES_NOT_EXIST";

        public string AddMember(string memberName, string hashedPassword, DateTime date)
        {
            // Add XML to file
            XDocument xmlDoc = XDocument.Load(memberFile);
            hashedPassword = HashPassword(hashedPassword);
            //// Structure:
            //// Member
            ////  Username
            ////  Password
            ////  Since
            XElement MEMBER = new XElement("Member");
            XElement USERNAME = new XElement("Username", memberName);
            XElement PASSWORD = new XElement("Password", hashedPassword);
            XElement SINCE = new XElement("Since", date.ToString());

            MEMBER.Add(USERNAME);
            MEMBER.Add(PASSWORD);
            MEMBER.Add(SINCE);

            XElement rootElement = xmlDoc.Element("Members");
            rootElement.Add(MEMBER);

            if (File.Exists(memberFile))
            {
                File.Delete(memberFile);
            }
            else
            {
                File.Create(memberFile).Close();
            }
            xmlDoc.Save(memberFile);

            return successMsg;
        }
        public string DoesMemberExist(string memberName)
        {
            // (1) Check if "Members.xml" exists in App_Data
            // (2) y: load file and loop through members to find memberName
            // (3) n: create file, return false

            if (!File.Exists(memberFile))
            {
                // (3)
                using (XmlWriter writer = XmlWriter.Create(memberFile))
                {
                    writer.WriteStartElement("Members");
                    writer.WriteEndElement();
                    writer.Flush();
                }

                return newFileMsg;
            } else
            {
                // (2) Load File
                XElement rootNode = XElement.Load(memberFile);

                foreach (XElement node in rootNode.Elements())
                {
                    // node is each member, go one step further
                    XElement nameNode = node.Element("Username");

                    if (nameNode.Value.Equals(memberName))
                    {
                        return foundMsg;
                    }
                }
                return dneMsg;
            }
        }

        //public MemberDetails AskMemberDetails(string name, string password)
        //{
        //    // Turn on login control?
        //    MemberDetails returnVal = new MemberDetails();
        //    returnVal.MemberName = name;
        //    returnVal.HashedPassword = HashPassword(password);
        //    returnVal.SinceDate = DateTime.Now;
        //    AddMember(returnVal.MemberName, returnVal.HashedPassword, returnVal.SinceDate);
        //    return returnVal;
        //}

        public string HashPassword(string password)
        {
            // Create a SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public string Login(string username, string password)
        {
            if (!DoesMemberExist(username).Equals(foundMsg))
            {
                return "USER_DOES_NOT_EXIST";
            }
            string hashedPassword = HashPassword(password);
            // (2) Load File
            XElement rootNode = XElement.Load(memberFile);

            foreach (XElement node in rootNode.Elements())
            {
                // node is each member, go one step further
                XElement nameNode = node.Element("Username");
                XElement passwordNode = node.Element("Password");
                if (nameNode.Value.Equals(username) && passwordNode.Value.Equals(hashedPassword))
                {
                    return "LOGIN_SUCCESSFUL";
                }
            }
            return "PASSWORD_INCORRECT";
        }
    }
}
