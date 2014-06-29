define([
       "collections/my-form-input-mode"
       , "views/my-form-input-mode" , "views/my-form"
       , "text!data/input.json",
], function(
  SnippetsCollection
  , InputView, MyFormView
  , inputJSON
){
  return {
      initialize: function () {
        new InputView({
            title: "Original",
            collection: new SnippetsCollection(formInJson)
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
