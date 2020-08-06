import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Customer } from '../models';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(
    private httpClient: HttpClient
  ) { }

  public getCustomers(): Observable<Customer[]> {
    return this.httpClient.get<Customer[]>('customer');
  }

  public getCustomer(id: number): Observable<Customer> {
    return this.httpClient.get<Customer>('customer/' + id);
  }

  public createCustomer(customer: Customer): Observable<object> {
    return this.httpClient.post('customer', customer);
  }
}
