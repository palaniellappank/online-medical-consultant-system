define([
       "jquery", "underscore", "backbone"
       , "models/snippet"
       , "views/snippet", "views/temp-snippet"
       , "helper/pubsub"
       , "templates/snippet/snippet-templates"
], function(
  $, _, Backbone
  , SnippetModel
  , SnippetView, TempSnippetView
  , PubSub
  , _snippetTemplates
){
    return SnippetView.extend({
        tagName: "li",
        className: "element-selector",
    events:{
      "mousedown" : "mouseDownHandler"
    }
    , mouseDownHandler: function(mouseDownEvent){
      mouseDownEvent.preventDefault();
      mouseDownEvent.stopPropagation();
      //hide all popovers
      $(".popover").hide();
      //TempSnippetView is Element that is dragging
      //console.dir(this.model.attributes);
      $("body").append(new TempSnippetView({model: new SnippetModel($.extend(true,{},this.model.attributes))}).render());
      PubSub.trigger("newTempPostRender", mouseDownEvent);
    },
    render: function () {
        console.log(this.model);
        this.template = _.template(_snippetTemplates["commonsnippettab"]);
        return this.$el.html(this.template(this.model.attributes));
    }
  });
});
