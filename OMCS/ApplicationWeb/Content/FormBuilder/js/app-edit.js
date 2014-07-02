define([
       "collections/my-form-input-mode"
       , "views/my-form-input-mode", "views/my-form"
       , "views/treatment-list"
       , "text!data/input.json",
], function(
  SnippetsCollection
  , InputView, MyFormView, TreatmentView
  , inputJSON
){
  return {
      initialize: function () {
        new InputView({
            collection: new SnippetsCollection(formInJson)
        });

        $(".TreatmentHistory").parent().attr("id", "TreatmentHistory");
        new TreatmentView({
            el: "#TreatmentHistory"
        });

        $("#saveBtn").click(function (e) {
            $("form#target").validate({
                submitHandler: function () {
                    $.ajax({
                        type: "POST",
                        url: $("form#target").attr("action"),
                        data: $("form#target").serialize(),
                        success: function () {
                            bootbox.alert("Cập nhật thành công!");
                        },
                        error: function (jqXHR, textStatus, errorThrown) {
                            bootbox.alert("Có lỗi xảy ra: " + textStatus);
                        }
                    });
                    return false;
                }
            });
            
        });

        $(".datepicker").datepicker({ dateFormat: 'dd/mm/yy' });
    }
  }
});
