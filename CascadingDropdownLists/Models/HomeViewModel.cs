using Microsoft.AspNetCore.Mvc.Rendering;

namespace CascadingDropdownLists.Models;

public class HomeViewModel
{
    public IEnumerable<SelectListItem> CourseLevelList { get; set; } = default!;

    public Lesson SelectedLesson { get; set; } = default!;
}
