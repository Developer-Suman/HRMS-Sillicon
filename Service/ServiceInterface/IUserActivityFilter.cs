using HRMS_Silicon.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;

namespace HRMS_Silicon.Service.ServiceInterface
{
    public interface IUserActivityFilter
    {
        List<UserActivity> GetAll();
        UserActivity GetById(int id);
        void OnActionExecuted(ActionExecutedContext context);
        void OnActionExecuting(ActionExecutingContext context);
        void StoreUserActivity(string data, string url, string userName, string ipAddress);
    }
}