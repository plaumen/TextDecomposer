import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';


@Component({
  selector: 'app-text-input',
  templateUrl: './text-input.component.html',
  styleUrls: ['./text-input.component.css']
})
export class TextInputComponent implements OnInit {

  private inputText: string;

  constructor(private data: DataService) { }

  ngOnInit() {

  }

  valuechange(text: string) {
    console.log(text);
    this.data.setCurrentInputText(text);
  }

}

