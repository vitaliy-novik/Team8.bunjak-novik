using Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Wunderlist.InterfaceRepositories;
using Wunderlist.Repositories;
using Wunderlist.Services;

namespace Wunderlist.WebUI.Controllers
{
    public class ProfileController : Controller
    {
        private AccountService _account;
        private static byte[] _defaultPhoto;
        static ProfileController()
        {
            string path = @"C:\Users\bunia\Source\Repos\Team8.bunjak-novik\Wunderlist.WebUI\Content\defaultPhoto.png";
            _defaultPhoto = System.IO.File.ReadAllBytes(path);
        }

        public ProfileController()
        {
            IUnitOfWork uow = new UnitOfWork("DefaultConnection");
            _account = new AccountService(uow);
        }

        [HttpPost]
        public void UploadFiles(HttpPostedFileBase image)
        {
            string email = User.Identity.Name;
            var photo = ConvertToArrayBytes(image);
            _account.ChangePhoto(email, photo);
            //var originalImage = new Bitmap(image.InputStream, false);
        }
        
        public void ChangeName(string name)
        {
            string email = User.Identity.Name;
            _account.ChangeName(email, name);
        }

        public JsonResult GetProfile()
        {
            string email = User.Identity.Name;
            User user =  _account.GetByEmail(email);
            var js = new
            {
                userName = user.UserName,
                photo = Convert.ToBase64String(user.Photo ?? _defaultPhoto)
            };

            return Json(js, JsonRequestBehavior.AllowGet);
        }
        
        private byte[] ConvertToArrayBytes(HttpPostedFileBase image)
        {
            BinaryReader reader = new BinaryReader(image.InputStream);
            byte[] imageBytes = reader.ReadBytes((int)image.ContentLength);

            return imageBytes;
        }
    }
}