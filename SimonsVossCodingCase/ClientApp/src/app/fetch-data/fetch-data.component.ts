import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html',
})
export class FetchDataComponent {
  public results: SearchResult[] = [];
  public searchString: string = 'Head Office';
  private _http: HttpClient;
  private _baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._http = http;
    this._baseUrl = baseUrl;
  }

  public getSearchResults(): void {
    this._http
      .get<SearchResult[]>(this._baseUrl + `api/search/${this.searchString}`)
      .subscribe({
        next: (result) => {
          this.results = result;
        },
        error: (e) => console.error(e),
        complete: () => console.info('completed'),
      });
  }
}

interface SearchResult {
  id: string;
  name: string;
  description: string;
  weight: number;
  type: string;
}
