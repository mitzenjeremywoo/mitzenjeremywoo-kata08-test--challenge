import './App.css';
import ProductContainer from "./Components/ProductContainer";

const storeItems = [
  {
    id: 1,
    name: "Apple",
    unitPrice: 2.0,
    special: {
      type: "bulk",
      quantity: 3,
      price: 5.0,
    },
  },
  {
    id: 2,
    name: "Orange",
    unitPrice: 1.5,
    special: {
      type: "bofo",
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

function App() {
  return (
    <div className="App">
    <header className="App-header">
       <ProductContainer/>
    </header>
    </div>
  );
}

export default App;
