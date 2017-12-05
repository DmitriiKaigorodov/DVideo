import { AuthService } from './services/auth.service';
import { AuthGuard } from './services/auth-guard.service';
import { NgModule } from '@angular/core';
import { Http, RequestOptions } from '@angular/http';
import { AuthHttp, AuthConfig } from 'angular2-jwt';
 
export function authHttpServiceFactory(http: Http, options: RequestOptions) {
  return new AuthHttp(new AuthConfig(), http, options);
}
 
@NgModule({
  providers: [
    {
      provide: AuthHttp,
      useFactory: authHttpServiceFactory,
      deps: [Http, RequestOptions],
      
    },
    AuthGuard,
    AuthService
  ]
})
export class AuthModule {}