import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AmigosComponent } from './amigos.component';

describe('AmigosComponent', () => {
  let component: AmigosComponent;
  let fixture: ComponentFixture<AmigosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AmigosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AmigosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
