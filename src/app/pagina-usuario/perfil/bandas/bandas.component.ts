import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import {Router } from '@angular/router';
import { finalize, take } from 'rxjs/operators';
import { BandasService } from './bandas.service';
import { Banda } from './banda.interface';

@Component({
  selector: 'app-bandas',
  templateUrl: './bandas.component.html',
  styleUrls: ['./bandas.component.scss']
})
export class BandasComponent implements OnInit {

  banda: Array<Banda>;
  bandas:any[];
  page=1;
  loading:boolean;
  errorOnLoading:boolean;

  
  constructor(
    private http:BandasService,
    private router:Router,
    private location:Location
  ) { 
    this.banda=[];
    this.bandas=[];
    this.loading = true;
    this.errorOnLoading = true;
    
  }

  ngOnInit(): void {
    this.getBandas();
    
  }

  prev(){
    this.page=this.page-1;
    this.getBandas();

  }
  next(){
    this.page=this.page+1;
    this.getBandas();
  }

  getBandas(){
    this.loading=true;
    this.errorOnLoading=false;
    
    this.http.getBandas(this.page)
      .pipe(
        take(1),
        finalize(()=>{
          this.loading=false;
        })
      )
      .subscribe(
        response => this.onSuccess(response),
        error=>this.onError(error),
      );
  }

  onError(error:any) {
    
    this.errorOnLoading=true;
    console.log(error);
  }
  onSuccess(response:Banda[]) {
    
    this.banda=response;
    this.retornarLista(this.banda);
  }

  deletar(id:number){
    this.http.deleteBanda(id)
    .subscribe(
      response => this.onSuccessDelete(id),
      error => this.OnError(error),
    )
  }
  onSuccessDelete(id:number){
    alert("apagado com sucesso!");
  }

  OnError(error: any){
    console.log(error);
  }

  retornarLista(banda:any){
    this.bandas.push(this.banda);
    console.log(this.bandas);
  }

}
