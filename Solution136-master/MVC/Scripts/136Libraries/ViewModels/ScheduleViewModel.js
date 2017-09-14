function ScheduleViewModel() {

    var ScheduleModelObj = new ScheduleModel();
    var self = this;
    var initialBind = true;
    var ScheduleListViewModel = ko.observableArray();

    this.Initialize = function () {

        var viewModel = {
            schedule_id: ko.observable(),
            course_id: ko.observable(),
            year: ko.observable(),
            quarter: ko.observable(),
            session: ko.observable(),
            schedule_day_id: ko.observable(),
            schedule_time_id: ko.observable(),
            instructor_id: ko.observable(),
            add: function (data) {
                self.InsertSchedule(data);
            }
        };

        ko.applyBindings(viewModel, document.getElementById("divSharedInsertSchedule"));
    };

    this.InsertSchedule = function (viewModel) {
        var model = {
            ScheduleId: viewModel.schedule_id,
            CourseId: viewModel.course_id,
            Year: viewModel.year,
            Quarter: viewModel.quarter,
            Session: viewModel.session,
            ScheduleDayId: viewModel.schedule_day_id,
            ScheduleTimeId: viewModel.schedule_time_id,
            InstructorId: viewModel.instructor_id
        };

        ScheduleModelObj.Create(model, function (result) {
            if (result == "ok") {
                alert("Create Schedule successful");
            } else {
                alert("Error occurred");
            }
        });

    };

    this.GetScheduleList = function () {
        ScheduleModelObj.GetScheduleList(function (ScheduleList) {
            ScheduleListViewModel.removeAll();

            for (var i = 0; i < ScheduleList.length; i++) {
                ScheduleListViewModel.push({
                    schedule_id: ScheduleList[i].ScheduleId,
                    course_id: ScheduleList[i].CourseId,
                    year: ScheduleList[i].Year,
                    quarter: ScheduleList[i].Quarter,
                    session: ScheduleList[i].Session,
                    schedule_day_id: ScheduleList[i].ScheduleDayId,
                    schedule_time_id: ScheduleList[i].ScheduleTimeId,
                    instructor_id: ScheduleList[i].InstructorId

                });
            }

            if (initialBind) {
                ko.applyBindings({ viewModel: ScheduleListViewModel }, document.getElementById("divSharedScheduleList"));
                initialBind = false; // this is to prevent binding multiple time because "Delete" function calls GetAll again
            }
        });
    };


    ko.bindingHandlers.DeleteSchedule = {
        init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
            $(element).click(function () {
                var model = {
                    ScheduleId: viewModel.schedule_id
                }
                ScheduleModelObj.Delete(model, function (result) {
                    if (result != "ok") {
                        alert("Error occurred");
                    } else {
                        ScheduleListViewModel.remove(viewModel);
                    }
                });
            });
        }
    };


    this.Load = function (schedule_id) {

        // Because the Load() is a async call (asynchronous), we'll need to use
        // the callback approach to handle the data after data is loaded.
        ScheduleModelObj.Load(schedule_id, function (result) {

            var viewModel = {
                schedule_id: result.ScheduleId,
                course_id: ko.observable(result.CourseId),
                year: ko.observable(result.Year),
                quarter: ko.observable(result.Quarter),
                session: ko.observable(result.Session),
                schedule_day_id: ko.observable(result.ScheduleDayId),
                schedule_time_id: ko.observable(result.ScheduleTimeId),
                instructor_id: ko.observable(result.InstructorId),
                update: function () {
                    self.UpdateSchedule(this);
                }
            }
            ko.applyBindings(viewModel, document.getElementById("divSharedEditSchedule"));
        });
    };

    this.UpdateSchedule = function (viewModel) {

        // convert the viewModel to same structure as PLAdmin model (presentation layer model)
        var scheduleData = {
            ScheduleId: viewModel.schedule_id,
            CourseId: viewModel.course_id,
            Year: viewModel.year,
            Quarter: viewModel.quarter,
            Session: viewModel.session,
            ScheduleDayId: viewModel.schedule_day_id,
            ScheduleTimeId: viewModel.schedule_time_id,
            InstructorId: viewModel.instructor_id
        };

        ScheduleModelObj.Update(scheduleData, function (message) {
            $('#divMessage').html(message);
        });

    };
}
