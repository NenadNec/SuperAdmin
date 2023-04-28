import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CandidatesService } from './candidates.service';


@Component({
  selector: 'app-candidates-details',
  templateUrl: './details-candidates.component.html',
})
export class DetailsCandidatesComponent implements OnInit {

  candidates: any = {};
  details: any;

  constructor(private router: Router, private route: ActivatedRoute, private candidatesService: CandidatesService) {
    
  }

  ngOnInit() {
    this.candidatesService.getDetails(this.route.snapshot.params['id']).subscribe(data =>{ console.log(data), this.details = data});
  };

  updateCandidates(): void {
    this.candidatesService.updateCandidates(this.candidates)
      .subscribe(data => {
        alert("Candidates updated successfully.");
        this.router.navigate(['/candidatess']);
      });

  };

}