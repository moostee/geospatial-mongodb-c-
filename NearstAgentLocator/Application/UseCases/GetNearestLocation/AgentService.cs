using NAL.Api.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NAL.Api.Infrastructure.Services
{
    public partial class AgentService : IAgentService
    {
        private readonly IAgentRepository _agentRepository;
        public AgentService(IAgentRepository agentRepository)
        {
            _agentRepository = agentRepository;
        }

        public async Task<List<Agents>> GetNearestLocationAsync(double longitude, double latitude, long maximumDistance = 5000, long mininumDistance = 0)
        {
            return await _agentRepository.NearAsync(longitude, latitude, maximumDistance, mininumDistance);
        }
    }
}
