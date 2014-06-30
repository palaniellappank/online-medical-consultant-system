require.config({
    shim: {
        'bootstrap': {
            exports: '$.fn.popover'
        }
    }
  , paths: {
      app: ".."
    , collections: "../collections"
    , data: "../data"
    , models: "../models"
    , helper: "../helper"
    , templates: "../templates"
    , views: "../views"
  }
});
require(['app/app-edit'], function (app) {
    app.initialize();
});
