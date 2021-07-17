import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Address } from '../models/Address';
import { AddressService } from '../services/address.service';

@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.scss']
})
export class AddressComponent implements OnInit {
  addresses!:Address[];
  addForm!:FormGroup;
  constructor(private addressService:AddressService,
              private fb:FormBuilder) {
    this.addForm = this.fb.group({
      'email':['', [Validators.required, Validators.email]],
      'days':['', Validators.required],
    })
   }

   get email() {
    return this.addForm.get('email');
  }

  get days() {
    return this.addForm.get('days');
  }

  ngOnInit(): void {
    this.fetchData();
  }

  fetchData() {
    this.addressService.getAddresses().subscribe({
      next: (data:Address[])=>{this.addresses=data;}
    });
  }

  onDelete(id:number) {
    if(confirm("Удалить запись?")) {
      this.addressService.delete(id).subscribe(
        {
          next: ()=>{this.addresses.splice(this.addresses.findIndex(x=>x.id==id),1);}
        }
      )
    }
  }

  create() {
    this.addressService.create(this.addForm.value).subscribe({
      next: (data)=>{this.addresses.push(data);}
    });
  }

  update(address:Address, days:any) {
    address.days=days;
    this.addressService.update(address).subscribe({
      next: ()=>{}
    });
  }

}
