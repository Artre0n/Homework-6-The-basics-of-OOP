using Задания.Classes;

try
{
    RentalService rentalService = new RentalService();

    Console.WriteLine("Введите информацию о моторной лодке:");
    Console.Write("Имя: ");
    string motorBoatName = Console.ReadLine();
    Console.Write("Длина: ");
    double motorBoatLength = double.Parse(Console.ReadLine());
    Console.Write("Цена аренды: ");
    decimal motorBoatPrice = decimal.Parse(Console.ReadLine());
    Console.Write("Лошадиные силы: ");
    int horsePower = int.Parse(Console.ReadLine());
    MotorBoat motorBoat = new MotorBoat(motorBoatName, motorBoatLength, motorBoatPrice, horsePower);
    rentalService.AddBoat(motorBoat);

    Console.WriteLine("Введите информацию о парусной лодке:");
    Console.Write("Имя: ");
    string sailBoatName = Console.ReadLine();
    Console.Write("Длина: ");
    double sailBoatLength = double.Parse(Console.ReadLine());
    Console.Write("Цена аренды: ");
    decimal sailBoatPrice = decimal.Parse(Console.ReadLine());
    Console.Write("Площадь паруса: ");
    double sailArea = double.Parse(Console.ReadLine());
    SailBoat sailBoat = new SailBoat(sailBoatName, sailBoatLength, sailBoatPrice, sailArea);
    rentalService.AddBoat(sailBoat);

    // Показать доступные лодки
    rentalService.ShowAvailableBoats();

    // Аренда лодок 
    motorBoat.Rent(12);
    sailBoat.Rent(15);

    // Показать доступные лодки после аренды
    rentalService.ShowAvailableBoats();

    // Возврат лодок
    motorBoat.Return();
    sailBoat.Return();

    // Показать доступные лодки после возврата
    rentalService.ShowAvailableBoats();
}
catch(FormatException)
{
    Console.WriteLine("Неверный формат числа");
}