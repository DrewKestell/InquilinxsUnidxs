var PropertyManagementCompanyComment = function (comment) {
    this.id = ko.observable(comment.ID);
    this.value = ko.observable(comment.Value);
};

var PropertyManagementCompany = function (company) {
    this.id = company.ID;
    this.name = ko.observable(company.Name);
    this.address = ko.observable(company.Address);
    this.city = ko.observable(company.City);
    this.stateAbbreviation = company.StateAbbreviation;
    this.stateId = ko.observable(company.StateID);
    this.zip = ko.observable(company.ZIP);

    this.comments = ko.observableArray(_.map(company.Comments, function (comment) {
        return new PropertyManagementCompanyComment(comment);
    }));

    this.allStates = company.AllStates;

    this.entityValidationErrors = ko.observableArray();

    this.detailLink = ko.computed(function () {
        return "/PropertyManagementCompany/Detail?propertyManagementCompanyID=" + this.id;
    }, this);

    this.editLink = ko.computed(function () {
        return "/PropertyManagementCompany/Edit?propertyManagementCompanyID=" + this.id;
    }, this);

    var isNew = !!document.getElementById("new-property-management-company-form");

    this.addComment = function () {
        this.comments.push(new PropertyManagementCompanyComment({}));
    };

    this.removeComment = function (comment) {
        this.comments.remove(comment);
    }.bind(this);

    this.save = function () {
        var url;
        if (isNew)
            url = "/PropertyManagementCompany/Create";
        else
            url = "/PropertyManagementCompany/Update";

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

var PropertyManagementCompanyIndex = function (index) {
    this.companies = ko.observableArray(_.map(index, function (company) {
        return new PropertyManagementCompany(company);
    }));

    this.deletePropertyManagementCompany = function (company) {
        if (confirm("Are you sure you wish to delete this Property Management Company?")) {
            $.ajax("/PropertyManagementCompany/Delete", {
                method: "DELETE",
                context: this,
                data: { propertyManagementCompanyID: company.id },
                dataType: "text",
                success: function () {
                    this.companies.remove(company);
                },
                error: function () {
                    alert("An error occured while attempting to delete the resource.");
                }
            });
        }
    };
};