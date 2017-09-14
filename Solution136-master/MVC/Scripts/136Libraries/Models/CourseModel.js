function CourseModel(asyncIndicator) {
    if (asyncIndicator == undefined) {
        asyncIndicator = true;
    }

    this.Delete = function (course, callback) {
        $.ajax({
            async: asyncIndicator,
            method: "POST",
            url: "http://localhost:9393/Api/Course/DeleteCourse",
            data: course,
            dataType: "json",
            success: function (result) {
                callback(result);
            },
            error: function () {
                alert('Error while deleteing course.  Is your service layer running?');
            }
        });
    };

    this.Create = function (course, callback) {
        $.ajax({
            async: asyncIndicator,
            method: "POST",
            url: "http://localhost:9393/Api/Course/InsertCourse",
            data: course,
            dataType: "json",
            success: function (result) {
                callback(result);
            },
            error: function () {
                alert('Error while adding course.  Is your service layer running?');
            }
        });
    };

    this.GetCourseList = function (callback) {
        var url = "http://localhost:9393/Api/Course/GetCourseList?bust=" + new Date();
        $.ajax({
            async: asyncIndicator,
            method: "GET",
            url: url,
            data: "",
            dataType: "json",
            success: function (result) {
                callback(result);
            },
            error: function () {
                alert('Error while loading student list.  Is your service layer running?');
            }
        });
    };

    this.Load = function (id, callback) {

        $.ajax({
            async: asyncIndicator,
            method: 'GET',
            url: "http://localhost:9393/Api/Course/GetCourse?CourseId=" + id + "&bust=" + new Date(),
            data: "",
            dataType: "json",
            success: function (result) {
                // when ajax call recevies data, it'll call the function "callback" which is passed in this as a parameter.
                // See AdminViewModel.load and see how it's being used
                callback(result); // "that" is currently pointing to the AdminModel object
            },
            error: function () {
                // if the call fails, it will return FirstName="First" and LastName="Last"
                alert('Error while loading course info.');
                callback("Error while loading course info");
            }
        });
    };

    this.Update = function (courseData, callback) {
        $.ajax({
            async: asyncIndicator,
            method: 'POST',
            url: "http://localhost:9393/Api/Course/UpdateCourse",
            data: courseData, // note, adminData must be the same as PLAdmin for this to work correctly
            success: function (message) {
                callback(message);
            },
            error: function () {
                callback('Error while updating course');
            }
        });

    };
}
