// Shared KO ViewModels
var EntityValidationErrors = function (entity) {
    this.entityName = entity.EntityName;
    this.fieldErrors = ko.observableArray();
    
    for (var field in entity.ValidationErrors) {
        this.fieldErrors.push(new FieldValidationErrors(field, entity.ValidationErrors[field]));
    };

    console.log(this.fieldErrors());
};

var FieldValidationErrors = function (fieldName, errors) {
    this.fieldName = fieldName;
    this.errors = errors;
};

// Prototype extensions
String.prototype.replaceAll = function (search, replace) {
    //if replace is not sent, return original string otherwise it will
    //replace search string with 'undefined'.
    if (replace === undefined) {
        return this.toString();
    }

    return this.replace(new RegExp('[' + search + ']', 'g'), replace);
};