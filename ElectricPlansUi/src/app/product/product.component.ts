import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { ProductService } from '../shared/products-data.service';
import { ToastrService } from 'ngx-toastr';
import { Product, ProductGrid } from '../shared/products-model';
import {MatTableDataSource} from '@angular/material/table';
import { MatSort } from '@angular/material';



@Component({
  selector: 'product',
  templateUrl: 'product.component.html',
  styleUrls: ['product.component.scss']
})

export class ProductComponent implements OnInit, AfterViewInit {
  usage: number;
  showPlans = false;
  isLoading = false;  
  displayedColumns: string[] = ['type', 'name', 'baseCost', 'consumptionCharge', 'tariff'];
  dataSource  = new MatTableDataSource;
  productGrid: ProductGrid[];
  constructor(private productService: ProductService, private toastrService: ToastrService) { }

  @ViewChild(MatSort) sort: MatSort;

  ngOnInit() {
    this.getProducts();    
  }

  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
  }
  compare() {
    if (this.usage > 0) {
      this.isLoading = true;
      this.productService.compareProducts(this.usage).subscribe((products: any) => {
        this.isLoading = false;
        this.showPlans = true;
        this.toastrService.success("Comparison Results are Ready!!")
        this.dataSource.data = products;        
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