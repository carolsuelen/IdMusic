import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CadastroComponent } from './cadastro/cadastro.component';
import { ExtratoComponent } from './extrato/extrato.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { PainelUsuarioComponent } from './painel-usuario/painel-usuario.component';


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
  path: 'extrato',
  component: ExtratoComponent,
},{
  path: 'painel-usuario',
  component: PainelUsuarioComponent,
},{
  path: 'cadastro',
  component: CadastroComponent,
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
