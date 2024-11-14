using System.IO.IsolatedStorage;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Transactions;

namespace project
{
    class Program
    {
        static void Main()
        {
            //Выведите на экран информацию о каждом типе данных в виде:
            //Тип данных – максимальное значение – минимальное значение
            //Console.WriteLine("задание 1");

            Console.WriteLine("Тип данных – максимальное значение – минимальное значение");
            Console.WriteLine($"byte: {byte.MaxValue} – {byte.MinValue}");
            Console.WriteLine($"sbyte: {sbyte.MaxValue} – {sbyte.MinValue}");
            Console.WriteLine($"short: {short.MaxValue} – {short.MinValue}");
            Console.WriteLine($"ushort: {ushort.MaxValue} – {ushort.MinValue}");
            Console.WriteLine($"int: {int.MaxValue} – {int.MinValue}");
            Console.WriteLine($"uint: {uint.MaxValue} – {uint.MinValue}");
            Console.WriteLine($"long: {long.MaxValue} – {long.MinValue}");
            Console.WriteLine($"ulong: {ulong.MaxValue} – {ulong.MinValue}");
            Console.WriteLine($"float: {float.MaxValue} – {float.MinValue}");
            Console.WriteLine($"double: {double.MaxValue} – {double.MinValue}");
            Console.WriteLine($"decimal: {decimal.MaxValue} – {decimal.MinValue}");
            Console.WriteLine($"char: {char.MaxValue} – {char.MinValue}");

            //Напишите программу, в которой принимаются данные пользователя в виде имени,
            //города, возраста и PIN - кода.Далее сохраните все значение в соответствующей
            //переменной, а затем распечатайте всю информацию в правильном формате.
            Console.WriteLine("\nзадание 2");
            Console.WriteLine("Введите имя, город, возраст и PIN-код");
            string[] user;
            while (true)
            {
                user = Console.ReadLine().Split(' ');
                if (user.Length == 4) break;
                else Console.WriteLine("введены не все данные");
            }
            User johan = new User(user[0], user[1]);
            if (int.TryParse(user[2], out int userAge) && int.TryParse(user[3], out int userPIN))
            {
                johan.age = userAge;
                johan.pin = userPIN;
            }
            else Console.WriteLine("неправильный ввод");

            johan.Print();

            //Преобразуйте входную строку: строчные буквы замените на заглавные, заглавные– на строчные
            Console.Write("Введите строку: ");
            char[] text = Console.ReadLine().ToCharArray();
            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsLower(text[i]))
                {
                    text[i] = char.ToUpper(text[i]);
                }
                else
                {
                    text[i] = char.ToLower(text[i]);
                }
            }
            Console.WriteLine(text);

            Console.WriteLine("\nзадание 4");

            //Введите строку, введите подстроку.Необходимо найти количество вхождений и вывести на экран.
            Console.Write("Введите строку: ");
            char[] sentence = Console.ReadLine().ToArray<char>();
            Console.Write("Введите подстроку: ");
            string substring;
            while (true)
            {
                substring = Console.ReadLine();
                if (substring.Length != 0) break;
                else Console.WriteLine("введите хоть что-то");
            }
            int len = substring.Length, count = 0;

            for (int i = 0; i <= (sentence.Length - len); i++)
            {
                if (string.Join("", sentence[i..(i + len)]) == substring) count++;
            }
            Console.WriteLine($"{count} substring(s)");


            //Console.WriteLine("\nзадание 5");
            //Цель этой задачи - определить, сколько бутылок виски беспошлинной торговли 
            //вам нужно будет купить, чтобы экономия по сравнению с обычной средней ценой фактически 
            //покрыла расходы на ваш отпуск.

