import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Person } from '../models/Person';


@Injectable({
  providedIn: 'root'
})
export class PersonService {

  private birthdaysUrl = environment.apiUrl+"Birthdays";

  constructor(private http: HttpClient) { }

  getPersons():Observable<Person[]> {
    return this.http.get<Person[]>(this.birthdaysUrl);
  }

  getPerson(id:number):Observable<Person> {
   return this.http.get<Person>(this.birthdaysUrl+'/'+id);
  }

  getUpcoming(days:number):Observable<Person[]> {
    return this.http.get<Person[]>(this.birthdaysUrl+'/GetUpcoming/'+days);
  }

  create(data:any):Observable<Person> {
    return this.http.post<Person>(this.birthdaysUrl, data);
  }

  update(data:any):Observable<Person> {
    return this.http.put<Person>(this.birthdaysUrl, data);
  }

  delete(id:number) {
    return this.http.delete(this.birthdaysUrl+'/'+id);
  }
}
