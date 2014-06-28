define([
       "models/snippet"
       , "views/snippet", "views/temp-snippet"
       , "helper/pubsub"
       , "templates/snippet/edit-mode/snippet-templates"
], function (
    SnippetModel
  , SnippetView, TempSnippetView
  , PubSub
  , _snippetTemplates
){
  return SnippetView.extend({
      className: ""
      , initialize: function () {
          this.template = _.template(_snippetTemplates[this.model.idFriendlyTitle()]);
      }
      , render: function (withAttributes) {
          var that = this;
          if (withAttributes) {
              return this.$el.html(
                that.template(that.model.getValues())
              ).attr({
                  "data-content": content
                , "data-title": that.model.get("title")
                , "data-trigger": "manual"
                , "data-html": true
              });
          } else {
              return this.$el.html(
              that.template(that.model.getValues())
            )
          }
      }
  });
});
