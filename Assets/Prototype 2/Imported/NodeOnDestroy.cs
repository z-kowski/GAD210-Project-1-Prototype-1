using UnityEngine;
using UnityEngine.Events;

//When attached to an object, that object becomes a "Node" that can be connected to another object containing a "Node Manager" script.
//Nodes contribute to a number of objects contained within a sort-of network, managed by the relevant Node Manager.

//This Node type removes itself from the network once it is destroyed.

public class NodeOnDestroy : MonoBehaviour
{
    [Tooltip("Reference the object which has the applicable Node Manager component, and select the New Node function.")]
    public UnityEvent NewNode;
    [Tooltip("Reference the object which has the applicable Node Manager component, and select the Delete Node function.")]
    public UnityEvent DeleteNode;

    void Start()
    {
        NewNode.Invoke();
    }

    void OnDestroy()
    {
        DeleteNode.Invoke();
    }
}