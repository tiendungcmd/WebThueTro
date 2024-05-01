import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MotelService {
  baseUrl = 'https://localhost:7202/api/';
  constructor(private http: HttpClient) { }
  dangTin(request:any){
    return this.http.post<any>(this.baseUrl + 'motel', request);
  }
}
