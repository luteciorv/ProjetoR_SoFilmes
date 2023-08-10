namespace SoFilmes.Domain.Entities
{
    public sealed class Genre : EntityBase
    {
        public Genre(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public IReadOnlyCollection<MovieGenre>? MoviesGenres { get; private set; }

        public void Update(string name)
        {
            Name = name;
            UpdatedAt = DateTime.Now;
        }
    }
}
