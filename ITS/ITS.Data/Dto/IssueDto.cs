using ITS.Data.Enum.Issue;

namespace ITS.Data.Dto
{
    public class IssueDto
    {
        public string nameIssue { get; set; }
        public string description { get; set; }
        public int authorId { get; set; }
        public IssueType issueType { get; set; }
        public IssueState issueState { get; set; }
        public int resposibleId { get; set; }
    }
}