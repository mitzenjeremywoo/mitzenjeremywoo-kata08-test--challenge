import { render, screen, waitFor  } from "@testing-library/react";
import ProductContainer from "./ProductContainer";
import { BuyOneFreeOneSpecialOffer, BulkBuySpecialOffer } from "../AppConstant";

global.fetch = jest.fn(() =>
  Promise.resolve({
    ok: true,
    json: () =>
      Promise.resolve(storeItems),
  })
) as jest.Mock;

const storeItems = [
  {
    id: 1,
    name: "Apple",
    unitPrice: 2.0,
    special: {
      type: BulkBuySpecialOffer,
      quantity: 3,
      price: 5.0,
    },
  },
  {
    id: 2,
    name: "Orange",
    unitPrice: 1.5,
    special: {
      type: BuyOneFreeOneSpecialOffer,
      quantity: 2,
      freeQuantity: 1,
    },
  },
  {
    id: 3,
    name: "Banana",
    unitPrice: 1.0,
  },
];

describe("Product Container loading stores items correctly", () => {

  it("product prices loads correctly from the API endpoint", () => {
    render(<ProductContainer />);
    
    expect(screen.getByText("Loading products...")).toBeInTheDocument();

    waitFor(() => {
      expect(screen.getByText("Apple")).toBeInTheDocument();
      expect(screen.getByText("Buy 3 for $5.00")).toBeInTheDocument();
      expect(screen.getByText("Orange")).toBeInTheDocument();
      expect(screen.getByText("Special: Buy 2 get 1 free")).toBeInTheDocument();
      expect(screen.getByText("Banana")).toBeInTheDocument();
    });    
  })
})
