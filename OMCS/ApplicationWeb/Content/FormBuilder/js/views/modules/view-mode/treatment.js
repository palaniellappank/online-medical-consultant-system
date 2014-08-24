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
          "click .slider-img": "viewFilmDocument"
      },
      viewFilmDocument: function (e) {
          var url = baseUrl + "FilmDocument/Details";
          var filmDocumentId = $(e.currentTarget).attr("data-id");
          $.get(url + "?id=" + filmDocumentId, function (data) {
              initModalWithData(data);
              Holder.run();
              $("#imgInp").change(function () {
                  readImgFromURL(this);
              });
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
