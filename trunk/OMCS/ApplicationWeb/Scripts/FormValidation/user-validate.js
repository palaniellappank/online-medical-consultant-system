$(function () {
    $("#create-form, #edit-form, #register-form").validate({

        rules: {
            Email: {
                maxlength: 50
            },
            FirstName: {
                maxlength: 50
            },
            LastName: {
                maxlength: 50
            },
            Password: {
                rangelength: [6, 32]
            },
            RePassword: {
                rangelength: [6, 32]
            }
        }
    });
})
