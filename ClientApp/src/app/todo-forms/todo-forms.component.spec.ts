import { FormBuilder } from '@angular/forms';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TodoFormsComponent } from './todo-forms.component';


describe('TodoFormsComponent', () => {
  let component: TodoFormsComponent;
  let fixture: ComponentFixture<TodoFormsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TodoFormsComponent ]
    })
    .compileComponents();
    component = new TodoFormsComponent(new FormBuilder());
  })

  );

  beforeEach(() => {
    fixture = TestBed.createComponent(TodoFormsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should create a form with 2 controls',()=>{
    expect(component.form.contains('name')).toBeTruthy();
    expect(component.form.contains('email')).toBeTruthy();

  });

  it('should make name control required',()=>{
   let control = component.form.get('name');
   control.setValue('');
   expect(control.valid).toBeFalsy();
  });
});
