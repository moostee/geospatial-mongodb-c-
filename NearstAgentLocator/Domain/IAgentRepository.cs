using NAL.Api.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NAL.Api.Infrastructure
{
    public interface IAgentRepository
    {
        Task<List<Agents>> NearAsync(double longitude, double latitude, long maximumDistance = 0, long minimumDistance = 5000);
    }
}