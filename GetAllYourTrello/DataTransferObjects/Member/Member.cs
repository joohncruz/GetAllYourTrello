using System;

namespace GetAllYourTrello.DataTransferObjects.Member
{
    public class Member
    {
        public string id { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateExpires { get; set; }
        public string idMember { get; set; }
        public string identifier { get; set; }
    }
}
