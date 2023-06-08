using Portfolio.Web.Models;
using Portfolio.Web.Models.Requests;
using Portfolio.Web.Models.Responses;

namespace Portfolio.Web.ApiServices.Interfaces
{
    public interface ISubscriptionApiService
    {
        Task<CoreListResponse<SubscriptionModel>> GetSubscriptions();
        Task<CoreGetResponse<SubscriptionModel>> GetSubscription(int Id);
        Task<CoreAddResponse> SaveSubscription(SubscriptionSaveRequest subscriptionRequest);
        Task<CoreResponseModel> UpdateSubscription(SubscriptionSaveRequest subscriptionRequest);
    }
}