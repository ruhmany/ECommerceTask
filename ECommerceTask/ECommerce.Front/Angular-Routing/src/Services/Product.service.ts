import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GetListOfProductsQuery } from 'src/Models/GetListOfProductsQuery';
import { Product } from 'src/Models/Products';

@Injectable({
    providedIn: 'root'
})
export class ProductListService {
    private apiUrl = 'ttps://localhost:7259/api'; // Replace with your actual API base URL

    constructor(private http: HttpClient) { }

    getList(query: GetListOfProductsQuery): Observable<any> {
        return this.http.get(`${this.apiUrl}/get-list`);
    }
    getProduct(queryParams: string): Observable<any> {
        return this.http.get<Product>(`${this.apiUrl}/get-product/${queryParams}`);
    }
}
