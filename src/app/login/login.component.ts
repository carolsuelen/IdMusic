import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  email= "";
  password= "";

  constructor(
    private router:Router
  ) { }

  ngOnInit(): void {
  }

  onSubmit(form:any) {
   
    
    if(!form.controls.email.touched && !form.controls.password.touched ) {
     console.log(' Por favor insira senha e e-mail válidos ')
    }
    
    if (form.invalid) {
      form.controls.email.markAsTouched();
      form.controls.password.markAsTouched();
    return;
    }
    
    this.router.navigate(['feed']);
    
  }
  
  exibeErro(nomeControle: string, form:NgForm) {
    if (!form.controls[nomeControle]) {
      return false;
    }
    
    return form.controls[nomeControle].invalid && form.controls[nomeControle].touched;
    
  }

}
