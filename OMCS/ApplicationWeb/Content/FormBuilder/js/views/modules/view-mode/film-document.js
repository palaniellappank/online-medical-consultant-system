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
          "click .img-modal": "viewImage"
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
