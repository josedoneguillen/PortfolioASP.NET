using System;
using Portfolio.Application.Dtos.Subscription;
using Portfolio.Application.Models;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Extensions
{
    public static class SubscriptionExtension
    {
        public static Subscription ConvertSubscriptionAddDtoToSubscription(this SubscriptionAddDto subscriptionAddDto)
        {
            return new Subscription()
            {
                Email = subscriptionAddDto.Email,
                OptOut = false,
                IdUserCreate = 0,
                CreationDate = DateTime.Now,
                IsPublished = true,
                IsDeleted = false
            };
        }
        public static Subscription ConvertSubscriptionUpdateDtoToSubscription(this Subscription subscription, SubscriptionUpdateDto subscriptionUpdateDto)
        {
            subscription.Email = subscriptionUpdateDto.Email ?? subscription.Email;
            subscription.OptOut = subscriptionUpdateDto.OptOut != null ? subscriptionUpdateDto.OptOut : subscription.OptOut;
            subscription.IdUserModification = 0;
            subscription.IsPublished = subscriptionUpdateDto.IsPublished.HasValue ? subscriptionUpdateDto.IsPublished.Value : subscription.IsPublished;
            subscription.ModificationDate = DateTime.Now;
            subscription.IsDeleted = subscriptionUpdateDto.IsDeleted.HasValue ? subscriptionUpdateDto.IsDeleted.Value : subscription.IsDeleted;
            subscription.DeletedDate = (subscriptionUpdateDto.IsDeleted.HasValue && subscriptionUpdateDto.IsDeleted == true) ? DateTime.Now : subscription.DeletedDate;

            return subscription;
        }
        public static SubscriptionGetModel CreateSubscriptionGetModel(this Subscription subscription)
        {
            return new Models.SubscriptionGetModel()
            {
                Id = subscription.Id,
                Email = subscription.Email,
                OptOut = subscription.OptOut
            };

        }
    }
}
