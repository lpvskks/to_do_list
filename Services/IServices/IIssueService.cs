using To_do_list.Data.DTO;
using To_do_list.Data.Entities.Enums;

namespace To_do_list.Services.IServices
{
    public interface IIssueService
    {
        public Task AddIssue(AddTextDTO textDTO);
        public Task DeleteIssue(DeleteIssueDTO deleteIssueDTO);

        public Task EditIssue(EditIssueDTO editIssueDTO);

        public Task<List<IssueDTO>> GetAllIssues();
        public Task ChangeStatus(Guid id, Statuses status);
    }


}
