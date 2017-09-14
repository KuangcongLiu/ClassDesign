function StudentViewModel() {

    var StudentModelObj = new StudentModel();
    var self = this;
    var initialBind = true;
    var studentListViewModel = ko.observableArray();

    this.Initialize = function() {

        var viewModel = {
            id: ko.observable("A0000111"),
            ssn: ko.observable("555-55-3333"),
            first: ko.observable("Bruce"),
            last: ko.observable("Wayne"),
            email: ko.observable("bwayne@ucsd.edu"),
            password: ko.observable("password"),
            shoesize: ko.observable("10"),
            weight: ko.observable("160"),
            add: function (data) {
                self.CreateStudent(data);
            }
        };

        ko.applyBindings(viewModel, document.getElementById("divStudent"));
    };

    this.CreateStudent = function(data) {
        var model = {
            StudentId: data.id(),
            SSN: data.ssn(),
            FirstName: data.first(),
            LastName: data.last(),
            Email: data.email(),
            Password: data.password(),
            ShoeSize: data.shoesize(),
            Weight: data.weight()
        }

        StudentModelObj.Create(model, function(result) {
            if (result == "ok") {
                alert("Create student successful");
            } else {
                alert("Error occurred");
            }
        });

    };

    this.GetStudentList = function() {

        StudentModelObj.GetStudentList(function(studentList) {
            studentListViewModel.removeAll();

            for (var i = 0; i < studentList.length; i++) {
                studentListViewModel.push({
                    student_id: studentList[i].StudentId,
                    first: studentList[i].FirstName,
                    last: studentList[i].LastName,
                    email: studentList[i].Email,
                    password: studentList[i].Password,
                    shoe_size: studentList[i].ShoeSize,
                    weight: studentList[i].Weight
                });
            }

            if (initialBind) {
                ko.applyBindings({ viewModel: studentListViewModel }, document.getElementById("divSharedStudentList"));
                initialBind = false; // this is to prevent binding multiple time because "Delete" functio calls GetAll again
            }
        });
    };

    ko.bindingHandlers.DeleteStudent = {
        init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
            $(element).click(function () {
                var model = {
                    StudentId: viewModel.student_id
                }
                StudentModelObj.Delete(model, function (result) {
                    if (result != "ok") {
                        alert("Error occurred");
                    } else {
                        studentListViewModel.remove(viewModel);
                    }
                });
            });
        }
    };

    this.Load = function (student_id) {
        console.log("id: " + student_id);
        // Because the Load() is a async call (asynchronous), we'll need to use
        // the callback approach to handle the data after data is loaded.
        StudentModelObj.Load(student_id, function (result) {

            var viewModel = {
                student_id: result.StudentId,
                ssn: ko.observable(result.SSN),
                first: ko.observable(result.FirstName),
                last: ko.observable(result.LastName),
                email: ko.observable(result.Email),
                password: ko.observable(result.Password),
                shoe_size: ko.observable(result.ShoeSize),
                weight: ko.observable(result.Weight),
                update: function () {
                    self.UpdateStudent(this);
                }
            }
            ko.applyBindings(viewModel, document.getElementById("divSharedEditStudent"));
        });
    };

    this.UpdateStudent = function (viewModel) {

        // convert the viewModel to same structure as PLAdmin model (presentation layer model)
        var studentData = {
            StudentId: viewModel.student_id,
            SSN: viewModel.ssn,
            FirstName: viewModel.first,
            LastName: viewModel.last,
            Email: viewModel.email,
            Password: viewModel.password,
            ShoeSize: viewModel.shoe_size,
            Weight: viewModel.weight
        };

        StudentModelObj.Update(studentData, function (message) {
            $('#divMessage').html(message);
        });

    };

}
