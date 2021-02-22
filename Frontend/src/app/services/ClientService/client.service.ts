import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { throwError, timer, Observable, } from 'rxjs';
import { retry, catchError, delay, tap } from 'rxjs/operators';
import { stringify } from '@angular/compiler/src/util';
import { Client } from '../../interfaces/client';
import { UserLogin } from '../models/userLogin';
import { map } from 'rxjs/operators'
import { AuthService } from '../auth/auth.service';
import { Decode } from '../models/decode';
@Injectable({
  providedIn: 'root'
})
export class ClientService {
  
  url ='https://idmusichtml.azurewebsites.net/api/client';
  url2 ='https://idmusichtml.azurewebsites.net/api/upload';
  url3= 'https://idmusichtml.azurewebsites.net/api/login';
  // url ='http://localhost:64483/api/client';
  // url2 ='http://localhost:64483/api/upload';
  // url3 ='http://localhost:64483/api/login';
  clientName?: string;
  clientInfo?:string;

  constructor (private http: HttpClient,
              private authService: AuthService){
              }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }
  getClientById(id: number): Observable<Client> {
    return this.http.get<Client>(this.url+ '/' + id)
  }
  // saveClient(client:Client){
  //   return this.http.post<Client>('https://idmusichtml.azurewebsites.net/api/client',client);

  // }

  getClientLogado(){
    this.clientInfo = this.authService.decode();
    // this.clientName = this.clientInfo.unique_name;

  }


  public InsertLogin(login:string, password:string) : Observable<any>
  { 
    var userLogin = new UserLogin(login, password);
    var data = JSON.stringify(userLogin);

    return this.http.post<any>(`${this.url3}`, JSON.parse(data),{})
            .pipe(map(user => {
                localStorage.setItem('tokenData', JSON.stringify(user));

                return user;
              } 
            ))
            .pipe(map(user => {
              localStorage.setItem('userData', JSON.stringify({login,password}));
              
              return user;
            } 
            ));

  }



  saveClient(client:Client): Observable<Client>{
        
    return this.http.post<Client>(this.url, JSON.stringify(client), this.httpOptions);
  }

  saveClientPhoto(client:Client): Observable<Client>{
    return this.http.post<Client>(this.url2, JSON.stringify(client), this.httpOptions);
  }
  
  updateClient(client:Client): Observable<Client> {
    return this.http.put<Client>(this.url + '/' + client.id, this.httpOptions);
      
  }
 

  deleteClient(client:Client){
    return this.http.delete<Client>(this.url + '/' + client.id, this.httpOptions);
  }
  
  handleError(error: HttpErrorResponse){
    let errorMessage = '';
    if(error.error instanceof ErrorEvent){
      errorMessage = error.error.message;
    } else {
      errorMessage = `Código do erro: ${error.status}, `+` mensagem: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
  logout() {
    localStorage.removeItem('currentUser');
  }

}
