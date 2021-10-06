export interface Product {
    type: string;
    name: string;
    baseCost: number;
    consumptionCharge: number;
    tariff: number
  }
  
  export interface ProductGrid extends Product {
    description: string,  
  }