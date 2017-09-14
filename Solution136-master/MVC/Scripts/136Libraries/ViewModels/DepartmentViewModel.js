function DepartmentViewModel() {

    var DepartmentModelObj = new DepartmentModel();
    var self = this;
    var initialBind = true;
    var departmentListViewModel = ko.observableArray();

    this.Initialize = function () {

        var viewModel = {
            department_id: ko.observable(),
            department_name: ko.observable(),
            department_description: ko.observable(),
            add: function (data) {
                self.InsertDepartment(data);
            }
        };

        ko.applyBindings(viewModel, document.getElementById("divSharedInsertDepartment"));
    };

    this.InsertDepartment = function (viewModel) {
        var model = {
            DepartmentId: viewModel.department_id,
            Name: viewModel.department_name,
            Description: viewModel.department_description
        };

        DepartmentModelObj.Create(model, function (result) {
            if (result == "ok") {
                alert("Create department successful");
            } else {
                alert("Error occurred");
            }
        });

    };

    this.GetDepartmentList = function () {

        DepartmentModelObj.GetDepartmentList(function (departmentList) {
            departmentListViewModel.removeAll();

            for (var i = 0; i < departmentList.length; i++) {
                departmentListViewModel.push({
                    department_id: departmentList[i].DepartmentId,
                    department_name: departmentList[i].Name,
                    department_description: departmentList[i].Description
                });
            }

            if (initialBind) {
                ko.applyBindings({ viewModel: departmentListViewModel }, document.getElementById("divSharedDepartmentList"));
                initialBind = false; // this is to prevent binding multiple time because "Delete" functio calls GetAll again
            }
        });
    };

    this.Load = function (department_id) {

        // Because the Load() is a async call (asynchronous), we'll need to use
        // the callback approach to handle the data after data is loaded.
        DepartmentModelObj.Load(department_id, function (result) {

            var viewModel = {
                department_id: result.DepartmentId,
                department_name: ko.observable(result.Name),
                department_description: ko.observable(result.Description),
                update: function () {
                    self.UpdateDepartment(this);
                }
            }
            ko.applyBindings(viewModel, document.getElementById("divSharedEditDepartment"));
        });
    };

    this.UpdateDepartment = function (viewModel) {

        // convert the viewModel to same structure as PLAdmin model (presentation layer model)
        var departmentData = {
            DepartmentId: viewModel.department_id,
            Name: viewModel.department_name,
            Description: viewModel.department_description
        };

        DepartmentModelObj.Update(departmentData, function (message) {
            $('#divMessage').html(message);
        });

    };
   
    ko.bindingHandlers.DeleteDepartment = {
        init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
            $(element).click(function () {
                var model = {
                    DepartmentId: viewModel.department_id
                }
                DepartmentModelObj.Delete(model, function (result) {
                    if (result != "ok") {
                        alert("Error occurred");
                    } else {
                        departmentListViewModel.remove(viewModel);
                    }
                });
            });
        }
    };

}
