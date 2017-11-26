import { Router } from '@angular/router';
import { UserService } from './../services/user.service';
import { UserSignupModel } from './../models/UserSignupModel';
import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, FormControl,
  RequiredValidator, ReactiveFormsModule, Validators } from '@angular/forms';
import { UsersValidators } from '../users.validators';
import { ToastyService } from 'ng2-toasty';



@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  form : FormGroup;
  userSignUpData = new UserSignupModel();
  constructor(private  fb : FormBuilder,
             private userService : UserService,
             private toatyService: ToastyService,
             private router : Router) 
  {

    this.form = fb.group(
      {
        userName : ['', [Validators.required, Validators.minLength(5)]],
        email : ['', [Validators.required, UsersValidators.emailRequired]],
        passwords : fb.group(
          {
            password : ['', [Validators.required, Validators.minLength(5)]],
            repeatPassword : ['', [Validators.required, Validators.minLength(5)]]
          }, { validator : UsersValidators.isPasswordsMath}
        )

       
      }
    )

    console.log(this.form);
   }

  ngOnInit() {
  }

  submit()
  {
    console.log(this.userSignUpData);

    this.userService.signUp(this.userSignUpData).subscribe( userData =>
      {
        this.toatyService.success({
          msg: "Sign Up succesfully! Welcome to DVideo, " + this.userSignUpData.name + "!",
          title: "Success",
          theme: "bootstrap"
        });

        setTimeout( () =>
        {
          this.router.navigate(['signin']);
        }, 2000);
      },
      error =>
      {
        this.toatyService.error({
          msg: "Something is going wrong. Please try again later",
          title: "Error",
          theme: "bootstrap"
        });
      }
    )
  }

}
