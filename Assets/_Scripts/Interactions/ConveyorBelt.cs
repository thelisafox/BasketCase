using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ConveyorBelt : MonoBehaviour
{
    private List<Transform> luggages;
    private Transform container;
    public Transform luggageParking;

    private void Start()
    {
        InitializeLuggageContainer();
    }

    private void InitializeLuggageContainer()
    {
        container = GameObject.Find("Luggages").transform;

        luggages = new List<Transform>();
        foreach (Transform l in container)
        {
            luggages.Add(l);
        }

        Top().GetComponent<Rotateable>().enabled = true;
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.V))
        {
            Pop();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            print(Top().name);
        }
    }

    private Transform Top()
    {
        return luggages.First();
    }    

    private void Pop()
    {
        Destroy(Top().gameObject);
        luggages.Remove(Top());
        Top().GetComponent<Rotateable>().enabled = true;
    }

    private void MoveLuggages()
    {
        foreach (Transform l in luggages)
        {

        }
    }
}
