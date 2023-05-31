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
            url: '/User/PostUpdateUser',
            contentType: 'application/json',
            dataType: 'json',
            data: JSON.stringify({
                'Id': parseInt(PostUpdateUser.Id.value),
                'FirstName': PostUpdateUser.FirstName.value,
                'LastName': PostUpdateUser.LastName.value,
                'DateOfBirth': Date.parse(PostUpdateUser.DateOfBirth.value)
            })
        }); 
    });
});