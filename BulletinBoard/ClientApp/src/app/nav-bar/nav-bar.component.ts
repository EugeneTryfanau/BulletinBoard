import { Component } from '@angular/core';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent {
  visibility: boolean = false;
  isAdmin: boolean = false; 
  username: any;

  constructor(private auth: AuthService) {

  }

  async ngOnInit() {
    const user = await this.auth.loadUser();
    this.username = user['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'];

    if (this.username != null) {
      this.visibility = true;
    } else {
      this.visibility = false;
    }

    if (this.username == "admin") {
      this.isAdmin = true;
    } else {
      this.isAdmin = false;
    }
  }

  logout() {
    return this.auth.logout();
  }

  showHidden() {
    let x = document.getElementById("tryfTopNav");
    if (x != null) {
      if (x?.className === "tryfTopNav") {
        x.className += " responsive";
      } else {
         x.className = "tryfTopNav";
      }
    }
  }

}
