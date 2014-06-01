﻿define([
       "jquery", "underscore", "backbone"
      , "collections/my-form-snippets"
      , "views/temp-snippet"
      , "helper/pubsub"
      , "text!templates/app/renderform.html"
], function(
  $, _, Backbone
  , MyFormSnippetsCollection
  , TempSnippetView
  , PubSub
  , _renderForm
){
  return Backbone.View.extend({
      el: "#build"
    , initialize: function () {
      this.collection.on("add", this.render, this);
      this.collection.on("remove", this.render, this);
      this.collection.on("change", this.render, this);
      PubSub.on("mySnippetDrag", this.handleSnippetDrag, this);
      PubSub.on("tempMove", this.handleTempMove, this);
      PubSub.on("tempDrop", this.handleTempDrop, this);
      this.$build = $("#build");
      this.fieldset = this.$el.find("fieldset");
      this.renderForm = _.template(_renderForm);
      this.render();
    },
    events: {
        "click #saveBtn":   "saveForm",
        "click #viewBtn":   "viewForm",
        "click #cancelBtn": "cancelForm",
    },

    saveForm: function () {
        window.snippetCollection = new MyFormSnippetsCollection(this.collection.toJSON());
        console.dir(this.collection);
        $.ajax({
            type: "post",
            url: "/MedicalProfileTemplate/Edit",
            data: {
                jsonString: JSON.stringify(snippetCollection.toJSON())
            },
            success: function (data) {
                console.dir(data.status);
                alert("Mẫu hồ sơ lưu thành công" + data.status);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert("Có lỗi xảy ra: " + textStatus);
            },
        })
    },

    viewForm: function () {
        this.collection = window.snippetCollection;
        this.initialize();
        this.render();
    },

    cancelForm: function () {
        alert("hehe");
    }
    
    , render: function(){
      //Render Snippet Views
      this.fieldset.empty();
      var that = this;
      _.each(this.collection.renderAll(), function(snippet){
          that.fieldset.append(snippet);
      });
      
      $("#render").val(that.renderForm({
        text: _.map(this.collection.renderAllClean(), function(e){return e.html()}).join("\n")
      }));
      console.dir(this.fieldset);
      this.fieldset.appendTo("#build form");
      this.delegateEvents();
    }

    , getBottomAbove: function(eventY){
        var myFormBits = $(this.fieldset.find(".component"));
      var topelement = _.find(myFormBits, function(renderedSnippet) {
        if (($(renderedSnippet).position().top + $(renderedSnippet).height()) > eventY  - 90) {
          return true;
        }
        else {
          return false;
        }
      });
      if (topelement){
        return topelement;
      } else {
        return myFormBits[0];
      }
    }

    , handleSnippetDrag: function(mouseEvent, snippetModel) {
      $("body").append(new TempSnippetView({model: snippetModel}).render());
      this.collection.remove(snippetModel);
      PubSub.trigger("newTempPostRender", mouseEvent);
    }

    , handleTempMove: function(mouseEvent){
      $(".target").removeClass("target");
      if(mouseEvent.pageX >= this.$build.position().left &&
          mouseEvent.pageX < (this.$build.width() + this.$build.position().left) &&
          mouseEvent.pageY >= this.$build.position().top &&
          mouseEvent.pageY < (this.$build.height() + this.$build.position().top)){
        $(this.getBottomAbove(mouseEvent.pageY)).addClass("target");
      } else {
        $(".target").removeClass("target");
      }
    }

    , handleTempDrop: function(mouseEvent, model, index){
      if(mouseEvent.pageX >= this.$build.position().left &&
         mouseEvent.pageX < (this.$build.width() + this.$build.position().left) &&
         mouseEvent.pageY >= this.$build.position().top &&
         mouseEvent.pageY < (this.$build.height() + this.$build.position().top)) {
        var index = $(".target").index();
        $(".target").removeClass("target");
        this.collection.add(model,{at: index+1});
      } else {
        $(".target").removeClass("target");
      }
    }
  })
});
