import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { throwError, timer, Observable, } from 'rxjs';
import { mergeMap } from 'rxjs/operators';
import {Banda} from './banda.interface';
import { catchError, retry } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BandasService {
  private http: HttpClient
  constructor(
   _http:HttpClient
  ) { 
    this.http=_http;
  }

  getBandas(): Observable<any>{
    return this.http.get<any>('http://rbdb.io/v4/artists',{
          
    });
    
  }

  getBanda(id: number){
  //  const error = throwError('Error Normal');
  //    return timer(3000).pipe(mergeMap(()=>error)); 
     return this.http.get<Banda>('rbdb.io/v4/artists/'+id);
  }

  deleteBanda(id:number){
    return this.http.delete<Banda>('rbdb.io/v4/artists/'+id.toString());
  }  

}
