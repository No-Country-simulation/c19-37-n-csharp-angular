import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit{
  form: FormGroup = this.formBuilder.group();

  constructor(private formBuilder:FormBuilder) {
  }
  ngOnInit(): void {
    this.form = this.formBuilder.group({
      email: ["",Validators.compose([Validators.required, Validators.email])]
    })
  }

}
