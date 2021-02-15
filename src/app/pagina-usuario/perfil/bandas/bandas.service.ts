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

  constructor(
    private http: HttpClient
  ) { }

  getBandas(page:number){
    return this.http.get<Banda[]>('rbdb.io/v3/artists/1',{
      params:{
        _page: String(page),
      }
    });
  }

  getBanda(id: number){
  //  const error = throwError('Error Normal');
  //    return timer(3000).pipe(mergeMap(()=>error)); 
     return this.http.get<Banda>('rbdb.io/v3/artists/'+id);
  }

  deleteBanda(id:number){
    return this.http.delete<Banda>('rbdb.io/v3/artists/'+id.toString());
  }  

}
