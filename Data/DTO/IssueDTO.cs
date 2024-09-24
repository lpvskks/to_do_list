using To_do_list.Data.Entities.Enums;

namespace To_do_list.Data.DTO
{
    public class IssueDTO
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public Statuses Status { get; set; }
    }
}
