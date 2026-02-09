using Google.Cloud.Firestore;

namespace backend.Models
{
    [FirestoreData]
    public class Product
    {
        [FirestoreProperty("id")]
        public string Id { get; set; }

        [FirestoreProperty("name")]
        public string Name { get; set; }

        [FirestoreProperty("category")]
        public string Category { get; set; }

        [FirestoreProperty("condition")]
        public string Condition { get; set; }

        [FirestoreProperty("description")]
        public string Description { get; set; }

        [FirestoreProperty("price")]
        public double Price { get; set; }

        [FirestoreProperty("imageUrl")]
        public string ImageUrl { get; set; }

        [FirestoreProperty("isSold")]
        public bool IsSold { get; set; }
    }
}

//note: This class defines the structure of a Product object that corresponds to the documents in the "Products" collection in Firestore. Each property is decorated with the [FirestoreProperty] attribute to map it to the corresponding field in the Firestore document.