using Examenss.Context;
using Examenss.Models;
using Microsoft.AspNetCore.Mvc;

namespace Examenss.Controllers
{
    [Route("api/MaterialControllers")]
    public class MaterialControllers: Controller
    {
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        [ApiExplorerSettings(GroupName = "v2")]
        public ActionResult MaterialsGet()
        {
            try
            {
                using (ContextGeneralMebel context = new ContextGeneralMebel())
                {
                    var materials = context.Materials.OrderBy(x => x.Names).ToList();
                    return Json(materials);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        [ApiExplorerSettings(GroupName = "v2")]
        public ActionResult Dobavitmaterial([FromForm] string Names, [FromForm] string Haracteristiki, [FromForm] string Proizvoditel)
        {
            try
            {
                using (ContextGeneralMebel context = new ContextGeneralMebel())
                {
                    Material material = new Material()
                    {
                        Names = Names,
                        Haracteristiki = Haracteristiki,
                        Proizvoditel = Proizvoditel
                    };
                    context.Materials.Add(material);
                    context.SaveChanges();
                    return Json(material);
                };
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
