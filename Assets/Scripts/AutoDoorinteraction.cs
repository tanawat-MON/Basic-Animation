using UnityEngine;

public class AutoDoorinteraction : MonoBehaviour, IInteractable
{
    Animator anim;
    bool opened;

    void Start()
    {
        anim = GameObject.Find("Door").GetComponentInChildren<Animator>();
    }

    public void Interact()
    {
        if (!opened) anim.SetTrigger("Open");
        else anim.SetTrigger("Close");
        opened = !opened;
    }


}
