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
      , render: function (childListRendered) {
          var isChild = this.model.get("parentId") != undefined;
          var sizepx = "auto";
          if (this.model.getValues()["inputsize"]) {
              switch (this.model.getValues()["inputsize"]) {
                  case "col-md-2":
                      sizepx = 50;
                      break;
                  case "col-md-4":
                      sizepx = 120;
                      break;
                  default:
                      sizepx = "auto";
              }
          }
          var snippetHtml = this.$el.html(
            this.template(_.extend(this.model.getValues(), { isChild: isChild, sizepx: sizepx }))
          );

          if (this.model.get("title") == "Table") {
              var holderList = this.$el.find(".component-holder");
              _.each(childListRendered, function (element, index, list) {
                  holderList.eq(index).html(element);
              });
          }
          return snippetHtml;
      }
  });
});
