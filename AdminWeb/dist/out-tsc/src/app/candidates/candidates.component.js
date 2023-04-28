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
var CandidatesComponent = /** @class */ (function () {
    function CandidatesComponent(router, candidatesService) {
        this.router = router;
        this.candidatesService = candidatesService;
        this.selected = [];
    }
    CandidatesComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.candidatesService.getCandidateForms()
            .subscribe(function (data) {
            _this.candidates = data;
            _this.candidates.forEach(function (x) { return x.checked = false; });
        });
    };
    ;
    CandidatesComponent.prototype.selectedCandidate = function (id) {
        if (!this.selected.includes(id)) {
            this.selected.push(id); //adding to array because value doesnt exists
        }
        else {
            this.selected.splice(this.selected.indexOf(id), 1); //deleting
        }
        console.log(this.selected);
    };
    CandidatesComponent.prototype.deletCandidate = function (id) {
        var _this = this;
        if (id != 0) {
            var ids = [id];
            this.candidatesService.deleteCandidate(ids)
                .subscribe(function (data) {
                if (data) {
                    _this.candidates = _this.candidates.filter(function (u) { return u.idCandidate !== id; });
                }
            });
        }
        else {
            this.candidatesService.deleteCandidate(this.selected)
                .subscribe(function (data) {
                if (data) {
                    _this.candidates = _this.candidates.filter(function (u) { return !_this.selected.includes(u.idCandidate); });
                }
            });
        }
    };
    CandidatesComponent = __decorate([
        core_1.Component({
            selector: 'app-candidates-read',
            templateUrl: './candidates.component.html',
            styles: []
        }),
        __metadata("design:paramtypes", [router_1.Router, candidates_service_1.CandidatesService])
    ], CandidatesComponent);
    return CandidatesComponent;
}());
exports.CandidatesComponent = CandidatesComponent;
//# sourceMappingURL=candidates.component.js.map