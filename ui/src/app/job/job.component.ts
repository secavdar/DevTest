import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

import { EngineerService, JobService, CustomerService } from '../services';
import { JobModel, Customer } from '../models';

@Component({
  selector: 'app-job',
  templateUrl: './job.component.html',
  styleUrls: ['./job.component.scss']
})
export class JobComponent implements OnInit {

  public engineers: string[] = [];
  public customers: Customer[] = [];

  public jobs: JobModel[] = [];

  public newJob: JobModel = {
    jobId: null,
    engineer: undefined,
    customer: undefined,
    when: null
  };

  constructor(
    private engineerService: EngineerService,
    private jobService: JobService,
    private customerService: CustomerService
  ) { }

  ngOnInit() {
    this.engineerService.GetEngineers().subscribe(engineers => this.engineers = engineers);
    this.customerService.getCustomers().subscribe(customers => this.customers = customers);
    this.jobService.GetJobs().subscribe(jobs => this.jobs = jobs);
  }

  public createJob(form: NgForm): void {
    if (form.invalid) {
      alert('form is not valid');
    } else {
      this.jobService.CreateJob(this.newJob).then(() => {
        this.jobService.GetJobs().subscribe(jobs => this.jobs = jobs);
      });
    }
  }

}
