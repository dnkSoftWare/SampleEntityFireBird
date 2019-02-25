using System;
using System.IO;
using System.Linq;
using FBSampleFromCore.Models;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FBSampleFromCore
{
    class Program
    {

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            // установка пути к текущему каталогу
           builder.SetBasePath(Directory.GetCurrentDirectory());
//            // получаем конфигурацию из файла appsettings.json
           builder.AddJsonFile("appsettings.json");
            // создаем конфигурацию
            var config = builder.Build();
            // получаем строку подключения
            string connectionString = config.GetConnectionString("DefaultConnection");

            using (FBSampleFromCore.Models.AppContext ctxt = new FBSampleFromCore.Models.AppContext(connectionString))
            {
                User user1 = new User()
                {
                    Id = 1,
                    Name = "Dima",
                    Psw = "123"
                };
                User user2 = new User()
                {
                    Id = 1,
                    Name = "Наташа",
                    Psw = "123654"
                };
                ctxt.Users.Add(user1);
                ctxt.Users.Add(user2);
                ctxt.SaveChanges();
                Console.WriteLine("Два пользователя добавлены!");
                // получаем объекты из бд и выводим на консоль
                var users = ctxt.Users.ToList();
                Console.WriteLine("Список объектов:");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Psw}");
                }
            }

            Console.ReadKey();
        }
    }
}
