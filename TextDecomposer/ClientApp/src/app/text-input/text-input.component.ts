import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';


@Component({
  selector: 'app-text-input',
  templateUrl: './text-input.component.html',
  styleUrls: ['./text-input.component.css']
})
export class TextInputComponent implements OnInit {

  constructor(private data: DataService) { }

  ngOnInit() {

  }

  parseToXml(text: string) {
    console.log("Parse clicked")
    this.data.getXml(text);
  }

  parseToCsv(text: string) {
    this.data.getCsv(text)
  }

}

