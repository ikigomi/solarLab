import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddressComponent } from './address/address.component';
import { EditComponent } from './edit/edit.component';
import { FullListComponent } from './full-list/full-list.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { path: 'list', component: FullListComponent},
  { path: 'edit', component: EditComponent},
  { path: 'edit/:id', component: EditComponent},
  { path: 'address', component: AddressComponent},
  { path: '**', component: HomeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
