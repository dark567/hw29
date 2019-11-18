using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BuissnesLayer;
using BuissnesLayer.Interfaces;
using DataLayer;
using DataLayer.Entityes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PresentationLayer;
using PresentationLayer.Models;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        //private EFDBContext _context;
        //private IDirectorysRepository _dirRep;
        private DataManager _datamanager;
        private ServicesManager _servicesmanager;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataManager"></param>
        public HomeController(/*EFDBContext context, IDirectorysRepository dirRep, */DataManager dataManager)
        {
            //_context = context;
            //dirRep = _dirRep;
            _datamanager = dataManager;
            _servicesmanager = new ServicesManager(_datamanager);
        }

        public IActionResult Index()
        {
            HelloModel _model = new HelloModel() { HelloMessage = "Hi, Igor!" };
            //List<Directory> _dirs = _context.Directory.Include(x=>x.Materials).ToList();
            //List<Directory> _dirs = _dirRep.GetAllDirectorys().ToList();
            //List<Directory> _dirs = _datamanager.Directorys.GetAllDirectorys(true).ToList();
            List<DirectoryViewModel> _dirs = _servicesmanager.Directorys.GetDirectoryesList();

            return View(_dirs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
