import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { CandidatesComponent } from './candidates/candidates.component';
import { AppRoutingModule } from './app.routing.module';
import { HttpClientModule } from '@angular/common/http';
import { CandidatesService } from './candidates/candidates.service';
import { DetailsCandidatesComponent } from './candidates/details-candidates.component';


@NgModule({
  declarations: [
    AppComponent,
    CandidatesComponent,
    DetailsCandidatesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [CandidatesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
