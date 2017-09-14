//// THe reason for asyncIndicator is to make sure Jasmine test cases can run without error
//// Due to async nature of ajax, the Jasmine's compare function would throw an error during
//// a callback. By allowing this optional paramter for StudentModel function, it forces the ajax
//// call to be synchronous when running the Jasmine tests.  However, the viewModel will not pass
//// this parameter so the asynncIndicator would be undefined which is set to "true". Ajax would
//// be async when called by viewModel.
function EnrollmentModel(asyncIndicator) {
    if (asyncIndicator == undefined) {
        asyncIndicator = true;
    }

    this.Create = function (enrollment, callback) {
        $.ajax({
            async: asyncIndicator,
            method: "POST",
            url: "http://localhost:9393/Api/Enrollment/InsertEnrollment",
            data: enrollment,
            dataType: "json",
            success: function (result) {
                callback(result);
            },
            error: function () {
                alert('Error while adding Enrollment.  Is your service layer running?');
            }
        });
    };

    this.Delete = function (enrollment, callback) {
        $.ajax({
            async: asyncIndicator,
            method: "POST",
            url: "http://localhost:9393/Api/Enrollment/DeleteEnrollment",
            data: enrollment,
            dataType: "json",
            success: function (result) {
                callback(result);
            },
            error: function () {
                alert('Error while deleteing enrollemnt.  Is your service layer running?');
            }
        });
    };

    this.GetEnrollment = function (url_address, callback) {
        var url = url_address;
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
                alert('Error while loading all enrollment list.  Is your service layer running?');
            }
        });
    };


    this.Load = function (student_id, schedule_id, callback) {
        $.ajax({
            method: 'GET',
            url: "http://localhost:9393/Api/Enrollment/GetEnrollment?StudentId="+student_id+"&ScheduleId="+schedule_id+"&bust="+new Date(),
            data: "",
            dataType: "json",
            success: function (result) {
                // when ajax call recevies data, it'll call the function "callback" which is passed in this as a parameter.
                // See AdminViewModel.load and see how it's being used
                callback(result); // "that" is currently pointing to the AdminModel object
            },
            error: function () {
                // if the call fails, it will return FirstName="First" and LastName="Last"
                alert('Error while loading enrollment info.');
                callback("Error while loading enrollment info");
            }
        });
    };

    this.Update = function (enrollmentData, callback) {
        $.ajax({
            method: 'POST',
            url: "http://localhost:9393/Api/Enrollment/UpdateEnrollment",
            data: enrollmentData, // note, adminData must be the same as PLAdmin for this to work correctly
            success: function (message) {
                callback(message);
            },
            error: function () {
                callback('Error while updating admin info');
            }
        });

    };
}
