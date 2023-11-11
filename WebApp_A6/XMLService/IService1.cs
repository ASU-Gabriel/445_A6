using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Configuration;

namespace XMLService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string AddMember(string memberName, string hashedPassword, DateTime date);

        [OperationContract]
        string DoesMemberExist(string memberName);

        //[OperationContract]
        //MemberDetails AskMemberDetails(string name, string pass);

        [OperationContract]
        string HashPassword(string data);

        [OperationContract]
        string Login(string username, string password);

        // TODO: Add your service operations here

    }
    [DataContract]
    public class MemberDetails
    {
        private string _name;
        private string _hashedPassword;
        private DateTime _date;
        public string MemberName {  get => _name; set => _name = value; }
        public string HashedPassword { get => _hashedPassword; set => _hashedPassword = value; }
        public DateTime SinceDate { get => _date; set => _date = value; }
    }
}
