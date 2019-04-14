using EMS.Model;
using EMS.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminLteAspNetMVC1.Common
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class PermissionControlAttribute : AuthorizeAttribute
    {
        //public AuthorizeResult AuthorizeResult { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var actionDescriptor = filterContext.ActionDescriptor;
            var controllerDescriptor = filterContext.ActionDescriptor.ControllerDescriptor;
            bool hasAllowAnonymous = actionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) || controllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true);
            if (hasAllowAnonymous)
            {
                filterContext.RouteData.DataTokens.Add("hasAllowAnonymous", true);
            }

            //List<string> functionList = null;
            //List<string> permissionLevelList = null;
            ////1. get Controller PermissionFunctionAttribute
            //if (controllerDescriptor.IsDefined(typeof(PermissionFunctionAttribute), true))
            //{
            //    var permissionFunction = (PermissionFunctionAttribute)controllerDescriptor.GetFilterAttributes(false).FirstOrDefault(m => m.GetType() == typeof(PermissionFunctionAttribute));
            //    if (permissionFunction != null)
            //    {
            //        functionList = permissionFunction.FunctionNames == null ? new List<string>() : permissionFunction.FunctionNames.ToList();
            //        permissionLevelList = permissionFunction.PermissionLevels == null ? new List<string>() : permissionFunction.PermissionLevels.ToList();
            //    }
            //}

            ////2. get Action PermissionFunctionAttribute
            //if (actionDescriptor.IsDefined(typeof(PermissionFunctionAttribute), true))
            //{
            //    var permissionFunction = (PermissionFunctionAttribute)controllerDescriptor.GetFilterAttributes(false).FirstOrDefault(m => m.GetType() == typeof(PermissionFunctionAttribute));
            //    if (permissionFunction != null)
            //    {
            //        functionList = permissionFunction.FunctionNames == null ? functionList : permissionFunction.FunctionNames.ToList().Union(functionList).Distinct().ToList();
            //        permissionLevelList = permissionFunction.PermissionLevels == null ? permissionLevelList : permissionFunction.PermissionLevels.ToList().Union(permissionLevelList).ToList();
            //    }
            //}

            //filterContext.RouteData.DataTokens.Add("functionList", functionList);
            //filterContext.RouteData.DataTokens.Add("permissionLevelList", permissionLevelList);

            base.OnAuthorization(filterContext);
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var routeData = httpContext.Request.RequestContext.RouteData;

            //1. 是否有AllowAnonymousAttribute
            bool hasAllowAnonymous = routeData.DataTokens["hasAllowAnonymous"] == null ? false : (bool)routeData.DataTokens["hasAllowAnonymous"];
            if (hasAllowAnonymous)
            {
                return true;
            }
            else
            {
                UserItem userItem = UserHelper.GetCurrentUser();
                List<PermissionItem> permissionList = PermissionDataHelper.GetPermissionData();

                if (userItem == null || permissionList == null)
                {
                    return false;
                }

                //2. 获取当前用户可用的Permission(Area， Controller， Action)
                List<PermissionItem> currentUserPermissionList = new List<PermissionItem>();
                foreach (var permission in permissionList)
                {
                    bool hasPermission = userItem.RoleList.Intersect(permission.RoleList).Count() > 0;
                    if (hasPermission)
                    {
                        currentUserPermissionList.Add(permission);
                    }
                }

                //3. 判断用户是否有当前请求的权限
                string area = routeData.DataTokens["area"] == null ? "" : (string)routeData.DataTokens["area"];
                string controller = routeData.Values["controller"] == null ? "" : (string)routeData.Values["controller"];
                string action = routeData.Values["action"] == null ? "" : (string)routeData.Values["action"];
                foreach (var permission in currentUserPermissionList)
                {
                    if (permission.HasActionPermission)
                    {
                        if (area.Equals(permission.Area, StringComparison.OrdinalIgnoreCase) && controller.Equals(permission.Controller, StringComparison.OrdinalIgnoreCase) && action.Equals(permission.ActionName, StringComparison.OrdinalIgnoreCase))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (area.Equals(permission.Area, StringComparison.OrdinalIgnoreCase) && controller.Equals(permission.Controller, StringComparison.OrdinalIgnoreCase))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new ContentResult() { Content = "抱歉，您无权进行当前操作，请重新登录或联系管理员." };
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
                //不指定重定向URL会导致还是原来没权访问的URL
                filterContext.HttpContext.Response.Redirect("~/Login/Login");
            }
        }
    }
}