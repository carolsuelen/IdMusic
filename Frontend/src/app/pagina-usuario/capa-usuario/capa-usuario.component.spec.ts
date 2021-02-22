import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CapaUsuarioComponent } from './capa-usuario.component';

describe('CapaUsuarioComponent', () => {
  let component: CapaUsuarioComponent;
  let fixture: ComponentFixture<CapaUsuarioComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CapaUsuarioComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CapaUsuarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
