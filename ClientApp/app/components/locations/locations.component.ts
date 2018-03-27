import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'locations',
    templateUrl: './locations.component.html'
})
export class LocationsComponent {
    public locations: Location[];
    public selfInfoEmployers: SelfInfoEmployers[];
    public selfInfoLocations: SelfInfoLocations[];

    editMode = false;
    selectedLocation: Location;

    private http: Http;
    private baseUrl: string;

    //Passsing the Http dependency to the constructor to access Http functions
    constructor(http: Http, @Inject('BASE_URL') baseUrl: string)
    {
        this.http = http;
        this.baseUrl = baseUrl;

        http.get(baseUrl + 'api/Locations/').subscribe(result => {
            this.locations = result.json() as Location[];
        }, error => console.error(error));

        http.get(baseUrl + 'api/SelfInfo/').subscribe(result => {
            this.selfInfoEmployers = result.json() as SelfInfoEmployers[];
        }, error => console.error(error));

        http.get(baseUrl + 'api/SelfInfo/?id=Locations').subscribe(result => {
            this.selfInfoLocations = result.json() as SelfInfoLocations[];
        }, error => console.error(error));
    }

    getLocations() { }

    editLocation(location: Location) {
        this.editMode = true;
        this.selectedLocation = location;

        window.console.log('editMode: ' + this.editMode);
        window.console.log(location.locationID);
    }

    cancel() {
        //this.selectedLocation = null;
        this.editMode = false;
    }

    updateLocation(location: Location) {
        window.console.log(location.locationID);
        //return this.http.put(this.baseUrl + 'api/Locations/', JSON.stringify(location));
    }

    deleteLocation(location: Location) {
        //return this.http.delete(this.baseUrl + 'api/Locations/', JSON.stringify(location));
    }
}

interface Location {
    erpEmployerID: string;
    locationID: string;
    name: string;
    address1: string;
    address2: string;
    city: string;
    state: string;
    zip: string;
    country: string;
    active: boolean;
    adCountryCode: number;
    adCountryAbrv: string;
}

interface SelfInfoLocations {
    locationID: string;
}

interface SelfInfoEmployers {
    employerID: string;
}
