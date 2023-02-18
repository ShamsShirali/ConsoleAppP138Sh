using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ConsoleAppP138Sh
{
    internal class Student:ICourseManagerService    
    {
        public int No;
        private string _fullName;
        private string _groupNo;
        public double Point;
        public DateTime StartDate;

        Student[] _students=new Student[0];
        public Student[] Students { get=> _students; set=>_students=value; }

        public static int count;

        public Student() 
        {
            count++;
            No = count;
        }

        public string FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                if (CheckFullName(value))
                {
                    _fullName = value;
                }
            }
        }

        public bool CheckFullName(string fullname)
        {
            if (string.IsNullOrWhiteSpace(fullname))
            {
                return false;
            }
            var split=fullname.Split(' ');

            if (split.Length != 2)
            {
                return false;
            }

            if (!char.IsUpper(split[0][0]) || !char.IsUpper(split[1][0]) || split[0].Length<3 || split[1].Length < 3)
            {
                return false;
            }

            for(int i = 1; i < split.Length; i++)
            {
                if (!char.IsLower(split[0][i]))
                {
                    return false;
                }
            }

            for(int i = 1; i < split.Length; i++)
            {
                if (!char.IsLower(split[0][i]))
                {
                    return false;
                }
            }
            return true;
        }

        public string GroupNo
        {
            get
            {
                return _groupNo;
            }
            set
            {
                if(CheckGroupNo(value))
                {
                    _groupNo = value;
                }
            }
        }

        public bool CheckGroupNo(string groupno)
        {

            if(string.IsNullOrWhiteSpace(groupno) || groupno.Length<4) 
            {
                return false;
            }

            if (!char.IsUpper(groupno[0]))
            {
                return false;
            }

            for(int i=1;i<groupno.Length;i++)
            {
                if (!char.IsDigit(groupno[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public void AddStudent(Student student)
        {
            Array.Resize(ref _students,_students.Length+1);
            _students[_students.Length - 1] = student;
        }

        public void ChangeStudentGroup(int studentno, string groupno)
        {
           foreach(var item in Students)
           {
                if(item.No==studentno)
                {
                    groupno=Console.ReadLine();
                    item.GroupNo=groupno;
                    
                }
           }

        }

        public Student FindStudentByNo(int no)
        {
            foreach (var item in Students)
            {
                if (item.No == no)
                {
                    return item;
                }
            }
            return null;
        }

        public Student GetAllStudents()
        {
           foreach(var item in Students)
            {
                return item;
            }
           return null;
        }

        public double GetAvgPoint(string groupno)
        {
            double sum = 0;
            int count = 0;

           foreach(var item in Students)
           {
                sum += item.Point;
                count++;
           }
           return sum/count;
        }

        public Student GetStudentByGroupNo(string groupno)
        {
            {

                foreach (var item in Students)
                {
                    if (item.GroupNo == groupno)
                    {
                        return item;
                    }
                }
                return null;
            }

        }

        public Student GetStudentsByDateRange(DateTime date1,DateTime date2)
        {
            foreach (var item in Students)
            {
                if (item.StartDate > date1 && item.StartDate < date2)
                {
                    return item;
                }
            }
            return null;
        }

        public void RemoveStudent(int studentno)
        {
            foreach (var item in Students)
            {
                if (item.No == studentno)
                {
                //    Remove(item);
                }
            }
        }

        public Student[] Search(string search)
        {
            Student[] wantedSearch = new Student[0];

            foreach (var item in Students)
            {
                if (item.FullName.Contains(search) || item.GroupNo.Contains(search)) 
                {
                    Array.Resize(ref _students, _students.Length + 1);
                    _students[_students.Length - 1] = item;
                }
            }

           return wantedSearch;

            
        }

        public void ShowInfo()
        {
            Console.Write($"\nNo: {No} - FullName: {FullName} - GroupNo: {GroupNo} - Point: {Point} - StartDate: {StartDate}");
        }
    }
}
