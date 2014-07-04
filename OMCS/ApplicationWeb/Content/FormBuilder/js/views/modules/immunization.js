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
          "click #new-btn": "add",
          "click .edit-btn": "edit",
          "click .delete-btn": "delete"
      },
      add: function () {
          var url = "/Immunization/Create";
          $.get(url + "?medicalProfileId=" + medicalProfileId, function (data) {
              initModalWithData(data);
          });
      },
      edit: function (e) {
          e.preventDefault();
          var url = "/Immunization/Edit";
          var id = $(e.currentTarget).attr("data-id");
          $.get(url + "?id=" + id, function (data) {
              initModalWithData(data);
          });
      },
      delete: function (e) {
          e.preventDefault();
          var url = "/Immunization/Delete";
          var id = $(e.currentTarget).attr("data-id");
          var that = this;
          bootbox.confirm("Bạn muốn xóa lượt tiêm chủng này?", function (result) {
              if (result) {
                  $.post(
                      url,
                      { id: id },
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
              url: immunizationUrl,
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
