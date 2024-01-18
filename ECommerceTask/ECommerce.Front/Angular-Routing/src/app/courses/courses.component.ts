import { query } from '@angular/animations';
import { Component, OnInit, inject } from '@angular/core';
import { Router } from '@angular/router';
import { GetListOfProductsQuery } from 'src/Models/GetListOfProductsQuery';
import { Product } from 'src/Models/Products';
import { ProductListService } from 'src/Services/Product.service';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.css'],
})
export class CoursesComponent implements OnInit {

  constructor(private productservice: ProductListService) { }
  products: Product[] = []
  router: Router = inject(Router)
  query: GetListOfProductsQuery = {
    pageIndex: 0, // Set your desired values
    pageSize: 10
  };
  ngOnInit() {
    this.getData()
  }

  getData() {
    this.productservice.getList(this.query).subscribe({
      next: response => {
        this.products = response.data
      },
      error: error => console.error(error)

    })
  }

  NavToCourse(param: string) {
    this.router.navigateByUrl(`Courses/Course/${param}`)
  }

  next() {
    this.products = []
    this.query.pageIndex += 1
    this.productservice.getList(this.query).subscribe({
      next: response => {
        this.products = response.data
      },
      error: error => console.error(error)

    })
  }

  prev() {
    this.products = []
    this.query.pageIndex -= 1
    this.productservice.getList(this.query).subscribe({
      next: response => {
        this.products = response.data
      },
      error: error => console.error(error)

    })
  }

}
