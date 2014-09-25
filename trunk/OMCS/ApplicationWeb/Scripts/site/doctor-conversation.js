$(function () {
    $('[data-toggle="tooltip"]').tooltip();
    var chatHub = $.connection.chatHub;
    registerClientMethodsInConversation(chatHub);

    //enable / disable
    $('#private-consult-enable').click(function () {
        if ($(this).prop("checked")) {
            $("#historyConsultant").css("display", "none");
            $("#patientDetailPanel").css("display", "block");
            var patientEmail = $("#txtToEmail").val();
            patientDetailView.render(patientEmail);
            var doctorEmail = $("#txtFromEmail").val();
            chatHub.server.updateStatusToBusy(doctorEmail);
        } else {
            $("#historyConsultant").css("display", "block");
            $("#patientDetailPanel").css("display", "none");
            var doctorEmail = $("#txtFromEmail").val();
            chatHub.server.updateStatusToOnline(doctorEmail);
        }
    });

    $(".datepicker").datepicker({ dateFormat: 'dd/mm/yy' });


    // Start Hub
    $.connection.hub.start().done(function () {
        var fromUser = $("#txtFromEmail").val();
        chatHub.server.connectDoctor(fromUser);
    });

    initUploadAttachment();
});

PatientDetailView = Backbone.View.extend({
    el: "#patientDetailPanel",
    times: 0,
    email: undefined,
    filmDocuments: [],
    events: {
        "click #btnViewPatientDetail": "viewPatientDetail",
        "click #btnSearchPatient": "searchPatient",
        "click #btnViewAllergy": "viewAllergy",
        "click #btnViewImmunization": "viewImmunization",
        "click #requestWebcam": "requestWebcam",
        "click #saveTreatmentBtn": "saveTreatment",
        "click #clearTreatmentBtn": "clearTreatment",
        "click .viewTreatment": "viewTreatment",
        "click .editTreatment": "editTreament",
        "click .viewConversation": "viewConversation",
        "click .deleteTreatment": "deleteTreatment",
        "click .btn-prev": "goToPrevious",
        "click .btn-next": "goToNext",
        "click .slider-img": "openDetailFilmDocument"
    },
    openDetailFilmDocument: function (e) {
        var position = $(e.currentTarget).attr("data-id");
        var filmDocument = this.filmDocuments[position];
        filmDocument.PositionId = position;
        var template = _.template($("#film-document-detail-template").html(), { filmDocument: filmDocument });  
        $('#modal-popup').html(template);
        $('#modal-popup').modal('show');
    },
    requestWebcam: function () {
        var toEmail = $('#txtToEmail').val();
        if (toEmail.length > 0) {
            chatHub.server.requestWebcam(toEmail);
        }
    },
    searchPatient: function (e) {
        var url = baseUrl + "DoctorConversation/SearchPatient";
        $.get(url, function (data) {
            $('#modal-popup').html(data);
            $('#modal-popup').modal('show');
        });
    },
    viewTreatment: function (e) {
        e.preventDefault();
        var treatmentId = $(e.target).parents("[data-treatmentid]").attr("data-treatmentid");
        var url = "/TreatmentHistory/View";
        var that = this;
        $.get(url + "?id=" + treatmentId, function (data) {
            $('#modal-popup').html(data);
            $('#modal-popup').modal('show');
        });
    },
    editTreament: function (e) {
        e.preventDefault();
        var treatmentId = $(e.target).parents("[data-treatmentid]").attr("data-treatmentid");
        var url = "/TreatmentHistory/Edit";
        var that = this;
        $.get(url + "?id=" + treatmentId, function (data) {
            initModalWithData(data);
        });
    },
    viewConversation: function (e) {
        e.preventDefault();
        var treatmentId = $(e.target).parents("[data-treatmentid]").attr("data-treatmentid");
        var patientEmail = $("#txtToEmail").val();
        var url = "/Conversation/DoctorTreatmentConversation?treatmentId=" + treatmentId + "&toEmail=" + patientEmail;
        var that = this;
        $.get(url, function (data) {
            $('#modal-popup').html(data);
            $('#modal-popup').modal('show');
        });
    },
    clearTreatment: function (e) {
        if (e != undefined) {
            e.preventDefault();
        }
        $("#newTreatmentForm")[0].reset();
        this.filmDocuments = [];
        this.renderFilmDocument();
    },
    saveTreatment: function (e) {
        e.preventDefault();
        var form = $("#newTreatmentForm");
        if (form.valid()) {
            var formData = new FormData(form[0]);
            var patientId = $("#patientId").val();
            formData.append("patientId", patientId);
            formData.append("filmDocuments", JSON.stringify(this.filmDocuments));
            var that = this;
            $.ajax({
                url: form.attr("action"),
                method: "post",
                contentType: false,
                processData: false,
                data: formData,
                success: function (response) {
                    var result = JSON.parse(response);
                    if (result.result == "ok") {
                        bootstrap_alert.warning(form.find(".alert-aria"), "Lượt khám bệnh lưu thành công");
                        that.clearTreatment();
                        that.renderTreatmentHistory(that.email);
                    }
                }
            });
        }
    },
    deleteTreatment: function (e) {
        e.preventDefault();
        var treatmentId = $(e.target).parents("[data-treatmentid]").attr("data-treatmentid");
        var url = "/TreatmentHistory/DeleteTreatment";
        var that = this;
        $.get(url + "?id=" + treatmentId, function (data) {
            initModalWithData(data);
        });
    },
    goToPrevious: function () {
        $('.flexslider').flexslider('prev');
    },
    goToNext: function () {
        $('.flexslider').flexslider('next');
    },
    viewPatientDetail: function () {
        var patientId = $("#patientId").val();
        $.get(baseUrl + "DoctorUser/View?id=" + patientId, function (data) {
            $('#view-container').html(data);
            $('#view-model').modal('show');
        });
    },
    viewAllergy: function () {
        var patientId = $("#patientId").val();
        $.ajax({
            url: baseUrl + "UserHealthRecord/ShowAllergyList/" + patientId,
            success: function (e) {
                $("#modal-popup-full").find(".modal-body").html(e);
                $("#modal-popup-full").modal("show");
            }
        });
    },
    viewImmunization: function () {
        var patientId = $("#patientId").val();
        $.ajax({
            url: "/UserHealthRecord/ShowImmunizationList/" + patientId,
            success: function (e) {
                $("#modal-popup-full").find(".modal-body").html(e);
                $("#modal-popup-full").modal("show");
            }
        });
    },
    renderTreatmentHistory: function (email) {
        $.ajax({
            url: baseUrl + "TreatmentHistory/GetAllTreatmentHistoryList?patientEmail=" + email,
            success: function (data) {
                treatmentHistories = JSON.parse(data);
                var template = _.template($("#treatment-history-template").html(), { treatmentHistories: treatmentHistories });
                $(".treatment-history-list").html(template);
                flexdestroy(".flexslider");
                $('.flexslider').flexslider({
                    animation: "slide",
                    controlNav: false,
                    directionNav: false,
                    slideshow: false
                });
            }
        });
    },
    renderFilmDocument: function () {
        if (this.filmDocuments.length > 0) {
            var template = _.template($("#film-document-template").html(), { filmDocuments: this.filmDocuments });
            this.$el.find(".film-document").show();
            this.$el.find(".film-document").find(".film-document-holder").html(template);
        } else {
            this.$el.find(".film-document").hide();
        }
    },
    render: function (email) {
        this.email = email;
        $.ajax({
            url: baseUrl + "DoctorUser/ViewInJson?email=" + email,
            success: function (data) {
                patientDetail = JSON.parse(data);
                var template = _.template($("#user-detail-heading-template").html(), { patientDetail: patientDetail });
                $("#patientDetailPanelHeading").html(template);
            }
        });
        this.renderTreatmentHistory(email);
        this.renderFilmDocument();
        $("input[name=medicalProfileId").select2({
            width: 170,
            ajax: {
                url: baseUrl + "DoctorMedicalProfile/GetMedicalProfileList?patientEmail=" + email,
                dataType: 'json',
                type: "GET",
                results: function (data) {
                    return {
                        results: $.map(data, function (item) {
                            return {
                                text: item.text,
                                id: item.id
                            }
                        })
                    };
                }
            }
        });
        if (this.times == 0) {
            var form = $("#newTreatmentForm");
            validationForm(form);
        }
        this.times++;
    }
});
var patientDetailView = new PatientDetailView();

