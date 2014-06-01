define([
       "jquery", "underscore", "backbone"
       , "models/snippet"
       , "views/snippet", "views/temp-snippet"
       , "helper/pubsub"
], function(
  $, _, Backbone
  , SnippetModel
  , SnippetView, TempSnippetView
  , PubSub
){
  return SnippetView.extend({
    className: "" 
  });
});
