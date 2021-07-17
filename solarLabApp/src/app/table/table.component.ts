import { Component, Input, OnInit } from '@angular/core';
import { Person } from '../models/Person';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss']
})
export class TableComponent implements OnInit {
  @Input() persons?: Person[];
  constructor() { }

  ngOnInit(): void {
    
  }

}
