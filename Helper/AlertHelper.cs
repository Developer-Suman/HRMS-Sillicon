using HRMS_Silicon.Service.ServiceImpl;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.Helper
{
    public class AlertHelper
    {
        public static void setMessage(Controller controller, string message, messageType message_type = messageType.success)
        {
            Alert alert = new Alert();
            alert.message = message;
            alert.message_type = message_type;
            controller.TempData["message"] = JsonConvert.SerializeObject(alert);
        }

        internal static void setMessage(DepartmentServiceImpl departmentServiceImpl, string v, messageType success)
        {
            throw new NotImplementedException();
        }
    }
}
