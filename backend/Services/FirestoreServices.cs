using Google.Cloud.Firestore;
using backend.Models;

namespace backend.Services
{
    public class FirestoreServices
    {
        private readonly FirestoreDb _firestoreDb;

        public FirestoreServices()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "firebase-key.json");
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            _firestoreDb = FirestoreDb.Create("byteback-6bb5d");
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            CollectionReference productsRef = _firestoreDb.Collection("Products");
            QuerySnapshot snapshot = await productsRef.GetSnapshotAsync(); 

            List<Product> products = new List<Product>();

            foreach (DocumentSnapshot document in snapshot.Documents)
            {
                if (document.Exists)
                {
                    Product product = document.ConvertTo<Product>();
                    products.Add(product);
                }
            }
       
       
            return products;
        }
    }


}

//note: This allows my backend to connect to the Firestore database and retrieve a list of products. The GetProductsAsync method queries the "Products" collection, converts each document to a Product object, and returns a list of products.

