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
          if (this.model.getValues()["mappingtype"] == "Copy") {
              this.template = _.template(_snippetTemplates["statictextcopy"]);
          } else {
              this.template = _.template(_snippetTemplates[this.model.idFriendlyTitle()]);
          }
      }
      , render: function () {
          return this.$el.html(
            this.template(this.model.getValues()));
      }
  });
});
