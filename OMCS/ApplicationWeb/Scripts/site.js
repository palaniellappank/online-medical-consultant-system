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
        number99: "Số nguyên dưới 100.",
        double: "Số thực với tối đa 2 chữ số thập phân.",
        digits: "Chỉ được nhập số.",
        creditcard: "Please enter a valid credit card number.",
        equalTo: "Giá trị này không khớp.",
        accept: "Định dạng không phù hợp.",
        maxlength: jQuery.validator.format("Độ dài không được quá {0} ký tự."),
        minlength: jQuery.validator.format("Please enter at least {0} characters."),
        rangelength: jQuery.validator.format("Please enter a value between {0} and {1} characters long."),
        range: jQuery.validator.format("Please enter a value between {0} and {1}."),
        max: jQuery.validator.format("Please enter a value less than or equal to {0}."),
        min: jQuery.validator.format("Please enter a value greater than or equal to {0}.")
    });
});


var vietnamEthnicity =
[
	{ id: "Kinh", text: "Kinh" },
	{ id: "Ba Na", text: "Ba Na" },
	{ id: "Bố Y", text: "Bố Y" },
	{ id: "Brâu", text: "Brâu" },
	{ id: "Bru - Vân Kiều", text: "Bru - Vân Kiều" },
	{ id: "Chơ Ro", text: "Chơ Ro" },
	{ id: "Chứt", text: "Chứt" },
	{ id: "Chăm", text: "Chăm" },
	{ id: "", text: "" },
	{ id: "Co", text: "Co" },
	{ id: "Cống", text: "Cống" },
	{ id: "Cơ Ho", text: "Cơ Ho" },
	{ id: "Cơ Lao", text: "Cơ Lao" },
	{ id: "Cơ Tu", text: "Cơ Tu" },
	{ id: "Chu ru", text: "Chu ru" },
	{ id: "Dao", text: "Dao" },
	{ id: "Ê Đê", text: "Ê Đê" },
	{ id: "Gia Lai", text: "Gia Lai" },
	{ id: "Gié - Triêng", text: "Gié - Triêng" },
	{ id: "H'Mông", text: "H'Mông" },
	{ id: "Giáy", text: "Giáy" },
	{ id: "Hà Nhì", text: "Hà Nhì" },
	{ id: "Hoa", text: "Hoa" },
	{ id: "Hrê", text: "Hrê" },
	{ id: "Kháng", text: "Kháng" },
	{ id: "Khơ me", text: "Khơ me" },
	{ id: "Khơ Mú", text: "Khơ Mú" },
	{ id: "La Chí", text: "La Chí" },
	{ id: "La Ha", text: "La Ha" },
	{ id: "La Hủ", text: "La Hủ" },
	{ id: "Lào", text: "Lào" },
	{ id: "Lô Lô", text: "Lô Lô" },
	{ id: "Lự", text: "Lự" },
	{ id: "M'Nông", text: "M'Nông" },
	{ id: "Mạ", text: "Mạ" },
	{ id: "Mảng", text: "Mảng" },
	{ id: "Mường", text: "Mường" },
	{ id: "Ngái", text: "Ngái" },
	{ id: "Nùng", text: "Nùng" },
	{ id: "Ô đu", text: "Ô đu" },
	{ id: "Pà Thẻn", text: "Pà Thẻn" },
	{ id: "Phù Lá", text: "Phù Lá" },
	{ id: "Pu Péo", text: "Pu Péo" },
	{ id: "Ra Glai", text: "Ra Glai" },
	{ id: "Rơ Măm", text: "Rơ Măm" },
	{ id: "Sán Chay", text: "Sán Chay" },
	{ id: "Sán Dìu", text: "Sán Dìu" },
	{ id: "Si La", text: "Si La" },
	{ id: "Tà Ôi", text: "Tà Ôi" },
	{ id: "Tày", text: "Tày" },
	{ id: "Thái", text: "Thái" },
	{ id: "Thổ", text: "Thổ" },
	{ id: "Xinh Mun", text: "Xinh Mun" },
	{ id: "Xtiêng", text: "Xtiêng" },
	{ id: "Xơ Đăng", text: "Xơ Đăng" }
];

var countries = [];
$.each({
    "Việt Nam": "Việt Nam",
    "Hoa Kì": "Hoa Kì",
    "Trung Quốc": "Trung Quốc",
    "Thái Lan": "Thái Lan",
    "Ấn Độ": "Ấn Độ",
    "Các nước khác": "Các nước khác"
}, function (k, v) {
    countries.push({ id: k, text: v });
});

var validationRegex = {
    double: /^\d+.?\d{0,2}$/,
    number99: /^\d{1,2}$/
}

function validationForm(form) {
    form.validate();
    $('<span style="color:red;">*</span>').insertBefore('.required');
}

function initModalWithData(data) {
    $('#modal-popup').html(data);
    $('#modal-popup').modal('show');
    var form = $('#modal-popup').find("form");  
    validationForm(form);
    $(".datepicker").datepicker({ dateFormat: 'dd/mm/yy' });
    $('#modal-popup').find(".saveBtn").click(function (e) {
        e.preventDefault();
        if (form.valid()) {
            var formData = new FormData(form[0]);
            $.ajax({
                url: form.attr("action"),
                method: "post",
                contentType: false,
                processData: false,
                data: formData,
                success: function () {
                    window.location.reload();
                }
            });
        }
    });
    var deleteBtn = $('#modal-popup').find(".deleteBtn");
    if (deleteBtn[0] != undefined) {
        deleteBtn.click(function (e) {
            e.preventDefault();
            var id = deleteBtn.attr("data-id");
            var url = deleteBtn.attr("data-url");
            bootbox.confirm("Bạn muốn xóa đối tượng này?", function (result) {
                if (result) {
                    $.post(
                        url,
                        { id: id },
                        function () {
                            window.location.reload();
                        });
                }
            });
        });
    }
    var imgViewBtn = $('#modal-popup').find(".img-modal");
    if (imgViewBtn[0] != undefined) {
        imgViewBtn.click(function (e) {
            e.preventDefault();
            $("#modal-popup-img").find("img").attr("src", imgViewBtn.attr("src"));
            $("#modal-popup-img").modal("show");
        });
    }
}

function readImgFromURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#targetImg').attr('src', e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }
}

function isImage(fileName) {
    var extension = fileName.substr(fileName.indexOf(".") + 1, fileName.length);
    if (extension == "jpg" || extension == "png"
        || extension == "jpeg" || extension == "gif" || extension == "JPG") {
        return true;
    }
    return false;
}