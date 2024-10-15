namespace FirstApi.Models
{
    public class TeamDTO
    {
        public int? Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        //public virtual Player? Player { get; set; }
    }
}
