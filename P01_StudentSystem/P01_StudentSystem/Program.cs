using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data;
using P01_StudentSystem.Models;

using StudentSystemContext db = new StudentSystemContext();

db.Database.Migrate();

Console.WriteLine("Student System");
Console.WriteLine();

// Students

if (!db.Students.Any())
{
    var student1 = new Student
    {
        Name = "Haitham Mohamed",
        PhoneNumber = "1143894042",
        RegisteredOn = DateTime.Now,
        Birthday = new DateTime(2005, 3, 19)
    };

    var student2 = new Student
    {
        Name = "Ahmed Mohamed",
        PhoneNumber = "1501377311",
        RegisteredOn = DateTime.Now,
        Birthday = new DateTime(2005, 8, 10)
    };

    db.Students.Add(student1);
    db.Students.Add(student2);

    db.SaveChanges();

    Console.WriteLine("Students added.");
}

Console.WriteLine();
Console.WriteLine("Students");

foreach (var student in db.Students)
{
    Console.WriteLine($"{student.StudentId} - {student.Name} - {student.PhoneNumber}");
}

// Courses

if (!db.Courses.Any())
{
    var course1 = new Course
    {
        Name = "C# Fundamentals",
        Description = "Introduction to C#",
        StartDate = DateTime.Now,
        EndDate = DateTime.Now.AddMonths(2),
        Price = 2500
    };

    var course2 = new Course
    {
        Name = "SQL Server",
        Description = "Database Course",
        StartDate = DateTime.Now,
        EndDate = DateTime.Now.AddMonths(3),
        Price = 2000
    };

    db.Courses.Add(course1);
    db.Courses.Add(course2);

    db.SaveChanges();

    Console.WriteLine("Courses added.");
}

Console.WriteLine();
Console.WriteLine("Courses");

foreach (var course in db.Courses)
{
    Console.WriteLine($"{course.CourseId} - {course.Name} - {course.Price}");
}

// Resources

if (!db.Resources.Any())
{
    var resource1 = new Resource
    {
        Name = "Lecture 1",
        Url = "https://youtube.com/lecture1",
        ResourceType = ResourceType.Video,
        CourseId = 1
    };

    var resource2 = new Resource
    {
        Name = "Slides",
        Url = "https://drive.google.com/slides",
        ResourceType = ResourceType.Presentation,
        CourseId = 1
    };

    db.Resources.Add(resource1);
    db.Resources.Add(resource2);

    db.SaveChanges();

    Console.WriteLine("Resources added.");
}

Console.WriteLine();
Console.WriteLine("Resources");

var resources = db.Resources
    .Include(r => r.Course)
    .ToList();

foreach (var resource in resources)
{
    Console.WriteLine($"{resource.Name} - {resource.Course.Name}");
}

// Homework

if (!db.Homeworks.Any())
{
    var homework = new Homework
    {
        Content = "Homework1.zip",
        ContentType = ContentType.Zip,
        SubmissionTime = DateTime.Now,
        StudentId = 2,
        CourseId = 1
    };

    db.Homeworks.Add(homework);

    db.SaveChanges();

    Console.WriteLine("Homework added.");
}

Console.WriteLine();
Console.WriteLine("Homeworks");

var homeworks = db.Homeworks
    .Include(h => h.Student)
    .Include(h => h.Course)
    .ToList();

foreach (var homework in homeworks)
{
    Console.WriteLine($"{homework.Student.Name} submitted {homework.Content} in {homework.Course.Name}");
}

// Student courses

if (!db.StudentsCourses.Any())
{
    var registration1 = new StudentCourse
    {
        StudentId = 1,
        CourseId = 1
    };

    var registration2 = new StudentCourse
    {
        StudentId = 1,
        CourseId = 2
    };

    var registration3 = new StudentCourse
    {
        StudentId = 2,
        CourseId = 1
    };

    db.StudentsCourses.Add(registration1);
    db.StudentsCourses.Add(registration2);
    db.StudentsCourses.Add(registration3);

    db.SaveChanges();

    Console.WriteLine("Students registered.");
}

Console.WriteLine();
Console.WriteLine("Student Courses");

var studentCourses = db.StudentsCourses
    .Include(sc => sc.Student)
    .Include(sc => sc.Course)
    .ToList();

foreach (var item in studentCourses)
{
    Console.WriteLine($"{item.Student.Name} -> {item.Course.Name}");
}

Console.WriteLine();
Console.WriteLine("Finished.");
