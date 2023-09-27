import { Component } from '@angular/core';
import { AuthService } from './auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ClientApp';
  username: any;

  constructor(private auth: AuthService) {
    
  }

  async ngOnInit() {
    const user = await this.auth.loadUser();
    this.username = user['username'];
  }

  logout() {
    return this.auth.logout();
  }
}
