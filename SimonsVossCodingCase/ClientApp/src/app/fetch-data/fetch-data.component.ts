import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public result: string[] = [];
  public searchString: string = "";

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<string[]>(baseUrl + `api/search/${this.searchString}`).subscribe(result => {
      this.result = result;
    }, error => console.error(error));
  }
}
