import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaVideosUsuarioComponent } from './lista-videos-usuario.component';

describe('ListaVideosUsuarioComponent', () => {
  let component: ListaVideosUsuarioComponent;
  let fixture: ComponentFixture<ListaVideosUsuarioComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListaVideosUsuarioComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListaVideosUsuarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
