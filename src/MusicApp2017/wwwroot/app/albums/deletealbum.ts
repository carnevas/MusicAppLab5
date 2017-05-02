import { Component } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'deletealbum',
    templateUrl: './deletealbum.component.html'
})

export class DeleteAlbumComponent {
    public album: Album;
    constructor(http: Http, route: ActivatedRoute) {
        var id = route.snapshot.params['id'];
        http.delete('/api/albums/' + id).subscribe(result => {
            this.album = result.json();
        })
    }
}

interface Album {
    albumID: number;
    title: string;
    artist: string;
    genre: string;
}
}