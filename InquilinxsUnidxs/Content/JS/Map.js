var Building = function (building) {
    this.id = building.ID;
    this.address = building.Address;
    this.latitude = building.Latitude;
    this.longitude = building.Longitude;
};

var Map = function (presenter) {
    this.buildings = ko.observableArray();

    // fucking javascript. this function is NASTY.
    this.populateBuildings = function () {
        var buildingsToUpdate = [];
        var buildingCounter = 0;
        var counter = 0;
        _.each(presenter.Buildings, function (building) {
            if (building.Latitude === 0 && building.Longitude === 0) {
                buildingCounter++;
            }
        });
        presenter.Buildings.forEach(function (building) {
            
            if (building.Latitude === 0 || building.Longitude === 0) {
                var address = building.Address.replaceAll(' ', '+');
                var url = 'https://maps.googleapis.com/maps/api/geocode/json?address=' + address + '&key=AIzaSyDZR2L4X7wU8GVxaVfNlPnE47pj39cVAbc';               
                var lat;
                var lng;
                $.ajax(url, {
                    method: "GET",
                    context: this,
                    dataType: "json",
                    success: function (data) {
                        counter++;                        
                        lat = data.results[0].geometry.location.lat;
                        lng = data.results[0].geometry.location.lng;
                        buildingsToUpdate.push({ ID: building.ID, Latitude: lat, Longitude: lng });
                        this.buildings().push(new Building({ ID: building.ID, Latitude: lat, Longitude: lng }));                       
                    },
                    error: function (jqXHR) {                        
                        alert("There was a problem with the Google Geocoding API.");
                    },
                    complete: function () {
                        if (counter === buildingCounter && buildingsToUpdate.length > 0) {
                            this.updateGeolocation(buildingsToUpdate);                            
                        };
                    }
                });                
                
            } else {
                this.buildings().push(new Building(building));
            }
        }.bind(this));
        if (buildingCounter === 0) {
            this.drawMap();
        }
    };

    this.updateGeolocation = function (buildingsToUpdate) {
        $.ajax('/Map/UpdateGeolocation', {
            method: "POST",
            context: this,
            data: $.toDictionary(buildingsToUpdate),
            dataType: "text",
            success: function (data) {
                this.drawMap();
            },
            error: function (jqXHR) {
                alert("There was a problem updating the latitude/longitude of one or more buildings.");
            }
        });
    };

    this.drawMap = function () {
        var map = new google.maps.Map(document.getElementById('map'), {
            center: { lat: 45.0094029, lng: -93.2943323 },
            zoom: 11
        });

         // can't get addGeoJson working, so we're doing it this way for now
        _.each(this.buildings(), function (building) {
            var location = { lat: building.latitude, lng: building.longitude };
            var marker = new google.maps.Marker({
                position: location,
                map: map,
                title: building.Address
            });
        });
        
    };

    this.populateBuildings();
};