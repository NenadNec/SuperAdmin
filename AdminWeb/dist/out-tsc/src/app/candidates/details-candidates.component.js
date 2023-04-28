"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var router_1 = require("@angular/router");
var candidates_service_1 = require("./candidates.service");
var DetailsCandidatesComponent = /** @class */ (function () {
    function DetailsCandidatesComponent(router, route, candidatesService) {
        this.router = router;
        this.route = route;
        this.candidatesService = candidatesService;
        this.candidates = {};
    }
    DetailsCandidatesComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.candidatesService.getDetails(this.route.snapshot.params['id']).subscribe(function (data) { console.log(data), _this.details = data; });
    };
    ;
    DetailsCandidatesComponent.prototype.updateCandidates = function () {
        var _this = this;
        this.candidatesService.updateCandidates(this.candidates)
            .subscribe(function (data) {
            alert("Candidates updated successfully.");
            _this.router.navigate(['/candidatess']);
        });
    };
    ;
    DetailsCandidatesComponent = __decorate([
        core_1.Component({
            selector: 'app-candidates-details',
            templateUrl: './details-candidates.component.html',
        }),
        __metadata("design:paramtypes", [router_1.Router, router_1.ActivatedRoute, candidates_service_1.CandidatesService])
    ], DetailsCandidatesComponent);
    return DetailsCandidatesComponent;
}());
exports.DetailsCandidatesComponent = DetailsCandidatesComponent;
//# sourceMappingURL=details-candidates.component.js.map