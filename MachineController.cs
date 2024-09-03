using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MachineController : MonoBehaviour
{
    public ProductSetVariables productSetVariables;
    #region Events
    public delegate void MachinePausedDelegate(bool isPaused);
    public event MachinePausedDelegate MachinePausedEvent;

    public delegate void NewProductRunSetCreatedDelegate(ProductRunSet productRunSet);
    public event NewProductRunSetCreatedDelegate NewProductRunSetCreatedEvent;

    #endregion

    public RunGraphController runGraphController;

    public bool isRunning= true;
    public bool CurrentSetFinished = true;

    public ProductRunSet productRunSet;
    private void Start()
    {
        CreateNewRuntSet();

        StartCoroutine(RunMachine());
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isRunning = !isRunning;


        }

        if(isRunning && CurrentSetFinished)
        {
            StartCoroutine(RunMachine());
        }

        if(Input.GetKeyDown(KeyCode.N))
        {
            StopAllCoroutines();
            CreateNewRuntSet();
            StartCoroutine (RunMachine());
        }
    }
    void CreateNewRuntSet()
    {
        productRunSet = ScriptableObject.CreateInstance<ProductRunSet>();

        if(NewProductRunSetCreatedEvent != null)
        NewProductRunSetCreatedEvent.Invoke(productRunSet);
        
        productRunSet.Initialize(productSetVariables,50, 0);

        productRunSet.ProductSetFinishedEvent += ProductSetFinished;
    }
    IEnumerator RunMachine()
    {
        CurrentSetFinished = false;

        if (MachinePausedEvent != null)
            MachinePausedEvent.Invoke(CurrentSetFinished);

        while (!CurrentSetFinished)
        {
            yield return StartCoroutine(CreatePart());
        }

        StopMachine();
    }
    IEnumerator StopMachine()
    {
        CurrentSetFinished = true;

        if (MachinePausedEvent != null)
            MachinePausedEvent.Invoke(CurrentSetFinished);
        StopAllCoroutines ();

        yield return null; 
    }
    //logic for creating randomized new part
    IEnumerator CreatePart()
    {
        yield return new WaitForSeconds(GetRandomCreateTime());

        productRunSet.AddProduct(BuildProduct());
    }
    float GetRandomCreateTime()
    {
        float timeToProduce = productSetVariables.productionTime + Random.Range(-productSetVariables.productionTimeDeviation, productSetVariables.productionTimeDeviation);
        return productSetVariables.productionTime;
    }
    OutputProduct BuildProduct()
    {
        OutputProduct outputProduct = ScriptableObject.CreateInstance<OutputProduct>();

        outputProduct.productSize = productSetVariables.size +Random.Range(-productSetVariables.sizeDeviation, productSetVariables.sizeDeviation);

        return outputProduct;
    }

    public void ProductSetFinished()
    {
        if(!isRunning)
        {
            StartCoroutine(StopMachine());
        }
    }
}
