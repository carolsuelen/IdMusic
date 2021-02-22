import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ClientService } from '../services/ClientService/client.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  email= "";
  password= "";

  constructor(
    private router:Router,
    private clientService: ClientService
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

    // this.authService
    //     .login(form.controls.email, form.controls.password)
    //     .subscribe((client) =>  {
    //       this.router.navigate(['/hero']);
    //     }, (error) => 
    //     {
    //       alert("Não foi possivel fazer o login, tente novamente!")
    // });


    this.login(form.controls.email.value,form.controls.password.value);
    // this.router.navigate(['feed']);
      
  }
  
  exibeErro(nomeControle: string, form:NgForm) {
    if (!form.controls[nomeControle]) {
      return false;
    }
    
    return form.controls[nomeControle].invalid && form.controls[nomeControle].touched;
    
  }

  login(email:string,password:string){
    this.clientService
    .InsertLogin(email,password)
    .subscribe(_response =>  {
      this.router.navigate([`feed`]);
    }, (_error) => 
    {
      alert("Não foi possivel fazer o login, tente novamente!")
    });
  }
  

}