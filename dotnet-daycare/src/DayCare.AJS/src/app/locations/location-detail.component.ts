import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';

import { Location } from './shared/location.model';
import { LocationService } from './shared/location.service';

@Component({
  selector: 'toh-location-detail',
  templateUrl: 'location-detail.component.html',
  styleUrls: ['location-detail.component.css']
})
export class LocationDetailComponent implements OnInit {
  @Input() location: Location;
  @Output() close = new EventEmitter();
  error: any;
  navigated = false;

  constructor(
    private locationService: LocationService,
    private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.route.params.forEach((params: Params) => {
      if (params['id'] !== undefined) {
        let id = +params['id'];
        this.navigated = true;
        this.locationService.getLocation(id)
            .then(location => this.location = location);
      } else {
        this.navigated = false;
        this.location = new Location();
      }
    });
  }
}