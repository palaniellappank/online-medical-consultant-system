define([
       "jquery", "underscore", "backbone"
      , "text!templates/app/renderform.html"
], function (
  $, _, Backbone
  , _renderForm
) {
    return Backbone.View.extend({
        el: "#build"
      , initialize: function () {
          this.$build = $("#build");
          this.fieldset = this.$el.find("fieldset");
          this.renderForm = _.template(_renderForm);
          this.render();
      },
        render: function () {
            //Render Snippet Views
            this.fieldset.empty();
            var that = this;
            _.each(this.collection.renderAll(), function (snippet) {
                that.fieldset.append(snippet);
            });
            this.fieldset.appendTo("#build form");
            this.delegateEvents();
        }
    })
});
