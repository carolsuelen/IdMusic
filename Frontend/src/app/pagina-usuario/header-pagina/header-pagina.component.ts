import { Component, OnInit } from '@angular/core';
import { ClientService } from 'src/app/client.service';

@Component({
  selector: 'app-header-pagina',
  templateUrl: './header-pagina.component.html',
  styleUrls: ['./header-pagina.component.scss']
})
export class HeaderPaginaComponent implements OnInit {

  constructor(clientService: ClientService
    ) { }

  ngOnInit(): void {
  }
  logout(){
    localStorage.removeItem('currentUser');
  }
  
}
