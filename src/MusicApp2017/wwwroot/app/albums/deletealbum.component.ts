import { Component } from '@angular/core';
import { Http, Headers } from '@angular/http';

@Component({
    selector: 'deletealbum',
    templateUrl: './deletealbum.component.html'
})

export class DeleteAlbumComponent {
    public album: Album;
    constructor(private http: Http) {
        this.http = http;
    }
    deleteAlbum(id: number) {
        this.http.delete('/api/albums/' + id, { params: { id: id } });
    }
}

interface Album {
    albumID: number;
    title: string;
    artist: string;
    genre: string;
}