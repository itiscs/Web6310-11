using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqApp
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Faculty { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name} {Faculty} {Address}";
        }

        public static List<Group> GetGroups()
        {
            var groups = new List<Group>();
            groups.Add(new Group() { Id = 1, Name = "6310", Faculty = "Экономический", Address = "adr 1" });
            groups.Add(new Group() { Id = 2, Name = "6311", Faculty = "Экономический", Address = "adr 1" });
            groups.Add(new Group() { Id = 3, Name = "9090", Faculty = "Математический", Address = "adr 2" });
            return groups ;
        }

    }
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int idGroup { get; set; }

        public List<int> Marks { get; set; } = new List<int>();

        public override string ToString()
        {
            return $"{Id} {Name} {idGroup} {Marks.Average()}";
        }


        public static List<Student> Generate()
        {
            var students = new List<Student>();
            students.Add(new Student
            {
                Id = 1,
                Name = "Ivan",
                idGroup = 1,
                Marks = new List<int>() { 5, 5, 5, 5, 4, 4, 4 }
            });
            students.Add(new Student
            {
                Id = 2,
                Name = "Petr",
                idGroup = 1,
                Marks = new List<int>() { 5, 3, 3, 3, 4, 4, 4 }
            });

            students.Add(new Student
            {
                Id = 3,
                Name = "Andrej",
                idGroup = 1,
                Marks = new List<int>() { 3, 3, 3, 3, 3, 3, 3, 5 }
            });

            students.Add(new Student
            {
                Id = 4,
                Name = "Ivan 4",
                idGroup = 2,
                Marks = new List<int>() { 5, 5, 5, 5}
            });

            students.Add(new Student
            {
                Id = 5,
                Name = "Ivan 5",
                idGroup = 2,
                Marks = new List<int>() {5, 4, 4, 4 }
            });

            students.Add(new Student
            {
                Id = 6,
                Name = "Ivan 6",
                idGroup = 2,
                Marks = new List<int>() { 2,2,2,2, 4, 4, 4 }
            });

            students.Add(new Student
            {
                Id = 7,
                Name = "Ivan 7",
                idGroup = 2,
                Marks = new List<int>() { 3,3,3,3,3,3 }
            });

            students.Add(new Student
            {
                Id = 8,
                Name = "Ivan 8 ",
                idGroup = 2,
                Marks = new List<int>() { 5, 5, 5, 5, 4, 4, 4 }
            });

            return students;
        }
           
    }
}
