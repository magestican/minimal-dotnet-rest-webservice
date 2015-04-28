
using System;
using System.Runtime.Serialization;

namespace givery
{
    [DataContract]
    class WrapperEvent
    {
        decimal Id;
        int UserId;
        string Name;
        DateTime StartDate;

        [DataMember]
        public decimal id
        {
            get { return Id; }
            set { Id = value; }
        }
        [DataMember]
        public int userId
        {
            get { return UserId; }
            set { UserId = value; }
        }
        [DataMember]
        public string name
        {
            get { return Name; }
            set { Name = value; }
        }

        [DataMember]
        public DateTime startDate
        {
            get { return StartDate; }
            set { StartDate = value; }
        }

    }
}
