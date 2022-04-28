using System.ComponentModel.DataAnnotations;

namespace CascadingDropdownLists.Models;

public class Lesson
{
    [Key]
    public int Id { get; set; }

    public string LessonName { get; set; } = default!;

    public int CourseLevelId { get; set; }

    public CourseLevel CourseLevel { get; set; } = default!;
}