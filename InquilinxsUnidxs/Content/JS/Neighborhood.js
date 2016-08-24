var Neighborhood = function (neighborhood) {
    this.id = neighborhood.ID;
    this.name = ko.observable(neighborhood.Name);

    this.entityValidationErrors = ko.observableArray();

    this.detailLink = ko.computed(function () {
        return "/Neighborhood/Detail?neighborhoodID=" + this.id;
    }, this);

    this.editLink = ko.computed(function () {
        return "/Neighborhood/Edit?neighborhoodID=" + this.id;
    }, this);

    var isNewNeighborhood = !!document.getElementById("new-neighborhood-form");

    this.save = function () {
        var url;
        if (isNewNeighborhood)
            url = "/Neighborhood/Create";
        else
            url = "/Neighborhood/Update";

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

var NeighborhoodIndex = function (index) {
    this.neighborhoods = ko.observableArray(_.map(index, function (neighborhood) {
        return new Neighborhood(neighborhood);
    }));

    this.deleteNeighborhood = function (neighborhood) {
        if (confirm("Are you sure you wish to delete this Neighborhood?")) {
            $.ajax("/Neighborhood/Delete", {
                method: "DELETE",
                context: this,
                data: { neighborhoodID: neighborhood.id },
                dataType: "text",
                success: function () {
                    this.neighborhoods.remove(neighborhood);
                },
                error: function () {
                    alert("An error occured while attempting to delete the resource.");
                }
            });
        }
    };
};