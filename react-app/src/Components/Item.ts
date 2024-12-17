
export interface SpecialOffer {
  type: string; 
  quantity: number;
  price?: number;        // For "bulk" offers
  freeQuantity?: number; // For "bofo" offers
}

export interface Item {
  id: number;
  name: string;
  unitPrice: number;
  special?: SpecialOffer;
}

export interface ProductItemProps {
  item: Item;
}
