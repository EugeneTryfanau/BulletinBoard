import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  constructor(private auth: AuthService) {
  }

  username: any = "";
  password: any = "";
  confirmPassword: any = "";

  register() {
    return this.auth.register({
      username: this.username,
      password: this.password,
      confirmPassword: this.confirmPassword
    });
  }

}
