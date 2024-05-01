import { Injectable } from '@angular/core';
import { User } from '../model/user';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = 'https://localhost:7202/api/';
  constructor(private http: HttpClient) { }
  private currentUserSource = new BehaviorSubject<User | any>(null);
  currentUser$ = this.currentUserSource.asObservable();
  login(request: any): Observable<any> {
    return this.http.post<User>(this.baseUrl + 'auth/login', request).pipe(
      map((response: User) => {
        const user = response;
        if(user){
          localStorage.setItem('user',JSON.stringify(user));
          this.currentUserSource.next(user);
        }
      })
    );
  }
  register(request: User) {
    return this.http.post<User>(this.baseUrl + 'auth/', request);
  }
  logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }
}
