import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CandidateForms } from '../models/CandidateForms.model';
import { CandidatesService } from './candidates.service';

@Component({
  selector: 'app-candidates-read',
  templateUrl: './candidates.component.html',
  styles: []
})
export class CandidatesComponent implements OnInit {

  candidates: CandidateForms[];
  selected: number[] = [];

  constructor(private router: Router, private candidatesService: CandidatesService) { }

  ngOnInit() {
    this.candidatesService.getCandidateForms()
      .subscribe(data => {
        this.candidates = data;
        this.candidates.forEach(x => x.checked = false)
      });
  };

  selectedCandidate(id) {

    if (!this.selected.includes(id)) {
      this.selected.push(id);
    } else {
      this.selected.splice(this.selected.indexOf(id), 1);
    }
    console.log(this.selected)
  }

  deletCandidate(id) {
    if (id != 0) {
      const ids = [id];
      this.candidatesService.deleteCandidate(ids)
        .subscribe(data => {
          if (data) {
            this.candidates = this.candidates.filter(u => u.idCandidate !== id);
          }
        })
    } else {
      this.candidatesService.deleteCandidate(this.selected)
        .subscribe(data => {
          if (data) {
            this.candidates = this.candidates.filter(u => !this.selected.includes(u.idCandidate));
          }
        })
    }
  }

}