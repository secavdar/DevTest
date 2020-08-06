import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { CustomerService } from '../services';
import { Customer } from '../models';

@Component({
  selector: 'app-customer-detail',
  templateUrl: './customer-detail.component.html',
  styleUrls: ['./customer-detail.component.scss']
})
export class CustomerDetailComponent implements OnInit {

  public customer: Customer;

  constructor(
    private route: ActivatedRoute,
    private customerService: CustomerService
  ) { }

  ngOnInit() {
    let customerId = this.route.snapshot.params.id;

    this.customerService.getCustomer(customerId).subscribe(data => {
      this.customer = data;
    });
  }
}
