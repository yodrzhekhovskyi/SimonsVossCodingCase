import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SearchResult } from '../interfaces/search-result';

@Injectable({
  providedIn: 'root'
})
export class SearchService {
  private _http: HttpClient;
  private _baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._http = http;
    this._baseUrl = baseUrl;
  }

  getSearchResults(searchString: string): Observable<SearchResult[]>{
    return this._http.get<SearchResult[]>(this._baseUrl + `api/search/${searchString}`);
  }
}
