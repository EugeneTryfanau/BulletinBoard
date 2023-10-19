import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { ChangePassword } from './models/changepassword';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) {
  }

  user: any = null;

  async loadUser() {
    const user = await firstValueFrom(
      this.http.get<any>("/api/user")
    )
    if ('userId' in user) {
      this.user = user
    }
    return user;
  }

  async getUserProfile(userId: any) {
    return await firstValueFrom(this.http.get<any>("/api/user-profile/" + userId));
  }

  async changePassword(passModel: ChangePassword) {
    return this.http.post("/api/user-profile/change-password", passModel);
  }

  login(loginForm: any) {
    return this.http.post<any>("/api/login", loginForm, { withCredentials: true })
      .subscribe(_ => {
        this.loadUser();
        window.location.href = "/";
      });
  }

  register(registerForm: any) {
    console.log(registerForm);
    return this.http.post<any>("/api/register", registerForm, { withCredentials: true })
      .subscribe(_ => {
        this.loadUser();
        window.location.href = "/";
      })
  }

  logout() {
    return this.http.get("/api/logout")
      .subscribe(_ => {
        this.user = null;
        window.location.href = "/";
      });
  }

  deleteAccount(userId: string) {
    return this.http.get("/api/delete-account/" + userId)
      .subscribe(_ => {
        this.user = null;
        window.location.href = "/";
      });
  }
}
