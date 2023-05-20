using Portfolio.Application.Core;
using Portfolio.Application.Contract;
using System.Threading.Tasks;
using System.Linq;
using Portfolio.Application.Responses;
using Portfolio.Application.Dtos.Subscription;
using Portfolio.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace Portfolio.Application.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository subscriptionRepository;
        private readonly ILogger<SubscriptionService> logger;
        public SubscriptionService(ISubscriptionRepository subscriptionRepository, ILogger<SubscriptionService> logger)
        {
            this.subscriptionRepository = subscriptionRepository;
            this.logger = logger;
        }
        public ServiceResult save()
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResult> Get()
        {
            throw new System.NotImplementedException();
        }

        Task<ServiceResult> ISubscriptionService.GetById(int Id)
        {
            throw new System.NotImplementedException();
        }

        Task<SubscriptionAddResponse> ISubscriptionService.ModifySubscription(SubscriptionUpdateDto subscriptionUpdateDto)
        {
            throw new System.NotImplementedException();
        }

        Task<SubscriptionAddResponse> ISubscriptionService.SaveSubscription(SubscriptionAddDto subscriptionAddDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
