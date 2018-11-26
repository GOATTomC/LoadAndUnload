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
    private string m_ProductName;

    private List<ProductInfo> m_Products;

    // Called when product is dropped into shelf
    private void AddProduct(ProductInfo product)
    {
        //Check if we want this product in this shelf
        if (product.ProductName == m_ProductName)
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

    private void RemoveProduct(ProductInfo product)
    {
        if (m_Products.Contains(product))
        {
            m_Products.Remove(product);
        }
    }
}
