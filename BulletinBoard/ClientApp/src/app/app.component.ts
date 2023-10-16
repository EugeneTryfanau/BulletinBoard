import { Component } from '@angular/core';
import { AuthService } from './services/auth.service';
import { CategoryService } from './services/category.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title: any = "ClientApp"

  constructor(private auth: AuthService, private categoryService: CategoryService) {
    
  }
}
