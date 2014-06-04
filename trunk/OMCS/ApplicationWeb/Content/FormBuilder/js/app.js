define([
       "jquery" , "underscore" , "backbone"
       , "collections/snippets" , "collections/my-form-snippets"
       , "views/tab" , "views/my-form"
       , "text!data/input.json"
       , "text!data/region.json"
       , "text!templates/app/render.html", 
], function(
  $, _, Backbone
  , SnippetsCollection, MyFormSnippetsCollection
  , TabView, MyFormView
  , inputJSON, regionJSON, renderTab
){
  return {
    initialize: function(){
        
        //Bootstrap tabs from json.
        new TabView({
            title: "Phân vùng"
        , collection: new SnippetsCollection(JSON.parse(regionJSON))
        });
      new TabView({
        title: "Dữ liệu động"
        , collection: new SnippetsCollection(JSON.parse(inputJSON))
      });

      //Make the first tab active!
      $("#components .tab-pane").first().addClass("active");
      $("#formtabs li").first().addClass("active");

      $(document).scroll(function () {
          var scroll = $(this).scrollTop();
         // var topDist = $("#tab-editor").position();
          var topDist = 90;
          console.log(scroll);
          if (scroll < topDist) {
              $('#tab-editor').css({ "position": "static", "top": "auto" });
          } else {
              $('#tab-editor').css({"position":"fixed","top":"60px"});
          }
      });
      // Bootstrap "My Form" with 'Form Name' snippet.
      new MyFormView({
        title: "Original"
        , collection: new MyFormSnippetsCollection(formInJson)
      });
    }
  }
});
