import { Pipe, PipeTransform } from '@angular/core';
import { Injectable } from '@angular/core';

@Pipe({
    name: 'searchAlbums',
    pure: false
})

@Injectable()
export class SearchAlbumsPipe implements PipeTransform {
    transform(albums: Album[], args: any[]): any {
        return albums.filter(album => album.title.toLowerCase().indexOf(args[0].toLowerCase()) !== -1)
         || albums.filter(album => album.artist.name.toLowerCase().indexOf(args[0].toLowerCase()) !== -1)
         || albums.filter(album => album.genre.name.toLowerCase().indexOf(args[0].toLowerCase()) !== -1);
    }
}

interface Album {
    albumID: number;
    title: string;
    artist: Artist;
    genre: Genre;
    rating: number;
}

interface Artist {
    artistID: number;
    name: string;
    bio: string;
}

interface Genre {
    genreID: number;
    name: string;
}


