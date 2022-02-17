using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RecruitmentSystem.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RecruitmentSystem.UI.Infrastructure.Filters
{
    public class CustomAuthFilter : IAuthorizationFilter
    {
        private readonly IUsuarioIdentityRepository _usuarioRepository;

        public CustomAuthFilter(IUsuarioIdentityRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var controllerExceptions = new string[] { "Home", "Identity", "Error" };
            var actionName = context.RouteData.Values["action"];
            string controllerName = (context.RouteData.Values["controller"] ?? context.RouteData.Values["area"]).ToString();
            if(!controllerExceptions.Contains(controllerName))
            {
                var userId = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
                var puedeAcceder =  _usuarioRepository.UsuarioTienePermiso(userId, controllerName);
                if(!puedeAcceder)
                {
                    context.Result = new RedirectResult("/Error/Unathorized");
                }
            }
        }
    }
}
