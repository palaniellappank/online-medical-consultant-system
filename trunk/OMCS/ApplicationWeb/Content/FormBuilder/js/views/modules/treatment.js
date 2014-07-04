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
          "click #newTreatmentHistoryBtn": "createNew",
          "click .edit-btn": "editTreatment",
          "click .delete-btn": "deleteTreatment",
          "click .add-film-btn": "addFilmDocument",
          "click .slider-img": "editFilmDocument"
      },
      createNew: function() {
          var url = "/TreatmentHistory/Create";
          $.get(url + "?medicalProfileId=" + medicalProfileId, function (data) {
              initModalWithData(data);
          });
      },
      addFilmDocument: function (e) {
          var url = "/FilmDocument/CreateForTreatment";
          var treatmentId = $(e.currentTarget).attr("data-id");
          $.get(url + "?treatmentHistoryId=" + treatmentId, function (data) {
              initModalWithData(data);
              Holder.run();
              $("#imgInp").change(function () {
                  readImgFromURL(this);
              });
          });
      },
      editFilmDocument: function (e) {
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
      editTreatment: function (e) {
          var url = "/TreatmentHistory/Edit";
          var treatmentId = $(e.currentTarget).attr("data-id");
          var that = this;
          $.get(url + "?id=" + treatmentId, function (data) {
              initModalWithData(data);
          });
      },
      deleteTreatment: function (e) {
          e.preventDefault();
          var url = "/TreatmentHistory/Delete";
          var treatmentId = $(e.currentTarget).attr("data-id");
          var that = this;
          bootbox.confirm("Bạn muốn xóa lượt tư vấn này?", function (result) {
              if (result) {
                  $.post(
                      url,
                      { id: treatmentId },
                      function () {
                          window.location.reload();
                  });
              }
          });
      },
      render: function () {
          var that = this;
          $.ajax({
              type: "POST",
              url: treatmentHistoryUrl,
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
