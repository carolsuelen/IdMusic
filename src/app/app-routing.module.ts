import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CadastroComponent } from './cadastro/cadastro.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { PaginaUsuarioComponent } from './pagina-usuario/pagina-usuario.component';
import { PerfilComponent } from './pagina-usuario/perfil/perfil.component';


const routes: Routes = [ {
  path: '',
  component: HomeComponent
},{
  path: 'home',
  component: HomeComponent,
},{
  path: 'login',
  component: LoginComponent,
},{
  path: 'cadastro',
  component: CadastroComponent,
},{
  path: 'feed',
  component: PaginaUsuarioComponent,
},{
  path: 'usuario',
  component: PerfilComponent,
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
