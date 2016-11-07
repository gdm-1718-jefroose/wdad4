import { Injectable } from '@angular/core';
import { Headers, Http, Response } from '@angular/http';
import { Globals }  from '../../shared/globals';

import { LOCATIONS } from './mock-locations';
import { Location } from './location.model';

import 'rxjs/add/operator/toPromise';

@Injectable()
export class LocationService {
  
  constructor(private globals: Globals, private http: Http) { }

  private locationsUrl = this.globals.BASE_URL_API + 'locations?withChildren=false';

  getLocations() {
    return this.http
      .get(this.locationsUrl)
      .toPromise()
      .then(response => {
        return response.json() as Location[];
      })
      .catch(this.handleError);
  }

  getLocation(id: number): Promise<Location> {
    return this.getLocations()
      .then(locations => locations.find(location => location.id === id));
  }

  save(location: Location): Promise<Location> {
    if (location.id) {
      return this.put(location);
    }
    return this.post(location);
  }

  private post(location: Location): Promise<Location> {
    let headers = new Headers({
      'Content-Type': 'application/json'
    });

    return this.http
      .post(this.locationsUrl, JSON.stringify(location), { headers: headers })
      .toPromise()
      .then(res => res.json().data)
      .catch(this.handleError);
  }

  // Update existing Hero
  private put(location: Location): Promise<Location> {
    let headers = new Headers();
    headers.append('Content-Type', 'application/json');

    let url = `${this.locationsUrl}/${location.id}`;

    return this.http
      .put(url, JSON.stringify(location), { headers: headers })
      .toPromise()
      .then(() => location)
      .catch(this.handleError);
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error);
    return Promise.reject(error.message || error);
  }

}