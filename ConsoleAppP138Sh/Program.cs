using System;

namespace ConsoleAppP138Sh
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();

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
                        Console.WriteLine("\nQrupunuzu daxil edin:");

                        string groupno= Console.ReadLine();

                        Student findgroupno=student.GetStudentByGroupNo(groupno);

                        if(findgroupno==null)
                        {
                            Console.WriteLine($"\n{ groupno} yoxdur!");
                        }
                        else
                        {
                            findgroupno.ShowInfo();
                        }

                        break;
                    case "2":
                        Console.WriteLine("Telebelerin siyahisi:");

                        student.GetAllStudents();
                        break;
                    case "3":
                        Console.WriteLine("Telebe elave edin:");

                        string noo;
                        int no;
                        do
                        {
                            Console.Write("No: ");

                            noo=Console.ReadLine();
                            no=Convert.ToInt32(noo);
                        }
                        while(no==0);

                        string fullname;
                        do
                        {
                            Console.Write("FullName: ");

                            fullname=Console.ReadLine();
                        }
                        while(!CheckFullName(fullname));

                        string groupnoo;
                        do
                        {
                            Console.Write("GroupNo: ");

                            groupnoo=Console.ReadLine();
                        }
                        while(!CheckGroupNo(groupnoo));

                        string pointt;
                        int point;
                        do
                        {
                            Console.Write("Point: ");

                            pointt = Console.ReadLine();
                            point = Convert.ToInt32(pointt);
                        }
                        while (point < 65);

                        Console.Write("StartDate: ");

                        string datetimee=Console.ReadLine();
                        DateTime datetime=Convert.ToDateTime(datetimee);

                        Student std = new Student()
                        {
                            No = no,
                            FullName = fullname,
                            GroupNo= groupnoo,
                            Point= point,
                            StartDate= datetime
                        };

                        student.AddStudent(std);
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

        static bool CheckFullName(string fullname)
        {
            if (string.IsNullOrWhiteSpace(fullname))
            {
                return false;
            }
            var split = fullname.Split(' ');

            if (split.Length != 2)
            {
                return false;
            }

            if (!char.IsUpper(split[0][0]) || !char.IsUpper(split[1][0]) || split[0].Length < 3 || split[1].Length < 3)
            {
                return false;
            }

            for (int i = 1; i < split.Length; i++)
            {
                if (!char.IsLower(split[0][i]))
                {
                    return false;
                }
            }

            for (int i = 1; i < split.Length; i++)
            {
                if (!char.IsLower(split[0][i]))
                {
                    return false;
                }
            }
            return true;
        }

        static bool CheckGroupNo(string groupno)
        {

            if (string.IsNullOrWhiteSpace(groupno) || groupno.Length < 4)
            {
                return false;
            }

            if (!char.IsUpper(groupno[0]))
            {
                return false;
            }

            for (int i = 1; i < groupno.Length; i++)
            {
                if (!char.IsDigit(groupno[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
