import { Component, OnInit } from '@angular/core';
import { Person } from '../models/Person';
import { PersonService } from '../services/person.service';

@Component({
  selector: 'app-full-list',
  templateUrl: './full-list.component.html',
  styleUrls: ['./full-list.component.scss']
})
export class FullListComponent implements OnInit {
  persons!:Person[];
  constructor(private personService:PersonService) { }

  ngOnInit(): void {
    this.fetchData();
  }

  onDelete(id:number) {
    if(confirm("Удалить запись?")) {
      this.personService.delete(id).subscribe({
        next: ()=>{this.fetchData();}
      })
    }
  }

  fetchData() {
    this.personService.getPersons().subscribe({
      next: (data:Person[])=>{this.persons=data;}
    });
  }

}
