using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Configuration;
using Microsoft.WindowsAzure.Storage.Table;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            Session["Index"] = -1;
            return View();
        }
        public ActionResult StartView()
        {
            Models.Picture[] pictures = (Models.Picture[])Session["Pictures"];
            int index = 0;
            if (Session["Index"] != null)
            {
                index = (int)Session["Index"];

                if (index == pictures.Length)
                {
                    return View("WinView");
                }
            }

            if (pictures == null)
            {
                pictures = GetAll();
                index = 0;
                Session.Add("Pictures", pictures);
                Session["Index"] = index;
            }
            else if (index == -1)
            {
                index = 0;
                Session["Index"] = index;
            }

            //ViewBag.Counter = index + 1;
            return View(pictures[index]);
        }
        public ActionResult Guess(string type)
        {
            Models.Picture[] pictures = (Models.Picture[])Session["Pictures"];
            int index = (int)Session["Index"];

            if (pictures[index].Type.Equals(type))
            {
                Session["Index"] = ((int)Session["Index"] + 1);
                return View("RightGuess", pictures[index]);
            }
            else
            {
                Session["Index"] = -1;
                return View("WrongGuess", pictures[index]);
            }
        }
        private Models.Picture[] GetAll()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                 ConfigurationManager.ConnectionStrings["DataConnectionString"].ConnectionString);

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("image");
            TableQuery<Models.Picture> query = new TableQuery<Models.Picture>();

            return table.ExecuteQuery(query).ToArray();
        }


    }
}
