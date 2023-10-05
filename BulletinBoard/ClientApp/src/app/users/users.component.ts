import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { firstValueFrom } from 'rxjs';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent {

  constructor(private http: HttpClient) {

  }

  users: any = [];


  async ngOnInit() {
    this.users = await firstValueFrom(
      this.http.get('/api/users')
    )
  }

  promotion(userId: string) {
    return this.http.post<any>("/api/users/" + userId, { withCredentials: true })
      .subscribe(_ => {
        this.users.filter((user: { id: string; }) => user.id != userId);
      })
  }

}
