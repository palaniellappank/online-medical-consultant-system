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
    , mouseDownHandler: function (mouseDownEvent) {
        if (this.model.getValues().ignore != true) {
            mouseDownEvent.preventDefault();
            mouseDownEvent.stopPropagation();
            //hide all popovers
            $(".popover").hide();
            //TempSnippetView is Element that is dragging
            //console.dir(this.model.attributes);
            $("body").append(new TempSnippetView({ model: new SnippetModel($.extend(true, {}, this.model.attributes)) }).render());
            PubSub.trigger("newTempPostRender", mouseDownEvent);
        }
    },
    render: function () {
        if (this.model.getValues().ignore == true) {
            this.template = _.template(_snippetTemplates["formname"]);
        } else {
            this.template = _.template(_snippetTemplates["commonsnippettab"]);
        }
        console.log(this.model.attributes);
        return this.$el.html(this.template(this.model.attributes));
    }
  });
});
