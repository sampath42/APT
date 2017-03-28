using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllPointsTransport.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public T UpdateAuditCols<T>(dynamic obj)
        {            
            obj.UpdatedDate = DateTime.Now;
            return obj;
        }
    }
}