import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PublicacaoUsuarioComponent } from './publicacao-usuario.component';

describe('PublicacaoUsuarioComponent', () => {
  let component: PublicacaoUsuarioComponent;
  let fixture: ComponentFixture<PublicacaoUsuarioComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PublicacaoUsuarioComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PublicacaoUsuarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
