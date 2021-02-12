import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HeaderPaginaComponent } from './header-pagina.component';

describe('HeaderPaginaComponent', () => {
  let component: HeaderPaginaComponent;
  let fixture: ComponentFixture<HeaderPaginaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HeaderPaginaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HeaderPaginaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
