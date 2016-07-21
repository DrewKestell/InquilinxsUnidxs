var Renter = function (renter) {
    this.id = renter.ID;
    this.firstName = renter.FirstName;
    this.lastName = renter.LastName;

    this.detailLink = ko.computed(function () {
        return "/Renter/Detail?renterID=" + this.id;
    }, this);

    this.editLink = ko.computed(function () {
        return "/Renter/Edit?renterID=" + this.id;
    }, this);

};

var RenterIndex = function (index, container) {
    this.renters = ko.observableArray(_.map(index, function (renter) {
        return new Renter(renter);
    }));

    this.deleteRenter = function (renter) {
        console.log(this);
        console.log(renter);
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
    };

    ko.applyBindings(this, container);
};