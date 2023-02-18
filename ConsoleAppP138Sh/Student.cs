using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ConsoleAppP138Sh
{
    internal class Student:ICourseManagerService    
    {
        private int _no;
        public string FullName;
        public string GroupNo;
        public double Point;
        public DateTime StartDate;

        Student[] _students;
        public Student[] Students { get=> _students; set=>_students=value; }

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

                }
            }
        }

            public static int count=0;

            public int No
            {
              get
              {
                return _no;
              }
              set
              {
                count++;
                No = count;
              }
            }
           
        

        public Student Search(string search)
        {
            Student[] wantedSearch = new Student[0];

            foreach (var item in Students)
            {
                if(item.Contains(search))
                {
                    Array.Resize(ref _students, _students.Length + 1);
                    _students[_students.Length - 1] = item;
                }
            }

            return wantedSearch;
        }
    }
}
