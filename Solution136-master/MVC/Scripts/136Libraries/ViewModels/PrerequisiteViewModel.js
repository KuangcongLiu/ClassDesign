function PrerequisiteViewModel() {

    var PrerequisiteModelObj = new PrerequisiteModel();
    var self = this;
    var initialBind = true;
    var prerequisiteListViewModel = ko.observableArray();

    this.Initialize = function () {

        var viewModel = {
            id: ko.observable(),
            course_id: ko.observable(),
            prerequisite_id: ko.observable(),
            add: function (data) {
                self.InsertPrerequisite(data);
            }
        };

        ko.applyBindings(viewModel, document.getElementById("divSharedInsertPrerequisite"));
    };

    this.InsertPrerequisite = function (viewModel) {
        var model = {
            Id: viewModel.id,
            CourseId: viewModel.course_id,
            PrerequisiteId: viewModel.prerequisite_id
        };

        PrerequisiteModelObj.Create(model, function (result) {
            if (result == "ok") {
                alert("Create Prerequisite successful");
            } else {
                alert("Error occurred");
            }
        });

    };

    this.GetPrerequisiteList = function () {

        PrerequisiteModelObj.GetPrerequisiteList(function (prerequisiteList) {
            prerequisiteListViewModel.removeAll();

            for (var i = 0; i < prerequisiteList.length; i++) {
                prerequisiteListViewModel.push({
                    id: prerequisiteList[i].Id,
                    course_id: prerequisiteList[i].CourseId,
                    prerequisite_id: prerequisiteList[i].PrerequisiteId
                });
            }

            if (initialBind) {
                ko.applyBindings({ viewModel: prerequisiteListViewModel }, document.getElementById("divSharedPrerequisiteList"));
                initialBind = false; // this is to prevent binding multiple time because "Delete" functio calls GetAll again
            }
        });
    };


    ko.bindingHandlers.DeletePrerequisite = {
        init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
            $(element).click(function () {
                var model = {
                    Id: viewModel.id
                }
                PrerequisiteModelObj.Delete(model, function (result) {
                    if (result != "ok") {
                        alert("Error occurred");
                    } else {
                        prerequisiteListViewModel.remove(viewModel);
                    }
                });
            });
        }
    };

    this.Load = function (id) {

        // Because the Load() is a async call (asynchronous), we'll need to use
        // the callback approach to handle the data after data is loaded.
        PrerequisiteModelObj.Load(id, function (result) {

            var viewModel = {
                id: result.Id,
                course_id: ko.observable(result.CourseId),
                prerequisite_id: ko.observable(result.PrerequisiteId),
                update: function () {
                    self.UpdatePrerequisite(this);
                }
            }
            ko.applyBindings(viewModel, document.getElementById("divSharedEditPrerequisite"));
        });
    };

    this.UpdatePrerequisite = function (viewModel) {

        // convert the viewModel to same structure as PLAdmin model (presentation layer model)
        var prerequisiteData = {
            Id: viewModel.id,
            CourseId: viewModel.course_id,
            PrerequisiteId: viewModel.prerequisite_id
        };

        PrerequisiteModelObj.Update(prerequisiteData, function (message) {
            $('#divMessage').html(message);
        });

    };

}
