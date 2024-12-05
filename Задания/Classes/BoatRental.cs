using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задания.Classes
{
    public abstract class Boat
    {
        public string Name { get; set; }
        public double Length { get; set; }
        public decimal RentalPrice { get; set; }
        public bool IsRented { get; private set; }
        public DateTime RentalStartTime { get; private set; }
        public int RentalDuration { get; private set; }

        protected Boat(string name, double length, decimal rentalPrice)
        {
            Name = name;
            Length = length;
            RentalPrice = rentalPrice;
            IsRented = false;
            RentalStartTime = DateTime.Now;
            RentalDuration = 0;
        }

        public void Rent(int duration)
        {
            if (!IsRented)
            {
                IsRented = true;
                RentalStartTime = DateTime.Now;
                RentalDuration = duration;
                Console.WriteLine($"{Name} была арендована на {duration} часов.");
            }
            else
            {
                Console.WriteLine($"{Name} уже арендована.");
            }
        }

        public decimal Return()
        {
            if (IsRented)
            {
                IsRented = false;
                decimal totalCost = RentalDuration * RentalPrice;
                Console.WriteLine($"{Name} была возвращена. Общая стоимость аренды: {totalCost}$.");
                RentalDuration = 0;
                return totalCost;
            }
            else
            {
                Console.WriteLine($"{Name} не была арендована.");
                return 0;
            }
        }

        public abstract void ShowInfo();
    }

    // Класс-наследник для моторной лодки
    public class MotorBoat : Boat
    {
        public int HorsePower { get; set; }

        public MotorBoat(string name, double length, decimal rentalPrice, int horsePower)
            : base(name, length, rentalPrice)
        {
            HorsePower = horsePower;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Моторная лодка: {Name}, Длина: {Length}м, Цена аренды: {RentalPrice}$/час, Лошадиные силы: {HorsePower}");
        }
    }

    // Класс-наследник для парусной лодки
    public class SailBoat : Boat
    {
        public double SailArea { get; set; }

        public SailBoat(string name, double length, decimal rentalPrice, double sailArea)
            : base(name, length, rentalPrice)
        {
            SailArea = sailArea;
        }
        public override void ShowInfo()
        {
            Console.WriteLine($"Парусная лодка: {Name}, Длина: {Length}м, Цена аренды: {RentalPrice}$/час, Площадь паруса: {SailArea}м^2");
        }
    }

    // Класс для управления арендой
    public class RentalService
    {
        private List<Boat> boats;

        public RentalService()
        {
            boats = new List<Boat>();
        }

        public void AddBoat(Boat boat)
        {
            boats.Add(boat);
        }

        public void ShowAvailableBoats()
        {
            Console.WriteLine("Доступные лодки для аренды:");
            foreach (var boat in boats)
            {
                if (!boat.IsRented)
                {
                    boat.ShowInfo();
                }
            }
        }
    }

}
