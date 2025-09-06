namespace ProjectManagementAPI.Models.Schema
{
    public class Column
    {
        public Guid ColumnID { get; set; }
        public Guid BoardID { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
