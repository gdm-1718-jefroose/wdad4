import { Component, OnInit } from '@angular/core';
import { Location } from './shared/location.model';
import { LocationService }  from './shared/location.service';

@Component({
  selector: 'toh-locations',
  templateUrl: './locations.component.html',
  styleUrls: ['./locations.component.css']
})
export class LocationsComponent implements OnInit {
  locations: Location[] = [];
  constructor(private locationService: LocationService) {}
  ngOnInit() {
    this.locationService.getLocations()
      .then(locations => {
        this.locations = locations;
      });
  }
}
