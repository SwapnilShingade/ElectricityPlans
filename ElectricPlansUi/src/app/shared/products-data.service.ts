import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable()
export class ProductService {
    public baseUrl = 'api'
    public apiUrl = 'http://localhost:62191/api/verivox/';

    constructor(private http: HttpClient) { }

    getProducts() {
        return this.http.get(this.apiUrl + 'Products');
    }

    compareProducts(usage: number) {
        return this.http.get(this.apiUrl + "Products/Compare?usage=" + usage);
    }
}