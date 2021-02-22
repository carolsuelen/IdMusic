import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm,FormGroup } from '@angular/forms';
import { Location } from '@angular/common';
import { formatCurrency } from '@angular/common';
import {ClientService} from '../services/ClientService/client.service';
import { Client } from '../interfaces/client';
import { compileDeclareComponentFromMetadata } from '@angular/compiler';
import {UploadService} from '../services/upload.service';
import {CadastroInput} from '../services/models/cadastro';
 
@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.scss'],
  providers : [ClientService]
})
export class CadastroComponent implements OnInit {
  public clients:Array<any>=[];
  public url: string = '';
  public fileToUpload?: File;
  public files: Array<any> = new Array<any>();
  capa : string = "";
  perfil:string = "";
  client = {} as Client;
  loading:boolean;
  errorOnLoading:boolean; 
  paginaAtual : number = 1 ;
  contador : number = 100;
  foto: string;
  fotoCapa : string;
  constructor(
    private clientService:ClientService,
    private router:Router,
    private location:Location,
    private _uploadService: UploadService,
    ){
      this.loading = true;
      this.errorOnLoading = true;
      this.foto = "";
      this.fotoCapa="";
      
      
    }

  ngOnInit(): void {
    console.log(this.client);
  }

  onSubmit(form:any) {
   
    
    if(!form.controls.email.touched && !form.controls.senha.touched ) {
     console.log(' Por favor insira senha e e-mail válidos ')
    }
    
    if (form.invalid) {
      form.controls.email.markAsTouched();
      form.controls.ássword.markAsTouched();
      form.controls.name.markAsTouched();
      form.controls.sobrenome.markAsTouched();
      form.controls.birthday.markAsTouched();
      form.controls.genreId.markAsTouched();
    return;
    }
    this.saveClient(form);
    this.router.navigate(['login']);
    
  }

  getClientById(client:Client){

    this.clientService.getClientById(client.id).subscribe();
  }

  saveClient(form:any) {
    debugger;
    var cadastro = new CadastroInput(form.controls.name.value,
                                    form.controls.email.value, 
                                    form.controls.password.value,
                                    Number(form.controls.genreId.value), 
                                    form.controls.birthday.value,
                                    this.capa,
                                    this.perfil,
                                    form.controls.biografy.value,
                                    form.controls.band.value);
    var data = JSON.stringify(cadastro);

    if (this.client.id !== undefined){
      this.clientService.updateClient(JSON.parse(data)).subscribe(() => {
        this.cleanForm(form);
      });
    } else {
      this.clientService.saveClient(JSON.parse(data)).subscribe(() => {
        this.cleanForm(form);
      });
    }
    this.router.navigate(['login']);
  }

  saveClientPhoto(photo:any) {
    debugger;
    this.clientService.saveClientPhoto(photo).subscribe(() => {
      (response: any) => {
        this.foto = response.url;
      }
    });
  }
  saveClientPhotoCapa(photo:any) {
    debugger;
    this.clientService.saveClientPhoto(photo).subscribe(() => {
      (response: any) => {
        this.fotoCapa = response.url;
      }
    });
  }


  deleteClient(client:Client){
    this.clientService.deleteClient(client).subscribe(()=>{
      this.getClientById(client);
    })
  }

  cleanForm(form:NgForm){
    form.resetForm();
  }

  
  exibeErro(nomeControle: string, form:NgForm) {
    if (!form.controls[nomeControle]) {
      return false;
    }
    console.log(form)
    return form.controls[nomeControle].invalid && form.controls[nomeControle].touched;
  }

  onSelectFile(event:any,name:string) {
    debugger;
    var files = event.target.files;
    if (files.length === 0)
      return;
 
    this.fileToUpload = files.item(0);
    if (this.fileToUpload !== undefined){
      const fileReader: FileReader = new FileReader();
      fileReader.readAsDataURL(this.fileToUpload);
  
      fileReader.onload = (event: any) => {
        if(name == "capa"){
          this.capa = event.target.result;
        }
         this.perfil = event.target.result;
      };
  
      this.files.push({ data: this.fileToUpload, fileName: this.fileToUpload.name });

      this._uploadService
        .uploadImage(this.files[0])
        .subscribe((result: any) => {
          if(name == "capa"){
            this.capa = result.url;
          }
          this.perfil = result.url;
          
        },
        (error: any) => {
          alert("Erro");
        });
    }
  }

}
