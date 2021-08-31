import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';

@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.css']
})
export class CatalogComponent implements OnInit {
  public cars: Car[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Car[]>(baseUrl + 'catalog').subscribe(result => {
      this.cars = result;
    }, error => console.error(error));
  }
  ngOnInit() {
  }

}
interface Car{
 id: number;
 brand: Brand;
 brandId: number;
 model: string;
        
        // public string Model { get; set; }
        // public EngineType EngineType { get; set; }
        // [Required]
        // public double? EngineSize { get; set; }
        // [Required]
        // [Range(2010,2021)]
        // public int? Year { get; set; }
        // [Required]
        // public int? Price { get; set; }
}
interface Brand{
  id: number;
  name: string;
}
