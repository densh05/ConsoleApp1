using System;
using System.Text;

namespace MoneyExchanger
{
    class Conventer // Создаем класс с именем Conventer.
    {
        private double UsdToUah;
        private double EurToUah;
        private double GbtToUah;

        public Conventer(double USD, double EUR, double GBT) //поля потрібні щоб зберігати курс валют
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
                "usd" => amount / UsdToUah,
                "eur" => amount / EurToUah,
                "gbt" => amount / GbtToUah,
                _ => throw new ArgumentException("Невідома валюта")
            };
        }

        //з валюти у грн
        public double ConvertToUah(double amount, string currency)
        {
            return currency.ToLower() switch
            {
                "usd" => amount * UsdToUah,
                "eur" => amount * EurToUah,
                "gbt" => amount * GbtToUah,
                _ => -1
            };
        }

        class Program
    {
            static void Main(string[] args)
            {

                Console.OutputEncoding = Encoding.Unicode;

                Console.WriteLine("Напишіть курс долара до гривні:");
                double usdRate = double.Parse(Console.ReadLine());

                Console.WriteLine("Напишіть курс евро до гривні:");
                double eurRate = double.Parse(Console.ReadLine());

                Console.WriteLine("Напишіть курс стерлінга до гривні:");
                double gbtRate = double.Parse(Console.ReadLine());

                Conventer conventer = new Conventer(usdRate, eurRate, gbtRate); //1

                

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

                            double resultFromUah = conventer.ConvertFromUah(uahAmount, currency);
                              if (resultFromUah == -1) 
                            {
                                Console.WriteLine("Невідома помилка,спробуйте ще раз");
                            }
                            else
                            {
                                Console.WriteLine($"Сума у валюті:" + resultFromUah); //Додано resultFromUah
                            }

                            break;

                        case "2":
                            Console.WriteLine("Введіть суму у валюті:");
                            double valutaAmount = double.Parse(Console.ReadLine());

                            Console.WriteLine("Виберіть валюту:USD,EUR,GBT");
                            string toCurrency = Console.ReadLine();

                            double resulToUah = conventer.ConvertToUah(valutaAmount, toCurrency); //currency = валюта
                             if (resulToUah == -1)
                            {
                                Console.WriteLine("Невідома помилка,спробуйте ще раз");
                            }
                            else
                            {
                                Console.WriteLine($"Сума у гривнях:" + resulToUah);
                            }
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
