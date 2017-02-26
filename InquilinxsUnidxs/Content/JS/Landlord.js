var Landlord = function (landlord) {
    this.id = landlord.ID;
    this.firstName = ko.observable(landlord.FirstName);
    this.lastName = ko.observable(landlord.LastName);
    this.propertyManagementCompanyId = ko.observable(landlord.PropertyManagementCompanyID);
    this.address = ko.observable(landlord.Address);
    this.city = ko.observable(landlord.City);
    this.stateAbbreviation = landlord.StateAbbreviation;
    this.stateId = ko.observable(landlord.StateID);
    this.zip = ko.observable(landlord.ZIP);
    this.allStates = landlord.AllStates;
    this.allPropertyManagementCompanies = landlord.AllPropertyManagementCompanies;

    this.entityValidationErrors = ko.observableArray();

    this.detailLink = ko.computed(function () {
        return "/Landlord/Detail?landlordID=" + this.id;
    }, this);

    this.editLink = ko.computed(function () {
        return "/Landlord/Edit?landlordID=" + this.id;
    }, this);

    var isNewLandlord = !!document.getElementById("new-landlord-form");

    this.save = function () {
        var url;
        if (isNewLandlord)
            url = "/Landlord/Create";
        else
            url = "/Landlord/Update";

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

var LandlordIndex = function (index) {
    this.landlords = ko.observableArray(_.map(index, function (landlord) {
        return new Landlord(landlord);
    }));

    this.deleteLandlord = function (landlord) {
        if (confirm("Are you sure you wish to delete this Landlord?")) {
            $.ajax("/Landlord/Delete", {
                method: "DELETE",
                context: this,
                data: { landlordID: landlord.id },
                dataType: "text",
                success: function () {
                    this.landlords.remove(landlord);
                },
                error: function () {
                    alert("An error occured while attempting to delete the resource.");
                }
            });
        }
    };
};