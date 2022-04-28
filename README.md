# ASP.NET MVC Cascading Dropdown List Demo
Reference: [Cascading DropDownList in .NET Core](https://www.findandsolve.com/articles/cascading-dropdownlist-in-net-core-5)

## Main Function for Cascading
Add the following HTML in your page, as in [Home.cshtml](CascadingDropdownLists/Views/Home/Index.cshtml):
```html
<div class="row">
    <div class="col-2 form-group">
        <select asp-for="SelectedLesson.CourseLevelId" class="form-select" id="courseLevelId"
                asp-items="@Model.CourseLevelList">
        </select>
    </div>
    <div class="col-2 form-group">
        <select asp-for="SelectedLesson.Id" class="form-select" id="lessonId"></select>
    </div>
    <div class="mt-2">
        <div class="col-2 form-group">
            <button type="button" class="btn btn-primary form-control">Submit</button>
        </div>
    </div>
</div>
```
> For Styling, I use [Bootstrap 5](https://getbootstrap.com/). You can use any CSS framework you want, but remember the `id` Attributes of the markup as they are key.

The following method can be used for cascading dropdown lists
```javascript
// On each new selection you make in the CourseLevel Dropdown,
// the event is invoked
$("#courseLevelId").change(function () {
    getSecondListByFirstListSelectedId();
});
// AJAX call to Action for fetching lessons according to CourseLevel ID
var getSecondListByFirstListSelectedId = function () {
    $.ajax({
        // Pass in Query Path by concatenation
        url: 'lessons/' + $('#courseLevelId').val(),
        type: 'GET',
        // Note: The data field will pass parameters in the "Query Params", not in "Query Path"
        //data: {
        //    levelId: $('#courseLevelId').val()
        //}
        success: function (data) {
            console.log(data);
            // Removing all existing options in dropdown and loading with data from Action
            $('#lessonId').find('option').remove();
            $(data).each(function (index, item) {
                 $('#lessonId').append('<option value="' + item.lessonId + '">' + item.lessonName + '</option>');
            });
        }
    });
}
```
