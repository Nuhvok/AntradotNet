import { HttpClient, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map, Observable } from 'rxjs';
import { Login } from 'src/app/shared/models/login';
import { User } from 'src/app/shared/models/user';
import { environment } from 'src/environments/environment';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private currentUserSubject = new BehaviorSubject<User>( { } as User);
  public currentUser = this.currentUserSubject.asObservable();

  private isLoggedInSubject = new BehaviorSubject<boolean>(false);
  public isLoggedIn = this.isLoggedInSubject.asObservable();

  private jwtHelper = new JwtHelperService();

  constructor(private http: HttpClient) { }

  login(userLogin: Login): Observable<boolean>
  {
    return this.http.post(`${environment.apiBaseUrl}account/login`, userLogin)
    .pipe( map( (response: any) =>
    {
      if(response)
      {
        localStorage.setItem('token', response.token);

        this.populateUserInfo();

        return true;
      }
      else
      {
        return false;
      }
    }))
  }

  logout()
  {
    localStorage.removeItem('token');
    this.currentUserSubject.next({} as User);
    this.isLoggedInSubject.next(false);
  }

  register()
  {

  }

  populateUserInfo()
  {
    var token = localStorage.getItem('token');

    if(token && !this.jwtHelper.isTokenExpired(token))
    {
      const decodedToken = this.jwtHelper.decodeToken(token);
      this.currentUserSubject.next(decodedToken);
      this.isLoggedInSubject.next(true);
    }
  }
}
