using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Controllers
{
    // http://forums.ext.net/showthread.php?16920-CLOSED-2-0-MVC-3-Razor-Example&p=72510&viewfull=1#post72510
    using Ext.Net.MVC;

    class StockQuotation
    {
        public string Company { get; set; }
        public int Price { get; set; }
        public DateTime LastUpdate { get; set; }
    }

    public class DataController : Controller
    {
        public StoreResult GetData(int start, int limit, int page)
        {
            StoreResult response = new StoreResult();

            List<StockQuotation> data = new List<StockQuotation>();

            Random randow = new Random();
            DateTime now = DateTime.Now;

            for (int i = start + 1; i <= start + limit; i++)
            {
                StockQuotation qoute = new StockQuotation()
                {
                    Company = "Company " + i,
                    Price = randow.Next(0, 200),
                    LastUpdate = now
                };

                data.Add(qoute);
            }

            response.Data = data;
            response.Total = 50000;

            return response;
        }

        public StoreResult GetChildren(string id)
        {
            StoreResult response = new StoreResult();

            List<TreeNode> data = new List<TreeNode>();

            Random randow = new Random();
            DateTime now = DateTime.Now;

            for (int i = 0; i <= 10; i++)
            {
                TreeNode qoute = new TreeNode
                {
                    Id = "Child-" + i,
                    Icon = ""
                };

                data.Add(qoute);
            }

            response.Data = data;
            response.Total = 50000;

            return new StoreResult { Data = data };
        }

        public class TreeNode
        {
            public string Id { get; set; }

            public string Icon { get; set; }
        }
    }
}
