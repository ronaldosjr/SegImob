import { Product } from './product';
export interface SalesItem {
    productId?: number;
    product?: Product;
    salesId?: number;
    amount?: number;
    total?: number;
}
