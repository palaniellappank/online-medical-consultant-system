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

          $.ajax({
              url: "/MedicalProfileTemplate/DetailInJson/1",
              success: function (data) {
                  var jsonType = JSON.parse(data);
                  new InputView({
                      title: "Original",
                      collection: new SnippetsCollection(jsonType)
                  });
              }
          });
          
    }
  }
});
