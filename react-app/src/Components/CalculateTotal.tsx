import React, { useState } from "react";
import { ProductListProps } from "./ProductListProps";

export const CalculateTotal: React.FC<ProductListProps> = (items) => {
  const [message, setMessage] = useState("");

  const handleCalculate = async () => { 
    setMessage("sending over item over to the server");

    try { 

      const response = await fetch("http://localhost:5039/checkout/calculate", {
        method: "POST",
        headers: { 
          "Content-Type": "application/json"
        },
        body: JSON.stringify(items)
      });

    }
    catch (error)
    {
      console.log(error);
    }
  };

  return (
    
    <div style={{ border: "1px solid #ccc", padding: "10px", margin: "10px" }}>
      <input
        type="button"
        value="Proceed to check out"
        className="storeInput"
        onClick={(e) => handleCalculate()}
        style={{ width: "auto", marginRight: "10px" }}
      />
    </div>
  );
};