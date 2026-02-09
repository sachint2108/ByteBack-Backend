import axios from 'axios';

const API_URL = 'https://byteback-backend.onrender.com/api/products';

export interface Product {
  id: string;        
    name: string;      
    price: number;     
    imageUrl: string;  
    description: string;
    category: string;
    condition: string;
    isSold: boolean;
}

export const fetchProducts = async (): Promise<Product[]> => {
  try 
  {
    console.log('Fetching from: ', API_URL);
    const response = await axios.get(API_URL);
    console.log('Response data: ', response.data);
    return response.data;
  }
  catch (error) {
    console.error('Error fetching products:', error);
    return [];
  }
};
