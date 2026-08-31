using System;
using UnityEngine;

public class Chestinteraction : MonoBehaviour, IInteractable
{
    Animator anim;
    bool opened;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void Interact()
    {
        if (!opened) anim.SetTrigger("open");
        else anim.SetTrigger("Close");
        opened = !opened;
    }


}
