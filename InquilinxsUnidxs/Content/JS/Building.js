var BuildingComment = function (buildingComment) {
    this.id = ko.observable(buildingComment.ID);
    this.value = ko.observable(buildingComment.Value);
    this.dateUpdated = ko.observable(buildingComment.DateUpdated);
    this.timeUpdated = ko.observable(buildingComment.TimeUpdated);
    this.createdBy = ko.observable(buildingComment.CreatedBy);
    this.lastUpdatedBy = ko.observable(buildingComment.LastUpdatedBy);
    
    this.commentInfo = ko.computed(function () {
        if (this.createdBy() && this.lastUpdatedBy() && this.dateUpdated() && this.timeUpdated())
            return 'Created by ' + this.createdBy() + '. Last Updated on ' + this.dateUpdated() + ' at ' + this.timeUpdated() + ' by ' + this.lastUpdatedBy();
        else
            return "";
    }, this);
};

var BuildingImage = function (buildingImage) {
    this.id = buildingImage.ID;
    this.SASURL = buildingImage.SASURL;
};

var Building = function (building) {
    this.id = building.ID;
    this.landlordId = ko.observable(building.LandlordID);
    this.neighborhoodId = ko.observable(building.NeighborhoodID);
    this.address = ko.observable(building.Address);
    this.city = ko.observable(building.City);
    this.stateAbbreviation = building.StateAbbreviation;
    this.stateId = ko.observable(building.StateID);
    this.zip = ko.observable(building.ZIP);

    this.buildingComments = ko.observableArray(_.map(building.BuildingComments, function (comment) {
        return new BuildingComment(comment);
    }));

    this.buildingImages = ko.observableArray(_.map(building.BuildingImages, function (image) {
        return new BuildingImage(image);
    }));

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

    this.addBuildingComment = function () {
        this.buildingComments.push(new BuildingComment({}));
    };

    this.removeBuildingComment = function (buildingComment) {
        this.buildingComments.remove(buildingComment);
    }.bind(this);

    this.addBuildingImage = function () {
        this.buildingImages.push(new BuildingImage({}));
    };

    this.removeBuildingImage = function (buildingImage) {
        this.buildingImages.remove(buildingImage);
    }.bind(this);

    this.uploadFile = function () {
        $modal = $('#myModal');
        var formData = new FormData();
        formData.append('file', $('#file')[0].files[0]);
        $.ajax("/Building/UploadFile", {
            method: "POST",
            contentType: false,
            processData: false,
            data: formData,
            success: function (data) {
                $modal.modal('hide');
            }
        });
    };

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