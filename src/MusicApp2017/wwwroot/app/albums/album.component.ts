import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
    selector: 'album',
    templateUrl: './album.component.html'
})

export class AlbumComponent {
    public album: Album;
    showForm = false;
    public artists: Artist[];
    public genres: Genre[];
    public router: Router;
    public putResponse: Object;
    constructor(private http: Http, route: ActivatedRoute, router: Router) {
        this.router = router;
        var id = route.snapshot.params['id'];
        http.get('/api/albums/' + id).subscribe(result => {
            this.album = result.json();
        })
        http.get('/api/artists').subscribe(result => {
            this.artists = result.json();
        });
        http.get('/api/genres').subscribe(result => {
            this.genres = result.json();
        });
    }
    deleteAlbum() {
        this.http.delete('/api/albums/' + this.album.albumID).subscribe();
        this.router.navigateByUrl("./albums");
    }
    onSubmit(form: NgForm) {
        this.http.put('/api/albums/' + this.album.albumID, JSON.stringify(this.album)).subscribe(res => this.putResponse = res.json());
        form.reset();
        this.showForm = !this.showForm;
    }
    toggleForm()
    {
        this.showForm = !this.showForm;
    }
}
class Album {
    constructor(
        public albumID: number = 0,
        public title: string = null,
        public artistID: number = 0,
        public genreID: number = 0,
        public rating: number = 0
    ) { }
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