import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit, ViewChild, ViewChildren } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Car, CatalogComponent } from '../catalog/catalog.component';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit{


  
  
  
  constructor(public http: HttpClient, @Inject('BASE_URL')public baseUrl: string,public route:ActivatedRoute) {    
 
  }

  ngOnInit() {
   }
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

}
