import { Component } from '@angular/core';
import { DataService } from '../data.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {

  constructor(private data: DataService) { }

  getXml() {
    this.data.getXmlPost();
  }

  getCsv() {
    this.data.getCsvPost();
  }

}
