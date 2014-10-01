$(function () {
    $('[data-toggle="tooltip"]').tooltip();
    OMCSChat.App.init($("#txtFromEmail").val());
    registerClientMethods(chatHub);
    $.connection.hub.start().done(function () {
        chatHub.server.connectPatient($("#txtFromEmail").val());
    });
    initSelectSpecialtyField();
    initUploadAttachment();
});

BodyView = Backbone.View.extend({
    el: $("body"),
    events: {
        "click .showDoctorDetail": "showDoctorDetail",
        "click": "handleClick",
        "click #closePatientWebcam": "hideWebcam",
        "click .open-request-consult": "openRequestConsult",
        "click .send-form-request": "sendRequestConsult"
    },
    openRequestConsult: function (e) {
        $("#modal-remind-consult").modal("hide");
        chatBoxView.openRequestConsultModal();
    },
    sendRequestConsult: function (e) {
        var condition = $("#modal-popup-request-consult").find(".conditionTxt").val();
        var requestConsult = $("#modal-popup-request-consult").find(".requestConsultTxt").val();
        content = "";
        if (condition.trim().length > 0) {
            content += "<b>Tình trạng hiện tại: </b>" + condition + "<br>";
        }
        if (requestConsult.trim().length > 0) {
            content += "<b>Nội dung cần tư vấn: </b>" + requestConsult;
        }
        if (content.trim().length > 0) {
            var toEmail = $('#txtToEmail').val();
            chatHub.server.sendMessageTo(toEmail, content);
            $("#modal-popup-request-consult").find("textarea").val("");
            $("#modal-popup-request-consult").modal("hide");
        } else {
            bootstrap_alert.warning($(".alert-aria"),
                "Bạn cần nhập ít nhất một trong hai giá trị <code>Tình trạng hiện tại</code> hoặc <code>Nội dung cần tư vấn</code>");
        }

    },
    showDoctorDetail: function (e) {
        $("#doctor-detail").removeData().unbind();
        new DoctorDetailView({
            doctorId: $(e.target).attr("data-id"),
            el: "#doctor-detail"
        });
    },
    handleClick: function (e) {
        if (!$(e.target).parents().hasClass("popover")) {
            $(".popover").remove();
        }
    },
    hideWebcam: function (e) {
        $(".webcam-content").css("display", "none");
    }
});
new BodyView();
var doctorList;
ChatBoxView = Backbone.View.extend({
    el: $("#chatbox"),
    contactListEl: $("#contact-list"),
    firstTime: true,
    initialize: function () {
        this.render();
    },
    events: {
        "click .list-group-item": "getMessageList",
        "mouseover": "getDoctorRating",
        "click #btnSendMsg": "sendMessage",
        "click #btnOpenRequestConsult": "openRequestConsultModal",
        "keypress #txtMessage": "sendMessagePress",
        "focus #txtMessage": "txtMessageFocus",
        "click #txtMessage": "remindForm",
        "click .picture-thumbnail": "showFullPicture"
    },
    remindForm: function (e) {
        if (this.firstTime == true) {
            this.firstTime = false;
            $("#modal-remind-consult").modal("show");
        }
    },
    txtMessageFocus: function (e) {
        $(".popover").hide();
    },
    openRequestConsultModal: function (e) {
        var toEmail = $('#txtToEmail').val();
        if (toEmail.length > 0) {
            $("#modal-popup-request-consult").modal("show");
        }
    },
    getDoctorRating: function (e) {
        var target = $(e.target).parents(".list-group-item");
        var email = target.attr("data-email");
        if (email != undefined) {
            //First hide popover form other list-group-item
            var exist = false;
            _.each($('.popover'), function (popover) {
                if ($(popover).find(".email").val() != email) {
                    $(popover).remove();
                } else exist = true;
            });
            if (exist) return;
            target.popover({
                content: "<div class='rating-popover'><div class='ajax-loader'></div><div>",
                html: true,
                container: 'body'
            }).popover('show');
            var currentLeft = parseInt($(".popover").css("left"));
            $(".popover").css("left", currentLeft - 14 + "px");
            setTimeout(function () {
                $.get('/Comment/RateQuickView?doctorEmail=' + email, function (d) {
                    $(".popover").find(".rating-popover").html(d);
                });
            }, 1000);
        } else {
            //$('.popover').remove();
        }
    },
    showFullPicture: function (e) {
        var target = $(e.currentTarget);
        $("#modal-popup-img").find("img").attr("src", target.attr("src"));
        $("#modal-popup-img").modal("show");
    },
    renderContactList: function (doctors) {
        //Get filter from user
        var selectedItems = $("#specialty-select").val();
        if (selectedItems != null && selectedItems.length != 0) {
            //Filter doctorList
            var filteredList = [];
            _.each(doctorList, function (doctor) {
                if (selectedItems.indexOf(doctor.SpecialtyField) != -1) {
                    filteredList.push(doctor);
                }
            });
            doctors = filteredList;
        }
        var template = _.template($("#doctor-list-template").html(), { doctors: doctors });
        if (this.contactListEl.hasClass("mCustomScrollbar")) {
            this.contactListEl.find(".mCSB_container").html(template);
            $("#contact-list").mCustomScrollbar("update");
        } else {
            this.contactListEl.html(template);
            this.contactListEl.mCustomScrollbar({
                theme: "minimal-dark"
            });
        }
    },
    getMessageList: function (e) {
        var username = $(e.currentTarget).find(".username").val();
        $('#txtToEmail').val(username);
        chatHub.server.getMessageList(username);
    },
    sendMessage: function (e) {
        var msg = $("#txtMessage").val();
        var toEmail = $('#txtToEmail').val();
        var fromEmail = $('#txtFromEmail').val();
        //var fileInput = document.getElementById('file');
        if ((msg.length > 0) && (toEmail.length > 0)) {
            chatHub.server.sendMessageTo(toEmail, msg);
            $("#txtMessage").val('');
        }
        return;
    },
    sendMessagePress: function (e) {
        if (e.keyCode == 13 && !e.shiftKey) {
            e.preventDefault();
            var msg = $("#txtMessage").val().replace('\r', '&lt;br/&gt;');
            var toEmail = $('#txtToEmail').val();
            var fromEmail = $('#txtFromEmail').val();
            if ((msg.length > 0) && (toEmail.length > 0)) {
                chatHub.server.sendMessageTo(toEmail, msg);
                $("#txtMessage").val('');
            }
            return;
        }

        if (e.keyCode == 13 && e.shiftKey) {
        }
    }
});

