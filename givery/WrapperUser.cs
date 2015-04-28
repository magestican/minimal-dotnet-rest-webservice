
using System.Runtime.Serialization;
namespace givery
{
    enum UserTypes
    {
        Student = 1,
        Company = 2

    }

    [DataContract]
    class WrapperUser
    {

        decimal Id;
        string Name;
        string Password;
        string Email;
        int GroupId;
        string Token;


        [DataMember]
        public string token
        {
            get { return Token; }
            set { Token = value; }
        }


        [DataMember]
        public decimal id
        {
            get { return Id; }
            set { Id = value; }
        }
        [DataMember]
        public string name
        {
            get { return Name; }
            set { Name = value; }
        }
        [DataMember]
        public string password
        {
            get { return Password; }
            set { Password = value; }
        }
        [DataMember]
        public string email
        {
            get { return Email; }
            set { Email = value; }
        }
        [DataMember]
        public int group
        {
            get { return GroupId; }
            set { GroupId = value; }
        }

    }
}
