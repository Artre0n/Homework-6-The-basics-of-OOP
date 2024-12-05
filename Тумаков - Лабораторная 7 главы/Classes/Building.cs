namespace Тумаков___Лабораторная_7_главы
{
    /// <summary>
    /// Класс, описывающий здание.
    /// </summary>
    public class Building
    {
        #region Закрытыe поля
        // Статическое поле для хранения последнего использованного номера здания
        private static int lastBuildingNumber = 0;

        // Закрытые поля
        private int buildingNumber; // Уникальный номер здания
        private double height; // Высота здания в метрах
        private int floors; // Этажность
        private int flats; // Общее количество квартир
        private int entrances; // Количество подъездов
        #endregion

        #region Конструктор
        /// <summary>
        /// Конструктор, который автоматически генерирует уникальный номер здания
        /// </summary>
        /// <param name="height">Высота здания</param>
        /// <param name="floors">Этажность здания</param>
        /// <param name="flats">Количество квартир</param>
        /// <param name="entrances">Количество подъездов</param>
        public Building(double height, int floors, int flats, int entrances)
        {
            this.buildingNumber = GenerateBuildingNumber();
            this.height = height;
            this.floors = floors;
            this.flats = flats;
            this.entrances = entrances;
        }
        #endregion

        /// <summary>
        /// Генерирует уникальный номер здания
        /// </summary>
        /// <returns>Уникальный номер здания</returns>
        private static int GenerateBuildingNumber()
        {
            lastBuildingNumber++;
            return lastBuildingNumber;
        }

        #region Свойства
        /// <summary>
        /// Получает высоту здания.
        /// </summary>
        public double Height => height;

        /// <summary>
        /// Получает этажность здания.
        /// </summary>
        public int Floors => floors;

        /// <summary>
        /// Получает количество квартир в здании.
        /// </summary>
        public int Flats => flats;

        /// <summary>
        /// Получает количество подъездов в здании.
        /// </summary>
        public int Entrances => entrances;

        /// <summary>
        /// Получает уникальный номер здания.
        /// </summary>
        public int BuildingNumber => buildingNumber;
        #endregion

        #region Методы
        /// <summary>
        /// Вычисляет высоту этажа.
        /// </summary>
        /// <returns>Высота одного этажа.</returns>
        public double FloorHeight()
        {
            if (floors > 0 && height > 0)
            {
                return height / floors;
            }
            throw new InvalidOperationException("Этажность и высота здания должны быть больше нуля.");
        }

        /// <summary>
        /// Вычисляет количество квартир в одном подъезде.
        /// </summary>
        /// <returns>Количество квартир в подъезде.</returns>
        public int FlatsPerEntrance()
        {
            if (entrances > 0 && flats > 0)
            {
                return flats / entrances;
            }
            throw new InvalidOperationException("Количество подъездов и квартир должно быть больше нуля.");
        }

        /// <summary>
        /// Вычисляет количество квартир на этаже.
        /// </summary>
        /// <returns>Количество квартир на этаже.</returns>
        public int FlatsPerFloor()
        {
            if (floors > 0 && flats > 0)
            {
                return flats / floors;
            }
            throw new InvalidOperationException("Этажность и высоту здания должна быть больше нуля.");
        }

        /// <summary>
        /// Выводит информацию о здании.
        /// </summary>
        public void ShowBuildingInfo()
        {
            Console.WriteLine("Информация о здании:");
            Console.WriteLine($"  Уникальный номер здания: {buildingNumber}");
            Console.WriteLine($"  Высота: {height} м");
            Console.WriteLine($"  Этажность: {floors} этажей");
            Console.WriteLine($"  Количество квартир: {flats}");
            Console.WriteLine($"  Количество подъездов: {entrances}");
            Console.WriteLine($"  Высота этажа: {FloorHeight():F2} м");
            Console.WriteLine($"  Количество квартир в подъезде: {FlatsPerEntrance()}");
            Console.WriteLine($"  Количество квартир на этаже: {FlatsPerFloor()}");
        }
        #endregion

    }

}
