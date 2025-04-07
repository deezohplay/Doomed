using UnityEngine;

public abstract class Interactables : MonoBehaviour
{
    public string promptMessage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }
    public void BaseInteract()
    {
       Interact();
    }
    protected virtual void Interact()
    {

    }
}
