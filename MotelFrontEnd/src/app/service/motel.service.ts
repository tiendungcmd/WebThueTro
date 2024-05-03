import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MotelService {
  baseUrl = 'https://localhost:7202/api/';
  constructor(private http: HttpClient) { }
  dangTin(request:any){
    const formData = new FormData();
    formData.append("username", request.name);
    formData.append("password", request.password);
    formData.append("iamges", request.iamges);

    return this.http.post<any>(this.baseUrl + 'motel', formData);
  }
}
