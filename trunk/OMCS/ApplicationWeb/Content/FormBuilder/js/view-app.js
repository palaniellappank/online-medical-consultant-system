define([
       "jquery" , "underscore" , "backbone", "jquery-ui"
       , "collections/my-form-input-mode"
       , "views/my-form-input-mode" , "views/my-form"
       , "text!data/input.json",
], function(
  $, _, Backbone, jqueryUI
  , SnippetsCollection
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
            $.post(
                $("form#target").attr("action"),
                $("form#target").serialize()
            );
        });

        $(".datepicker").datepicker();
    }
  }
});
