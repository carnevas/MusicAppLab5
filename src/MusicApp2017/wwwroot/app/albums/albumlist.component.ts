import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { SearchAlbumsPipe } from './searchalbums.pipe';

@Component({
    selector: 'albumlist',
    templateUrl: './albumlist.component.html'
})

export class AlbumListComponent {
    public albums: Album[];
    constructor(http: Http) {
        http.get('/api/albums').subscribe(result => {
            this.albums = result.json();
        });
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