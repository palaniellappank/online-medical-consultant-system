define([
       "collections/snippets" , "collections/my-form-snippets"
       , "views/tab" , "views/my-form"
       , "text!data/input.json"
       , "text!data/region.json"
       , "text!data/data.json"
       , "text!templates/app/render.html", 
], function(
  SnippetsCollection, MyFormSnippetsCollection
  , TabView, MyFormView
  , inputJSON, regionJSON, dataJSON, renderTab
){
  return {
    initialize: function(){
        
        //Bootstrap tabs from json.
        new TabView({
            title: "Phân vùng"
        , collection: new SnippetsCollection(JSON.parse(regionJSON))
        });
      new TabView({
        title: "Tùy chỉnh"
        , collection: new SnippetsCollection(JSON.parse(inputJSON))
      });

      new TabView({
          title: "Có sẵn"
      , collection: new SnippetsCollection(JSON.parse(dataJSON))
      });

      //Make the first tab active!
      $("#components .tab-pane").first().addClass("active");
      $("#formtabs li").first().addClass("active");

      $(document).scroll(function () {
          var scroll = $(this).scrollTop();
          var topDist = 90;
          if (window.widthDefault == undefined) {
              window.widthDefault = $('#tab-editor').css("width");
          }
          if (scroll < topDist) {
              $('#tab-editor').css({ "position": "static", "top": "auto" });
          } else {
              $('#tab-editor').css("width", window.widthDefault);
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
