import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.scss']
})
export class CadastroComponent implements OnInit {

  constructor(
    private router:Router
    ){}

  ngOnInit(): void {
  }


  onClick(){
    this.router.navigate(['login']);
  }
}
