using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Shelf : MonoBehaviour {

    public event Action OnFull;

    [SerializeField]
    private int m_ProductAmount;

    [SerializeField]
    private ScriptableProduct m_Product;

    private List<ProductInfo> m_Products;


    private void Start()
    {
        m_Products = new List<ProductInfo>();
    }

    // Called when product is dropped into shelf
    public void AddProduct(ProductInfo product)
    {
        //Check if we want this product in this shelf
        if (product.Product.productName == m_Product.name)
        {
            m_Products.Add(product);

            if (m_Products.Count == m_ProductAmount)
            {
                if (OnFull != null)
                {
                    OnFull.Invoke();
                }
            }
        }
    }

    public void RemoveProduct(ProductInfo product)
    {
        if (m_Products.Contains(product))
        {
            m_Products.Remove(product);
        }
    }
}
