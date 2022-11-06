using eCodes.Services;
using eCodes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eCodes.Models.SearchObjects;
using eCodes.Models.Requests;

namespace eCodes.Controllers
{

    public class NotificationsController : BaseCRUDController<Models.Notifications, NotificationSearchObject, NotificationUpsertRequest, NotificationUpsertRequest>
    {

        public NotificationsController(INotificationService notificationService)
            : base(notificationService)
        {

        }

    }
}