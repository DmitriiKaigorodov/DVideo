import { UserSignupModel } from './../models/UserSignupModel';
import { Http } from '@angular/http';
import { Injectable } from '@angular/core';

@Injectable()
export class UserService {

  private readonly usersEndpoint = "api/users";
  constructor(private http : Http) { }

  signUp(userData : UserSignupModel)
  {
    return this.http.post(this.usersEndpoint, userData).map( response => response.json());
  }
}
