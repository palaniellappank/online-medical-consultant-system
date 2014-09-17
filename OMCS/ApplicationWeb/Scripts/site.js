$.blockUI.defaults.message = "<h1>Vui lòng chờ</h1>";
var isError;
function doOnlineCheck() {
    var submitURL = baseUrl + "Home/Index";
    if (isError == undefined || isError == false) {
        $.ajax({
            url: submitURL,
            type: 'get',
            timeout: 5000,
            success: function (msg) {
                isError = false;
            },
            error: function () {
                bootbox.alert("Kết nối mạng bị lỗi");
                isError = true;
            }
        });
    }
}

$(document).ajaxComplete(function (event, xhr, settings) {
    $('[data-toggle="tooltip"]').tooltip();
});

bootstrap_alert = function () { }
bootstrap_alert.warning = function (target, message) {
    target.html('<div class="alert alert-success"><a class="close" data-dismiss="alert">×</a><span>' + message + '</span></div>')
}

function flexdestroy(selector) {
    var el = $(selector);
    var elClean = el.clone();

    elClean.find('.flex-viewport').children().unwrap();
    elClean
    .find('.clone, .flex-direction-nav, .flex-control-nav')
    .remove()
    .end()
    .find('*').removeAttr('style').removeClass(function (index, css) {
        return (css.match(/\bflex\S+/g) || []).join(' ');
    });

    elClean.insertBefore(el);
    elClean.next().remove();
}

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

   // setInterval(function () {
   //     doOnlineCheck();
   // }, 10000);

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
        minlength: jQuery.validator.format("Độ dài ít nhất phải {0} ký tự."),
        rangelength: jQuery.validator.format("Độ dài trong khoảng {0} đến {1} ký tự."),
        range: jQuery.validator.format("Vui lòng nhập giá trị trong khoảnh từ {0} đến {1}."),
        max: jQuery.validator.format("Vui lòng nhập giá trị nhỏ hơn hoặc bằng {0}."),
        min: jQuery.validator.format("Vui lòng nhập giá trị lớn hơn hoặc bằng {0}.")
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
    $('<span style="color:red;">*</span>').insertBefore(form.find('.required'));
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

DoctorDetailView = Backbone.View.extend({
    initialize: function (options) {
        $.blockUI();
        this.options = options;
        this.render();
    },
    events: {
        "rating.change .rating": "ratingChange",
        "click #btnPostComment": "postComment",
        "click .pagination a": "goToPage",
        "keypress #txtComment": "postCommentPress"
    },
    render: function (e) {
        var that = this;
        $.get(baseUrl + 'Comment/Evaluate/' + this.options.doctorId, function (response) {
            $.unblockUI();
            that.$el.find(".modal-body").html(response);
            initRating();
            that.$el.modal("show");
        });
    },
    ratingChange: function (event, value, caption) {
        $.blockUI();
        var that = this;
        $.ajax({
            url: baseUrl + "Comment/Rate",
            type: "POST",
            data: { ratingScore: value, doctorId: this.options.doctorId },
            success: function (e) {
                that.render();
            }
        });
    },
    postComment: function (e) {
        e.preventDefault();
        var content = $("#txtComment").val().trim();
        if (content != "") {
            $.blockUI();
            var that = this;
            $.ajax({
                url: baseUrl + "Comment/PostComment",
                type: "POST",
                data: { content: content, doctorId: this.options.doctorId },
                success: function (e) {
                    that.render();
                }
            });
        }
    },
    postCommentPress: function (e) {
        if (e.which == 13 && e.shiftKey) {
        }
        else if (e.which == 13) {
            e.preventDefault();
            var content = $("#txtComment").val().trim();
            if (content != "") {
                $.blockUI();
                var that = this;
                $.ajax({
                    url: baseUrl + "Comment/PostComment",
                    type: "POST",
                    data: { content: content, doctorId: this.options.doctorId },
                    success: function (e) {
                        that.render();
                    }
                });
            }
        }
    },
    goToPage: function (e) {
        e.preventDefault();
        var url = $(e.target).attr("href");
        $.ajax({
            url: url,
            type: "GET",
            success: function (e) {
                $("#post-list").html(e);
            }
        });
    }
});


DoctorCommentView = Backbone.View.extend({
    initialize: function (options) {
        this.options = options;
    },
    events: {
        "click #btnPostComment": "postComment",
        "click .pagination a": "goToPage",
        "keypress #txtComment": "postCommentPress"
    },
    postComment: function (e) {
        e.preventDefault();
        var content = $("#txtComment").val().trim();
        if (content != "") {
            $.blockUI();
            $("#txtComment").val("");
            var that = this;
            $.ajax({
                url: baseUrl + "Comment/PostComment",
                type: "POST",
                data: { content: content, doctorId: this.options.doctorId },
                success: function (e) {
                    $.ajax({
                        url: baseUrl + "Comment/Index/" + that.options.doctorId,
                        type: "GET",
                        success: function (e) {
                            $.unblockUI();
                            $(".comment-list").html(e);
                        }
                    });
                    //   that.render();
                }
            });
        }
    },
    postCommentPress: function (e) {
        if (e.which == 13 && e.shiftKey) {
        }
        else if (e.which == 13) {
            e.preventDefault();
            var content = $("#txtComment").val().trim();
            if (content != "") {
                $.blockUI();
                $("#txtComment").val("");
                var that = this;
                $.ajax({
                    url: baseUrl + "Comment/PostComment",
                    type: "POST",
                    data: { content: content, doctorId: this.options.doctorId },
                    success: function (e) {
                        $.ajax({
                            url: baseUrl + "Comment/Index/" + that.options.doctorId,
                            type: "GET",
                            success: function (e) {
                                $.unblockUI();
                                $(".comment-list").html(e);
                            }
                        });
                        //   that.render();
                    }
                });
            }
        }
    },
    goToPage: function (e) {
        e.preventDefault();
        var url = $(e.target).attr("href");
        $.blockUI();
        $.ajax({
            url: url,
            type: "GET",
            success: function (e) {
                $.unblockUI();
                $(".comment-list").html(e);
            }
        });
    }
});