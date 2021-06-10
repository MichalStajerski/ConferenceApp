using ConferenceApp.Models;
using Grpc.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceApp.Controllers
{
    public class ConferenceController : Controller
    {
             
        private static List<ConferenceUser> _conferenceUsers = new List<ConferenceUser>();
        //private static IEnumerable<ConferenceUser> _conferenceUsers = new List<ConferenceUser>();
        public IActionResult Index()
        {
            return View(_conferenceUsers);
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(ConferenceUser conferenceUser)
        {
            if (ModelState.IsValid)
            {
                _conferenceUsers.Add(conferenceUser);
               
                return RedirectToAction(nameof(Index));
           
            }

            //return PartialView("Register", _conferenceUsers);
            return View();
        }


        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ConferenceUser model, CT model2)
        {
            {
                string uniqueFileName = null;
                
                if (model.ProfilePicture != null)
                {                  
                    string uploadsFolder = "C:/Users/m9185/source/repos/ConferenceApp/ConferenceApp/wwwroot/images/";
                    //zapewnienie nazwa pliku była unikalna
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfilePicture.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    //skopiuj plik to folderu wwwroot/images za przy pomocy metody CopyTo() 
                    model.ProfilePicture.CopyTo(new FileStream(filePath, FileMode.Create));

                    ConferenceUser newUser = new ConferenceUser
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        ConferenceType = model.ConferenceType,                      
                        ProfilePicturePath = filePath
                    };

                    
                    var p = filePath.ToString();
                    var context = new UserContext();
                    context.ConferenceUsers.Add(new ConferenceUser
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        //ConferenceType = model2.ConferenceType,
                        ProfilePicturePath = p

                    });
                    context.ConferenceTypes.Add(new CT
                    {
                        ConferenceType = model2.ConferenceType
                    });
                    context.SaveChanges();
                     
                    context.Database.EnsureCreated();

                    _conferenceUsers.Add(newUser);
                    return RedirectToAction("index");
                }
            }
            return View();
        }
    }
}


