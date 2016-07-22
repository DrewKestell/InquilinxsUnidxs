var Renter = function (renter) {
    this.id = renter.ID;
    this.firstName = renter.FirstName;
    this.lastName = renter.LastName;
    this.entityValidationErrors = ko.observableArray();

    this.detailLink = ko.computed(function () {
        return "/Renter/Detail?renterID=" + this.id;
    }, this);

    this.editLink = ko.computed(function () {
        return "/Renter/Edit?renterID=" + this.id;
    }, this);

    var isNewRenter = !!document.getElementById("new-renter-form");

    this.save = function () {
        var url;
        if (isNewRenter)
            url = "/Renter/Create";
        else
            url = "/Renter/Update";

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

var RenterIndex = function (index) {
    this.renters = ko.observableArray(_.map(index, function (renter) {
        return new Renter(renter);
    }));

    this.deleteRenter = function (renter) {
        if (confirm("Are you sure you wish to delete this Renter?")) {
            $.ajax("/Renter/Delete", {
                method: "DELETE",
                context: this,
                data: { renterID: renter.id },
                dataType: "text",
                success: function () {
                    this.renters.remove(renter);
                },
                error: function () {
                    alert("An error occured while attempting to delete the resource.");
                }
            });
        }        
    };
};