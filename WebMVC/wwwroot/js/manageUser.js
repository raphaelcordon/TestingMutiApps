$(document).ready(function () {

    $("#btnCreateUser").on("click", function () {
        $.ajax({
            type: 'POST',
            url: 'User/CreateUser',
            contentType: 'application/json',
            dataType: 'json',
            data: JSON.stringify({
                'FirstName': createUser.FirstName.value,
                'LastName': createUser.LastName.value,
                'DateOfBirth': createUser.DateOfBirth.value
            })
        });

    });

    $("#btnUpdateUser").on("click", function () {
        $.ajax({
            type: 'POST',
            url: 'User/PostUpdateUser',
            contentType: 'application/json',
            dataType: 'json',
            data: JSON.stringify({
                'Id': updateUser.updateId.value,
                'FirstName': updateUser.updateFirstName.value,
                'LastName': updateUser.updateLastName.value,
                'DateOfBirth': updateUser.updateDateOfBirth.value
            })
        });
    });

});