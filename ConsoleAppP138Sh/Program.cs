using System;

namespace ConsoleAppP138Sh
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string secin;

            do
            {
                Console.WriteLine("\n1.Qrupdaki telebelerin siyahisini gosterin:");
                Console.WriteLine("2.Butun telebelerin siyahisini gosterin:");
                Console.WriteLine("3.Telebe elave edin:");
                Console.WriteLine("4.Tarix araligina gore telebelere baxin:");
                Console.WriteLine("5.Umumi axtaris:");
                Console.WriteLine("6.Telebenin qrupunu deyisin:");
                Console.WriteLine("7.Secilmis telebeni silin:");
                Console.WriteLine("8.Secilmis qrupun ortalama balina baxin:");
                Console.WriteLine("0.Menudan cixin!");

                Console.WriteLine("\nSeciminizi daxil edin:");
                secin = Console.ReadLine();

                switch(secin)
                {
                    
                    case "1":
                        Console.WriteLine("Qrupunuzu daxil edin:");

                        
                        break;
                    case "2":
                        Console.WriteLine();
                        break;
                    case "3":
                        Console.WriteLine();
                        break;
                    case "4":
                        Console.WriteLine();
                        break;
                    case "5":
                        Console.WriteLine();
                        break;
                    case "6":
                        Console.WriteLine();
                        break;
                    case "7":
                        Console.WriteLine();
                        break;
                    case "0":
                        Console.WriteLine("\nMenudan cixdiniz(");
                        break;
                    default: 
                        Console.WriteLine("\nYanlis secim etmisiz!!!");
                        break;
                }
            }
            while (secin != "0");
        }
    }
}
