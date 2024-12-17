import { ProductItem } from "./ProductItem";
import { useEffect, useState } from "react";
import { Item } from "./Item";
import { ProductFetchEndpoint } from "../AppConstant";
import { CalculateTotal } from "./CalculateTotal";

const ProductContainer = () => {

  const [items, setStoreItems] = useState<Item[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchProducts = async () => {
      try {
        setLoading(true);
        setError(null);

        const response = await fetch(ProductFetchEndpoint);
        if (!response.ok) {
          throw new Error("Failed to fetch products");
        }
        const data: Item[] = await response.json();
        setStoreItems(data);
      } catch (err) {
        setError((err as Error).message);
      } finally {
        setLoading(false);
      }
    };

    fetchProducts();
  }, []);

  if (loading) {
    return <p>Loading products...</p>;
  }

  if (error) {
    return <p>Error: {error}</p>;
  }

  return (
      <div>
        {items.map((item) => (
          <ProductItem key={item.id} item={item} />
        ))}

        <div> 
          <CalculateTotal items={items}/>
        </div>
      </div>
    );
  };
  
  export default ProductContainer;