define([
       "collections/my-form-input-mode"
       , "views/my-form-input-mode", "views/my-form"
       , "views/modules/treatment"
       , "views/modules/film-document"
       , "views/modules/allergy"
       , "views/modules/immunization"
       , "text!data/input.json",
], function(
  SnippetsCollection
  , InputView, MyFormView
  , TreatmentView, FilmDocument, AllergyView, ImmunizationView
  , inputJSON
){
  return {
      initialize: function () {
        new InputView({
            collection: new SnippetsCollection(formInJson)
        });

          //Detect module TreatmentHistory
        if ($(".TreatmentHistory").length != 0) {
            $(".TreatmentHistory").parent().attr("id", "TreatmentHistory");
            new TreatmentView({
                el: "#TreatmentHistory"
            });
        };

        if ($(".FilmDocument").length != 0) {
            $(".FilmDocument").parent().attr("id", "FilmDocument");
            new FilmDocument({
                el: "#FilmDocument"
            });
        };

        if ($(".AllergyRegion").length != 0) {
            $(".AllergyRegion").parent().attr("id", "AllergyRegion");
            new AllergyView({
                el: "#AllergyRegion"
            });
        };

        if ($(".ImmunizationRegion").length != 0) {
            $(".ImmunizationRegion").parent().attr("id", "ImmunizationRegion");
            new ImmunizationView({
                el: "#ImmunizationRegion"
            });
        };

        $("#saveBtn").click(function (e) {
            $("form#target").validate({
                submitHandler: function () {
                    $.ajax({
                        type: "POST",
                        url: $("form#target").attr("action"),
                        data: $("form#target").serialize(),
                        success: function () {
                            bootbox.alert("Cập nhật thành công!");
                        },
                        error: function (jqXHR, textStatus, errorThrown) {
                            bootbox.alert("Có lỗi xảy ra: " + textStatus);
                        }
                    });
                    return false;
                }
            });
            
        });
        $(".datepicker").datepicker({ dateFormat: 'dd/mm/yy' });
    }
  }
});
