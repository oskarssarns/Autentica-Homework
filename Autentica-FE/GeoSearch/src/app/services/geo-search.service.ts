import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Place } from '../models/place.model';
import { environment } from '../../environment/environment';

@Injectable({
  providedIn: 'root'
})
export class GeoSearchService {
  constructor(private http: HttpClient) { }

  getExtremeNorth(): Observable<Place> {
    return this.http.get<Place>(`${environment.baseUrl}/ExtremeNorth`);
  }

  getExtremeSouth(): Observable<Place> {
    return this.http.get<Place>(`${environment.baseUrl}/ExtremeSouth`);
  }

  getExtremeWest(): Observable<Place> {
    return this.http.get<Place>(`${environment.baseUrl}/ExtremeWest`);
  }

  getExtremeEast(): Observable<Place> {
    return this.http.get<Place>(`${environment.baseUrl}/ExtremeEast`);
  }

  searchPlaceByName(searchQuery: string): Observable<Place[]> {
    return this.http.get<Place[]>(`${environment.baseUrl}/SearchPlace?searchQuery=${searchQuery}`);
  }
}
