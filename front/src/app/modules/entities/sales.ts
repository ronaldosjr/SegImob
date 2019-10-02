import { SalesItem } from './sales-item';
import { Seller } from './seller';

export interface Sales {
    id?: number;
    seller?: Seller;
    sellerId?: number;
    salesItem?: SalesItem[];
    total?: number;
}
