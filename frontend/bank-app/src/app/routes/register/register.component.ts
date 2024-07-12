import { Component, inject, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { RegisterService } from '../../services/register.service';
import { RouterLink } from '@angular/router';
import { error } from 'console';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [RouterLink, ReactiveFormsModule],
  providers: [RegisterService],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css',
})
export class RegisterComponent implements OnInit {
  public registerForm!: FormGroup;
  formBuilder = inject(FormBuilder);
  private registerService: RegisterService = inject(RegisterService);
  ngOnInit(): void {
    this.registerForm = this.initFormRegister();
  }

  public onSubmit(): void {
    const formValue = this.registerForm.value;
    // this.registerService.post(formValue).subscribe(
    //   (data: any) => {
    //     console.log({ data });
    //   },
    //   (err: any) => {
    //     console.log(err);
    //   }
    // );
    console.log(
      this.registerService.post(formValue).subscribe((data) => {
        console.log(data);
      })
    );
  }

  public initFormRegister(): FormGroup {
    return this.formBuilder.group({
      name: ['', [Validators.required]],
      lastname: ['', [Validators.required]],
      dni: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      password: [
        '',
        [
          Validators.required,
          Validators.minLength(8),
          Validators.pattern('^(?=.*[A-Z])(?=.*d)(?=.*[@$!%*?&]).*$'),
        ],
      ],
    });
  }

  getErrors(element: string): string | null {
    const control = this.registerForm.get(element);
    if (control && control.errors && control.touched) {
      if (control.errors['required']) return 'This field is required';
      if (control.errors['email']) return 'Please enter a valid email address';
      if (control.errors['minlength']) {
        const minLength = control.errors['minlength'].requiredLength;
        return `Minimum length is ${minLength} characters`;
      }
      if (control.errors['pattern']) {
        return 'Must contain at least uppercase letter, number, and special character.';
      }
      return 'error';
    }
    return null;
  }
}
