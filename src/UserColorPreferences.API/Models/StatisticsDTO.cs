namespace UserColorPreferences.API.Models
{
    public class StatisticsDTO
    {
        public string AgeGroup { get; init; }
        public int MinAge { get; init; }
        public int MaxAge { get; init; }
        public string FavoriteColor { get; init; }
        public int Count { get; init; }
    }
}
