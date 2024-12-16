using System;

namespace AutoSalon.Models
{
    public class Auto
    {
        public int IdAuto { get; set; }
        public string Make { get; set; }

        public decimal EngineCapacity { get; set; }
        // Модель автомобиля
        public string Model { get; set; }

        // Тип кузова автомобиля
        public string BodyType { get; set; }

        // Год выпуска автомобиля
        public int Year { get; set; }

        // Цена автомобиля
        public decimal Price { get; set; }

        // Тип двигателя
        public string EngineType { get; set; }

        // Привод (например, передний, задний, полный)
        public string Drive { get; set; }

        // Коробка передач (например, механическая, автоматическая)
        public string Transmission { get; set; }

        // Описание автомобиля
        public string Description { get; set; }

        // Пробег автомобиля
        public int Mileage { get; set; } // Пробег только для чтения

        public string Photo { get; set; }

        public int IdUser { get; set; }

        public virtual Users User { get; set; }

        // Конструктор класса
        public Auto(string make, string model, string bodyType, int year, decimal price,
                    string engineType, string drive, string transmission, string description, string photoUrl)
        {
            Make = make; // Инициализация марки
            Model = model; // Инициализация модели
            BodyType = bodyType; // Инициализация типа кузова
            Year = year; // Инициализация года выпуска
            Price = price; // Инициализация цены
            EngineType = engineType; // Инициализация типа двигателя
            Drive = drive; // Инициализация привода
            Transmission = transmission; // Инициализация коробки передач
            Description = description; // Инициализация описания
            Mileage = 0; // Начальный пробег
            Photo = photoUrl;
        }

        public Auto(string make)
        {
            Make = make; // Инициализация марки
        }

        public Auto(){}
    }
}
