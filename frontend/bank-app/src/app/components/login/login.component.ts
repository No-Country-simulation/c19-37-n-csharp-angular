import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent implements OnInit {
  form: FormGroup = this.formBuilder.group({});

  constructor(private formBuilder: FormBuilder, private authService: AuthService) {}
  ngOnInit(): void {
    this.form = this.formBuilder.group({
      email: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  get email() {
    return this.form.get('email');
  }

  get password() {
    return this.form.get('password');
  }

  sendForm() {
    this.authService.login(this.form).subscribe({
      next: (value) => { },
      error: (error) => { },
      complete: ()=>{}
    })
  }
}
