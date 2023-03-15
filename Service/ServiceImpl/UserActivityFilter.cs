using HRMS_Silicon.Data;
using HRMS_Silicon.Models;
using HRMS_Silicon.Service.ServiceInterface;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;

namespace HRMS_Silicon.Service.ServiceImpl
{
    public class UserActivityFilter : IActionFilter, IUserActivityFilter
    {
        private readonly ApplicationDbContext context;
        public UserActivityFilter(ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;

        }
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var data = "";
            var controllerName = context.RouteData.Values["controller"];
            var actionName = context.RouteData.Values["action"];

            //Url the user has visited;
            var url = $"{controllerName}/{actionName}";

            if (!string.IsNullOrEmpty(context.HttpContext.Request.QueryString.Value))
            {
                //User sent data through Url
                data = context.HttpContext.Request.QueryString.Value;
            }
            else
            {
                //User sent data through Form
                var userData = context.ActionArguments.FirstOrDefault();
                var stringUserData = JsonConvert.SerializeObject(userData);

                data = stringUserData;
            }

            //Track Username if user are logged otherwise you get null
            var userName = context.HttpContext.User.Identity.Name;

            //Track Ip address
            var ipAddress = context.HttpContext.Connection.RemoteIpAddress.ToString();

            StoreUserActivity(data, url, userName, ipAddress);

        }

        public void StoreUserActivity(string data, string url, string userName, string ipAddress)
        {
            var userActivity = new UserActivity
            {
                Data = data,
                Url = url,
                UserName = userName,
                IpAddress = ipAddress
            };

            context.userActivities.Add(userActivity);
            context.SaveChanges();
        }

        public List<UserActivity> GetAll()
        {
            return context.userActivities.ToList();
        }

        public UserActivity GetById(int id)
        {
            var userActivity = context.userActivities.Find(id);
            return userActivity;
        }
    }
}
