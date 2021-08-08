import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-todo-forms',
  templateUrl: './todo-forms.component.html',
  styleUrls: ['./todo-forms.component.css']
})
export class TodoFormsComponent implements OnInit {
  form: FormGroup;

  constructor(fb: FormBuilder) {
    this.form = fb.group({
      name: ['', Validators.required],
      email: [''],
    });
   }

  ngOnInit() {
  }

}
