import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaFotoUsuarioComponent } from './lista-foto-usuario.component';

describe('ListaFotoUsuarioComponent', () => {
  let component: ListaFotoUsuarioComponent;
  let fixture: ComponentFixture<ListaFotoUsuarioComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListaFotoUsuarioComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListaFotoUsuarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
