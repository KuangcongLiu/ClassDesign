function CapeViewModel() {

    var CapeModelObj = new CapeModel();
    var self = this;
    var initialBind = true;
    var CapeListViewModel = ko.observableArray();

    this.Initialize = function () {

        var viewModel = {
            cape_id: ko.observable(""),
            schedule_id: ko.observable(""),
            rate: ko.observable(""),
            cape_description: ko.observable(""),
            student_id: ko.observable(""),
            add: function (data) {
                self.InsertCape(data);
            }
        };

        ko.applyBindings(viewModel, document.getElementById("divSharedInsertCape"));
    };

    this.InsertCape = function (viewModel) {
        var model = {
            CapeId: viewModel.cape_id,
            ScheduleId: viewModel.schedule_id,
            Rate: viewModel.rate,
            CapeDescription: viewModel.cape_description,
            StudentId: viewModel.student_id
        };

        CapeModelObj.Create(model, function (result) {
            if (result == "ok") {
                alert("Create cape successful");
            } else {
                alert("Error occurred");
            }
        });

    };

    this.GetCapeList = function () {
        CapeModelObj.GetCapeList(function (CapeList) {
            CapeListViewModel.removeAll();

            for (var i = 0; i < CapeList.length; i++) {
                CapeListViewModel.push({
                    cape_id: CapeList[i].CapeId,
                    schedule_id: CapeList[i].ScheduleId,
                    rate: CapeList[i].Rate,
                    cape_description: CapeList[i].CapeDescription,
                    student_id: CapeList[i].StudentId
                });
            }

            if (initialBind) {
                ko.applyBindings({ viewModel: CapeListViewModel }, document.getElementById("divSharedCapeList"));
                initialBind = false; // this is to prevent binding multiple time because "Delete" function calls GetAll again
            }
        });
    };

   

    ko.bindingHandlers.DeleteCape = {
        init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
            $(element).click(function () {
                var model = {
                    CapeId: viewModel.cape_id
                }
                CapeModelObj.Delete(model, function (result) {
                    if (result != "ok") {
                        alert("Error occurred");
                    } else {
                        CapeListViewModel.remove(viewModel);
                    }
                });
            });
        }
    };


    this.Load = function (cape_id) {

        // Because the Load() is a async call (asynchronous), we'll need to use
        // the callback approach to handle the data after data is loaded.
        CapeModelObj.Load(cape_id, function (result) {

            var viewModel = {
                cape_id: result.CapeId,
                schedule_id: ko.observable(result.ScheduleId),
                rate: ko.observable(result.Rate),
                cape_description: ko.observable(result.CapeDescription),
                student_id: ko.observable(result.StudentId),
                update: function () {
                    self.UpdateCape(this);
                }
            }
            ko.applyBindings(viewModel, document.getElementById("divSharedEditCape"));
        });
    };

    this.UpdateCape = function (viewModel) {

        // convert the viewModel to same structure as PLAdmin model (presentation layer model)
        var capeData = {
            CapeId: viewModel.cape_id,
            ScheduleId: viewModel.schedule_id,
            Rate: viewModel.rate,
            CapeDescription: viewModel.cape_description,
            StudentId: viewModel.student_id
        };

        CapeModelObj.Update(capeData, function (message) {
            $('#divMessage').html(message);
        });

    };
}
