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
var core_1 = require("@angular/core");
var http_1 = require("@angular/http");
var router_1 = require("@angular/router");
var AlbumComponent = (function () {
    function AlbumComponent(http, route, router) {
        var _this = this;
        this.http = http;
        this.showForm = false;
        this.router = router;
        var id = route.snapshot.params['id'];
        http.get('/api/albums/' + id).subscribe(function (result) {
            _this.album = result.json();
        });
        http.get('/api/artists').subscribe(function (result) {
            _this.artists = result.json();
        });
        http.get('/api/genres').subscribe(function (result) {
            _this.genres = result.json();
        });
    }
    AlbumComponent.prototype.deleteAlbum = function () {
        var _this = this;
        this.http.delete('/api/albums/' + this.album.albumID).subscribe(function (res) { return _this.deleteResponse = res.json(); });
        this.router.navigateByUrl("./albums");
    };
    AlbumComponent.prototype.onSubmit = function (form) {
        var _this = this;
        var headers = new http_1.Headers();
        headers.append('Content-Type', 'application/json');
        this.http.put('/api/albums/' + this.album.albumID, JSON.stringify(this.album), { headers: headers }).subscribe(function (res) { return _this.putResponse = res.json(); });
        form.reset();
        this.showForm = !this.showForm;
    };
    AlbumComponent.prototype.toggleForm = function () {
        this.showForm = !this.showForm;
    };
    return AlbumComponent;
}());
AlbumComponent = __decorate([
    core_1.Component({
        selector: 'album',
        templateUrl: './album.component.html'
    }),
    __metadata("design:paramtypes", [http_1.Http, router_1.ActivatedRoute, router_1.Router])
], AlbumComponent);
exports.AlbumComponent = AlbumComponent;
var Album = (function () {
    function Album(albumID, title, artistID, genreID, rating) {
        if (albumID === void 0) { albumID = 0; }
        if (title === void 0) { title = null; }
        if (artistID === void 0) { artistID = 0; }
        if (genreID === void 0) { genreID = 0; }
        if (rating === void 0) { rating = 0; }
        this.albumID = albumID;
        this.title = title;
        this.artistID = artistID;
        this.genreID = genreID;
        this.rating = rating;
    }
    return Album;
}());
//# sourceMappingURL=album.component.js.map