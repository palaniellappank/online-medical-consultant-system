define([
       "jquery" , "underscore" , "backbone"
       , "collections/my-form-input-mode"
       , "views/my-form-input-mode" , "views/my-form"
       , "text!data/input.json",
], function(
  $, _, Backbone
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
    }
  }
});
