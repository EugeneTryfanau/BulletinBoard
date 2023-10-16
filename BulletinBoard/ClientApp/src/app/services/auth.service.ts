import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';

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

  login(loginForm: any) {
    return this.http.post<any>("/api/login", loginForm, { withCredentials: true })
      .subscribe(_ => {
        this.loadUser();
        window.location.href = "/";
      });
  }

  register(registerForm: any) {
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
}
