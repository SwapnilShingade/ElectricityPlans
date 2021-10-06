import { Component, OnInit } from '@angular/core';
import { ProductService } from '../shared/products-data.service';
import { ToastrService } from 'ngx-toastr';
import { Product, ProductGrid } from '../shared/products-model';



@Component({
  selector: 'product',
  templateUrl: 'product.component.html',
  styleUrls: ['product.component.scss']
})

export class ProductComponent implements OnInit {
  usage: number;
  showPlans = false;
  isLoading = false;  
  displayedColumns: string[] = ['type', 'name', 'baseCost', 'consumptionCharge', 'tariff'];
  dataSource: Product[];
  productGrid: ProductGrid[];
  constructor(private productService: ProductService, private toastrService: ToastrService) { }

  ngOnInit() {
    this.getProducts();
  }
  compare() {
    if (this.usage > 0) {
      this.isLoading = true;
      this.productService.compareProducts(this.usage).subscribe((products: any) => {
        this.isLoading = false;
        this.showPlans = true;
        this.toastrService.success("Comparison Results are Ready!!")
        this.dataSource = products;
      },
        error => {
          this.isLoading = false;
          this.showPlans = false;
          this.toastrService.error("Error Occured: " + error);
        });
    } else {
      this.toastrService.info("Usage should be greater than 0 kWh/year.")

    }
  }

  getProducts() {
    this.isLoading = true;
    this.productService.getProducts().subscribe((products: ProductGrid[]) => {
      this.isLoading = false;
      this.productGrid = products;
      this
    },
      error => {
        this.isLoading = false;
        this.toastrService.error("Error Occured: " + error);
      }
    )
  }

  checkUsage()
  {
     return this.usage != null ? false: true;
  }
}