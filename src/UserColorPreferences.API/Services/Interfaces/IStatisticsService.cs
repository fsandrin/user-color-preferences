using System.Collections.Generic;
using System.Threading.Tasks;
using UserColorPreferences.API.Models;

namespace UserColorPreferences.API.Services.Interfaces
{
    public interface IStatisticsService
    {
        Task<IEnumerable<StatisticsDTO>> Get();
    }
}
