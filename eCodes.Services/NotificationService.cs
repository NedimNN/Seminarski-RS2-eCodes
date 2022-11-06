using AutoMapper;
using eCodes.Models.Requests;
using eCodes.Models.SearchObjects;
using eCodes.Services.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCodes.Services
{
    public class NotificationService : BaseCRUDService<Models.Notifications, Database.Notification, NotificationSearchObject, NotificationUpsertRequest, NotificationUpsertRequest>, INotificationService
    {
        public NotificationService(_210331Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IQueryable<Notification> AddFilter(IQueryable<Notification> query, NotificationSearchObject search = null)
        {
            var filter =  base.AddFilter(query, search);

            if(search?.BuyerId > 0)
            {
                filter = filter.Where(w => w.BuyerId == search.BuyerId);
            }
            return filter;
        }
        public override IQueryable<Notification> AddInclude(IQueryable<Notification> query, NotificationSearchObject search = null)
        {
            if (search?.IncludeBuyer == true)
            {
                query = query.Include(i => i.Buyer.Person.City);

            }

            return query;
        }

    }
}
