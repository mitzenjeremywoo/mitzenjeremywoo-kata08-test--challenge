import { render, screen, fireEvent, waitFor  } from "@testing-library/react";
import { ProductItem } from "./ProductItem";
import {act} from 'react';

const bulkSpecialProductMockData = {
  id: 1,
  name: "Apple",
  unitPrice: 2.0,
  special: {
    type: "bulk",
    quantity: 3,
    price: 5.0,
  },
};

const unitSpecialProductMockData = {
  id: 1,
  name: "Orange",
  unitPrice: 2.0,
};

describe("Product Item loading special offers", () => {
  it("loads bulk offers correctly", () => {
    render(<ProductItem item={bulkSpecialProductMockData}/>);
    expect(screen.getByText("Apple")).toBeInTheDocument();
    expect(screen.getByText("Special: Buy 3 for $5.00")).toBeInTheDocument();
  }) 
    
  it("loads unit price offers correctly", () => {
    render(<ProductItem item={unitSpecialProductMockData}/>);
    expect(screen.getByText("Orange")).toBeInTheDocument();
    waitFor(() => { 
      expect(screen.getByText("Unit Price")).toBeInTheDocument();
      expect(screen.getByText("Special")).not.toBeInTheDocument();  
    });
  })

  it("ensure unit price total are correctly calculated", () => {
    const { debug } = render(<ProductItem item={unitSpecialProductMockData}/>);

    const input = screen.getByRole("spinbutton");
    fireEvent.change(input, { target: { value: "5"}})   
    expect(screen.getByText("Orange")).toBeInTheDocument();
    waitFor(() => {
      expect(screen.getByText("10.00")).toBeInTheDocument();
    });    
  })
})
