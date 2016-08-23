var Building = function (building) {
    this.id = building.ID;
    this.latitude = building.Latitude;
    this.longitude = building.Longitude;
    this.fullAddress = building.FullAddress;
    this.landlordId = building.LandlordID;
    this.landlordName = building.LandlordName;
    this.neighborhoodId = building.NeighborhoodID;
    this.neighborhoodName = building.NeighborhoodName;
    this.residenceCount = building.ResidenceCount;
    this.renterCount = building.RenterCount;
};

var Map = function (presenter) {
    this.buildings = ko.observableArray();
    this.neighborhoodId = ko.observable();
    this.landlordId = ko.observable();
    this.filter = ko.observable();
    var map;
    var markers = [];

    this.allNeighborhoods = presenter.AllNeighborhoods;
    this.allLandlords = presenter.AllLandlords;

    // fucking javascript. this function is NASTY.
    this.populateBuildings = function (buildings) {
        var buildingsToUpdate = [];
        var buildingCounter = 0;
        var counter = 0;
        _.each(buildings, function (building) {
            if (building.Latitude === 0 && building.Longitude === 0) {
                buildingCounter++;
            }
        });
        buildings.forEach(function (building) {
            
            if (building.Latitude === 0 || building.Longitude === 0) {
                var address = building.FullAddress.replaceAll(' ', '+');
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
                this.populateBuildings(data.Buildings);
            },
            error: function (jqXHR) {
                alert("There was a problem applying filters.");
            }
        });
    };

    this.drawMap = function () {
        map = new google.maps.Map(document.getElementById('map'), {
            center: { lat: 44.9790629, lng: -93.268982 },
            zoom: 12
        });

         // can't get addGeoJson working, so we're doing it this way for now
        _.each(this.buildings(), function (building) {
            var location = { lat: building.latitude, lng: building.longitude };
            var marker = new google.maps.Marker({
                position: location,
                map: map,
                title: building.FullAddress,
                icon: "http://i.imgur.com/KrtIF7r.png" // host this somewhere else
            });
            var contentString =
            '<div class="info-window">' +
                '<div><label>Address:</label> <a href="/Building/Detail?buildingID=' + building.id + '">' + building.fullAddress + '</a></div>' +
                '<div><label>Landlord:</label> <a href="/Landlord/Detail?landlordID=' + building.landlordId + '">' + building.landlordName + '</a></div>' +
                '<div><label>Neighborhood:</label> <a href="/Neighborhood/Detail?neighborhoodID=' + building.neighborhoodId + '">' + building.neighborhoodName + '</a></div>' +
                '<div><label>Total Residences:</label>' + ' ' + building.residenceCount + '</div>' +
                '<div><label>Total Renters:</label>' + ' ' + building.renterCount + '</div>' +
            '</div>';
            var infoWindow = new google.maps.InfoWindow({
                content: contentString
            });
            marker.addListener('click', function () {
                infoWindow.open(map, marker);
            });
            markers.push(marker);
        });        
    };

    this.clearAllMarkers = function () {
        for (var i = 0; i < markers.length; i++) {
            markers[i].setMap(null);
        }
        markers = [];
    };

    this.applyFilters = function () {
        $.ajax('/Map/Show', {
            method: "GET",
            context: this,
            dataType: "json",
            data: {
                landlordID: this.landlordId(),
                neighborhoodID: this.neighborhoodId(),
                filter: this.filter()
            },
            success: function (data) {
                this.buildings([]);
                this.clearAllMarkers();
                this.populateBuildings(data.Buildings);
            },
            error: function (jqXHR) {
                alert("There was a problem updating the latitude/longitude of one or more buildings.");
            }
        });
    };

    this.populateBuildings(presenter.Buildings);
};