import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { formatCurrency } from '@angular/common';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.scss']
})
export class CadastroComponent implements OnInit {

  nome= "";
  sobrenome= "";
  email="";
  senha="";
  data="";
  genero=""
  visivel="";

  constructor(
    private router:Router
    ){}

  ngOnInit(): void {
    
  }

  onSubmit(form:any) {
   
    
    if(!form.controls.email.touched && !form.controls.senha.touched ) {
     console.log(' Por favor insira senha e e-mail válidos ')
    }
    
    if (form.invalid) {
      form.controls.email.markAsTouched();
      form.controls.senha.markAsTouched();
      form.controls.nome.markAsTouched();
      form.controls.sobrenome.markAsTouched();
      form.controls.data.markAsTouched();
      form.controls.genero.markAsTouched();
    return;
    }
    
    this.router.navigate(['feed']);
    
  }
  
  exibeErro(nomeControle: string, form:NgForm) {
    if (!form.controls[nomeControle]) {
      return false;
    }
    console.log(form)
    return form.controls[nomeControle].invalid && form.controls[nomeControle].touched;
    
  }

}
