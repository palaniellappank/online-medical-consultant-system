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
          "click .saveCreateBtn": "saveTreatment",
          "click .edit-btn": "editTreatment",
          "click .saveEditBtn": "saveEditTreatment",
          "click .delete-btn": "deleteTreatment",
      },
      createNew: function() {
          var url = "/TreatmentHistory/Create";
          var that = this;
          $.get(url + "?medicalProfileId=" + medicalProfileId, function (data) {
            $('#create-treatment-history-container').html(data);
            $('#create-treatment-history-modal').modal('show');
            that.$el.find(".create-form").validate();
            $('<span style="color:red;">*</span>').insertBefore('.required');
            $(".datepicker").datepicker({ dateFormat: 'dd/mm/yy' });
          });
      },
      editTreatment: function (e) {
          var url = "/TreatmentHistory/Edit";
          var treatmentId = $(e.currentTarget).attr("data-id");
          var that = this;
          $.get(url + "?id=" + treatmentId, function (data) {
              $('#edit-treatment-history-container').html(data);
              $('#edit-treatment-history-modal').modal('show');
              that.$el.find(".edit-form").validate();
              $('<span style="color:red;">*</span>').insertBefore('.required');
              $(".datepicker").datepicker({ dateFormat: 'dd/mm/yy' });
          });
      },
      saveTreatment: function (e) {
          e.preventDefault();
          var form = this.$el.find(".create-form");
          if (form.valid()) {
              $.post(
                  form.attr("action"),
                  form.serializeArray(),
                  function () {
                      window.location.reload();
              });
          }  
      },
      saveEditTreatment: function () {
          e.preventDefault();
          var form = this.$el.find(".edit-form");
          if (form.valid()) {
              $.post(
                  form.attr("action"),
                  form.serializeArray(),
                  function () {
                      window.location.reload();
              });
          }
      },
      deleteTreatment: function (e) {
          e.preventDefault();
          var url = "/TreatmentHistory/Delete";
          var treatmentId = $(e.currentTarget).attr("data-id");
          var that = this;
          bootbox.confirm("Bạn muốn xóa lượt tư vấn này?", function () {
              $.post(
                  url,
                  {id : treatmentId},
                  function () {
                      window.location.reload();
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
               //   bootbox.alert("abc");
              },
              error: function (jqXHR, textStatus, errorThrown) {
                  bootbox.alert("Có lỗi xảy ra: " + textStatus);
              }
          });
        }
    })
});
