namespace PSW.GMS.Common.Pagination
{
    public class ServerPaginationModel 
    {
        public int offset { get; set; }
        public int Size { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }
        // Chances of not fetching totalRecords, int Default Value 0, therefore keeping it string 
        public string TotalRecords { get; set; }

    }
}