BodyView = Backbone.View.extend({
    el: $("body"),
    events: {
        "click #closePatientWebcam": "hideWebcam",
        "click #takePhoto": "takePhoto",
        "click .useAsFilmDocument": "useAsFilmDocument"
    },
    hideWebcam: function (e) {
        $(".webcam-content").css("display", "none");
    },
    useAsFilmDocument: function (e) {
        var imagePath = $("#modal-popup-img-use-as").find("img").attr("src");
        var url = baseUrl + "FilmDocument/CreateFromAttachment?imagePath=" + imagePath;
        $.get(url, function (data) {
            $('#modal-popup').html(data);
            $('#modal-popup').modal('show');
            var form = $('#modal-popup').find("form");
            validationForm(form);
        });
    },
    takePhoto: function (e) {
        var video = $("#webcam")[0];
        var photo = $("#photo")[0],
            context = photo.getContext('2d');

        photo.width = video.clientWidth;
        photo.height = video.clientHeight;
        context.drawImage(video, 0, 0, photo.width, photo.height);

        var url = baseUrl + "FilmDocument/CreateWhenChat";
        $.get(url, function (data) {
            $('#modal-popup').html(data);
            $('#modal-popup').modal('show');
            var form = $('#modal-popup').find("form");
            validationForm(form);
            $("#imgPhoto").attr("src", photo.toDataURL());
            $("textarea[name=imgBase64]").val(photo.toDataURL());
        });
    }
});
new BodyView();
ChatBoxView = Backbone.View.extend({
    el: $("#chatbox"),
    doctorListEl: $("#contact-list"),
    events: {
        "click .list-group-item": "getMessageList",
        "click #btnSendMsg": "sendMessage",
        "keypress #txtMessage": "sendMessagePress",
        "click .picture-thumbnail": "showFullPicture"
    },
    showFullPicture: function (e) {
        var target = $(e.currentTarget);
        $("#modal-popup-img-use-as").find("img").attr("src", target.attr("src"));
        $("#modal-popup-img-use-as").modal("show");
    },
    renderContactList: function (conversations) {
        var template = _.template($("#doctor-list-template").html(), { conversations: conversations });
        this.doctorListEl.html(template);
    },
    getMessageList: function (e) {
        var username = $(e.currentTarget).find(".username").val();
        $('#txtToEmail').val(username);
        chatHub.server.getMessageList(username);
        $("#private-consult-enable").removeAttr("disabled");
        $("#txtMessage").removeAttr("disabled");
        $("#btnSendMsg").removeAttr("disabled");
    },
    sendMessage: function (e) {
        var msg = $("#txtMessage").val();
        var toEmail = $('#txtToEmail').val();
        var fromEmail = $('#txtFromEmail').val();
        if ((msg.length > 0) && (toEmail.length > 0)) {
            chatHub.server.sendMessageTo(toEmail, msg);
            $("#txtMessage").val('');
        }
        return;
    },
    sendMessagePress: function (e) {
        if (e.keyCode == 13 && !e.shiftKey) {
            e.preventDefault();
            var msg = $("#txtMessage").val();
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

var ModalPopupView = Backbone.View.extend({
    el: "#modal-popup",
    events: {
        "click .deleteFilmDocumentBtn": "deleteFilmDocument",
        "click .saveFilmDocumentBtn": "saveFilmDocument"
    },
    saveFilmDocument: function (e) {
        var id = $(e.currentTarget).attr("data-id");
        var treatment = patientDetailView.filmDocuments[id];
      //  treatment.FilmTypeId = form.find("select[name=FilmTypeId]").val();
        treatment.Description = this.$el.find("textarea[name=Description]").val();
        treatment.Conclusion = this.$el.find("textarea[name=Conclusion]").val();
        patientDetailView.filmDocuments[id] = treatment;
        patientDetailView.renderFilmDocument();
        $('#modal-popup').modal('hide');
    },
    deleteFilmDocument: function (e) {
        bootbox.confirm("Bạn có muốn xóa hồ sơ ảnh này?", function (result) {
            if (result) {
                var id = $(e.currentTarget).attr("data-id");
                var treatment = patientDetailView.filmDocuments[id];
                //  treatment.FilmTypeId = form.find("select[name=FilmTypeId]").val();
                patientDetailView.filmDocuments.splice(id, 1);
                patientDetailView.renderFilmDocument();
                $('#modal-popup').modal('hide');
            } else {
            }
        });
    }
});
new ModalPopupView();
// Declare a proxy to reference the hub. 
var chatHub = $.connection.chatHub;

function registerClientMethodsInConversation(chatHub) {
    chatHub.client.onConnected = function (id, doctorDetail) {
        $(".unread-message").html(doctorDetail.CountMessageUnRead);
    }

    chatHub.client.onMessageUnRead = function (doctorDetail) {
        $(".unread-message").html(doctorDetail.CountMessageUnRead);
    }
    chatHub.client.messageReceived = function (sender, receiver, message) {
        console.log("Message Receive:");
        console.log(receiver);

        var fromEmail = $('#txtFromEmail').val();
        var toEmail = $('#txtToEmail').val();
        if (receiver.Email == fromEmail) {
            chatBoxView.renderContactList(receiver.ConversationList);
            if (toEmail == sender.Email) {
                AddMessage(sender, message);
            }
        }

        if (sender.Email == fromEmail) {
            chatBoxView.renderContactList(sender.ConversationList);
            if (toEmail == receiver.Email) {
                AddMessage(sender, message);
            }
        }
    }

    chatHub.client.onGetConversationList = function (conversations) {
        console.log(conversations);
        chatBoxView.renderContactList(conversations);
    }

    chatHub.client.onGetMessageList = function (fromUser, toUser, messageDetails) {
        var loginEmail = $('#txtFromEmail').val();
        var templateLeft = $("#chat-left-template").html();
        var templateRight = $("#chat-right-template").html();
        if ($("#chat-content").hasClass("mCustomScrollbar")) {
            $("#chat-content").mCustomScrollbar("destroy");
        }
        $("#chat-content").html("");
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