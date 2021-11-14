import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Bicycle } from './bicycle';

@Injectable()
export class DataService {

    private url = "/api/bicycles";

    constructor(private http: HttpClient) { }

    getBicycles() {
        return this.http.get(this.url);
    }

    getBicycleTypes() {
        return this.http.get(this.url + "/types");
    }

    getBicycle(id: number) {
        return this.http.get(this.url + '/' + id);
    }

    createBicycle(bicycle: Bicycle) {
        return this.http.post(this.url, bicycle);
    }

    editBicycle(bicycle: Bicycle) {
        return this.http.put(this.url + '/' + bicycle.id, bicycle);
    }

    deleteBicycle(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
}