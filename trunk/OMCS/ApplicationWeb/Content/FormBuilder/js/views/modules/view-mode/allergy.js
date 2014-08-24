define([
], function () {
    return Backbone.View.extend({
      initialize: function (options) {
          this.render();
          this.delegateEvents();
      },
      events: {
          "click .view-btn": "viewAllergy"
      },
      viewAllergy: function (e) {
          e.preventDefault();
          var url = baseUrl + "Allergy/Details";
          var id = $(e.currentTarget).attr("data-id");
          $.get(url + "?id=" + id, function (data) {
              initModalWithData(data);
          });
      },
      render: function () {
          var that = this;
          $.ajax({
              type: "POST",
              url: allergyUrl,
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
