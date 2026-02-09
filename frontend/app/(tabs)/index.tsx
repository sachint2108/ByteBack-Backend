import React, { useEffect, useState } from 'react';
import { View, Text, FlatList, Image, StyleSheet, ActivityIndicator } from 'react-native';
import { fetchProducts } from '../../Services/api';

interface Product {
    id: string;
    name: string;
    price: number;
    imageUrl: string;
    condition: string;
    description: string;
    category: string;
    isSold: boolean;
}

export default function HomeScreen() {
    const [products, setProducts] = useState<Product[]>([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        loadProducts();
    }, []);

    const loadProducts = async () => {
        try {
            const data = await fetchProducts();
            console.log("Store Data:", data); 
            setProducts(data);
        } catch (error) {
            console.error("Error:", error);
        } finally {
            setLoading(false);
        }
    };

    if (loading) {
        return (
            <View style={styles.center}>
                <ActivityIndicator size="large" color="#0000ff" />
                <Text>Loading ByteBack Store...</Text>
            </View>
        );
    }

    return (
        <View style={styles.container}>
            <Text style={styles.header}>ByteBack Store</Text>
            <FlatList
                data={products}
                keyExtractor={(item) => item.id} 
                renderItem={({ item }) => (
                    <View style={styles.card}>
                        <Image 
                            source={{ uri: item.imageUrl }} 
                            style={styles.image} 
                            resizeMode="contain"
                        />
                        <View style={styles.info}>
                            <Text style={styles.name}>{item.name}</Text>
                            <Text style={styles.price}>R {item.price}</Text>
                            <Text style={styles.condition}>{item.condition}</Text>
                        </View>
                    </View>
                )}
            />
        </View>
    );
}

const styles = StyleSheet.create({
    container: { flex: 1, padding: 15, backgroundColor: '#f5f5f5' },
    center: { flex: 1, justifyContent: 'center', alignItems: 'center' },
    header: { fontSize: 28, fontWeight: 'bold', marginBottom: 20, textAlign: 'center', marginTop: 40 },
    card: { backgroundColor: 'white', marginBottom: 20, borderRadius: 12, overflow: 'hidden', elevation: 3 },
    image: { width: '100%', height: 220, backgroundColor: '#fff' },
    info: { padding: 15 },
    name: { fontSize: 20, fontWeight: 'bold', marginBottom: 5 },
    price: { fontSize: 18, color: '#2e7d32', fontWeight: '600', marginBottom: 5 },
    condition: { fontSize: 14, color: '#757575', fontStyle: 'italic' }
});