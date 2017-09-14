//// THe reason for asyncIndicator is to make sure Jasmine test cases can run without error
//// Due to async nature of ajax, the Jasmine's compare function would throw an error during
//// a callback. By allowing this optional paramter for StudentModel function, it forces the ajax
//// call to be synchronous when running the Jasmine tests.  However, the viewModel will not pass
//// this parameter so the asynncIndicator would be undefined which is set to "true". Ajax would
//// be async when called by viewModel.
function PrerequisiteModel(asyncIndicator) {
    if (asyncIndicator == undefined) {
        asyncIndicator = true;
    }

    this.Create = function (prerequisite, callback) {
        $.ajax({
            async: asyncIndicator,
            method: "POST",
            url: "http://localhost:9393/Api/Prerequisite/InsertPrerequisite",
            data: prerequisite,
            dataType: "json",
            success: function (result) {
                callback(result);
            },
            error: function () {
                alert('Error while adding Prerequisite.  Is your service layer running?');
            }
        });
    };

    this.Delete = function (prerequisite, callback) {
        $.ajax({
            async: asyncIndicator,
            method: "POST",
            url: "http://localhost:9393/Api/Prerequisite/DeletePrerequisite",
            data: prerequisite,
            dataType: "json",
            success: function (result) {
                callback(result);
            },
            error: function () {
                alert('Error while deleteing prerequisite.  Is your service layer running?');
            }
        });
    };

  

    this.GetPrerequisiteList = function (callback) {
        var url = "http://localhost:9393/Api/Prerequisite/GetPrerequisiteList?bust=" + new Date();
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
                alert('Error while loading prerequisite list.  Is your service layer running?');
            }
        });
    };

    this.Load = function (id, callback) {
        $.ajax({
            async: asyncIndicator,
            method: 'GET',
            url: "http://localhost:9393/Api/Prerequisite/GetPrerequisite?Id=" + id + "&bust=" + new Date(),
            data: "",
            dataType: "json",
            success: function (result) {
                // when ajax call recevies data, it'll call the function "callback" which is passed in this as a parameter.
                // See AdminViewModel.load and see how it's being used
                callback(result); // "that" is currently pointing to the AdminModel object
            },
            error: function () {
                // if the call fails, it will return FirstName="First" and LastName="Last"
                alert('Error while loading prerequisite info.');
                callback("Error while loading prerequisite info");
            }
        });
    };

    this.Update = function (prerequisiteData, callback) {
        $.ajax({
            async: asyncIndicator,
            method: 'POST',
            url: "http://localhost:9393/Api/Prerequisite/UpdatePrerequisite",
            data: prerequisiteData, // note, adminData must be the same as PLAdmin for this to work correctly
            success: function (message) {
                callback(message);
            },
            error: function () {
                callback('Error while updating prerequisite');
            }
        });

    };
}
