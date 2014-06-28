define([
       "models/snippet"
       , "views/input-mode-snippet"
], function(
  SnippetModel
  , SnippetView
){
  return Backbone.Collection.extend({
    model: SnippetModel
    , renderAll: function(){
        return this.map(function (snippet) {
            return new SnippetView({ model: snippet }).render();
      });
    }
  });
});
