using System;
using System.Text;

namespace MoneyExchanger
{
    internal class Program
    {
        class Conventer
        {
            private double UsdToUah;
            private double EurToUah;
            private double GbtToUah;

            public Conventer(double USD, double EUR, double GBT)
            {
                UsdToUah = USD;
                EurToUah = EUR;
                GbtToUah = GBT;
            }

            //з гривні у валюту   amount=кількість
            public double ConvertFromUah(double amount, string currency)
            {
                return currency.ToLower() switch
                {
                    "USD" => amount / UsdToUah,
                    "EUR" => amount / EurToUah,
                    "GBT" => amount / GbtToUah,
                    _ => throw new ArgumentException("Невідома валюта")
                };
            }

            //з валюти у грн
            public double ConvertToUah(double amount, string currency)
            {
                return currency.ToLower() switch
                {
                    "USD" => amount * UsdToUah,
                    "EUR" => amount * EurToUah,
                    "GBT" => amount * GbtToUah,
                    _ => throw new ArgumentException("Невідома валюта")
                };
            }

            static void Main(string[] args)
            {
                Console.OutputEncoding = Encoding.Unicode;

                Console.WriteLine("Напишіть курс долара до гривні:");
                double usdRate = double.Parse(Console.ReadLine());

                Console.WriteLine("Напишіть курс евро до гривні:");
                double eurRate = double.Parse(Console.ReadLine());

                Console.WriteLine("Напишіть курс стерлінга до гривні:");
                double gbtRate = double.Parse(Console.ReadLine());

                Conventer conventer = new Conventer(usdRate, eurRate, gbtRate);

                while (true)
                {
                    Console.WriteLine("Виберіть операцію:");
                    Console.WriteLine("1 - Конвертувати з гривні у валюту");
                    Console.WriteLine("2 - Конвертувати з валюти у гривню");
                    Console.WriteLine("3 - Вихід");

                    string choice = Console.ReadLine();

                    if (choice == "3") break;

                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine("Введіть суму у гривнях:");
                            double uahAmount = double.Parse(Console.ReadLine());

                            Console.WriteLine("Виберіть валюту:USD,EUR,GBT");
                            string currency = Console.ReadLine();
                            break;

                        case "2":
                            Console.WriteLine("Введіть суму у валюті:");
                            double valutaAmount = double.Parse(Console.ReadLine());

                            Console.WriteLine("Виберіть валюту:USD,EUR,GBT");
                            string toCurrency = Console.ReadLine();
                            break;

                        default:
                            Console.WriteLine("Виникла помилка, спробуйте ще раз!");
                            break;



                    }
                }

                Console.WriteLine("До зустрічі!");

            }



        }
    }
}
