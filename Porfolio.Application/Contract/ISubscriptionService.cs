using Portfolio.Application.Core;
using Portfolio.Application.Dtos.Subscription;
using Portfolio.Application.Responses;
using System.Threading.Tasks;

namespace Portfolio.Application.Contract
{
    public interface ISubscriptionService
    {
        Task<ServiceResult> Get();
        Task<ServiceResult> GetById(int Id);
        Task<SubscriptionAddResponse> SaveSubscription(SubscriptionAddDto subscriptionAddDto);
        Task<SubscriptionAddResponse> ModifySubscription(SubscriptionUpdateDto subscriptionUpdateDto);
    }
}
