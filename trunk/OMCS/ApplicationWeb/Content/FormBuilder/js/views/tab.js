define([
       "text!templates/app/tab-nav.html"

], function(
           _tabNavTemplate){
  return Backbone.View.extend({
    tagName: "div"
    , className: "tab-pane"
    , initialize: function (options) {
      this.id = options.title.toLowerCase().replace(/\W/g, '');
      this.title = options.title;
      this.tabNavTemplate = _.template(_tabNavTemplate);
      this.render();
    }
    , render: function () {
        // Render Snippet Views
        this.$el.append("<ul class='nav nav-pills nav-stacked' style='max-width: 300px;'></ul>");
        var that = this;
      if (that.collection !== undefined) {
        _.each(this.collection.renderAll(), function(snippet){
            that.$el.find(".nav").append(snippet);
        });
      } else if (that.options.content){
          that.$el.find(".nav").append(that.options.content);
      }
      // Render & append nav for tab
      $("#formtabs").append(this.tabNavTemplate({title: this.title, id: this.id}))
      // Render tab
      this.$el.attr("id", this.id);
      this.$el.appendTo(".tab-content");
      this.delegateEvents();
    }
  });
});
