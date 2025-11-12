using System.Drawing;
using Examenss.Context;
using Examenss.Models;
using Microsoft.AspNetCore.Mvc;

namespace Examenss.Controllers
{
    [Route("api/MebelsControllers")]
    [ApiController]
    public class MebelsControllers: Controller
    {
        /// <summary>
        /// Для сортировки мебели пользователем
        /// </summary>
        /// <param name="Names"></param>
        /// <param name="Description"></param>
        /// <param name="Material"></param>
        /// <param name="Ves"></param>
        /// <param name="Size"></param>
        /// <param name="Price"></param>  
        /// </returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        [ApiExplorerSettings(GroupName = "v2")]
        public ActionResult MebelsGet()
        {
            try
            {
                using (ContextGeneralMebel context = new ContextGeneralMebel())
                {
                    var mebel = context.Mebels.OrderBy(x => x.Names).ToList();
                    return Json(mebel);
                }
            }
            catch(Exception ex) 
            {
                return StatusCode(500);
            }
        }
        /// <summary>
        /// Для добавления мебели 
        /// </summary>
        /// <param name="Names"></param>
        /// <param name="Description"></param>
        /// <param name="Material"></param>
        /// <param name="Ves"></param>
        /// <param name="Size"></param>
        /// <param name="Price"></param>  
        ///  <param name="200">Успешная авторизация</param>
        /// <param name="500">Ошибка подключения к серверу</param>
        /// <param name="400">Плохой запрос</param>
        /// </returns>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        [ApiExplorerSettings(GroupName = "v2")]
        public ActionResult Dobavit([FromForm] string Names, [FromForm] string Description, [FromForm] string Material, [FromForm] int Ves, [FromForm] int Size, [FromForm] int Price)
        {
            try
            {
                using (ContextGeneralMebel context = new ContextGeneralMebel())
                {
                    Mebel mebels = new Mebel()
                    {
                        Names = Names,
                        Description = Description,
                        Material = Material,
                        Ves = Ves,
                        Size = Size,
                        Price = Price
                    };
                    context.Mebels.Add(mebels);
                    context.SaveChanges();
                    return Json(mebels);
                };
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        /// <summary>
        /// Для удаления мебели 
        /// </summary>
        /// <param name="Names"></param>  
        ///  <param name="200">Успешная авторизация</param>
        /// <param name="500">Ошибка подключения к серверу</param>
        /// <param name="400">Плохой запрос</param>
        /// </returns>
        public ActionResult DeleteMebel(int Id)
        {
            try
            {
             using (ContextGeneralMebel context = new ContextGeneralMebel())
            {
                var mebels = context.Mebels.Where(me => me.Id == Id).First();
                context.Mebels.Remove(mebels);
                context.SaveChanges();
                return Json(mebels);
            };
            }
            catch
            {
                return StatusCode(500);
            }
            
        }
    }
}
