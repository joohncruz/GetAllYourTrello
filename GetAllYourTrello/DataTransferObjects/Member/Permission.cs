namespace GetAllYourTrello.DataTransferObjects.Member
{
    public class Permission
    {
        public string idModel { get; set; }
        public string modelType { get; set; }
        public bool read { get; set; }
        public bool write { get; set; }
    }
}
