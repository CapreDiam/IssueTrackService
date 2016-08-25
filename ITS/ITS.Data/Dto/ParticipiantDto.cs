namespace ITS.Data.Dto
{
    public class ParticipiantDto
    {
        public int IdParticipiant { get; set; }
        public string Name { get; set; }

        public void Validate()
        {
            if (IdParticipiant == null) throw new System.ArgumentException("IdParticipiant can't  be null");
            if (Name == null) throw new System.ArgumentException("Name can't  be null");
        }
    }
}