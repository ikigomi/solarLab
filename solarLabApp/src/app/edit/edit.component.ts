import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Person } from '../models/Person';
import { PersonService } from '../services/person.service';
import { UploadService } from '../services/upload.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss']
})
export class EditComponent implements OnInit {
  creationForm:FormGroup;
  imageUrl!:string;
  file:any;
  person!:Person;

  constructor(private fb:FormBuilder,
    private route:ActivatedRoute,
    private router:Router,
    private personService:PersonService,
    private uploadService:UploadService) {
      this.creationForm = this.fb.group({
        'id':[''],
        'firstName':['', Validators.required],
        'lastName':['', Validators.required],
        'email':['', [Validators.required, Validators.email]],
        'birthday':['', Validators.required],
        'imgUrl':[''],

      })
     }

  ngOnInit(): void {
    this.route.params.subscribe({
      next: (params)=> {
        let id = params['id'];
        if(id) {        
          this.personService.getPerson(id).subscribe({
            next: (data)=>{              
              this.person=data;           
              this.creationForm.patchValue(this.person);
            }
          });
        }
      }
    });
  }

  get firstName() {
    return this.creationForm.get('firstName');
  }

  get lastName() {
    return this.creationForm.get('lastName');
  }

  get email() {
    return this.creationForm.get('email');
  }

  get birthday() {
    return this.creationForm.get('birthday');
  }
  
  get imgUrl() {
    return this.creationForm.get('imgUrl');
  }

  set setFile(val:any) {
    this.file=val;
  }

  create() {
    this.uploadService.upload(this.file)?.subscribe({
      next: (data)=>{
        this.imageUrl=data['path'];
        this.creationForm.patchValue({'imgUrl':this.imageUrl});
        this.personService.create(this.creationForm.value).subscribe({
          complete: ()=> {this.router.navigate(['list']);}
        });
      }
    });
  }

  update() {
    this.personService.update(this.creationForm.value).subscribe({
      complete: ()=> {this.router.navigate(['list']);}
    });
  }

}
