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
  public searchLine: string;
  public pagesAmount: number;
  public currentPage: number = 1;
  public resultSource: ResultSource;

  constructor(
    public http: HttpClient,
    @Inject("BASE_URL") public baseUrl: string,
    public router: Router,
    public sanitizer: DomSanitizer
  ) {
    this.GetCatalog();
  }
  ngOnInit() {}

  RedirectToForm(id: number) {
    this.router.navigate(["/request-form/" + id]);
  }

  KeyUp(isFromSearchLine: boolean = true) {
    if (isFromSearchLine) this.currentPage = 1;
    this.http
      .get<[Car[], number]>(this.baseUrl + "catalog/search", {
        params: {
          searchLine: this.searchLine,
          pageNumber: this.currentPage.toString(),
        },
      })
      .subscribe(
        (result) => {
          this.resultSource = ResultSource.Search;
          this.cars = result["item1"];
          this.pagesAmount = result["item2"];
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

  SetCurrentPage(index: number) {
    this.currentPage = index;
    if (this.resultSource === ResultSource.Catalog) this.GetCatalog();
    else this.KeyUp(false);
  }

  private GetCatalog() {
    this.http
      .get<[Car[], number]>(this.baseUrl + "catalog", {
        params: { pageNumber: this.currentPage.toString() },
      })
      .subscribe(
        (result) => {
          this.resultSource = ResultSource.Catalog;
          this.cars = result["item1"];
          this.pagesAmount = result["item2"];
          if (this.cars) {
            for (let car of this.cars) {
              car.photo = this.sanitizer.bypassSecurityTrustUrl(
                "data:image/jpeg;base64," + car.photo
              );
              car.engineSize.toLocaleString;
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
enum ResultSource {
  Catalog,
  Search,
}
