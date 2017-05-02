import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Http, Headers } from '@angular/http';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'updatealbum',
    templateUrl: './updatealbum.component.html'
})

export class UpdateAlbumComponent {
    public album: Album;
    postResponse: Object;
    showForm = false;
    title: string;
    artist: string;
    genre: string;
    public artists: Artist[];
    public genres: Genre[];
    constructor(private http: Http, route: ActivatedRoute) {
        var id = route.snapshot.params['id'];
        http.get('/api/albums/' + id).subscribe(result => {
            this.album = result.json();
        http.get('/api/artists').subscribe(result => {
            this.artists = result.json();
        });
        http.get('/api/genres').subscribe(result => {
            this.genres = result.json();
        });
        })
    }
    onSubmit(form: NgForm)
    {
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');
        this.http.post('/api/albums', JSON.stringify(this.album), { headers: headers }).subscribe(res => this.postResponse = res.json());
        form.reset();
        this.showForm = !this.showForm;
    }

    toggleForm()
    {
        this.showForm = !this.showForm;
    }
}

interface Album {
    albumID: number;
    title: string;
    artist: string;
    genre: string;
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