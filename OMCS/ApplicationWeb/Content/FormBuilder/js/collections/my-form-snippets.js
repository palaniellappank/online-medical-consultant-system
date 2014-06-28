define([
       "models/snippet"
       , "collections/snippets" 
       , "views/my-form-snippet"
], function(
  SnippetModel
  , SnippetsCollection
  , MyFormSnippetView
){
  return SnippetsCollection.extend({
    model: SnippetModel
    , renderAll: function(){
        return this.map(function (snippet) {
        return new MyFormSnippetView({model: snippet}).render(true);
      })
    }
    , renderAllClean: function(){
        return this.map(function (snippet) {
        return new MyFormSnippetView({model: snippet}).render(false);
      });
    }
  });
});
