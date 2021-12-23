import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserFavorites } from 'src/app/shared/models/userFavorites';
import { UserPurchases } from 'src/app/shared/models/userPurchases';
import { UserProfile } from 'src/app/shared/models/userProfile';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http : HttpClient) { }

  getUserFavorites(id: number) : Observable<UserFavorites>
  {
    return this.http.get<UserFavorites>(`${environment.apiBaseUrl}user/favorites/${id}`)
  }

  getUserPurchases(id: number) : Observable<UserPurchases>
  {
    return this.http.get<UserPurchases>(`${environment.apiBaseUrl}user/purchases/${id}`)
  }

  getUserProfile(id: number) : Observable<UserProfile>
  {
    return this.http.get<UserProfile>(`${environment.apiBaseUrl}user/profile/${id}`)
  }
}
