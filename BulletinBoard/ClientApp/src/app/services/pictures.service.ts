import { HttpClient, HttpErrorResponse, HttpEventType } from '@angular/common/http';
import { EventEmitter, Injectable, Output } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PicturesService {

  public progress: number = 0;
  public message: string = "";

  @Output() public onUploadFinished = new EventEmitter();

  constructor(private http: HttpClient) { }

  uploadPicture(formData: any) {
    this.http.post("/api/upload", formData, { reportProgress: true, observe: 'events' })
      .subscribe(
        {
          next: (event) => {
            if (event.type === HttpEventType.UploadProgress)
              this.progress = Math.round(100 * event.loaded / event.total!);
            else if (event.type === HttpEventType.Response) {

              this.message = 'Upload success.';
              this.onUploadFinished.emit(event.body);
            }
          },
          error: (err: HttpErrorResponse) => console.log(err)
        });
  }
}
