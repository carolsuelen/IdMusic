import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CadastroComponent } from './cadastro/cadastro.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { PaginaUsuarioComponent } from './pagina-usuario/pagina-usuario.component';
import { AmigosComponent } from './pagina-usuario/perfil/amigos/amigos.component';
import { BandasComponent } from './pagina-usuario/perfil/bandas/bandas.component';
import { FotosComponent } from './pagina-usuario/perfil/fotos/fotos.component';
import { PerfilComponent } from './pagina-usuario/perfil/perfil.component';
import { SobreComponent } from './pagina-usuario/perfil/sobre/sobre.component';
import { VideosComponent } from './pagina-usuario/perfil/videos/videos.component';


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
},{
  path: 'amigos',
  component: AmigosComponent,
},{
  path: 'fotos',
  component: FotosComponent,
},{
  path: 'videos',
  component: VideosComponent,
},{
  path: 'sobre',
  component: SobreComponent,
},{
  path: 'bandas',
  component: BandasComponent,
}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
