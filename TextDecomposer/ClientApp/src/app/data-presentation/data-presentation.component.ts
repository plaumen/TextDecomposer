import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service'

@Component({
  selector: 'app-data-presentation',
  templateUrl: './data-presentation.component.html',
  styleUrls: ['./data-presentation.component.css']
})
export class DataPresentationComponent implements OnInit {

  parsedText: string;

  constructor(private data:DataService) { }

  ngOnInit() {

    this.data.currentMessage.subscribe(m => this.parsedText = m)
   
  }

}
