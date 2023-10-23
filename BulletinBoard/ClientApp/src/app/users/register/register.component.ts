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

  fieldCondition: any = {
    1 : "Показать",
    2 : "Скрыть"
  };
  notNecessory: boolean = false;
  addInfoToField: any = this.fieldCondition[1];

  email: any = "";
  username: any = "";
  city: any = "";
  gender: any = "";
  phoneNumber: any = "";
  birthdayDate: any = "";
  password: any = "";
  confirmPassword: any = "";

  register() {
    return this.auth.register({
      email: this.email,
      username: this.username,
      city: this.city,
      gender: this.gender,
      phoneNumber: this.phoneNumber,
      birthdayDate: this.birthdayDate,
      password: this.password,
      confirmPassword: this.confirmPassword
    });
  }

  hideShowNotNecessory() {
    this.notNecessory = !this.notNecessory;
    if (this.notNecessory == false) {
      this.addInfoToField = this.fieldCondition[1];
    } else {
      this.addInfoToField = this.fieldCondition[2]
    }
  }

}
