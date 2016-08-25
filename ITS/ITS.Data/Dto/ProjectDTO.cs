using System.CodeDom;

namespace ITS.Data.Dto
{
    public class ProjectDto
    {
        public int IdProject { get; set; }
        public int IdVersionProject { get; set; }
        public string Description { get; set; }
        public string NameProject { get; set; }

        public void Validate()
        {
            if (IdVersionProject == null) throw new System.ArgumentException("IdVersionProject can't  be null");
            if (NameProject == null) throw new System.ArgumentException("NameProject cannto be null");

        }
    }
}