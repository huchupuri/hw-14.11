using System;

namespace lab
{
    class Program
    {
        static void Main(string[] args)
        {
            //Создать перечислимый тип данных отображающий виды банковского
            //счета(текущий и сберегательный).Создать переменную типа перечисления, присвоить ей
            //значение и вывести это значение на печать.


            Console.WriteLine("лаба 3.1");
            
            AccountType bankType = AccountType.savings;
            Console.WriteLine($"текущий вид счета: {bankType}");


            //Создать структуру данных, которая хранит информацию о банковском
            //счете – его номер, тип и баланс. Создать переменную такого типа, заполнить структуру
            //значениями и напечатать результат.

            Console.WriteLine("лаба 3.2");
            
            BankBill bankBill = new BankBill(1111, bankType, 2222);
            bankBill.Print();


            //Создать перечислимый тип ВУЗ{ КГУ, КАИ, КХТИ}. Создать
            //структуру работник с двумя полями: имя, ВУЗ.Заполнить структуру данными и
            //распечатать.

            
            Console.WriteLine("домашнее задание 3.1");

            List<Worker> units = new List<Worker>();
            units.Add(new Worker("Joey J.", University.KAI));
            units.Add(new Worker("Walter J.", University.KGU));
            units.Add(new Worker("C. Sanders", University.KChTI));
            foreach (Worker unit in units)
            {
                unit.Print();
            }

        }
    }

    /// <summary>
    /// структура для работников вуза
    /// </summary>
    public struct Worker
    {
        /// <summary>
        /// инициализация параметров экзепляра
        /// </summary>
        public string name;
        public University university;

        /// <summary>
        /// создание конструктора структуры
        /// </summary>
        public Worker(string name, University university)
        {
            this.name = name;
            this.university = university;
        }
        public void Print() => Console.WriteLine($"работник: {name}     вуз: {university}");
    }

    /// <summary>
    /// университеты
    /// </summary>
    public enum University { KGU, KAI, KChTI }

    /// <summary>
    /// виды счетов в банке
    /// </summary>
    public enum AccountType
    {
        undefine,
        savings,
        debit
    }


    /// <summary>
    /// информация о банковском счёте
    /// </summary>
    public struct BankBill
    {
        /// <summary>
        /// инициализация параметров экзепляра
        /// </summary>
        public int id;
        readonly public AccountType account { get; }
        public int bill;

        /// <summary>
        /// создание конструктора структуры
        /// </summary>
        public BankBill(int id, AccountType account, int bill)
        {
            this.id = id;
            this.account = account;
            this.bill = bill;
        }

        /// <summary>
        /// вывод информации об экземпляре
        /// </summary>
        public void Print()

        {
            Console.WriteLine($"номер счета: {id}\nтип счета: {account}\nсредств на счете:{bill}");
        }
    }
    
    
}
    