﻿function AdminModel(asyncIndicator) {
    if (asyncIndicator == undefined) {
        asyncIndicator = true;
    }

    this.Load = function (adminId, callback) {
        $.ajax({
            async: asyncIndicator,
            method: 'GET',
            url: "http://localhost:9393/Api/Admin/GetAdmin?AdminId="+adminId,
            data: "",
            dataType: "json",
            success: function (result) {
                // when ajax call recevies data, it'll call the function "callback" which is passed in this as a parameter.
                // See AdminViewModel.load and see how it's being used
                callback(result); // "that" is currently pointing to the AdminModel object
            },
            error: function () {
                // if the call fails, it will return FirstName="First" and LastName="Last"
                alert('Error while loading admin info.');
                callback("Error while loading admin info");
            }
        });
    };

    this.Update = function (adminData, callback) {

        $.ajax({
            async: asyncIndicator,
            method: 'POST',
            url: "http://localhost:9393/Api/Admin/UpdateAdmin",
            data: adminData, // note, adminData must be the same as PLAdmin for this to work correctly
            success: function (message) {
                callback(message);
            },
            error: function () {
                callback('Error while updating admin info');
            }
        });

    };
}
