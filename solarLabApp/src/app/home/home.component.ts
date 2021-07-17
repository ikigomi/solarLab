import { Component, OnInit } from '@angular/core';
import { Person } from '../models/Person';
import { PersonService } from '../services/person.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit{
  days:number=5;
  current: Person[]=[];
  upcoming: Person[]=[];
  constructor(private personService:PersonService) { }

  ngOnInit(): void {       
    this.fetchData(0, this.current);
    this.fetchData(this.days, this.upcoming);
  }

  fetchData(days:number, arr:Person[]) {
    this.personService.getUpcoming(days).subscribe({
      next: (data:Person[]) => {data.forEach(val => arr.push(val));},     
    });
  }

  updateUpcoming(days:any) {
    this.upcoming=[];
    this.days= days > 0 ? days:0;
    this.fetchData(this.days, this.upcoming);
  }
}
