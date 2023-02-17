using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ConsoleAppP138Sh
{
    internal interface ICourseManagerService
    {

        Student[] Students { get; set; }

        public void AddStudent(string student);


        public void ChangeStudentGroup(int studentno, string groupno);



        public Student[] GetStudentByGroupNo(string groupno);

        public Student[] GetAllStudents();


        public Student FindStudentByNo(int no);


        public Student Search(string search);

        public Student[] GetStudentsByDateRange();


        public void RemoveStudent();


        public Student[] GetAvgPoint();
       
    }
}
