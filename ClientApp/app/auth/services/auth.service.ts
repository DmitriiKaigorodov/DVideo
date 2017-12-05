import { UserSigninModel } from './../../users/models/UserSigninModel';

import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import { JwtHelper, tokenNotExpired } from 'angular2-jwt/angular2-jwt'

@Injectable()
export class AuthService {

  private jwtHelper = new JwtHelper();
  private readonly authEndPoint = "/api/auth"
  constructor(private http : Http) { }

  signIn( userSigninModel :UserSigninModel)
  {
    return this.http.post(this.authEndPoint, userSigninModel)
          .map( response => response.json());
  }

  signOut()
  {
    localStorage.removeItem("id_token");
  }

  currentUser()
  {
     var token  = <string>localStorage.getItem("id_token");
     return this.jwtHelper.decodeToken(token);
  }

  isTokenExpired()
  {
    return tokenNotExpired();
  }
}