function CourseViewModel() {

    var CourseModelObj = new CourseModel();
    var self = this;
    var initialBind = true;
    var courseListViewModel = ko.observableArray();

    this.GetCourseList = function () {

        CourseModelObj.GetCourseList(function (courseList) {
            courseListViewModel.removeAll();

            for (var i = 0; i < courseList.length; i++) {
                courseListViewModel.push({
                    course_id: courseList[i].CourseId,
                    course_title: courseList[i].Title,
                    course_level: courseList[i].CourseLevel,
                    course_description: courseList[i].Description,
                    department_id: courseList[i].DepartmentId
                });
            }

            if (initialBind) {
                ko.applyBindings({ viewModel: courseListViewModel }, document.getElementById("divSharedCourseList"));
                initialBind = false; // this is to prevent binding multiple time because "Delete" functio calls GetAll again
            }
        });
    };

    this.Initialize = function () {

        var viewModel = {
            course_id: ko.observable(),
            title: ko.observable(),
            course_level: ko.observable(),
            description: ko.observable(),
            department_id: ko.observable(),
            add: function (data) {
                self.InsertCourse(data);
            }
        };

        ko.applyBindings(viewModel, document.getElementById("divSharedInsertCourse"));
    };

    this.InsertCourse = function (viewModel) {
        var model = {
            CourseId: viewModel.course_id,
            Title: viewModel.title,
            CourseLevel: viewModel.course_level,
            Description: viewModel.description,
            DepartmentId: viewModel.department_id
        };

        CourseModelObj.Create(model, function (result) {
            if (result == "ok") {
                alert("Create course successful");
            } else {
                alert("Error occurred");
            }
        });

    };

    this.Load = function (course_id) {

        // Because the Load() is a async call (asynchronous), we'll need to use
        // the callback approach to handle the data after data is loaded.
        CourseModelObj.Load(course_id, function (result) {

            var viewModel = {
                course_id: result.CourseId,
                title: ko.observable(result.Title),
                course_level: ko.observable(result.CourseLevel),
                description: ko.observable(result.Description),
                department_id: ko.observable(result.DepartmentId),
   
                update: function () {
                    self.UpdateCourse(this);
                }
            }
            ko.applyBindings(viewModel, document.getElementById("divSharedEditCourse"));
        });
    };

    this.UpdateCourse = function (viewModel) {

        // convert the viewModel to same structure as PLAdmin model (presentation layer model)
        var courseData = {
            CourseId: viewModel.course_id,
            Title: viewModel.title,
            CourseLevel: viewModel.course_level,
            Description: viewModel.description,
            DepartmentId: viewModel.department_id
        };

        CourseModelObj.Update(courseData, function (message) {
            $('#divMessage').html(message);
        });

    };

    ko.bindingHandlers.DeleteCourse = {
        init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
            $(element).click(function () {
                var model = {
                    CourseId: viewModel.course_id
                }
                CourseModelObj.Delete(model, function (result) {
                    if (result != "ok") {
                        alert("Error occurred");
                    } else {
                        courseListViewModel.remove(viewModel);
                    }
                });
            });
        }
    };
}
