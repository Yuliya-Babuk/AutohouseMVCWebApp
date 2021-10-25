import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

interface Request{
  name: string;
  surname: string;
  phoneNumber: string;
  carId: number;  
}

@Component({
  selector: 'app-request-form',
  templateUrl: './request-form.component.html',
  styleUrls: ['./request-form.component.scss']
})
export class RequestFormComponent implements OnInit {
  requestErrors: string []=[];
  requestForm: FormGroup
  constructor(public http: HttpClient, @Inject('BASE_URL')public baseUrl: string,public route:ActivatedRoute,public router: Router) {    
  }

  ngOnInit() {
  this.requestForm = new FormGroup({ 
    name: new FormControl(),
    surname: new FormControl(),
    phoneNumber: new FormControl(),
    carId: new FormControl()     
  }) }

  Send() {    
    let param:any;
    this.route.params.subscribe(x=>{param=x}) ;  
    this.requestForm.value.carId= param.id; 
    this.http.post<any>(this.baseUrl + 'request/add', this.requestForm.value).subscribe(result => {
      console.log("test");    
    this.router.navigate(['/']);  
    
    }, error => {
      this.requestErrors = [];
      let errorKeys=Object.getOwnPropertyNames(error.error.errors);
      for (let errorKey of errorKeys)
      {
        if(Array.isArray(error.error.errors[errorKey]))
        {
        for(let errorMessage of error.error.errors[errorKey]){
          this.requestErrors.push(errorKey + ':' + errorMessage);
        }
        } else{
          this.requestErrors.push(error.error.errors[errorKey]);
        }   
      };
    });
  }

}

