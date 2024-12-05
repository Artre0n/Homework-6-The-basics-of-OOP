namespace Тумаков___Лабораторная_7_главы.Classes
{
    public enum AccountType
    {
        Текущий,
        Накопительный,
        Депозитный,
        Инвестиционный,
        Валютный,
        Расчетный
    }

    // Класс для банковского счета
    public class BankAccount
    {
        // Закрытые поля
        // Статическая переменная для хранения последнего номера счета
        private static int lastAccountNumber = 0;

        private string accountNumber;
        private decimal balance;
        private AccountType accountType;

        // Конструктор класса
        public BankAccount(string accountNumber, decimal currentBalance, AccountType accountType)
        {
            this.accountNumber = accountNumber;
            this.balance = currentBalance;
            this.accountType = accountType;
        }
        public BankAccount(decimal currentBalance, AccountType accountType)
        {
            this.accountNumber = GenerateAccountNumber();
            this.balance = currentBalance;
            this.accountType = accountType;
        }

        private static string GenerateAccountNumber()
        {
            lastAccountNumber++;
            return lastAccountNumber.ToString("D16");
        }

    
        public string GetAccountNumber()
        {
            return accountNumber;
        }

        
        public decimal GetBalance()
        {
            return balance;
        }

        
        public AccountType GetAccountType()
        {
            return accountType;
        }

        
        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine($"Пополнение на сумму {amount}$. Новый баланс: {balance}$.");
            }
            else
            {
                Console.WriteLine("Сумма пополнения должна быть положительной.");
            }
        }

        
        public void Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"Снятие на сумму {amount}$. Новый баланс: {balance}$.");
            }
            else
            {
                Console.WriteLine("Недостаточно средств или сумма снятия некорректна.");
            }
        }

        
        public void ShowAccountInfo()
        {
            Console.WriteLine("Информация о счете:");
            Console.WriteLine($"  Номер счета: {accountNumber}");
            Console.WriteLine($"  Баланс: {balance}$");
            Console.WriteLine($"  Тип счета: {accountType}\n");
        }
    }
}
