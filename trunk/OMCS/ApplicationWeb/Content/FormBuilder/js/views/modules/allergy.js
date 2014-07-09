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
          "click #newAllergyBtn": "addAllergy",
          "click .edit-btn": "editAllergy",
          "click .delete-btn": "deleteAllergy"
      },
      addAllergy: function () {
          if (medicalProfileId == 0) {
              bootbox.alert("Bạn cần lưu lại hồ sơ trước khi thực hiện thao tác này!");
              return;
          };
          var url = "/Allergy/Create";
          $.get(url + "?medicalProfileId=" + medicalProfileId, function (data) {
              initModalWithData(data);
          });
      },
      editAllergy: function (e) {
          e.preventDefault();
          var url = "/Allergy/Edit";
          var id = $(e.currentTarget).attr("data-id");
          $.get(url + "?id=" + id, function (data) {
              initModalWithData(data);
          });
      },
      deleteAllergy: function (e) {
          e.preventDefault();
          var url = "/Allergy/Delete";
          var id = $(e.currentTarget).attr("data-id");
          var that = this;
          bootbox.confirm("Bạn muốn xóa dị ứng này này?", function (result) {
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
