using AutoSalon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Newtonsoft.Json;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore.Storage;
using System.IO;
using Microsoft.AspNetCore.Http;
using SkiaSharp;
using Microsoft.EntityFrameworkCore;

namespace AutoSalon.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CarDbContext dataBase;
        public List<Auto> cars;
        public List<Users> users;

        public HomeController(ILogger<HomeController> logger, CarDbContext dataBase)
        {
            _logger = logger;
            this.dataBase = dataBase;
        }

        public async Task<IActionResult> Index()
        {
            cars = await dataBase.GetAllAutoAsync();

            return View(cars);
        }

        public IActionResult Credit()
        {

            return View();
        }

        public IActionResult Leasing()
        {

            return View();
        }

        public IActionResult Company()
        {
            return View();
        }

        public IActionResult Contacts()
        {           
            return View();           
        }

        public async Task<IActionResult> DeleteAuto(int IdAuto)
        {
            var auto = await dataBase.Autos.FindAsync(IdAuto); // Найти автомобиль по идентификатору

            if (auto == null)
            {
                return NotFound(); // Если не найден, вернуть 404
            }

            dataBase.Autos.Remove(auto); // Удалить автомобиль
            await dataBase.SaveChangesAsync(); // Сохранить изменения в базе данных
            return RedirectToAction("Announcements");
        }

        [HttpPost]
        public async Task<IActionResult> SubmitAds(string Make, string Model, int Year, int year, string BodyType, IFormFile Photo,
                    string EngineType, string Drive, string Transmission, decimal EngineCapacity, int Mileage, decimal Price, string Description)
        {
            string filePath = "";

            if (Photo != null && Photo.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image");

                // Создаём папку, если она не существует
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Определяем путь для сохранения файла
                filePath = Path.Combine(uploadsFolder, Path.GetFileNameWithoutExtension(Photo.FileName) + ".png");

                using (var stream = new MemoryStream())
                {
                    await Photo.CopyToAsync(stream);
                    stream.Position = 0;

                    using (var original = SKBitmap.Decode(stream))
                    {
                        using (var image = SKImage.FromBitmap(original))
                        using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
                        using (var fs = new FileStream(filePath, FileMode.Create))
                        {
                            data.SaveTo(fs);
                        }
                    }
                }
            }

            // Создание нового экземпляра Auto и заполнение его свойств
            Auto auto = new Auto
            {
                Make = Make,
                Model = Model,
                Year = Year,
                BodyType = BodyType,
                EngineType = EngineType,
                Drive = Drive,
                Transmission = Transmission,
                EngineCapacity = EngineCapacity,
                Mileage = Mileage,
                Price = Price,
                Description = Description,
                Photo = "/image/" + Path.GetFileNameWithoutExtension(Photo.FileName) + ".png",
                IdUser = AppSettings.GetIdUser()
            };

            dataBase.Autos.Add(auto); // Добавляем авто в контекст
            await dataBase.SaveChangesAsync(); // Сохраняем изменения

            return RedirectToAction("SubmitAds"); // Перенаправление на другую страницу после успешного добавления
        }
        public async Task<IActionResult> SubmitAds()
        {
            int idUser = AppSettings.GetIdUser();
            var user = await dataBase.FoundUserSever(idUser);

            ViewBag.IdUser = idUser;
            ViewBag.Name = user.Name;
            ViewBag.Surname = user.Surname;
            ViewBag.Patronymic = user.Patronymic;
            ViewBag.Login = user.Login;
            ViewBag.Password = user.Password;

            return View();
        }
        public IActionResult ExitCabinet()
        {
            AppSettings.RemoveIsLoggedIn();
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Cabinet()
        {
            int idUser = AppSettings.GetIdUser();
            var user = await dataBase.FoundUserSever(idUser);

            return View(user);
        }

        public async Task<IActionResult> Announcements()
        {
            int idUser = AppSettings.GetIdUser();
            var user = await dataBase.FoundUserSever(idUser);

            ViewBag.IdUser = idUser;
            ViewBag.Name = user.Name;
            ViewBag.Surname = user.Surname;
            ViewBag.Patronymic = user.Patronymic;
            ViewBag.Login = user.Login;
            ViewBag.Password = user.Password;

            cars = await dataBase.GetAllAutoAsync();

            return View(cars);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(string Name, string Surname, string Patronymic, string Login, string Password, string Password2)
        {
            int idUser = AppSettings.GetIdUser();
            var user = await dataBase.FoundUserSever(idUser);

            if (user != null && Password == Password2)
            {
                user.Name = Name;
                user.Surname = Surname;
                user.Patronymic = Patronymic;
                user.Login = Login;
                user.Password = Password;

                dataBase.Users.Update(user);
                dataBase.SaveChanges();

                return RedirectToAction("Cabinet");
            }
            return RedirectToAction("Cabinet");
        }

        [HttpPost]
        public async Task<IActionResult> Autorization(string login, string password)
        {
            users = await dataBase.GetAllUserAsync();

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Login == login && users[i].Password == password)
                {
                    AppSettings appSettings = new AppSettings();
                    appSettings.WriteBoolToJson(true, users[i].IdUser);
                    return RedirectToAction("Index");
                }
            }

            AppSettings.RemoveIsLoggedIn();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Registration(string Name, string Surname, string Patronymic, string Login, string Password)
        {
            Users users = new Users();

            users.Name = Name;
            users.Surname = Surname;
            users.Patronymic = Patronymic;
            users.License = false;
            users.Login = Login;
            users.Password = Password;

            if (ModelState.IsValid)
            {
                dataBase.Users.Add(users); // Добавляем пользователя в контекст
                await dataBase.SaveChangesAsync(); // Сохраняем изменения

                return RedirectToAction("Index"); // Перенаправление на индекс или другую страницу
            }

            return RedirectToAction("Index"); // Если модель не валидна, возвращаем представление с ошибками
        }

        [HttpPost]
        public IActionResult Index(string mark, string model, string year, string yearBefor, string cost, string costBefor)
        {
            return RedirectToAction("Privacy", new { mark = mark, model = model, year = year, yearBefor = yearBefor, cost = cost, costBefor = costBefor });
        }

        public async Task<IActionResult> Privacy(string mark, string model, string year, string yearBefor, string cost, string costBefor)
        {
            ViewBag.mark = mark;
            ViewBag.model = model;
            ViewBag.year = year;
            ViewBag.yearBefor = yearBefor;
            ViewBag.cost = cost;
            ViewBag.costBefor = costBefor;

            cars = await dataBase.GetAllAutoAsync();

            return View(cars);
        }

        public async Task<IActionResult> SeeCar(string Make, string Model, string BodyType, int Year, double Price, string EngineType,
            string Drive, string Transmission, string Description, int Mileage, string PhotoUrl, string EngineCapacity)
        {
            ViewBag.Make = Make;
            ViewBag.Model = Model;
            ViewBag.BodyType = BodyType;
            ViewBag.Year = Year;
            ViewBag.Price = Price;
            ViewBag.EngineType = EngineType;
            ViewBag.Drive = Drive;
            ViewBag.Transmission = Transmission;
            ViewBag.Description = Description;
            ViewBag.Mileage = Mileage;
            ViewBag.PhotoUrl = PhotoUrl;
            ViewBag.EngineCapacity = EngineCapacity;

            cars = await dataBase.GetAllAutoAsync();

            return View(cars);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SendEmail(string subject, string body, string auto)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587, // Порт SMTP
                    Credentials = new NetworkCredential("pavelusov2004@gmail.com", "eiul myck rosp llsm"),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                   From = new MailAddress("pavelusov2004@gmail.com"),
                    Subject = subject + " покупка авто: " + auto,
                    Body = "+375 " + body,
                    IsBodyHtml = true,
                };

                mailMessage.To.Add("pavelmakeeev@yandex.ru");
                smtpClient.Send(mailMessage);
            }
            catch (SmtpException smtpExx)
            {
                ViewBag.ResponseMessage = $"Ошибка SMTP: {smtpExx.Message}";
            }

            return RedirectToAction("Index");
        }
    }
}
