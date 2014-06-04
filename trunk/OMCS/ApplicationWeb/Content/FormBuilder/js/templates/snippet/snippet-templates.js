define(function(require) {
  var formname               = require('text!templates/snippet/formname.html')
  , textinput                = require('text!templates/snippet/textinput.html')
  , appendedcheckbox         = require('text!templates/snippet/appendedcheckbox.html')
  , appendedtext             = require('text!templates/snippet/appendedtext.html')
  , filebutton               = require('text!templates/snippet/filebutton.html')
  , button                   = require('text!templates/snippet/button.html')
  , buttondouble             = require('text!templates/snippet/buttondouble.html')
  , buttondropdown           = require('text!templates/snippet/buttondropdown.html')
  , multiplecheckboxes       = require('text!templates/snippet/multiplecheckboxes.html')
  , multiplecheckboxesinline = require('text!templates/snippet/multiplecheckboxesinline.html')
  , multipleradios           = require('text!templates/snippet/multipleradios.html')
  , multipleradiosinline     = require('text!templates/snippet/multipleradiosinline.html')
  , prependedcheckbox        = require('text!templates/snippet/prependedcheckbox.html')
  , selectbasic              = require('text!templates/snippet/selectbasic.html')
  , selectmultiple           = require('text!templates/snippet/selectmultiple.html')
  , textarea                 = require('text!templates/snippet/textarea.html')
  , textinput                = require('text!templates/snippet/textinput.html')
  , commonsnippettab = require('text!templates/snippet/common-snippet-tab.html')
  , datepicker = require('text!templates/snippet/datepicker.html');

  return {
    formname                   : formname
    , textinput                : textinput
    , appendedcheckbox         : appendedcheckbox
    , appendedtext             : appendedtext
    , filebutton               : filebutton
    , singlebutton             : button
    , doublebutton             : buttondouble
    , buttondropdown           : buttondropdown
    , multiplecheckboxes       : multiplecheckboxes
    , multiplecheckboxesinline : multiplecheckboxesinline
    , multipleradios           : multipleradios
    , multipleradiosinline     : multipleradiosinline
    , prependedcheckbox        : prependedcheckbox
    , selectbasic              : selectbasic
    , selectmultiple           : selectmultiple
    , textarea                 : textarea
    , textinput                : textinput
    , commonsnippettab: commonsnippettab
    , datepicker: datepicker
  }
});
