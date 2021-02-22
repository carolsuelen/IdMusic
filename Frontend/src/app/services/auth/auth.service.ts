import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';


// import { ProviderService } from '../provider.service';
import jwt_decode from "jwt-decode";

import { map } from 'rxjs/operators'
import { Auth } from '../models/auth';
import { UserLogged } from '../models/userLogged';
import { UserLogin } from '../models/userLogin';

@Injectable({
  providedIn: 'root'
})

export class AuthService{
private http: HttpClient;
accessToken:Auth;
decoded?:string;
// private currentUserSubject: BehaviorSubject<Auth>;
// public currentUser: Observable<Auth>;
  
  constructor(_http: HttpClient) 
  { 
    // super("login");
    this.http = _http;
    this.accessToken = new Auth;
    this.decoded="";
  // this.currentUser= this.currentUserSubject.asObservable();
  }

  // public get currentUserValue() : Auth {
  //   return this.currentUserSubject.value;
  // }

  // public get userInformations(): UserLogged {
  //   try {
  //     return jwt_decode(this.currentUserValue.accessToken);
  //   } catch(Error)
  //   {
  //     return null;
  //   }
  // }

  // login(username: string, password: string)
  // {
  //   var userLogin = new UserLogin(username, password);
  //   var data = JSON.stringify(userLogin);

  //   return this.http.post<any>(`${this.url}`, JSON.parse(data),{})
  //           .pipe(map(user => {
  //             localStorage.setItem('currentUser', JSON.stringify(user));
  //             this.currentUserSubject.next(user);
  //             return user;
  //           }))
  // }
  setUsuario(usuario:any){
    localStorage.setItem('usuario',JSON.stringify(usuario));
  }

  getUsuario(){
    const usuarioGuardado = localStorage.getItem('usuario');
    if(usuarioGuardado){
      return JSON.parse(usuarioGuardado);
    }
    return null;
  }

  getAccessToken(){
    
    const logindata = localStorage.getItem('tokenData');
    if(logindata){
      var data =JSON.parse(logindata);
      var token = data.accessToken;
      return token;
    }
    return null;
  }

  decode(){
    debugger;
    var token = this.getAccessToken();
    this.decoded = jwt_decode(token);
    return this.decoded;
  }
}