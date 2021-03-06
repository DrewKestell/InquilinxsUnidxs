﻿var ResidenceComment = function (residenceComment) {
    this.id = ko.observable(residenceComment.ID);
    this.value = ko.observable(residenceComment.Value);
    this.dateUpdated = ko.observable(residenceComment.DateUpdated);
    this.timeUpdated = ko.observable(residenceComment.TimeUpdated);
    this.createdBy = ko.observable(residenceComment.CreatedBy);
    this.lastUpdatedBy = ko.observable(residenceComment.LastUpdatedBy);

    this.commentInfo = ko.computed(function () {
        if (this.createdBy() && this.lastUpdatedBy() && this.dateUpdated() && this.timeUpdated())
            return 'Created by ' + this.createdBy() + '. Last Updated on ' + this.dateUpdated() + ' at ' + this.timeUpdated() + ' by ' + this.lastUpdatedBy();
        else
            return "";
    }, this);
};

var Residence = function (residence) {
    this.id = residence.ID;
    this.name = ko.observable(residence.Name);
    this.buildingId = ko.observable(residence.BuildingID);
    this.buildingAddress = residence.BuildingAddress;

    this.residenceComments = ko.observableArray(_.map(residence.ResidenceComments, function (comment) {
        return new ResidenceComment(comment);
    }));

    this.allBuildings = residence.AllBuildings;

    this.entityValidationErrors = ko.observableArray();

    this.detailLink = ko.computed(function () {
        return "/Residence/Detail?residenceID=" + this.id;
    }, this);

    this.editLink = ko.computed(function () {
        return "/Residence/Edit?residenceID=" + this.id;
    }, this);

    var isNewResidence = !!document.getElementById("new-residence-form");

    this.addResidenceComment = function () {
        this.residenceComments.push(new ResidenceComment({}));
    };

    this.removeResidenceComment = function (residenceComment) {
        this.residenceComments.remove(residenceComment);
    }.bind(this);

    this.save = function () {
        var url;
        if (isNewResidence)
            url = "/Residence/Create";
        else
            url = "/Residence/Update";

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

var ResidenceIndex = function (index) {
    this.residences = ko.observableArray(_.map(index, function (residence) {
        return new Residence(residence);
    }));

    this.deleteResidence = function (residence) {
        if (confirm("Are you sure you wish to delete this Residence?")) {
            $.ajax("/Residence/Delete", {
                method: "DELETE",
                context: this,
                data: { residenceID: residence.id },
                dataType: "text",
                success: function () {
                    this.residences.remove(residence);
                },
                error: function () {
                    alert("An error occured while attempting to delete the resource.");
                }
            });
        }
    };
};