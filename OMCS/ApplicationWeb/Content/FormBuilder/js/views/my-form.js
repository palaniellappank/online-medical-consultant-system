define([
      "collections/my-form-snippets"
      , "views/temp-snippet"
      , "helper/pubsub"
      , "text!templates/app/renderform.html"
      , "text!templates/app/changenotice.html"
], function(
  MyFormSnippetsCollection
  , TempSnippetView
  , PubSub
  , _renderForm
  , _changeNotice
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
        "click #viewBtn":   "viewForm"
    },

    saveForm: function () {
        window.snippetCollection = new MyFormSnippetsCollection(this.collection.toJSON());
        $.ajax({
            type: "post",
            url: "/AdminTemplate/CheckTemplateChanged",
            data: {
                jsonString: JSON.stringify(snippetCollection.toJSON()),
                MedicalProfileTemplateId: medicalProfileTemplateId
            },
            success: function (data) {
                var template = _.template(_changeNotice, {result : JSON.parse(data)});
                $("#change-notice").html(template);
                $("#modal-change-notice").modal("show");
                $("#save-confirm").click(function (e) {
                    $("#modal-change-notice").modal("hide");
                    $.ajax({
                        type: "post",
                        url: "/AdminTemplate/SaveTemplate",
                        data: {
                            jsonString: JSON.stringify(snippetCollection.toJSON()),
                            MedicalProfileTemplateId: medicalProfileTemplateId
                        },
                        success: function (data) {
                            bootbox.alert("Mẫu hồ sơ đã được cập nhật thành công");
                        },
                        error: function (jqXHR, textStatus, errorThrown) {
                            bootbox.alert("Có lỗi xảy ra: " + textStatus);
                        }
                    });
                });
            },
            error: function (jqXHR, textStatus, errorThrown) {
                bootbox.alert("Có lỗi xảy ra: " + textStatus);
            }
        })
    },

    viewForm: function () {
        console.log(this.collection.toJSON());

        console.log(new MyFormSnippetsCollection(this.collection.toJSON()));
    }
    
    , render: function(){
      //Render Snippet Views
      this.fieldset.empty();
      var that = this;
      _.each(this.collection.renderAll(), function(snippet){
          that.fieldset.append(snippet);
      });
      
      this.fieldset.appendTo("#build form");
      this.delegateEvents();
    }

    , getBottomAbove: function(eventX, eventY){
        var myFormBits = $(this.fieldset.find(".component,.component-holder"));
        var prevComponentName = null;
        var topelement = _.find(myFormBits, function(renderedSnippet) {
          //Ignore element that inside component-holder
          if ($(renderedSnippet).parent().attr("class") &&
            $(renderedSnippet).parent().attr("class").indexOf("component-holder") != -1)
            return false;
          var className = $(renderedSnippet).attr("class");
          var top = $(renderedSnippet).position().top;
          var left = $(renderedSnippet).position().left;
          var height = $(renderedSnippet).height();
          var width = $(renderedSnippet).width();
          if (className == "component-holder") {     
            if (((top < eventY) && (top + height > eventY))
              && ((left < eventX) && (left + width > eventX))) {
              return true;
            } else {
              return false;
            }
          }
          if ($(renderedSnippet).attr("data-title") == "Xây dựng bảng") {
            return false;
          }
          //90 is the height of target
          if (top + height > eventY - 90) {
            return true;
          }
          return false;
        });
        if (topelement){
          return topelement;
        } else {
          if (myFormBits[0] == undefined) {
            //This is the first component to add
            this.$el.find("fieldset").append("<div class='target'></div>");
          }
          return myFormBits[0];
        }
    }

    , handleSnippetDrag: function(mouseEvent, snippetModel) {
      this.tempSnippet = new TempSnippetView({model: snippetModel});
      $("body").append(this.tempSnippet.render(false));
      if (snippetModel.get("parentId") == undefined) {
        var index = _.indexOf(this.collection.models, snippetModel);
        this.collection.each(function(child) {
          if (child.get("parentId") > index) {
            child.set("parentId", child.get("parentId") - 1);
          };
        });
      }
      this.collection.remove(snippetModel);
      PubSub.trigger("newTempPostRender", mouseEvent);
    }

    , handleTempMove: function(mouseEvent){
      $(".target").removeClass("target");
      //Minus for relative position of md-col-9
      var pageX = mouseEvent.pageX - 70;
      var pageY = mouseEvent.pageY - 78;
      if(pageX >= this.$build.position().left &&
          pageX < (this.$build.width() + this.$build.position().left) &&
          pageY >= this.$build.position().top &&
          pageY < (this.$build.height() + this.$build.position().top)){
        var element = $(this.getBottomAbove(pageX, pageY));
        //Update content of dragging element
  /*      if (element.parents("[data-title='Xây dựng bảng']").length != 0) {
          var temp = $("#temp").html();
          $("#temp").html("Put");
          $("#temp").toggleClass("col-md-6");
          $("#temp").attr("data-temp", temp);
        } else {
          $("#temp").toggleClass("col-md-6");
          $("#temp").html($("#temp").attr("data-temp"));
          $("#temp").attr("data-temp", undefined);
        }*/
        //If it drag into component-holder, replace the content
        if (element.attr("class") && 
          element.attr("class").indexOf("component-holder") != -1 &&
          !element.attr("data-temp")) {
            
            element.attr("data-temp", element.html());
            element.html("");
        } else {
          $(".component-holder[data-temp]").each(function(index, component) {
            $(component).html($(component).attr("data-temp"));
            $(component).removeAttr("data-temp");
          });
        }
        element.addClass("target");
      } else {
        $(".target").removeClass("target");
      }
    }

    , handleTempDrop: function(mouseEvent, model){
      if(mouseEvent.pageX >= this.$build.position().left &&
         mouseEvent.pageX < (this.$build.width() + this.$build.position().left) &&
         mouseEvent.pageY >= this.$build.position().top &&
         mouseEvent.pageY < (this.$build.height() + this.$build.position().top)) {
         if ($(".target").attr("class").indexOf("component-holder") != -1) {
            var position = $(".target").attr("data-position");
            var parent = $(".target").parents(".component");
            var parentModel = this.collection.at(parent.index());
            model.set("parentId", parent.index());
            model.set("positionInTable", position);
            if (model.get("fields")["label"] != undefined) {
              model.setField("label", "");
            }
            if (model.get("fields")["name"] != undefined) {
              model.setField("name", "");
            }
            this.collection.add(model);
         } else {
            var index = $(".target").index();
            model.unset("parentId");
            model.unset("positionInTable");
            $(".target").removeClass("target");
            //Should increase parent_id to avoid affect
            this.collection.each(function(child) {
                if (child.get("parentId") > index) {
                  child.set("parentId", child.get("parentId") + 1);
                };
            });
            this.collection.add(model,{at: index+1});
         }
      } else {
        $(".target").removeClass("target");
      }
    }
  })
});
