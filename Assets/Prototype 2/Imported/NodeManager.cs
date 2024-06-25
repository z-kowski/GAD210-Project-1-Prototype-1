using System.Collections;
using UnityEngine;

//"Node Managers" are objects that are connected to other object "Nodes"
//Something needs to happen to a node for the node manager to perform a function

public class NodeManager : MonoBehaviour
{
    [Tooltip("Select only this if the object is to perform an animation.")]
    public bool isAnimated = false;

    [Tooltip("Select only this if the object is to be destroyed.")]
    public bool isDestructable = false;

    [Tooltip("The visible number of nodes connected to this object.")]
    public int ConnectedNodes;

    [Tooltip("The animator component that needs to be referenced in order to perform an animation.")]
    public Animator animatorComponent;

    [Tooltip("The main camera (most likely the player) that is primarily used in the scene.")]
    public GameObject mainCamera;

    [Tooltip("A camera facing an object to be animated can be referenced here, to show a desired action taking place on the screen.")]
    public GameObject objectCamera;

    [Tooltip("Set how long the Object Camera will render in unscaled time. Especially useful for extended animations.")]
    public int animEndState;

    void Update()
    {
        if (ConnectedNodes <= 0)
        {
            if (isDestructable)
            {
                Destroy(gameObject);
            }
            if (isAnimated)
            {
                StartCoroutine(ThisAnimation()); //The coroutine handles the animation and how long the object camera will render, until the animation is completed, before returning to the main camera.
            }
        }
    }

    public void NewNode()
    {
        ConnectedNodes++;
        Debug.Log(gameObject.name + " has " + ConnectedNodes + " node(s) remaining.");
    }

    public void DeleteNode()
    {
        ConnectedNodes--;
        Debug.Log(gameObject.name + " has " + ConnectedNodes + " node(s) remaining.");
    }

    IEnumerator ThisAnimation()
    {
        Time.timeScale = 0; //Make sure the animator component's "Update Mode" is using "Unscaled Time".
        //mainCamera.SetActive(false); //Deprecated but kept for future reference. This breaks animations (notably for player Transforms) since the animator is connected to the player camera.
        mainCamera.GetComponent<AudioListener>().enabled = false; //Effectively allows audio near objectCamera to be heard more clearly.
        objectCamera.SetActive(true);
        animatorComponent.SetBool("isAnimating", true);
        yield return new WaitForSecondsRealtime(animEndState);
        {
            isAnimated = false;
            Time.timeScale = 1;
            //mainCamera.SetActive(true); //Deprecated but kept for future reference. This breaks animations (notably for player Transforms) since the animator is connected to the player camera.
            mainCamera.GetComponent<AudioListener>().enabled = true; //Returns closest audio to the player's location.
            objectCamera.SetActive(false);
            yield break;
        }
    }
}
