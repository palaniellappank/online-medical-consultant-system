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
        var that = this;
        return this.map(function (snippet) {
            //Just render parent
            if (!snippet.has("parentId")) {
                //Just a common component
                if (snippet.get("title") != "Table") {
                    return new SnippetView({ model: snippet }).render();
                } else {
                    //This is a table and should find and load all component inside
                    var id = that.indexOf(snippet);
                    var childList = that.filter(function(child) {
                        return child.get("parentId") == id;
                    });
                    var totalChildLength = snippet.getValues()["columns"].length * snippet.getValues()["numofrows"];
                    var totalChild = new Array(totalChildLength);
                    var childListRendered = _.each(childList, function(snippet) {
                        totalChild[snippet.get("positionInTable")] = new SnippetView({ model: snippet }).render();
                    });
                    return new SnippetView({ model: snippet }).render(totalChild);
                }
            }
        });
    }
  });
});
