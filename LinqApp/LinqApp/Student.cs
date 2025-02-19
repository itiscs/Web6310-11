using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqApp
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }

        public List<int> Marks { get; set; } = new List<int>();

        public override string ToString()
        {
            return $"{Id} {Name} {Group} {Marks.Average()}";
        }


        public static List<Student> Generate()
        {
            var students = new List<Student>();
            students.Add(new Student
            {
                Id = 1,
                Name = "Ivan",
                Group = "6310",
                Marks = new List<int>() { 5, 5, 5, 5, 4, 4, 4 }
            });
            students.Add(new Student
            {
                Id = 2,
                Name = "Petr",
                Group = "6310",
                Marks = new List<int>() { 5, 3, 3, 3, 4, 4, 4 }
            });

            students.Add(new Student
            {
                Id = 3,
                Name = "Andrej",
                Group = "6310",
                Marks = new List<int>() { 3, 3, 3, 3, 3, 3, 3, 5 }
            });

            students.Add(new Student
            {
                Id = 4,
                Name = "Ivan 4",
                Group = "6310",
                Marks = new List<int>() { 5, 5, 5, 5}
            });

            students.Add(new Student
            {
                Id = 5,
                Name = "Ivan 5",
                Group = "6310",
                Marks = new List<int>() {5, 4, 4, 4 }
            });

            students.Add(new Student
            {
                Id = 6,
                Name = "Ivan 6",
                Group = "6311",
                Marks = new List<int>() { 2,2,2,2, 4, 4, 4 }
            });

            students.Add(new Student
            {
                Id = 7,
                Name = "Ivan 7",
                Group = "6311",
                Marks = new List<int>() { 3,3,3,3,3,3 }
            });

            students.Add(new Student
            {
                Id = 8,
                Name = "Ivan 8 ",
                Group = "6311",
                Marks = new List<int>() { 5, 5, 5, 5, 4, 4, 4 }
            });

            return students;
        }
           
    }
}
