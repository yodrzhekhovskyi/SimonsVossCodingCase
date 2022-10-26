import { Component } from '@angular/core';
import { SearchResult } from '../interfaces/search-result';
import { SearchService } from '../services/search.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
})
export class SearchComponent {
  public results: SearchResult[] = [];
  public searchString: string = '';
  public showWeights: boolean = true;
  public isLoading: boolean = false;
  private _searchService: SearchService;

  constructor(searchService: SearchService) {
    this._searchService = searchService;
  }

  public getSearchResults(): void {
    this.isLoading = true;
    this._searchService.getSearchResults(this.searchString).subscribe({
      next: (result) => {
        this.results = result;
      },
      error: (e) => console.error(e),
      complete: () => (this.isLoading = false),
    });
  }
}
