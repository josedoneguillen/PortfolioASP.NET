using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Portfolio.Application.Core;
using Portfolio.Application.Contract;
using Portfolio.Application.Dtos.Subscription;
using Portfolio.Infrastructure.Interfaces;
using Portfolio.Domain.Entities;
using Portfolio.Application.Extensions;
using System.Collections.Generic;

namespace Portfolio.Application.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository subscriptionRepository;
        private readonly ILogger<SubscriptionService> logger;
        protected ServiceResult result;
        public SubscriptionService(ISubscriptionRepository subscriptionRepository, ILogger<SubscriptionService> logger)
        {
            this.subscriptionRepository = subscriptionRepository;
            this.result = new ServiceResult();
            this.logger = logger;
        }

        public async Task<ServiceResult> Get()
        {
            try
            {
                this.result.Data = await this.getSubscriptions();
            }
            catch (Exception ex)
            {
                // Send Notification
                this.result.Success = false;
                this.result.Message = "Error obteniendo las subscripciones";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return this.result;
        }

        public async Task<ServiceResult> GetById(int Id)
        {
            try
            {
                this.result.Data = (await this.getSubscriptions(Id)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                // Send Notification
                this.result.Success = false;
                this.result.Message = "Error obteniendo la subscripción";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return this.result;
        }

        public async Task<ServiceResult> ModifySubscription(SubscriptionUpdateDto subscriptionUpdateDto)
        {
            try
            {
                // Field Validations
                if (subscriptionUpdateDto.Id == 0)
                {
                    this.result.Message = "Id de la subscripción a modificar es requerido";
                    this.result.Success = false;
                    return result;
                }

                if (subscriptionUpdateDto.IdUser == 0)
                {
                    this.result.Message = "Id del usuario que realiza la modificación es requerido";
                    this.result.Success = false;
                    return result;
                }

                Subscription subscription = await this.subscriptionRepository.GetEntityByID(subscriptionUpdateDto.Id);


                if (subscription == null)
                {
                    this.result.Message = "Esta Subscrición no existe";
                    this.result.Success = false;
                    return result;
                }

                subscription = subscription.ConvertSubscriptionUpdateDtoToSubscription(subscriptionUpdateDto);

                await this.subscriptionRepository.Update(subscription);

                this.result.Message = "Subscrición actualizada correctamente";

            }
            catch (Exception ex)
            {
                // Send Notification
                this.result.Success = false;
                this.result.Message = "Error modificando la subscripción";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return this.result;
        }

        public async Task<ServiceResult> SaveSubscription(SubscriptionAddDto subscriptionAddDto)
        {
            try
            {
                // Field Validations
                if (string.IsNullOrEmpty(subscriptionAddDto.Email))
                {
                    this.result.Message = "Email es requerido";
                    this.result.Success = false;
                    return result;
                }

                Subscription subscription = subscriptionAddDto.ConvertSubscriptionAddDtoToSubscription();


                await this.subscriptionRepository.Save(subscription);

                this.result.Message = "Subscripción agregada correctamente";
                this.result.Data = subscription.Id;

            }
            catch (Exception ex)
            {
                // Send Notification
                this.result.Success = false;
                this.result.Message = "Error agregando la subscripción";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return this.result;
        }

        private async Task<List<Models.SubscriptionGetModel>> getSubscriptions(int? Id = null)
        {
            List<Models.SubscriptionGetModel>? subscriptions = new List<Models.SubscriptionGetModel>();
            try
            {
                subscriptions = (from subscription in (await this.subscriptionRepository.GetAll())
                        where subscription.Id == Id || !Id.HasValue
                        select subscription.CreateSubscriptionGetModel()).ToList();
            }
            catch (Exception ex)
            {
                subscriptions = null;
                this.logger.Log(LogLevel.Error, "Error obteniendo las subscripciones", ex.ToString());
            }

            return subscriptions;
        }
    }
}
