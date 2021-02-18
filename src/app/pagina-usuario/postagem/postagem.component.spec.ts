import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PostagemComponent } from './postagem.component';

describe('PostagemComponent', () => {
  let component: PostagemComponent;
  let fixture: ComponentFixture<PostagemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PostagemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PostagemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
