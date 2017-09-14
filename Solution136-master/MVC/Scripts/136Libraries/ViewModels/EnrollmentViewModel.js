function EnrollmentViewModel() {

    var EnrollmentModelObj = new EnrollmentModel();
    var self = this;
    var initialBind = true;
    var EnrollmentListViewModel = ko.observableArray();

    this.Initialize = function () {

        var viewModel = {
            grade: ko.observable(),
            student_id: ko.observable(),
            schedule_id: ko.observable(),
            add: function (data) {
                self.InsertEnrollment(data);
            }
        };

        ko.applyBindings(viewModel, document.getElementById("divSharedInsertEnrollment"));
    };

    this.InsertEnrollment = function (viewModel) {
        var model = {
            StudentId: viewModel.student_id,
            ScheduleId: viewModel.schedule_id,
            Grade: viewModel.grade
        };

        EnrollmentModelObj.Create(model, function (result) {
            if (result == "ok") {
                alert("Create Enrollment successful");
            } else {
                alert("Error occurred");
            }
        });

    };

    this.GetAllEnrollment = function () {
        var url_address = "http://localhost:9393/Api/Enrollment/GetAllEnrollmentList?bust=" + new Date();
        EnrollmentModelObj.GetEnrollment(url_address, function (EnrollmentList) {
            EnrollmentListViewModel.removeAll();

            for (var i = 0; i < EnrollmentList.length; i++) {
                EnrollmentListViewModel.push({
                student_id: EnrollmentList[i].StudentId,
                schedule_id: EnrollmentList[i].ScheduleId,
                grade: EnrollmentList[i].Grade
                });
            }

            if (initialBind) {
                ko.applyBindings({ viewModel: EnrollmentListViewModel }, document.getElementById("divSharedEnrollmentList"));
                initialBind = false; // this is to prevent binding multiple time because "Delete" function calls GetAll again
            }
        });
    };

    this.GetEnrollmentByStudent = function (student_id) {
        var url_address = "http://localhost:9393/Api/Enrollment/GetEnrollmentByStudentList?StudentId=" + student_id + "&bust=" + new Date();
        EnrollmentModelObj.GetEnrollment(url_address, function (EnrollmentList) {
            EnrollmentListViewModel.removeAll();
            
            for (var i = 0; i < EnrollmentList.length; i++) {
                EnrollmentListViewModel.push({
                    student_id: EnrollmentList[i].StudentId,
                    schedule_id: EnrollmentList[i].ScheduleId,
                    grade: EnrollmentList[i].Grade
                });
            }
            

            if (initialBind) {
                ko.applyBindings({ viewModel: EnrollmentListViewModel }, document.getElementById("divSharedEnrollmentList"));
                initialBind = false; // this is to prevent binding multiple time because "Delete" function calls GetAll again
            }
        });
    };

    ko.bindingHandlers.DeleteEnrollment = {
        init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
            $(element).click(function () {
                var model = {
                    StudentId : viewModel.student_id,
                    ScheduleId: viewModel.schedule_id 
                }
                EnrollmentModelObj.Delete(model, function (result) {
                    if (result != "ok") {
                        alert("Error occurred");
                    } else {
                        EnrollmentListViewModel.remove(viewModel);
                    }
                });
            });
        }
    };


    this.Load = function (student_id, schedule_id) {
        console.log(student_id + " : " + schedule_id);
        // Because the Load() is a async call (asynchronous), we'll need to use
        // the callback approach to handle the data after data is loaded.
        EnrollmentModelObj.Load(student_id, schedule_id, function (result) {

            var viewModel = {
                grade: ko.observable(result.Grade),
                student_id: result.StudentId,
                schedule_id: result.ScheduleId,
                update: function () {
                    self.UpdateEnrollment(this);
                }
            }
   
            ko.applyBindings(viewModel, document.getElementById("divSharedEditEnrollment"));
        });
    };
    
    this.UpdateEnrollment = function (viewModel) {

        // convert the viewModel to same structure as PLAdmin model (presentation layer model)
        var enrollmentData = {
            StudentId: viewModel.student_id,
            ScheduleId: viewModel.schedule_id,
            Grade: viewModel.grade
        };

        EnrollmentModelObj.Update(enrollmentData, function (message) {
            $('#divMessage').html(message);
        });

    };
}
