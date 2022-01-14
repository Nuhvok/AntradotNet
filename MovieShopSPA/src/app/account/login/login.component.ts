import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { Login } from 'src/app/shared/models/login';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  userLogin: Login ={
    email: '',
    password: ''
  };

  constructor(private authService: AuthenticationService, private router: Router) { }

  ngOnInit(): void {
  }

  loginSubmit()
  {
    //console.log("submit clicked");
    this.authService.login(this.userLogin)
    .subscribe(
      (response) => {
        if(response)
        {
          this.router.navigateByUrl('/');
        }
        
        
        (err: HttpErrorResponse) => {
          console.log(err.message);
        }
      })
  }

}
