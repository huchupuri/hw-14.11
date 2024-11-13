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

    public struct Worker
    {
        public readonly string name;
        public University university;
        public Worker(string name, University university)
        {
            this.name = name;
            this.university = university;
        }
        public void Print() => Console.WriteLine($"работник: {name}     вуз: {university}");
    }

    public enum University { KGU, KAI, KChTI }

    public enum AccountType
    {
        undefine,
        savings,
        debit
    }
    public struct BankBill
    {
        public int id;
        readonly public AccountType account { get; }
        public int bill;

        public BankBill(int id, AccountType account, int bill)
        {
            this.id = id;
            this.account = account;
            this.bill = bill;
        }
        public void Print()

        {
            Console.WriteLine($"номер счета: {id}\nтип счета: {account}\nсредств на счете:{bill}");
        }
    }
    
    
}
    