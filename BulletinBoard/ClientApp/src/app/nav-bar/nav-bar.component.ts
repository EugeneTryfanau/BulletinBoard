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
  userName: any;
  userRole: any;

  constructor(private auth: AuthService) {

  }

  async ngOnInit() {
    const user = await this.auth.loadUser();
    this.userName = user['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'];
    this.userRole = user['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];

    if (this.userName != null) {
      this.visibility = true;

      if (this.userRole == "admin") {
        this.isAdmin = true;
      }
    } else {
      this.isAdmin = false;
      this.visibility = false;
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
