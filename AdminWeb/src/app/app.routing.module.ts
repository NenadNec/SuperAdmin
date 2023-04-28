import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CandidatesComponent } from './candidates/candidates.component';
import { DetailsCandidatesComponent } from './candidates/details-candidates.component';

const routes: Routes = [
  { path: 'forms', component: CandidatesComponent },
  { path: 'details/:id', component: DetailsCandidatesComponent },
  { path: '', redirectTo: '/forms', pathMatch: 'full'}
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ],
  declarations: []
})
export class AppRoutingModule { }