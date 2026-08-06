using System.ComponentModel.DataAnnotations;

namespace P01_StudentSystem.Models;

public class Course
{
    [Key]
    public int CourseId { get; set; }

    [Required]
    [MaxLength(80)]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public decimal Price { get; set; }

    public ICollection<Resource> Resources { get; set; }
        = new List<Resource>();

    public ICollection<Homework> HomeworkSubmissions { get; set; }
        = new List<Homework>();

    public ICollection<StudentCourse> StudentCourses { get; set; }
        = new List<StudentCourse>();
}