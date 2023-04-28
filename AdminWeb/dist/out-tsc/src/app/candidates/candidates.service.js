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
var http_1 = require("@angular/common/http");
var httpOptions = {
    headers: new http_1.HttpHeaders({ 'Content-Type': 'application/json' })
};
var CandidatesService = /** @class */ (function () {
    function CandidatesService(http) {
        this.http = http;
        this.url = 'https://localhost:5001/api/admin'; //https://localhost:5001
    }
    //https://superadminbackend.herokuapp.com/api/admin
    CandidatesService.prototype.getCandidateForms = function () {
        return this.http.get(this.url + "/FormView");
    };
    CandidatesService.prototype.getCandidates = function (id) {
        return this.http.get(this.url + "/get-candidates/" + id);
    };
    CandidatesService.prototype.getDetails = function (id) {
        return this.http.get(this.url + "/detailcandidate/" + id);
    };
    CandidatesService.prototype.deleteCandidate = function (ids) {
        return this.http.post(this.url + "/delete/", ids);
    };
    CandidatesService.prototype.createCandidates = function (candidates) {
        return this.http.post(this.url + "/add-candidates", candidates);
    };
    CandidatesService.prototype.updateCandidates = function (candidates) {
        return this.http.put(this.url + "/update-candidates", candidates);
    };
    CandidatesService = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [http_1.HttpClient])
    ], CandidatesService);
    return CandidatesService;
}());
exports.CandidatesService = CandidatesService;
//# sourceMappingURL=candidates.service.js.map