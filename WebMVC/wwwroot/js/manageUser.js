$(document).ready(function () {

    $("#btnCreateUser").on("click", function () {
        $.ajax({
            type: 'POST',
            url: '/Users/CreateUser',
            contentType: 'application/json',
            dataType: 'json',
            data: JSON.stringify({
                'FirstName': createUser.FirstName.value,
                'LastName': createUser.LastName.value,
                'DateOfBirth': createUser.DateOfBirth.value
            }),
            success: function (response) {
                window.location.href = response.redirectToUrl;
            }
        });

    });

    $("#btnUpdateUser").on("click", function () {
        $.ajax({
            type: 'PUT',
            url: '/Users/PostUpdateUser',
            contentType: 'application/json',
            dataType: 'json',
            data: JSON.stringify({
                'Id': updateUser.Id.value,
                'FirstName': updateUser.FirstName.value,
                'LastName': updateUser.LastName.value,
                'DateOfBirth': updateUser.DateOfBirth.value
            }),
            success: function (response) {
                window.location.href = response.redirectToUrl;
            }
        }); 
    });
});