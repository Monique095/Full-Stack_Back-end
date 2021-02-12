using FullStack.API.Services;
using FullStack.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Users;

namespace FullStack.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AdvertsController : ControllerBase
    {
        public IAdverts_Service _adverts_service;

        public AdvertsController(IAdverts_Service adverts_Service)
        {
            _adverts_service = adverts_Service;
        }

        [HttpGet("myads")]
        public IActionResult GetMyAdverts()
        {
            var user = (UserModel)HttpContext.Items["User"];
            var result = _adverts_service.GetMyAdverts(user.Id);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetAllAdverts()
        {
            var adverts = _adverts_service.GetAllAdverts();
            return Ok(adverts);
        }

        [HttpGet("{id}")]
        public IActionResult GetAdvertById( int id )
        {
            var advert = _adverts_service.GetAdvertById(id);
            return Ok(advert);
        }

        [Authorize]
        [HttpPost("create")]
        public IActionResult CreateProduct(Advert advert)
        {
            _adverts_service.CreateAdvert(advert);
            return Ok(advert);

        }

        [HttpPut("{id}")]
        public IActionResult Update(Advert advert)
        {
            _adverts_service.UpdateAdvert(advert);
            return Ok(advert);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAdvert ( int id )
        {
            _adverts_service.DeleteAdvert(id);
            return Ok();
        }

    }
}
