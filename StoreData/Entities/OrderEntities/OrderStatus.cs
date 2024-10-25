using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Entities.OrderEntities
{
    public enum OrderStatus
    {
        Placed,
        Running,
        Delivering,
        Delivered,
        Cancelled
    }
}
