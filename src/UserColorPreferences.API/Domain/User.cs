namespace UserColorPreferences.API.Domain
{
    public class User
    {
        public User(int? id, string firstName, string lastName, int age, string favoriteColor)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            FavoriteColor = favoriteColor;
        }

        protected User() { }


        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string FavoriteColor { get; set; }
    }
}