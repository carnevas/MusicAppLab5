import { Pipe, PipeTransform } from '@angular/core';
import { Injectable } from '@angular/core';
import { Component } from '@angular/core';
@Component({
    selector: 'searchalbums'
    templateUrl: './searchalbums.component.html'
})

@Pipe({
    name: 'searchAlbums',
    pure: false
})

@Injectable()
export class SearchAlbumsPipe implements PipeTransform {
    transform(albums: any[], args: any[]): any {
        albums.filter(album => album.title.toLowerCase().indexOf(args[0].toLowerCase()) !== -1);
        albums.filter(album => album.artist.name.toLowerCase().indexOf(args[0].toLowerCase()) !== -1);
        albums.filter(album => album.genre.name.toLowerCase().indexOf(args[0].toLowerCase()) !== -1);
        return albums;
    }
}
