var Building = function (building) {
    this.id = building.ID;
    this.landlordId = ko.observable(building.LandlordID);
    this.neighborhoodId = ko.observable(building.NeighborhoodID);
    this.address = ko.observable(building.Address);
    this.city = ko.observable(building.City);
    this.stateAbbreviation = building.StateAbbreviation;
    this.stateId = ko.observable(building.StateID);
    this.zip = ko.observable(building.ZIP);

    this.allStates = building.AllStates;
    this.allLandlords = building.AllLandlords;
    this.allNeighborhoods = building.AllNeighborhoods;

    this.entityValidationErrors = ko.observableArray();

    this.detailLink = ko.computed(function () {
        return "/Building/Detail?buildingID=" + this.id;
    }, this);

    this.editLink = ko.computed(function () {
        return "/Building/Edit?buildingID=" + this.id;
    }, this);

    var isNewBuilding = !!document.getElementById("new-building-form");

    this.save = function () {
        var url;
        if (isNewBuilding)
            url = "/Building/Create";
        else
            url = "/Building/Update";

        $.ajax(url, {
            method: "POST",
            context: this,
            data: $.toDictionary(ko.toJS(this)),
            dataType: "json",
            success: function (data) {
                window.location.replace(data);
            },
            error: function (jqXHR) {
                this.entityValidationErrors(_.map(jqXHR.responseJSON.Entities, function (entity) {
                    return new EntityValidationErrors(entity);
                }));
            }
        });
    };

};

var BuildingIndex = function (index) {
    this.buildings = ko.observableArray(_.map(index, function (building) {
        return new Building(building);
    }));

    this.deleteBuilding = function (building) {
        if (confirm("Are you sure you wish to delete this Building?")) {
            $.ajax("/Building/Delete", {
                method: "DELETE",
                context: this,
                data: { buildingID: building.id },
                dataType: "text",
                success: function () {
                    this.buildings.remove(building);
                },
                error: function () {
                    alert("An error occured while attempting to delete the resource.");
                }
            });
        }
    };
};