using System;
using Portfolio.Application.Dtos.Subscription;
using Portfolio.Application.Models;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Entities.Security;

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
                IsPublished = subscriptionAddDto.IsPublished,
                IsDeleted = false
            };
        }
        public static Subscription ConvertSubscriptionUpdateDtoToSubscription(this Subscription subscription, SubscriptionUpdateDto subscriptionUpdateDto)
        {
            subscription.Email = subscriptionUpdateDto.Email ?? subscription.Email;
            subscription.OptOut = subscriptionUpdateDto.OptOut != null ? subscriptionUpdateDto.OptOut : subscription.OptOut;
            subscription.IdUserModification = subscriptionUpdateDto.IdUser;
            subscription.IdUserDelete = (subscriptionUpdateDto.IsDeleted == true) ? subscriptionUpdateDto.IdUser : 0;
            subscription.IsPublished = subscriptionUpdateDto.IsPublished;
            subscription.ModificationDate = DateTime.Now;
            subscription.IsDeleted = subscriptionUpdateDto.IsDeleted;
            subscription.DeletedDate = (subscriptionUpdateDto.IsDeleted == true) ? DateTime.Now : subscription.DeletedDate;

            return subscription;
        }
        public static SubscriptionGetModel CreateSubscriptionGetModel(this Subscription subscription)
        {
            return new Models.SubscriptionGetModel()
            {
                Id = subscription.Id,
                Email = subscription.Email,
                OptOut = subscription.OptOut,
                IsPublished = subscription.IsPublished,
                IsDeleted = subscription.IsDeleted
            };

        }
    }
}
