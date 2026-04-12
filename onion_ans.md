using System;
using System.Collections.Generic;
using System.Linq;

namespace OnionGradingSystem
{
    //////////////////////////
    // 🟣 CORE LAYER
    //////////////////////////

    public interface IGradeStrategy
    {
        bool IsMatch(int marks);
        string Calculate(int marks);
    }

    public interface IStudentRepository
    {
        void Save(string name, int marks, string grade);
    }

    //////////////////////////
    // 🔵 INFRASTRUCTURE LAYER
    //////////////////////////

    // 🎯 Grade Strategies (Each rule separate class)

    public class DistinctionGrade : IGradeStrategy
    {
        public bool IsMatch(int marks) => marks >= 90;
        public string Calculate(int marks) => "Distinction";
    }

    public class APlusGrade : IGradeStrategy
    {
        public bool IsMatch(int marks) => marks >= 80 && marks < 90;
        public string Calculate(int marks) => "A+";
    }

    public class AGrade : IGradeStrategy
    {
        public bool IsMatch(int marks) => marks >= 70 && marks < 80;
        public string Calculate(int marks) => "A";
    }

    public class BGrade : IGradeStrategy
    {
        public bool IsMatch(int marks) => marks >= 60 && marks < 70;
        public string Calculate(int marks) => "B";
    }

    public class FGrade : IGradeStrategy
    {
        public bool IsMatch(int marks) => marks < 60;
        public string Calculate(int marks) => "F";
    }

    // 🎯 Fake Database Implementation

    public class FakeDatabase : IStudentRepository
    {
        public void Save(string name, int marks, string grade)
        {
            Console.WriteLine("=================================");
            Console.WriteLine($"Saved Student Record");
            Console.WriteLine($"Name : {name}");
            Console.WriteLine($"Marks: {marks}");
            Console.WriteLine($"Grade: {grade}");
            Console.WriteLine("=================================\n");
        }
    }

    //////////////////////////
    // 🟡 SERVICE LAYER
    //////////////////////////

    public class StudentService
    {
        private readonly List<IGradeStrategy> _strategies;
        private readonly IStudentRepository _repository;

        public StudentService(List<IGradeStrategy> strategies, IStudentRepository repository)
        {
            _strategies = strategies;
            _repository = repository;
        }

        public void ProcessStudent(string name, int marks)
        {
            var strategy = _strategies.First(s => s.IsMatch(marks));
            string grade = strategy.Calculate(marks);

            _repository.Save(name, marks, grade);
        }
    }

    //////////////////////////
    // 🔴 PRESENTATION LAYER
    //////////////////////////

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("🧅 Onion Architecture - Student Grading System\n");

            // 🧠 All strategies (order matters!)
            var strategies = new List<IGradeStrategy>
            {
                new DistinctionGrade(),
                new APlusGrade(),
                new AGrade(),
                new BGrade(),
                new FGrade()
            };

            // 🗄 Repository
            IStudentRepository repository = new FakeDatabase();

            // ⚙️ Service
            var service = new StudentService(strategies, repository);

            // 🧪 Test data
            service.ProcessStudent("Nafis", 95);
            service.ProcessStudent("Rahim", 82);
            service.ProcessStudent("Karim", 74);
            service.ProcessStudent("Sakib", 65);
            service.ProcessStudent("Jahid", 40);

            Console.WriteLine("Done processing students...");
        }
    }
}