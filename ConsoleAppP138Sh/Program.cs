using System;
using System.Drawing;
using System.Text.RegularExpressions;

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
                        
                        var see=student.GetAllStudents(); 

                        foreach(var item in see)
                        {
                            if (item == null)
                            {
                                Console.WriteLine("\nSiyahi bosdur:(");
                            }
                            else
                            {
                                Console.Write($"\nNo: {item.No} - FullName: {item.FullName} - GroupNo: {item.GroupNo} - Point: {item.Point} - StartDate: {item.StartDate}");
                            }
                        }
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
                        Console.WriteLine("\nTarix araliqlarini elave edin:");

                        Console.Write("Baslangic araliq: ");
                        string datee1 = Console.ReadLine();
                        DateTime date1 = Convert.ToDateTime(datee1);

                        Console.Write("Son araliq: ");
                        string datee2= Console.ReadLine();
                        DateTime date2 = Convert.ToDateTime(datee2);

                        var see2=student.GetStudentsByDateRange(date1, date2);

                        foreach(var item in see2)
                        {
                            if (item == null)
                            {
                                Console.WriteLine("\nSiyahi bosdur:(");
                            }
                            else
                            {
                                Console.Write($"\nNo: {item.No} - FullName: {item.FullName} - GroupNo: {item.GroupNo} - Point: {item.Point} - StartDate: {item.StartDate}");
                            }
                        }
                        break;
                    case "5":
                        Console.WriteLine("\nAxtaris:");

                        string look=Console.ReadLine();
                        var see3 = student.Search(look);

                        foreach(var item in see3)
                        {
                            if (look == null)
                            {
                                Console.WriteLine("Siyahida axtarisiniza uygun netice tapilmamaqdadir:)");
                            }
                            else
                            {
                                Console.Write($"\nNo: {item.No} - FullName: {item.FullName} - GroupNo: {item.GroupNo} - Point: {item.Point} - StartDate: {item.StartDate}");
                            }
                        }
                        break;
                    case "6":
                        string stdnoo;
                        int stdno;
                        do
                        {
                            Console.Write("No: ");

                            stdnoo = Console.ReadLine();
                            stdno = Convert.ToInt32(stdnoo);
                        }
                        while (stdno == 0);

                        string groupn;
                        do
                        {
                            Console.Write("GroupNo-nu deyise bilersiniz: ");

                            groupn = Console.ReadLine();
                        }
                        while (!CheckGroupNo(groupn));

                        student.ChangeStudentGroup(stdno, groupn);

                        
                        break;
                    case "7":
                        Console.WriteLine();
                        break;
                    case "8":
                        Console.WriteLine("Grupu daxil edin:");
                        string grouppno = Console.ReadLine();

                        Console.WriteLine(student.GetAvgPoint(grouppno));
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
