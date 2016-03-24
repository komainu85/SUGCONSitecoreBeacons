define(
  ["sitecore",
    "/-/speak/v1/experienceprofile/DataProviderHelper.js",
    "/-/speak/v1/experienceprofile/CintelUtl.js"
  ],
  function (sc, providerHelper, cintelUtil, ExternalDataApiVersion) {
      var cidParam = "cid";
      var intelPath = "/intel";

      var app = sc.Definitions.App.extend({
          initialized: function () {
              $('.sc-progressindicator').first().show().hide();
              var contactId = cintelUtil.getQueryParam(cidParam);
              var tableName = "";
              var baseUrl = "/sitecore/api/ao/v1/contacts/" + contactId + intelPath +"/visitedanimals";

              providerHelper.initProvider(this.VisitedAnimalsDataProvider,
                tableName,
                baseUrl,
                this.ExternalDataTabMessageBar);

              providerHelper.getData(this.VisitedAnimalsDataProvider,
                $.proxy(function (jsonData) {
                    var dataSetProperty = "Data";
                    if (jsonData.data.dataSet != null && jsonData.data.dataSet.visitedanimals.length > 0) {
                        var dataSet = jsonData.data.dataSet.visitedanimals;
                        this.VisitedAnimalsDataProvider.set(dataSetProperty, jsonData);
                        this.VistedAnimalsList.viewModel.items(dataSet);
                    } else {
                        this.AnimalIdLabel.set("isVisible", false);
                        this.ExternalDataTabMessageBar.addMessage("notification", this.NoAnimalData.get("text"));
                    }
                }, this));
          }
      });
      return app;
  });