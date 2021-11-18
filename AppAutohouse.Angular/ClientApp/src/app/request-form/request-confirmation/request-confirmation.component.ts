import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-request-confirmation",
  templateUrl: "./request-confirmation.component.html",
  styleUrls: ["./request-confirmation.component.css"],
})
export class RequestConfirmationComponent implements OnInit {
  public name: string;
  constructor() {
    this.name = localStorage.getItem("name");
  }

  ngOnInit() {}
}
