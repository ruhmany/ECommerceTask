import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from 'src/Models/Products';
import { ProductListService } from 'src/Services/Product.service';

@Component({
  selector: 'app-coursedetails',
  templateUrl: './coursedetails.component.html',
  styleUrls: ['./coursedetails.component.css'],
})
export class CoursedetailsComponent {
  product: Product | null = null;
  constructor(public productService: ProductListService, private activatedRoute: ActivatedRoute) {
    this.activatedRoute.paramMap.subscribe({
      next: params => {
        let productCode = params.get("id")
        if (productCode)
          this.getProduct(productCode);
      }
    })
  }
  getProduct(productCode: string) {
    this.productService.getProduct(productCode).subscribe({
      next: response => this.product = response
    })
  }
}