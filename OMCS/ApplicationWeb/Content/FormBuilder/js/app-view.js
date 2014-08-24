define([
       "collections/my-form-view-mode"
       , "views/my-form-view-mode"
       , "views/modules/view-mode/treatment"
       , "views/modules/view-mode/film-document"
       , "views/modules/view-mode/allergy"
       , "views/modules/view-mode/immunization"
], function(
  SnippetsCollection
  , InputView
  , TreatmentView, FilmDocument, AllergyView, ImmunizationView
){
  return {
      initialize: function () {
        new InputView({
            collection: new SnippetsCollection(detailsInJson)
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
    }
  }
});
