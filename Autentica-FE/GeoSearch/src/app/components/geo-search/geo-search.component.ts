import { Component } from '@angular/core';
import * as Leaflet from 'leaflet';
import { Place } from 'src/app/models/place.model';
import { GeoSearchService } from 'src/app/services/geo-search.service';

@Component({
  selector: 'app-geo-search',
  templateUrl: './geo-search.component.html',
  styleUrls: ['./geo-search.component.css']
})
export class GeoSearchComponent {
  title = 'angular-leaflet-maps';
  map!: Leaflet.Map;
  markers: Leaflet.Marker[] = [];
  options = {
    layers: [
      Leaflet.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a>'
      })
    ],
    zoom: 8,
    center: { lat: 57, lng: 25 }
  };
  searchQuery: string = '';
  searchResults: any[] = [];

  constructor(private geoSearchService: GeoSearchService) { }

  public searchPlaces() {
    if (this.searchQuery.trim() !== '') {
      this.geoSearchService.searchPlaceByName(this.searchQuery).subscribe(
        (response) => {
          this.searchResults = response;
        },
        (error) => {
          console.log('Error retrieving search results:', error);
        }
      );
    } else {
      this.searchResults = [];
    }
  }

  selectPlace(place: Place) {
    const marker = this.generateMarker(place, place.name);
    this.addMarker(marker);
  }

  getExtremeCoordinates() {
    this.geoSearchService.getExtremeWest().subscribe(
      (westResponse) => {
        const westMarker = this.generateMarker(westResponse, 'West');
        this.addMarker(westMarker);
      },
      (error) => {
        console.log('Error retrieving extreme west coordinate:', error);
      }
    );

    this.geoSearchService.getExtremeEast().subscribe(
      (eastResponse) => {
        const eastMarker = this.generateMarker(eastResponse, 'East');
        this.addMarker(eastMarker);
      },
      (error) => {
        console.log('Error retrieving extreme east coordinate:', error);
      }
    );

    this.geoSearchService.getExtremeNorth().subscribe(
      (northResponse) => {
        const northMarker = this.generateMarker(northResponse, 'North');
        this.addMarker(northMarker);
      },
      (error) => {
        console.log('Error retrieving extreme north coordinate:', error);
      }
    );

    this.geoSearchService.getExtremeSouth().subscribe(
      (southResponse) => {
        const southMarker = this.generateMarker(southResponse, 'South');
        this.addMarker(southMarker);
      },
      (error) => {
        console.log('Error retrieving extreme south coordinate:', error);
      }
    );
  }

  public removeAllCoordinates(): void {
    this.markers.forEach(marker => {
      marker.removeFrom(this.map);
    });
    this.markers = [];
  }

  public generateMarker(response: Place, label: string) {
    const position = { lat: +response.ddn, lng: +response.dde };
    const marker = Leaflet.marker(position, { draggable: true })
      .bindPopup(`<b>${label}:</b><br>${position.lat}, ${position.lng}`);

    return marker;
  }

  public addMarker(marker: Leaflet.Marker) {
    marker.addTo(this.map);
    this.markers.push(marker);
  }

  public onMapReady($event: Leaflet.Map) {
    this.map = $event;
  }

  public mapClicked($event: any) {
    console.log($event.latlng.lat, $event.latlng.lng);
  }

  public markerClicked($event: any, label: string) {
    console.log(`Marker clicked (${label}): ${$event.latlng.lat}, ${$event.latlng.lng}`);
  }

  public markerDragEnd($event: any, label: string) {
    console.log(`Marker dragged (${label}): ${$event.target.getLatLng()}`);
  }
}
