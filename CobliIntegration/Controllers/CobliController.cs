using CobliIntegration.Domain.Cobli;
using CobliIntegration.Services.Services;
using CobliIntegration.Services.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace CobliIntegration.Controllers
{
    public class CobliController : Controller
    {
        private readonly IUnitOfWork uow;

        public CobliController(IUnitOfWork uow) 
        {
            this.uow = uow;
        }

        /// <summary>
        /// This endpoint returns the list of all events in your Cobli Account based on filters
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet("Events")]
        public ActionResult<ResponseEvent> GetEvents(GetEventsFilter filter)
        {
            return Ok(uow.CobliService.GetEvents(filter));
        }

        /// <summary>
        /// This endpoint returns the list of all medias in your Cobli Account based on filters
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet("Medias")]
        public ActionResult<ResponseEvent> GetEvents(GetMediaFilter filter)
        {
            return Ok(uow.CobliService.GetMedias(filter));
        }

        /// <summary>
        /// This endpoint returns a temporary link to download a specific media
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Medias/{id}")]
        public ActionResult<ResponseEvent> GetEvents(string id)
        {
            return Ok(uow.CobliService.GetMedia(id));
        }
    }
}