var chatBoxView = new ChatBoxView();

var chatHub = $.connection.chatHub;

function initSelectSpecialtyField() {
    $("#specialty-select").select2();
    $("#specialty-select").on("change", function (e) {
        var selectedItems = $("#specialty-select").val();
        if (selectedItems != null && selectedItems.length != 0) {
            //Filter doctorList
            var filteredList = [];
            _.each(doctorList, function (doctor) {
                if (selectedItems.indexOf(doctor.SpecialtyField) != -1) {
                    filteredList.push(doctor);
                }
            });
            chatBoxView.renderContactList(filteredList);
        } else {
            chatBoxView.renderContactList(doctorList);
        }
    });
}

function registerClientMethods(chatHub) {
    chatHub.client.onConnected = function (id, doctorDetail) {
        $(".unread-message").html(doctorDetail.CountMessageUnRead);
    }

    chatHub.client.onMessageUnRead = function (doctorDetail) {
        $(".unread-message").html(doctorDetail.CountMessageUnRead);
    }

    chatHub.client.onGetDoctorList = function (doctors) {
        doctorList = doctors;
        chatBoxView.renderContactList(doctors);
    }

    chatHub.client.onRefreshDoctorList = function () {
        chatHub.server.connectPatient($("#txtFromEmail").val());
    }

    chatHub.client.onGetMessageList = function (fromUser, toUser, messageDetails) {
        $("#chat-doctor").html("");
        var templateTop = $("#chat-top-template").html();
        $("#chat-doctor").append(_.template(templateTop, { user: toUser }));
        $('[data-toggle="tooltip"]').tooltip();
        if ($("#chat-content").hasClass("mCustomScrollbar")) {
            $("#chat-content").mCustomScrollbar("destroy");
        }
        $("#chat-content").html("");
        var loginEmail = $('#txtFromEmail').val();
        var templateLeft = $("#chat-left-template").html();
        var templateRight = $("#chat-right-template").html();
        _.forEach(messageDetails, function (message) {
            if (loginEmail == message.Email) {
                $("#chat-content").append(_.template(templateLeft, { user: fromUser, message: message }));
            } else {
                $("#chat-content").append(_.template(templateRight, { user: toUser, message: message }));
            }
        });
        $("#chat-content").mCustomScrollbar({
            theme: "minimal-dark"
        });
        $("#chat-content").mCustomScrollbar("scrollTo", "last");
    }

    // On New User Connected
    chatHub.client.onNewDoctorConnected = function (id, name) {
        AddUser(chatHub, id, name);
    }

    chatHub.client.messageReceived = function (sender, receiver, message) {
        var fromEmail = $('#txtFromEmail').val();
        var toEmail = $('#txtToEmail').val();
        if (receiver.Email == fromEmail) {
            chatBoxView.renderContactList(receiver.DoctorList);
            if (toEmail == sender.Email) {
                AddMessage(sender, message);
            }
        }

        if (sender.Email == fromEmail) {
            chatBoxView.renderContactList(sender.DoctorList);
            if (toEmail == receiver.Email) {
                AddMessage(sender, message);
            }
        }
    }
}

