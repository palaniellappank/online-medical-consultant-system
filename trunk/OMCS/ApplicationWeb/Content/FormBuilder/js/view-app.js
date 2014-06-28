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
                messages: {
                    Name: "Hãy điền tên chuyên khoa."
                },
                submitHandler: function () {
                    console.log(submitHandler);
                    $.ajax({
                        type: "POST",
                        url: $("form#target").attr("action"),
                        data: $("form#target").serialize(),
                        success: function () {
                            bootbox.alert("Cập nhật thành công!");
                        }
                    });
                }
            });
            
        });

        $(".datepicker").datepicker();
    }
  }
});
