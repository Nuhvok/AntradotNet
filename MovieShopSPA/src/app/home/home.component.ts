import { Component, OnInit } from '@angular/core';
import { MovieService } from '../core/services/movie.service';
import { UserService } from '../core/services/user.service';
import { MovieCard } from '../shared/models/movieCard';
import { MovieDetails } from '../shared/models/movieDetails';
import { UserFavorites } from '../shared/models/userFavorites';
import { UserPurchases } from '../shared/models/userPurchases';
import { UserProfile } from '../shared/models/userProfile';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  movieCards! : MovieCard[];
  // movieDetails! : MovieDetails;
  // userFavorites! : UserFavorites;
  constructor(private movieService : MovieService, private userService : UserService) { }

  ngOnInit(): void {
    this.movieService.getTopGrossingMovies()
    .subscribe(
      m=> {
        this.movieCards = m;
        // console.log('Inside Subscription');
        // console.log(this.movieCards);
      }
      );

    //   this.movieService.getMovieDetails(1)
    // .subscribe(
    //   m=> {
    //     this.movieDetails = m;
    //     // console.log('Inside Subscription');
    //     console.log(this.movieDetails);
    //   }
    // );

    // this.userService.getUserFavorites(49821)
    // .subscribe(
    //   m=> {
    //     this.userFavorites = m;
    //     // console.log('Inside Subscription');
    //     console.log(this.userFavorites);
    //   }
    // );

  }

}
