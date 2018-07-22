import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs'

@Injectable({
  providedIn: 'root'
})
export class DataService {

  private messageSource = new BehaviorSubject('no parsed text!');
  currentMessage = this.messageSource.asObservable();

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getXml(text: string) {
    this.http.get(this.baseUrl + "api/textconversion/xml/" + text, { responseType: 'text' }).subscribe(d => this.changeMessage(d.toString()))
  }

  getCsv(text: string) {
    this.http.get(this.baseUrl + "api/textconversion/csv/" + text, { responseType: 'text' }).subscribe(d => this.changeMessage(d.toString()))
  }

  changeMessage(message: string) {
    this.messageSource.next(message)
  }
}
