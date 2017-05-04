import { Component } from '@angular/core';
import { Http } from '@angular/http';

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
    filter() {
        var filter, table, tr, td, i;
        var input = document.getElementById("search");
        filter = input.nodeValue.toLowerCase();
        table = document.getElementById("albums");
        tr = table.getElementsByTagName("tr");
        for (i = 0; i < tr.length; i++) {
            td = tr[i].getElementsByTagName("td");
            for (var j = 0; j < td.length; j++) {
                var item = td[j];
                if (item) {
                    if (item.innerHTML.toLowerCase().indexOf(filter) > -1) {
                        tr[i].style.display = "";
                    } else {
                        tr[i].style.display = "none";
                    }
                }
            }
        }
    }
}

interface Album {
    albumID: number;
    title: string;
    artist: string;
    genre: string;
    rating: number;
}