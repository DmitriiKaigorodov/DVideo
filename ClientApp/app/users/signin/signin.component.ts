import { UserSigninModel } from './../models/UserSigninModel';
import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../auth/services/auth.service';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent implements OnInit {

  userSignInModel = new UserSigninModel();
  signInError = false;
  constructor(private authService : AuthService) { }

  ngOnInit() {
  }

  signin()
  {
    this.signInError = false;
    this.authService.signIn(this.userSignInModel).subscribe( tokenJson =>
    {
      var token = tokenJson.token;
      localStorage.setItem('id_token', token);
      console.log(this.authService.currentUser());
    },
    error =>
    {
      this.signInError = true;
    })
  }

}
