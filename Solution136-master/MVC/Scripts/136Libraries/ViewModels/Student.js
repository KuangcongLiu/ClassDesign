var student = function() {
    function checkInputValues() {
        if ($("#studentId").val() === "") {
            alert("Invalid student id!");
            return false;
        }

        if ($("#first").val() === "") {
            alert("Invalid first name!");
            return false;
        }

        if ($("#last").val() === "") {
            alert("Invalid last name!");
            return false;
        }

        $("#addStudentForm").submit();
        return true;
    }

    return{
        checkInputValues: checkInputValues
    }
}();
