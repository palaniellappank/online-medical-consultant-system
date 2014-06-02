define([
      'jquery', 'underscore', 'backbone'
], function($, _, Backbone) {
  return Backbone.Model.extend({
      getValues: function () {
          //result = []
          //_.each(this.get("fields"), function (elem) {
          //    console.log(elem);
          //    var o;
          //    if (elem["name"] != "id") {
          //        if (elem["type"] == "select") {
          //            o[k] = _.find(elem["value"], function (o) { return o.selected })["value"];
          //          } else {
          //            o[k] = elem["value"];
          //          }
          //          return o;
          //      }
          //      result.push(o);
          //});
          //return result;
          return _.reduce(this.get("fields"), function (o, v, k) {
              console.log(o, v, k);
        //    if (v["name"] != "id") {
                if (v["type"] == "select") {
                    o[k] = _.find(v["value"], function (o) { return o.selected })["value"];
                } else {
                    o[k] = v["value"];
                }
        //    }
            return o;
          }, {});
          
    }
    , idFriendlyTitle: function(){
      return this.get("title").replace(/\W/g,'').toLowerCase();
    }
    , setField: function(name, value) {
      var fields = this.get("fields")
      fields[name]["value"] = value;
      this.set("fields", fields);
    }
  });
});
