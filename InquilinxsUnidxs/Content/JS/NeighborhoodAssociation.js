var NeighborhoodAssociation = function (neighborhoodAssociation) {
    this.id = neighborhoodAssociation.ID;
    this.name = ko.observable(neighborhoodAssociation.Name);
    this.contactFirstName = ko.observable(neighborhoodAssociation.ContactFirstName);
    this.contactLastName = ko.observable(neighborhoodAssociation.ContactLastName);
    this.contactTitle = ko.observable(neighborhoodAssociation.ContactTitle);
    this.contactPhoneNumber = ko.observable(neighborhoodAssociation.ContactPhoneNumber);

    this.entityValidationErrors = ko.observableArray();

    this.detailLink = ko.computed(function () {
        return "/NeighborhoodAssociation/Detail?neighborhoodAssociationID=" + this.id;
    }, this);

    this.editLink = ko.computed(function () {
        return "/NeighborhoodAssociation/Edit?neighborhoodAssociationID=" + this.id;
    }, this);

    var isNewNeighborhoodAssociation = !!document.getElementById("new-neighborhood-association-form");

    this.save = function () {
        var url;
        if (isNewNeighborhoodAssociation)
            url = "/NeighborhoodAssociation/Create";
        else
            url = "/NeighborhoodAssociation/Update";
        console.log($.toDictionary(ko.toJS(this)));
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

var NeighborhoodAssociationIndex = function (index) {
    this.neighborhoodAssociations = ko.observableArray(_.map(index, function (neighborhoodAssociation) {
        return new NeighborhoodAssociation(neighborhoodAssociation);
    }));

    this.deleteBuilding = function (neighborhoodAssociation) {
        if (confirm("Are you sure you wish to delete this Neighborhood Association?")) {
            $.ajax("/NeighborhoodAssociation/Delete", {
                method: "DELETE",
                context: this,
                data: { neighborhoodAssociationID: neighborhoodAssociation.id },
                dataType: "text",
                success: function () {
                    this.neighborhoodAssociations.remove(neighborhoodAssociation);
                },
                error: function () {
                    alert("An error occured while attempting to delete the resource.");
                }
            });
        }
    };
};