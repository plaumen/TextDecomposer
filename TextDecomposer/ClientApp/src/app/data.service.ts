import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs'

@Injectable({
  providedIn: 'root'
})
export class DataService {

  private messageSource = new BehaviorSubject('');
  currentMessage = this.messageSource.asObservable();

  private text: string;


  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getXmlPost() {
    this.http.post(this.baseUrl + "api/textconversion/xml/", this.text, { responseType: 'text' }).subscribe(d => this.changeMessage(d.toString()))
  }

  getCsvPost() {
    this.http.post(this.baseUrl + "api/textconversion/csv/", this.text, { responseType: 'text' } ).subscribe(d => this.changeMessage(d.toString()))
  }

  changeMessage(message: string) {
    this.messageSource.next(message)
  }

  setCurrentInputText(inputText: string) {
        this.text = inputText;
  }
}
