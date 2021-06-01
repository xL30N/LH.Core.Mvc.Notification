using Microsoft.AspNetCore.Mvc;

namespace LH.Core.Mvc.Notification
{
    public static class ControllerExtension
    {
        public static void ShowNotification(this Controller controller, string message, MessageType type)
        {
            string key = type.ToString();
            controller.TempData[key] = message;
        }
    }
}