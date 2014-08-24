define(function(require) {
  var formname               = require('text!templates/snippet/view-mode/formname.html')
  , textinput                = require('text!templates/snippet/view-mode/textinput.html')
  , multiplecheckboxes       = require('text!templates/snippet/view-mode/multiplecheckboxes.html')
  , multiplecheckboxesinline = require('text!templates/snippet/view-mode/multiplecheckboxesinline.html')
  , multipleradios           = require('text!templates/snippet/view-mode/multipleradios.html')
  , multipleradiosinline     = require('text!templates/snippet/view-mode/multipleradiosinline.html')
  , selectbasic              = require('text!templates/snippet/view-mode/selectbasic.html')
  , selectmultiple           = require('text!templates/snippet/view-mode/selectmultiple.html')
  , textarea                 = require('text!templates/snippet/view-mode/textarea.html')
  , statictext = require('text!templates/snippet/view-mode/static-text.html')
  , datepicker = require('text!templates/snippet/view-mode/datepicker.html')
  , statictextcopy = require('text!templates/snippet/view-mode/static-text-copy.html')
  , table = require('text!templates/snippet/table.html');
  return {
    formname                   : formname
    , textinput                : textinput
    , multiplecheckboxes       : multiplecheckboxes
    , multiplecheckboxesinline : multiplecheckboxesinline
    , multipleradios           : multipleradios
    , multipleradiosinline     : multipleradiosinline
    , selectbasic              : selectbasic
    , selectmultiple           : selectmultiple
    , textarea                 : textarea
    , statictext: statictext
    , datepicker: datepicker
    , statictextcopy: statictextcopy
    , table: table
  }
});
