$(document).ready(function () {
    $.validator.setDefaults({
        highlight: function (element) {
            $(element).closest('.form-group').addClass('has-error');
        },
        unhighlight: function (element) {
            $(element).closest('.form-group').removeClass('has-error');
        },
        errorElement: 'span',
        errorClass: 'help-block',
        errorPlacement: function (error, element) {
            if (element.parent('.input-group').length) {
                error.insertAfter(element.parent());
            } else {
                error.insertAfter(element);
            }
        }
    });

    jQuery.extend(jQuery.validator.messages, {
        required: "Bạn cần nhập giá trị này.",//This field is required.
        remote: "Giá trị này cần được thay đổi.",//Please fix this field
        email: "Email không đúng định dạng.",
        url: "Đường dẫn không đúng định dạng.",
        date: "Ngày tháng không đúng định dạng.",
        dateISO: "Ngày tháng không đúng định dạng (ISO).",
        number: "Kiểu số không đúng định dạng.",
        digits: "Chỉ được nhập số.",
        creditcard: "Please enter a valid credit card number.",
        equalTo: "Giá trị này không khớp.",
        accept: "Định dạng không phù hợp.",
        maxlength: jQuery.validator.format("Please enter no more than {0} characters."),
        minlength: jQuery.validator.format("Please enter at least {0} characters."),
        rangelength: jQuery.validator.format("Please enter a value between {0} and {1} characters long."),
        range: jQuery.validator.format("Please enter a value between {0} and {1}."),
        max: jQuery.validator.format("Please enter a value less than or equal to {0}."),
        min: jQuery.validator.format("Please enter a value greater than or equal to {0}.")
    });
});