            bool priceCheck, holidayPriceCheck, saleCheck;
            double holidayPrice, salePrice, normalPrice;
            Console.Write("стандартная цена:");
            while (true)
            {
                if (priceCheck = double.TryParse(Console.ReadLine(), out normalPrice) && normalPrice > 0) break;
                else Console.WriteLine("введите число > 0");
            }
            Console.Write("скидка:");
            while (true)
            {
                if (saleCheck = double.TryParse(Console.ReadLine(), out salePrice) && salePrice > 0) break;
                else Console.WriteLine("введите число > 0");
            }
            salePrice = 1 - salePrice * 0.01;
            Console.Write("стоимость отпуска:");
            while (true)
            {
                if (holidayPriceCheck = double.TryParse(Console.ReadLine(), out holidayPrice) && holidayPrice > 0) break;
                else Console.WriteLine("введите число > 0");
            }
            Console.WriteLine($"{(int)(holidayPrice / (normalPrice - salePrice * normalPrice))} бутылок");

            Console.WriteLine("\nзадание 6\n");
            //Создать структуру студента.У студента есть Фамилия, Имя, его Идентификатор, Дата рождения, Категория алкоголизма

            AlcoholType pivo = new AlcoholType(Drink.pivo, 5.4);
            AlcoholType pivas = new AlcoholType(Drink.pivas, 8);
            AlcoholType kvas = new AlcoholType(Drink.kvas, 1.2);
            AlcoholType whiskey = new AlcoholType(Drink.whiskey, 45.3);

            List<Student> units = new List<Student>();

            units.Add(new Student("Евгений", "Пушин", "svin", new DateTime(2006, 1, 1), 'a', 5, whiskey));
            units.Add(new Student("Роман", "Романов", "romas", new DateTime(2006, 1, 2), 'a', 4, pivo));
            units.Add(new Student("Золтан", "Хивай", "zirilla.gif", new DateTime(1763, 11, 6), 'a', 20, pivas));
            units.Add(new Student("Фогель", "", "McLovin", new DateTime(2008, 1, 1), 'c', 2, whiskey));
            units.Add(new Student("George", "Smith", "D/I", new DateTime(2000, 1, 1), 'd', 3, pivas));


            double commonVolume = 0;
            double commonAlc = 0;

            foreach (Student unit in units)
            {
                commonVolume += unit.volume;
                commonAlc += unit.volume * unit.alcohole.percentage * 0.01;
            }
            Console.WriteLine($"Всего выпито: {commonVolume}л. напитков, в которых содержалось {Math.Round(commonAlc, 2)}л. спирта");
            foreach (Student unit in units)
            {
                Console.WriteLine($"Студент {unit.name} {unit.surname} выпил {Math.Round((100 * unit.volume / commonVolume), 1)}% от всех напитков и {Math.Round((unit.volume * unit.alcohole.percentage / commonAlc), 1)}% всего спирта");
            }


        }
    }
    public struct User
    {
        public string name, city;
        public int age, pin;
        public User(string name, string city)
        {
            this.name = name;
            this.city = city;
        }
        public void Print() => Console.WriteLine($"имя: {name} || город: {city} || возраст: {age} || PIN: {pin}");

    }

    public struct Student
    {
        public string surname, name, login;
        DateTime birthDay;
        char alcoholCategory;
        public double volume;
        public AlcoholType alcohole;
        public Student(string name, string surname, string login,
        DateTime birthDay, char alcoholCategory, double volume, AlcoholType alcohole)
        {
            this.surname = surname;
            this.name = name;
            this.login = login;
            this.birthDay = birthDay;
            this.alcoholCategory = alcoholCategory;
            this.volume = volume;
            this.alcohole = alcohole;
        }
        public double AlcVolume()
        {
            return (volume * alcohole.percentage);
        }
    }



    public struct AlcoholType
    {
        public Drink drink;
        public double percentage;
        public AlcoholType(Drink drink, double percentage)
        {
            this.drink = drink;
            this.percentage = percentage;
        }
    }
    public enum Drink { pivo, pivas, kvas, whiskey }

}