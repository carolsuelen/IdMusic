import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CadastroComponent } from './cadastro/cadastro.component';
import { FooterComponent } from './footer/footer.component';
import { HeaderComponent } from './header/header.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { PaginaUsuarioComponent } from './pagina-usuario/pagina-usuario.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HeaderPaginaComponent } from './pagina-usuario/header-pagina/header-pagina.component';
import { MenuComponent } from './pagina-usuario/menu/menu.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { PerfilComponent } from './pagina-usuario/perfil/perfil.component';


@NgModule({
  declarations: [
    AppComponent,
    CadastroComponent,
    FooterComponent,
    HeaderComponent,
    HomeComponent,
    LoginComponent,
    PaginaUsuarioComponent,
    HeaderPaginaComponent,
    MenuComponent,
    PerfilComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    BrowserAnimationsModule,
    MatSidenavModule,
    MatToolbarModule,
  ],
  exports: [
    MatSidenavModule,
    MatToolbarModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
