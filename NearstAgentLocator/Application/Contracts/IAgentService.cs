using NAL.Api.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NAL.Api.Infrastructure.Services
{
    public interface IAgentService
    {
        Task<List<Agents>> GetNearestLocationAsync(double longitude, double latitude, long maximumDistance = 5000, long mininumDistance = 0);
    }
}
