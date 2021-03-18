using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFood.Application.Interfaces;
using MyFood.Application.ViewModels;
using MyFood.Domain.Core.Bus;
using MyFood.Domain.Core.Notifications;
using MyFood.WebApi.Controllers;

namespace Next3.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ApiController
    {
        private readonly IRestaurantAppService _restaurantAppService;

        public RestaurantController(
            IRestaurantAppService restaurantAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _restaurantAppService = restaurantAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<RestaurantViewModel>> Get()
        {
            return await _restaurantAppService.GetAll();
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<RestaurantViewModel> Get(Guid id)
        {
            return await _restaurantAppService.GetById(id);
        }

        [HttpGet]
        [Route("{latitude}/{longitude}/{maxDistance}")]
        public async Task<IEnumerable<RestaurantViewModel>> Get(double latitude, double longitude, double maxDistance)
        {
            return await _restaurantAppService.GetClosest(latitude, longitude, maxDistance); ;
        }


        [HttpPost]
        [Authorize(Policy = "CanWriteRestaurantData")]
        public IActionResult Post([FromBody]RestaurantViewModel restaurantViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(restaurantViewModel);
            }

            _restaurantAppService.Register(restaurantViewModel);

            return Response(restaurantViewModel);
        }

        [HttpPut]
        public IActionResult Put([FromBody]RestaurantViewModel restaurantViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(restaurantViewModel);
            }

            _restaurantAppService.Update(restaurantViewModel);

            return Response(restaurantViewModel);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            _restaurantAppService.Remove(id);

            return Response();
        }

    }
}