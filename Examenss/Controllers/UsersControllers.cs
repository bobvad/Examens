using Examenss.Context;
using Examenss.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Examenss.Controllers
{
    [Route("api/UsersControllers")]
    [ApiExplorerSettings(GroupName = "v1")]

    public class UsersControllers: Controller
    {
        /// <summary>
        /// Для авторизации пользователя
        /// </summary>
        /// <param name="Login"></param>
        /// <param name="Password"></param>
        /// <returns>
        /// </returns>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        public ActionResult AutIn([FromForm] string Login, [FromForm] string Password)
        {
            if (Login == null && Password == null)
                return StatusCode(401,"Заполните поля");
            try
            {
                using (ContextGeneralMebel context = new ContextGeneralMebel())
                {
                    var user = context.Users.Where(x => x.Login == Login && x.Password == Password);
                    GenerateToken();
                    context.SaveChanges();
                    return Json(user);
                };
            }
            catch
            {
                return StatusCode(500);
            }
        }
        /// <summary>
        /// Для регистрации пользователя
        /// </summary>
        /// <param name="Login"></param>
        /// <param name="Password"></param>
        /// <returns>
        /// </returns>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        public ActionResult RegIn([FromForm] string Login, [FromForm] string Password)
        {
            if (Login == null && Password == null)
                return StatusCode(401, "Заполните поля");
            try
            {
                using (ContextGeneralMebel context = new ContextGeneralMebel())
                {
                    Users users = new Users()
                    {
                        Login = Login,
                        Password = Password
                    };
                    context.Users.Add(users);
                    context.SaveChanges();
                    return Json(users);
                };
            }
            catch
            {
                return StatusCode(500);
            }
        }
        public void GenerateToken()
        {
            Random randomss = new Random();
            string tokens = "QwWEeRrTtYyUuIiOoPpAaDfsghjklzxcvbnm123456789";
            string token = "";
            for (int i = 0; i < tokens.Length; i++)
            {
                int randoms = randomss.Next(tokens.Length);
                char rnds = token[randoms];
                tokens += rnds;
            }
        }
    }
}
