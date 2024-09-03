using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductSet : ScriptableObject
{
    #region Events
    public delegate void ProductSetFinishedDelegate();
    public event ProductSetFinishedDelegate ProductSetFinishedEvent;

    public delegate void NumberOfProductsChangedDelegate(int productsCount);
    public event NumberOfProductsChangedDelegate NumberOfProductsChangedEvent;
    
    public delegate void SetNumberChangedDelegate(int setNumber);
    public event SetNumberChangedDelegate SetNumberChangedEvent;

    public delegate void MeanSetDelegate(float mean);
    public event MeanSetDelegate MeanSetEvent;

    public delegate void StandardDeviationSetDelegate(float standardDeviation);
    public event StandardDeviationSetDelegate StandardDeviationSetEvent;

    public delegate void ProductAddedToSetDelegate(OutputProduct product);
    public event ProductAddedToSetDelegate ProductAddedToSetEvent;
    
    public delegate void ProductSetActiveDelegate(bool isActive);
    public event ProductSetActiveDelegate ProductSetActiveEvent;
    #endregion 

    ProductSetVariables productSetVariables;
    public int SetNumber    {
        get { return setNumber; }
        set
        {
            setNumber = value;
            if(SetNumberChangedEvent != null)
            SetNumberChangedEvent.Invoke(setNumber);
        }
    }
    int setNumber;

    public float Mean
    {
        get { return mean; }
        set { 
            mean = value;
            if(MeanSetEvent != null)
                MeanSetEvent.Invoke(mean); 
        }
    }
    float mean= 0;
    public float StandardDeviation {
        get { return standardDeviation; }
        set { 
            standardDeviation = value; 
            if(StandardDeviationSetEvent != null)
                StandardDeviationSetEvent.Invoke(standardDeviation); 
        }
    }
    float standardDeviation = 0;


    public List<OutputProduct> products;
    public Vector2 valueRange;
    public int containerSize;

    #region Initialization Logic
    public void Initialize(ProductSetVariables productSetVariables,int containerSize,int setNumber)
    {
        this.productSetVariables = productSetVariables;
        this.setNumber = setNumber;
        this.containerSize = containerSize;
        this.valueRange = productSetVariables.fullRange;
        products = new List<OutputProduct>();
    }
    public virtual void Initialize(ProductSet setToCopy)
    {
        Initialize(setToCopy.productSetVariables,setToCopy.containerSize,setToCopy.SetNumber);
    }
    #endregion

    public void SetActive(bool isActive)
    {
        if(ProductSetActiveEvent != null)
        ProductSetActiveEvent.Invoke(isActive);
    }

    public void AddProduct(OutputProduct product)
    {
        product.CheckInControlLimits(productSetVariables.controlLimits.x, productSetVariables.controlLimits.y);

        products.Add(product);

        product.setNumber = products.Count;

        if (products.Count >= containerSize)
        {
            if(ProductSetFinishedEvent != null)
            ProductSetFinishedEvent.Invoke();

        }

        if(NumberOfProductsChangedEvent != null)
        NumberOfProductsChangedEvent.Invoke(products.Count);

        if(ProductAddedToSetEvent!=null)
        ProductAddedToSetEvent(product);

        CalculateMean();
    }
    void CalculateMean()
    {
        float sum = 0;
        foreach (OutputProduct tempOutputProduct in products)
        {
            sum += tempOutputProduct.productSize;
        }

        Mean = sum / products.Count;

        CalculateStandardDeviation();
    }
    public float GetMeanPercentage()
    {
        return Mean / valueRange.y;
    }
    void CalculateStandardDeviation()
    {
        float squaredDifferences = 0;
        foreach(OutputProduct tempOutputProduct in products)
        {
            squaredDifferences += Mathf.Pow(tempOutputProduct.productSize - Mean, 2);
        }
        float variance = squaredDifferences / products.Count;

        StandardDeviation = Mathf.Sqrt(variance);
    }
    public float GetStandardDeviationPercentage()
    {
        return StandardDeviation/valueRange.y;
    }
}
