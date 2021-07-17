import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Address } from '../models/Address';

@Injectable({
  providedIn: 'root'
})
export class AddressService {
  private addressUrl = environment.apiUrl+"addresses";

  constructor(private http:HttpClient) { }

  getAddresses() {
    return this.http.get<Address[]>(this.addressUrl);
  }

  getAddress(id:number) {
    return this.http.get<Address>(this.addressUrl+'/'+id);
  }

  create(data:any) {
    return this.http.post<Address>(this.addressUrl, data);
  }

  delete(id:number) {
    return this.http.delete(this.addressUrl+'/'+id);
  }

  update(data:any) {
    return this.http.put(this.addressUrl, data);
  }
}
