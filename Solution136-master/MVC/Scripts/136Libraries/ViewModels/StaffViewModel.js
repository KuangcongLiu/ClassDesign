function StaffViewModel() {
    var self = this;
    var staffModelObj = new StaffModel();

    this.Load = function (staff_id) {

        // Because the Load() is a async call (asynchronous), we'll need to use
        // the callback approach to handle the data after data is loaded.
        staffModelObj.Load(staff_id, function (result) {

            var viewModel = {
                email: ko.observable(result.Email),
                password: ko.observable(result.Password),
                staff_id: result.StaffId,
                update: function () {
                    self.UpdateStaff(this);
                }
            }

            ko.applyBindings(viewModel, document.getElementById("divEditStaff"));
        });
    };

    this.UpdateStaff = function (viewModel) {

        // convert the viewModel to same structure as PLAdmin model (presentation layer model)
        var staffData = {
            StaffId: viewModel.staff_id,
            Email: viewModel.email,
            Password: viewModel.password
        };

        staffModelObj.Update(staffData, function (message) {
            $('#divMessage').html(message);
        });

    };
}
