using ITS.Data.Enum.Issue;

namespace ITS.Data.Dto
{
    public class IssueDto
    {
        public string NameIssue { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public IssueType IssueType { get; set; }
        public IssueState IssueState { get; set; }
        public int ResposibleId { get; set; }


        public bool Validate()
        {
            if (NameIssue == null) throw new System.ArgumentException("NameIssue can't  be less 0");
            if (AuthorId == null) throw new System.ArgumentException("AuthorId can't  be less 0");
            if (IssueType == null) throw new System.ArgumentException("IssueType can't  be less 0");
            if (ResposibleId == null) throw new System.ArgumentException("ResposibleId can't  be less 0");

            return true;
        }
    }
}