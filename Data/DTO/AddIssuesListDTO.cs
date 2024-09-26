using To_do_list.Data.Entities.Enums;

namespace To_do_list.Data.DTO
{
    public class AddIssuesListDTO
    {
        public string Text { get; set; }
        public Statuses Status { get; set; }  // Статус задачи
    }
}
