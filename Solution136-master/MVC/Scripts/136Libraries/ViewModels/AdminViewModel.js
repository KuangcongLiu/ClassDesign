function AdminViewModel() {
    var self = this;
    var adminModelObj = new AdminModel();

    this.Load = function (admin_id) {
       

        // Because the Load() is a async call (asynchronous), we'll need to use
        // the callback approach to handle the data after data is loaded.
        adminModelObj.Load(admin_id, function (result) {

            var viewModel = {
                email: ko.observable(result.Email),
                password : ko.observable(result.Password),
                admin_id: result.AdminId,
                update: function() {
                    self.UpdateAdmin(this);
                }
            }

            ko.applyBindings(viewModel , document.getElementById("divAdminEdit"));
        });
    };

    this.UpdateAdmin = function (viewModel) {

        // convert the viewModel to same structure as PLAdmin model (presentation layer model)
        var adminData = {
            AdminId: viewModel.admin_id,
            Email: viewModel.email,
            Password: viewModel.password
        };

        adminModelObj.Update(adminData, function (message) {
            $('#divMessage').html(message);
        });

    };
}
