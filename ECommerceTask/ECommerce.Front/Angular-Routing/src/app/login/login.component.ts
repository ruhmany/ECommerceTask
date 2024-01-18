import { Component } from '@angular/core';
import { AuthService } from '../../Services/User.service';
import { LoginUserCommand } from 'src/Models/LoginUserModel';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [AuthService],
})
export class LoginComponent {
  returnUrl = "";
  form: FormGroup;
  data: FormData = new FormData();
  constructor(private builder: FormBuilder, private AuthService: AuthService, private router: Router, private activatedRoute: ActivatedRoute) {
    this.form = this.builder.group({
      email: [null, [Validators.required, Validators.email]],
      password: [null, [Validators.required]]
    })
  }
  login() {
    if (this.form.invalid) return;

    this.data.set("EmailAddress", this.form.get("email")!.value)
    this.data.set("Password", this.form.get("password")!.value)

    const credentials: LoginUserCommand = {
      UsernameOrEmail: this.form.get("email")!.value,
      Password: this.form.get("password")!.value
    };

    this.AuthService.login(credentials);
    this.AuthService.isLoggedIn.subscribe({
      next: authenticated => {
        if (authenticated) {
          this.router.navigateByUrl('/Courses');
        }
      }, error(err) {
        console.error(err);
      },
    })
  }

  // usernameOrEmail: string = '';
  // password: string = '';

  // constructor(private AuthService: AuthService, private router: Router) { }

  // login() {
  //   const credentials: LoginUserCommand = {
  //     UsernameOrEmail: this.usernameOrEmail,
  //     Password: this.password
  //   };

  //   this.AuthService.login(credentials).subscribe(
  //     (authModel: AuthModel) => {
  //       // Handle successful login here
  //       this.router.navigateByUrl('/Courses');
  //     },
  //     (error) => {
  //       // Handle login error here
  //       console.error('Login failed:', error);
  //     }
  //   );
  // }
}

