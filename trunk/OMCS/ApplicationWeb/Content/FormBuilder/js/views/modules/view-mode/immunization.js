define([
], function () {
    return Backbone.View.extend({
      initialize: function (options) {
          this.render();
          this.delegateEvents();
      },
      render: function () {
          var that = this;
          $.ajax({
              type: "POST",
              url: immunizationUrl,
              data: { medicalProfileId: medicalProfileId },
              success: function (data) {
                  that.$el.append(data);
              },
              error: function (jqXHR, textStatus, errorThrown) {
                  bootbox.alert("Có lỗi xảy ra: " + textStatus);
              }
          });
        }
    })
});
