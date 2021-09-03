using Newtonsoft.Json;
using UserColorPreferences.API.Domain;

namespace UserColorPreferences.API.Models
{
    public class UserDTO
    {
        [JsonConstructor]
        public UserDTO(int? id, string firstName, string lastName, int age, string favoriteColor)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            FavoriteColor = favoriteColor;
        }

        public UserDTO(User user) : this(user.Id, user.FirstName, user.LastName, user.Age, user.FavoriteColor)
        {
        }

        public UserDTO() { }


        [JsonProperty("id")]
        public int? Id { get; init; }

        [JsonProperty("firstName")]
        public string FirstName { get; init; }

        [JsonProperty("lastName")]
        public string LastName { get; init; }

        [JsonProperty("age")]
        public int Age { get; init; }

        [JsonProperty("favoriteColor")]
        public string FavoriteColor { get; init; }


        public User ToModel()
        {
            return new User(Id, FirstName, LastName, Age, FavoriteColor);
        }
    }
}
