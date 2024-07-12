import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class RegisterService {
  private readonly URL_API = 'https://pokeapi.co/api/v2';
  private readonly http = inject(HttpClient);
  constructor() {}
  post(data: any): Observable<any> {
    const url = this.URL_API + '/pokemon?limit=20&offset=0';
    const resolve = this.http.get<any>(url);
    return resolve;
  }
  get(data: any) {
    return data;
  }
}
