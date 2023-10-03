import { Component } from '@angular/core';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent {

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
