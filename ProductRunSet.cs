using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProductRunSet : ScriptableObject
{
    public enum SetStatus { untracked,tracked}
    public SetStatus setStatus;
    #region Events
    public delegate void NewSetOfTrackProductsCreated(TrackedProductsSet trackedProducts);
    public event NewSetOfTrackProductsCreated NewSetOfTrackedProductsCreatedEvent;

    public delegate void ProductAddedDelegate();
    public event ProductAddedDelegate ProductAddedEvent;

    public delegate void NewSetOfUntrackProductsCreated(UntrackedProductSet untrackedProducts);
    public event NewSetOfUntrackProductsCreated NewSetOfUntrackedProductsCreatedEvent;

    public delegate void NewUntrackProductSetContainerCreated(UntrackedProductSetContainer untrackedProductSetContainer);
    public event NewUntrackProductSetContainerCreated NewUntrackProductSetContainerCreatedEvent;

    public delegate void TrackProductsSetActiveDelegate(TrackedProductsSet trackedProducts);
    public event TrackProductsSetActiveDelegate TrackProductsSetActiveEvent;


    public delegate void ProductSetFinishedDelegate();
    public event ProductSetFinishedDelegate ProductSetFinishedEvent;
    #endregion
    public ProductSetVariables productSetVariables;
    int currentCount = 0;
    public int setCounter = 0;
    int setSize = 0;
    int numberOfUntrackedSetsInContainer = 0;
    public UntrackedProductSetContainer currentUntrackedProductSetContainer;
    public TrackedProductsSet ActiveProductSet
    {
        get { return activeProductSet; }
        set { activeProductSet = SetActiveProductSet(value); }
    }
    TrackedProductsSet activeProductSet;
    public ProductSet currentProductSet;
    public List<ProductSet> fullProductSet = new List<ProductSet>();
    public List<UntrackedProductSetContainer> untrackedProductSetContainers = new List<UntrackedProductSetContainer>();
    public void Initialize(ProductSetVariables productSetVariables,int setSize, int numberOfUntrackedSetsInContainer)
    {
        this.productSetVariables = productSetVariables;
        this.setSize = setSize;
        this.numberOfUntrackedSetsInContainer = numberOfUntrackedSetsInContainer;

        CreateNewTrackedDataSet();
        //CreateNewUntrackedSetContainer();
    }

    TrackedProductsSet SetActiveProductSet(TrackedProductsSet activeProductSet)
    {
        if(ActiveProductSet != null)
            ActiveProductSet.SetActive(false);

        activeProductSet.SetActive(true);
        
        if(TrackProductsSetActiveEvent != null)
            TrackProductsSetActiveEvent.Invoke(activeProductSet);
        
        return activeProductSet;
    }
    public void AddProduct(OutputProduct outputProduct)
    {
        if(currentProductSet==null)
        { 
            if (setStatus==SetStatus.untracked) 
                CreateNewUntrackedDataSet();
            
            else
                CreateNewTrackedDataSet();
        }

        else
            currentProductSet.AddProduct(outputProduct);

        ProductAddedEvent?.Invoke();

        currentCount++;
    }
    public void CreateNewTrackedDataSet()
    {
        currentProductSet = CreateInstance<TrackedProductsSet>();

        currentProductSet.Initialize(productSetVariables,setSize,setCounter);

        ActiveProductSet = currentProductSet as TrackedProductsSet;
        
        currentProductSet.ProductSetFinishedEvent += ProductSetFull;

        if(NewSetOfTrackedProductsCreatedEvent != null)
        NewSetOfTrackedProductsCreatedEvent(currentProductSet as TrackedProductsSet);

        fullProductSet.Add(currentProductSet);

        setCounter++;
    }
    public void CreateNewUntrackedSetContainer()
    {
        currentUntrackedProductSetContainer = CreateInstance<UntrackedProductSetContainer>();

        currentUntrackedProductSetContainer.Initialize(numberOfUntrackedSetsInContainer,fullProductSet.Count);

        if (NewUntrackProductSetContainerCreatedEvent != null)
            NewUntrackProductSetContainerCreatedEvent.Invoke(currentUntrackedProductSetContainer);

        currentUntrackedProductSetContainer.ProductSetContainerFullEvent += SetContainerFull;

        untrackedProductSetContainers.Add(currentUntrackedProductSetContainer);
    }
    public void CreateNewUntrackedDataSet()
    {
        currentProductSet = CreateInstance<UntrackedProductSet>();

        currentProductSet.Initialize(productSetVariables, setSize, setCounter);

        currentProductSet.ProductSetFinishedEvent += ProductSetFull;

        if (currentUntrackedProductSetContainer == null)
        {
            Debug.LogWarning("No Untracked Container");
            CreateNewUntrackedSetContainer();
        }


        currentUntrackedProductSetContainer.AddProductSet(currentProductSet as UntrackedProductSet);

              
        fullProductSet.Add(currentProductSet);

        setCounter++;
    }
    public List<TrackedProductsSet> GetTrackedProductsSets()
    {
        List<ProductSet > trackedProductsSets = fullProductSet.Where(x => x.GetType() == typeof(TrackedProductsSet)).ToList();


        return trackedProductsSets.Cast<TrackedProductsSet>().ToList();
    }
    public void InsertSet(UntrackedProductSet set)
    {

        ConvertSet(set);
    }
    void ConvertSet(UntrackedProductSet set)
    {
        ConvertedTrackedProductSet trackedProductsSet = CreateInstance<ConvertedTrackedProductSet>();

        trackedProductsSet.Initialize(set);

        ActiveProductSet = trackedProductsSet;

        trackedProductsSet.SetNumber = set.SetNumber;

        fullProductSet.Remove(set);
        fullProductSet.Insert(trackedProductsSet.SetNumber, trackedProductsSet);
        
        NewSetOfTrackedProductsCreatedEvent(trackedProductsSet);

/*        foreach (OutputProduct outputProduct in set.products)
        {*/
            trackedProductsSet.products = set.products.ToList();
            //yield return new WaitForSeconds(.2f);
        //}
        

    }
    public void UnsubscribeEvent(Action<TrackedProductsSet> action )
    {
        if(NewSetOfTrackedProductsCreatedEvent != null)
        Debug.Log(NewSetOfTrackedProductsCreatedEvent.GetInvocationList());
    }

    void SetContainerFull()
    {
        currentUntrackedProductSetContainer.ProductSetContainerFullEvent -= SetContainerFull;
        currentUntrackedProductSetContainer = null;
        Debug.Log(currentProductSet);
        setStatus = SetStatus.tracked;
    }

    void ProductSetFull()
    {
        ProductSetFinishedEvent.Invoke();

        currentProductSet.ProductSetFinishedEvent -= ProductSetFull;

        if(currentProductSet.GetType() == typeof(TrackedProductsSet))
            setStatus = SetStatus.untracked;

        currentProductSet = null;
    }
}
