import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AuthbuttonComponent } from './authbutton.component';

describe('AuthbuttonComponent', () => {
  let component: AuthbuttonComponent;
  let fixture: ComponentFixture<AuthbuttonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AuthbuttonComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AuthbuttonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
