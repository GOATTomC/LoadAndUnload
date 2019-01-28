using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ProductInfo))]
public class Product : Pickup {


    private ProductInfo m_myProductInfo;
    private List<Collider> m_currentCollisions = new List<Collider>();


    protected override void Awake()
    {
        base.Awake();
        m_myProductInfo = GetComponent<ProductInfo>();
    }


    public void OnTriggerEnter(Collider other)
    {
        Shelf shelf = other.GetComponent<Shelf>();
     if (shelf)
        {
            shelf.AddProduct(m_myProductInfo);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        Shelf shelf = other.GetComponent<Shelf>();
        if (shelf)
        {
 
            shelf.RemoveProduct(m_myProductInfo);
        }

    }


}
