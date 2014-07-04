define([
      "templates/snippet/edit-mode/snippet-templates"
], function (
  _templateHTML
) {
    return Backbone.View.extend({
      initialize: function (options) {
          this.render();
          this.delegateEvents();
      },
      events: {
          "click #newFilmDocumentBtn": "addFilm",
          "click .edit-btn": "editFilm",
          "click .delete-btn": "deleteFilm",
          "click .delete-btn": "deleteFilm",
          "click .img-modal": "viewImage"
      },
      addFilm: function () {
          var url = "/FilmDocument/CreateForMedicalProfile";
          $.get(url + "?medicalProfileId=" + medicalProfileId, function (data) {
              initModalWithData(data);
              Holder.run();
              $("#imgInp").change(function () {
                  readImgFromURL(this);
              });
          });
      },
      editFilm: function (e) {
          var url = "/FilmDocument/Edit";
          var filmDocumentId = $(e.currentTarget).attr("data-id");
          $.get(url + "?id=" + filmDocumentId, function (data) {
              initModalWithData(data);
              Holder.run();
              $("#imgInp").change(function () {
                  readImgFromURL(this);
              });
          });
      },
      deleteFilm: function (e) {
          e.preventDefault();
          var url = "/FilmDocument/Delete";
          var filmDocumentId = $(e.currentTarget).attr("data-id");
          var that = this;
          bootbox.confirm("Bạn muốn xóa hồ sơ ảnh này?", function (result) {
              if (result) {
                  $.post(
                      url,
                      { id: filmDocumentId },
                      function () {
                          window.location.reload();
                      });
              }
          });
      },
      viewImage: function (e) {
          e.preventDefault();
          $("#modal-popup-img").find("img").attr("src", $(e.currentTarget).attr("src"));
          $("#modal-popup-img").modal("show");
      },
      render: function () {
          var that = this;
          $.ajax({
              type: "POST",
              url: filmDocumentUrl,
              data: { medicalProfileId: medicalProfileId },
              success: function (data) {
                  that.$el.append(data);
                  $('[data-toggle="tooltip"]').tooltip();
              },
              error: function (jqXHR, textStatus, errorThrown) {
                  bootbox.alert("Có lỗi xảy ra: " + textStatus);
              }
          });
        }
    })
});
