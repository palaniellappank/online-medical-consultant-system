define(function(require) {
  var formname               = require('text!templates/snippet/edit-mode/formname.html')
  , textinput                = require('text!templates/snippet/edit-mode/textinput.html')
  , multiplecheckboxes       = require('text!templates/snippet/edit-mode/multiplecheckboxes.html')
  , multiplecheckboxesinline = require('text!templates/snippet/edit-mode/multiplecheckboxesinline.html')
  , multipleradios           = require('text!templates/snippet/edit-mode/multipleradios.html')
  , multipleradiosinline     = require('text!templates/snippet/edit-mode/multipleradiosinline.html')
  , selectbasic              = require('text!templates/snippet/edit-mode/selectbasic.html')
  , selectmultiple           = require('text!templates/snippet/edit-mode/selectmultiple.html')
  , textarea                 = require('text!templates/snippet/edit-mode/textarea.html')
  , statictext = require('text!templates/snippet/edit-mode/static-text.html')
  , datepicker = require('text!templates/snippet/edit-mode/datepicker.html')
  , statictextcopy = require('text!templates/snippet/edit-mode/static-text-copy.html')
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
