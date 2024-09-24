using To_do_list.Data;
using To_do_list.Data.DTO;
using To_do_list.Data.Entities;
using To_do_list.Data.Entities.Enums;
using To_do_list.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace To_do_list.Services
{
    public class IssueService:IIssueService
    {
        private readonly AppDBContext _dbContext;
        public IssueService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddIssue(AddTextDTO textDTO)
        {
           if (textDTO == null && textDTO.Text == "") 
            {
                throw new BadHttpRequestException("blablabla ТЕКСТ ПУСТОЙ ЗАКАЛИБАЛИ");
            }

           Issue issue = new Issue() { 
               Text = textDTO.Text,
               Status = Statuses.NotDone
           };

            _dbContext.Add(issue);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteIssue(DeleteIssueDTO deleteIssueDTO)
        {
            var issue = await _dbContext.Issues.FirstOrDefaultAsync(i => i.Id == deleteIssueDTO.Id);
            if (issue == null) {
                throw new BadHttpRequestException("НЕТ ЗАДАЧИ ВАЩЕТА");
            }

            _dbContext.Remove(issue);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditIssue(EditIssueDTO editIssueDTO)
        {
            if (editIssueDTO.Text == "")
            {
                throw new BadHttpRequestException("blablabla ТЕКСТ ПУСТОЙ ЗАКАЛИБАЛИ");
            }

            var issue = await _dbContext.Issues.FirstOrDefaultAsync(i => i.Id == editIssueDTO.Id);
            if (issue == null)
            {
                throw new BadHttpRequestException("НЕТ ЗАДАЧИ ВАЩЕТА");
            }

            issue.Text = editIssueDTO.Text;
            await _dbContext.SaveChangesAsync();
        }

        public async Task <List<IssueDTO>> GetAllIssues()
        {
            var issues = await _dbContext.Issues.ToListAsync();
            var allIssues = issues.Select(i => new IssueDTO { 
              Id = i.Id,
              Text = i.Text,
              Status = i.Status
            }
            ).ToList();
            return allIssues;
        }

        public async Task ChangeStatus(Guid id, Statuses status)
        {
            if (status == null)
            {
                throw new BadHttpRequestException("СТАТУС ПУСТОЙ АААААААААААААААААААА");
            }

            var issue = await _dbContext.Issues.FirstOrDefaultAsync(i => i.Id == id);
            if (issue == null)
            {
                throw new BadHttpRequestException("НЕТ ЗАДАЧИ ВАЩЕТА");
            }

            issue.Status = status;
            await _dbContext.SaveChangesAsync();
        }

    }
}
