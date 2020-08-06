import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { flatMap } from 'rxjs/operators';

import { CustomerService } from '../services';
import { Customer } from '../models';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {

  public newCustomer: Customer = {
    id: undefined,
    name: undefined,
    type: undefined
  };

  public customers: Customer[] = [];

  constructor(
    private customerService: CustomerService
  ) { }

  ngOnInit() {
    this.customerService.getCustomers().subscribe(data => {
      this.customers = data;
    });
  }

  createCustomer(form: NgForm) {
    if (form.invalid) {
      alert('form is not valid');
    }
    else {
      this.customerService.createCustomer(this.newCustomer).pipe(flatMap(data => {
        return this.customerService.getCustomers();
      })).subscribe(data => {
        this.customers = data;
      });
    }
  }
}
