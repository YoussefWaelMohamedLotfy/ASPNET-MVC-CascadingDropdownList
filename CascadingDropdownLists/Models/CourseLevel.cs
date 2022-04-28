using System.ComponentModel.DataAnnotations;

namespace CascadingDropdownLists.Models;

public class CourseLevel
{
    [Key]
    public int Id { get; set; }

    public string LevelName { get; set; } = default!;

    public List<Lesson> Lessons { get; set; } = default!;
}