import React, { useState } from "react";
import { ProductItemProps }  from "./Item"
import { BuyOneFreeOneSpecialOffer, BulkBuySpecialOffer } from "../AppConstant";

export const ProductItem: React.FC<ProductItemProps> = ({ item }) => {
  const [quantity, setQuantity] = useState(1);

  const calculatePrice = (): number => {
    const { unitPrice, special } = item;

    if (!special) {
      return unitPrice * quantity;
    }

    if (special.type === BulkBuySpecialOffer && special.price) {
      const bulkSets = Math.floor(quantity / special.quantity);
      const remainingItems = quantity % special.quantity;
      return bulkSets * special.price + remainingItems * unitPrice;
    }

    if (special.type === BuyOneFreeOneSpecialOffer && special.freeQuantity) {
      const paidItems = Math.ceil(quantity / (special.quantity + special.freeQuantity)) * special.quantity;
      return paidItems * unitPrice;
    }

    return unitPrice * quantity; // return unit price as default 
  };

  return (
    <div style={{ border: "1px solid #ccc", padding: "10px", margin: "10px" }}>
      <h3>{item.name}</h3>
      <p>Unit Price: ${item.unitPrice.toFixed(2)}</p>
      {item.special && (
        <p>
          Special:{" "}
          {item.special.type === BulkBuySpecialOffer && item.special.price
            ? `Buy ${item.special.quantity} for $${item.special.price.toFixed(2)}`
            : item.special.type === BuyOneFreeOneSpecialOffer && item.special.freeQuantity
            ? `Buy ${item.special.quantity} get ${item.special.freeQuantity} free`
            : ""}
        </p>
      )}

      <input
        type="number"
        min="1"
        value={quantity}
        className="storeInput"
        onChange={(e) => setQuantity(Number(e.target.value))}
        style={{  width: "50px", marginRight: "10px" }}
        
      />
      <p>Total Price: ${calculatePrice().toFixed(2)}</p>
    </div>
  );
};