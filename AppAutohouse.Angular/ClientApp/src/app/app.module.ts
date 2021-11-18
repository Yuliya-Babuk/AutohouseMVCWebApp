import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { RouterModule } from "@angular/router";
import { AppComponent } from "./app.component";
import { NavMenuComponent } from "./nav-menu/nav-menu.component";
import { CatalogComponent } from "./catalog/catalog.component";
import { RequestFormComponent } from "./request-form/request-form.component";
import { CommonModule } from "@angular/common";
import { RequestConfirmationComponent } from "./request-form/request-confirmation/request-confirmation.component";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    CatalogComponent,
    RequestFormComponent,
    RequestConfirmationComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    CommonModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: "", component: CatalogComponent, pathMatch: "full" },
      { path: "request-form/:id", component: RequestFormComponent },
      { path: "catalog", component: CatalogComponent },
      { path: "confirmation", component: RequestConfirmationComponent },
    ]),
  ],
  providers: [],
  exports: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
