import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit{
  form = FormGroup;

  constructor(private formBuilder:FormBuilder) {
  }
  ngOnInit(): void {
    form = this.formBuilder.group
  }

}
