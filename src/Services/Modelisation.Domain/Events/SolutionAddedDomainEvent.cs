using Modelisation.Domain.EmplacementAggregate;

namespace Modelisation.Domain.Events
{
    public class SolutionAddedDomainEvent
    {
        public string UserId { get; }
        public Solution Solution { get; }

        public SolutionAddedDomainEvent(Solution solution, string userId)
        {
            UserId = userId;
            Solution = solution;
        }
    }
}