function AddMessage(user, message) {
    var loginEmail = $('#txtFromEmail').val();
    var template = $("#chat-right-template").html();
    if (loginEmail == user.Email) {
        template = $("#chat-left-template").html();
    }
    $("#chat-content .mCSB_container").append(_.template(template, { user: user, message: message }));
    $("#chat-content").mCustomScrollbar("update");
    $("#chat-content").mCustomScrollbar("scrollTo", "last");
}

function initUploadAttachment() {
    var uploader = new plupload.Uploader({
        runtimes: 'html5,flash,silverlight,html4',
        browse_button: 'pickfiles', // you can pass in id...
        container: document.getElementById('upload-container'), // ... or DOM Element itself
        url: baseUrl + 'UserConversation/Upload',
        flash_swf_url: baseUrl + 'Content/plupload/js/Moxie.swf',
        silverlight_xap_url: baseUrl + 'Content/plupload/js/Moxie.xap',

        filters: {
            max_file_size: '4mb',
            mime_types: [
                { title: "Image files", extensions: "jpg,gif,png" },
                { title: "Zip files", extensions: "zip,rar,7z,pdf,doc,docx,xls,xlsx" }
            ]
        },

        multipart_params: {
        },

        init: {
            UploadProgress: function (up, file) {
                document.getElementById(file.id).getElementsByTagName('b')[0].innerHTML = '<span>' + file.percent + "%</span>";
            },

            FilesAdded: function () {
                uploader.start();
            },

            UploadComplete: function () {
                chatHub.server.getLastestChatMessage($('#txtToEmail').val());
                $('#filelist').children().fadeOut(2000);
            },

            Error: function (up, err) {
                console.log("\nError #" + err.code + ": " + err.message);
            }
        }
    });

    uploader.init();
    uploader.bind('FilesAdded', function (up, files) {
        uploader.settings.multipart_params.fromEmail = $('#txtFromEmail').val();
        uploader.settings.multipart_params.toEmail = $('#txtToEmail').val();
        plupload.each(files, function (file) {
            document.getElementById('filelist').innerHTML += '<div id="' + file.id + '">' + file.name + ' (' + plupload.formatSize(file.size) + ') <b></b></div>';
        });
    });
}