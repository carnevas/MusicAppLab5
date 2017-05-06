"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var core_1 = require("@angular/core");
var core_2 = require("@angular/core");
var SearchAlbumsPipe = (function () {
    function SearchAlbumsPipe() {
    }
    SearchAlbumsPipe.prototype.transform = function (albums, search) {
        if (search == null) {
            return albums;
        }
        else {
            return albums.filter(function (album) {
                return album.title.toLowerCase().indexOf(search.toLowerCase()) !== -1
                    || album.artist.name.toLowerCase().indexOf(search.toLowerCase()) !== -1
                    || album.genre.name.toLowerCase().indexOf(search.toLowerCase()) !== -1;
            });
        }
    };
    return SearchAlbumsPipe;
}());
SearchAlbumsPipe = __decorate([
    core_1.Pipe({
        name: 'searchAlbums',
        pure: false
    }),
    core_2.Injectable()
], SearchAlbumsPipe);
exports.SearchAlbumsPipe = SearchAlbumsPipe;
//# sourceMappingURL=searchalbums.pipe.js.map