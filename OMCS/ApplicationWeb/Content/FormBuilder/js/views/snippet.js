define([
  "text!templates/popover/popover-main.html"
  , "text!templates/popover/popover-input.html"
  , "text!templates/popover/popover-select.html"
  , "text!templates/popover/popover-textarea.html"
  , "text!templates/popover/popover-textarea-split.html"
  , "text!templates/popover/popover-checkbox.html"
  , "templates/snippet/snippet-templates"
  , "bootstrap"
], function(
  _PopoverMain
  , _PopoverInput
  , _PopoverSelect
  , _PopoverTextArea
  , _PopoverTextAreaSplit
  , _PopoverCheckbox
  , _snippetTemplates
){
  return Backbone.View.extend({
    tagName: "div"
    , className: "component" 
    , initialize: function () {
      this.template = _.template(_snippetTemplates[this.model.idFriendlyTitle()])
      this.popoverTemplates = {
        "input" : _.template(_PopoverInput)
        , "select" : _.template(_PopoverSelect)
        , "textarea" : _.template(_PopoverTextArea)
        , "textarea-split" : _.template(_PopoverTextAreaSplit)
        , "checkbox" : _.template(_PopoverCheckbox)
      }
    }
    , render: function(childListRendered){
      var isChild = this.model.get("parentId") != undefined;
      var sizepx = "auto";
      if (this.model.getValues()["inputsize"]) {
        switch(this.model.getValues()["inputsize"]) {
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
      var content = _.template(_PopoverMain)({
        "title": this.model.get("name"),
        "items" : this.model.get("fields"),
        "popoverTemplates": this.popoverTemplates
      });
      var snippetHtml = this.$el.html(
        this.template(_.extend(this.model.getValues(), {isChild: isChild, sizepx: sizepx}))
      ).attr({
        "data-content"     : content
        , "data-title"     : this.model.get("name")
        , "data-trigger"   : "manual"
        , "data-html"      : true
      });

      if (this.model.get("title") == "Table") {
        var holderList = this.$el.find(".component-holder");
        _.each(childListRendered, function(element, index, list){
          holderList.eq(index).html(element);
        });
      }
      return snippetHtml;
    }
  });
});
