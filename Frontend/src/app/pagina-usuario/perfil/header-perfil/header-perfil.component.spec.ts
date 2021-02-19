import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HeaderPerfilComponent } from './header-perfil.component';

describe('HeaderPerfilComponent', () => {
  let component: HeaderPerfilComponent;
  let fixture: ComponentFixture<HeaderPerfilComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HeaderPerfilComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HeaderPerfilComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
