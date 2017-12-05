import { AuthModule } from './../auth/auth.module';
import { UserService } from './services/user.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SignupComponent } from './signup/signup.component';
import { SigninComponent } from './signin/signin.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    AuthModule
  ],
  declarations: [SignupComponent, SigninComponent],
  exports: [SignupComponent],
  providers: [UserService]
})
export class UsersModule { }
