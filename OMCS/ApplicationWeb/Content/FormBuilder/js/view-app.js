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

        $(".datepicker").datepicker();
    }
  }
});
