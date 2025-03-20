import {Component, inject, OnInit, TemplateRef} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Employee} from '../_models/employee';
import {RouterLink} from '@angular/router';
import {BsModalRef, BsModalService} from 'ngx-bootstrap/modal';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import {ToastrService} from 'ngx-toastr';
import {NewEmployee} from '../_models/newEmployee';

@Component({
  selector: 'app-employees',
  standalone: true,
  imports: [
    RouterLink,
    ReactiveFormsModule
  ],
  templateUrl: './employees.component.html',
  styleUrl: './employees.component.css'
})
export class EmployeesComponent implements OnInit {
  private http = inject(HttpClient);
  private toastr = inject(ToastrService);
  private modalService = inject(BsModalService);

  baseUrl: string = 'http://localhost:5276';
  allEmployes: Employee[] = [];

  newForm = new FormGroup({
    firstName: new FormControl(),
    lastName: new FormControl(),
    email: new FormControl()
  });

  modalRef?: BsModalRef;


  ngOnInit() {
    this.loadEmployeeList();
  }

  openModal(template: TemplateRef<void>) {
    this.modalRef = this.modalService.show(template);
  }

  closeModal(){
    this.modalRef?.hide();
  }

  loadEmployeeList(){
    this.http
      .get<Employee[]>(`${this.baseUrl}/api/employee/all`)
      .subscribe(
        {
          next: data => {this.allEmployes = data},
          error: (err) => this.toastr.error("Fehler beim Laden von Mitarbeitern"),
          complete: () => console.log("Request completed.")
        });
  }

  onSubmit() {
    console.warn(this.newForm.value);
    const newEmployee : NewEmployee = {
      firstMiddleName: this.newForm.value.firstName,
      lastName: this.newForm.value.lastName,
      email: this.newForm.value.email
    };

    this.http
      .post(`${this.baseUrl}/api/employee/new`, newEmployee)
      .subscribe(
        {
          next: () => {
            this.loadEmployeeList();
            this.toastr.success("Mitarbeiter erstellt!");
            this.newForm.reset();
            this.closeModal();

          },
          error: (err) => this.toastr.error("Fehler beim Erstellen des Mitarbeiters!")
        }
      )
  }
}
