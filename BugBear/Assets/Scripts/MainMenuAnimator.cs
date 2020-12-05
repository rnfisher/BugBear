using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MainMenuAnimator : MonoBehaviour
{
    public GameObject Menu;
    Animator animator;

    void Start()
    {
      
        Animator animator = Menu.GetComponent<Animator>();
        if (animator != null);
    }

    public void OptionsButton()
    {
        UnityEngine.Debug.Log("transition");
        animator.SetBool("MenuToOptions", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
