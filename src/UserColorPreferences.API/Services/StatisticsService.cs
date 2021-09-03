using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserColorPreferences.API.Data.Repositories.Interfaces;
using UserColorPreferences.API.Domain;
using UserColorPreferences.API.Models;
using UserColorPreferences.API.Services.Interfaces;

namespace UserColorPreferences.API.Services
{
    public class StatisticsService : IStatisticsService
    {
        private static readonly int[] _ageGroups = new int[] { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 95, 100, 105, 110, 115, 120 };

        private readonly IUserRepository _userRepository;

        public StatisticsService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<IEnumerable<StatisticsDTO>> Get()
        {
            IEnumerable<User> users = await _userRepository.List();

            var statistics = users.GroupBy(user => GetAgeGroup(user.Age))
                                .Select(ageGroup =>
                                {
                                    var favoriteColorCount = 0;

                                    var favoriteColors = ageGroup.GroupBy(g => g.FavoriteColor)
                                                                .OrderByDescending(o =>
                                                                {
                                                                    var count = o.Count();

                                                                    if (count > favoriteColorCount)
                                                                        favoriteColorCount = count;

                                                                    return favoriteColorCount;
                                                                })
                                                                .Where(w => w.Count() == favoriteColorCount)
                                                                .Select(s => s.Key)
                                                                .OrderBy(o => o)
                                                                .AsEnumerable();

                                    return new StatisticsDTO
                                    {
                                        AgeGroup = ageGroup.Key.ToString(),
                                        MinAge = ageGroup.Key.MinAge,
                                        MaxAge = ageGroup.Key.MaxAge,
                                        FavoriteColor = string.Join(", ", favoriteColors),
                                        Count = favoriteColorCount
                                    };
                                })
                                .OrderBy(o => o.MinAge);


            return statistics;
        }


        private AgeGroup GetAgeGroup(in int age)
        {
            var indexOf = Array.BinarySearch(_ageGroups, age);

            if (indexOf < 0)
            {
                indexOf = (indexOf * -1) - 1;
            }

            return new AgeGroup(_ageGroups[indexOf - 1], _ageGroups[indexOf]);
        }

        private struct AgeGroup
        {
            public int MinAge;
            public int MaxAge;

            public AgeGroup(int minAge, int maxAge)
            {
                MinAge = minAge;
                MaxAge = maxAge;
            }

            public override string ToString()
            {
                return $"from {MinAge} to {MaxAge}";
            }
        }
    }
}
