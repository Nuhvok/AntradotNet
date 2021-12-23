import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MovieCard } from 'src/app/shared/models/movieCard';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { MovieDetails } from 'src/app/shared/models/movieDetails';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  constructor(private http : HttpClient) { }

  getTopGrossingMovies() : Observable<MovieCard[]>
  {
    return this.http.get<MovieCard[]>(`${environment.apiBaseUrl}movies/toprevenue`)
    //return this.http.get<MovieCard[]>('https://localhost:7169/api/movies/toprevenue')
  }

  getMovieDetails(id: number) : Observable<MovieDetails>
  {
    return this.http.get<MovieDetails>(`${environment.apiBaseUrl}movies/details/${id}`)
    //return this.http.get<MovieCard[]>('https://localhost:7169/api/movies/toprevenue')
  }

}
