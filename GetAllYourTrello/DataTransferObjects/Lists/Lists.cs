using System.Collections.Generic;

namespace GetAllYourTrello.DataTransferObjects.Lists
{
    public class Lists
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<Cards> cards { get; set; }
    }
}
