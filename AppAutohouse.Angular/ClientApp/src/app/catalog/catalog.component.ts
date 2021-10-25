import { HttpClient } from "@angular/common/http";
import { Component, Inject, OnInit } from "@angular/core";
import { FormControl, FormGroup } from "@angular/forms";
import { DomSanitizer } from "@angular/platform-browser";
import { Router } from "@angular/router";

@Component({
  selector: "app-catalog",
  templateUrl: "./catalog.component.html",
  styleUrls: ["./catalog.component.css"],
})
export class CatalogComponent implements OnInit {
  public cars: Car[];
  public name: any;
  public description: any;
  public logo: any;
  public searchForm: FormGroup;

  constructor(
    public http: HttpClient,
    @Inject("BASE_URL") public baseUrl: string,
    public router: Router,
    public sanitizer: DomSanitizer
  ) {
    http.get<Car[]>(baseUrl + "catalog").subscribe(
      (result) => {
        this.cars = result;
        if (this.cars) {
          for (let car of this.cars) {
            car.photo = this.sanitizer.bypassSecurityTrustUrl(
              "data:image/jpeg;base64," + car.photo
            );
          }
        }
      },
      (error) => console.error(error)
    );
  }
  ngOnInit() {
    this.searchForm = new FormGroup({
      searchInput: new FormControl(),
    });
  }
  RedirectToForm(id: number) {
    this.router.navigate(["/request-form/" + id]);
  }

  Send() {
    console.log(this.searchForm.value);
    this.http
      .get<Car[]>(this.baseUrl + "catalog/search", {
        params: { searchLine: this.searchForm.value.searchInput },
      })
      .subscribe(
        (result) => {
          this.cars = result;
          if (this.cars) {
            for (let car of this.cars) {
              car.photo = this.sanitizer.bypassSecurityTrustUrl(
                "data:image/jpeg;base64," + car.photo
              );
            }
          }
        },
        (error) => console.error(error)
      );
  }

  PassDataToModal(logo: any, description: any, name: any) {
    this.logo = logo;
    this.description = description;
    this.name = name;
  }
}
export interface Car {
  id: number;
  brand: Brand;
  brandId: number;
  model: string;
  engineType: string;
  engineSize: number;
  year: number;
  price: number;
  photo: any;
}
export interface Brand {
  id: number;
  name: string;
  logo: string;
  description: string;
}
