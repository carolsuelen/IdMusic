import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaBandaUsuarioComponent } from './lista-banda-usuario.component';

describe('ListaBandaUsuarioComponent', () => {
  let component: ListaBandaUsuarioComponent;
  let fixture: ComponentFixture<ListaBandaUsuarioComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListaBandaUsuarioComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListaBandaUsuarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
