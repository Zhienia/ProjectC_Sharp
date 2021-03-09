using System;

namespace TestProjectGaletinko
{
    class Product
    {
        private string nameProduct;
        private int costProduct;

        public Product(string nameProduct, int costProduct) {
            this.nameProduct = nameProduct;
            this.costProduct = costProduct;
        }

        public void setNameProduct(string nameProduct)
        {
            this.nameProduct = nameProduct;
        }

        public void setCostProduct(int costProduct)
        {
            this.costProduct = costProduct;
        }

        public string getNameProduct()
        {
            return nameProduct;
        }

        public int getCostProduct()
        {
            return costProduct;
        }
    }
}
