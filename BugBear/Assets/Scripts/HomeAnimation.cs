using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HomeAnimation : MonoBehaviour
{
    public Animator animator;
    public GameObject options;
    public GameObject main;

    void Start()
    {

    }

    public void MenuToOptions()
    {
        StartCoroutine(MenuToOptionsAnimation());
    }
    public void OptionsToMenu()
    {
        StartCoroutine(OptionsToMenuAnimation());
    }


    IEnumerator MenuToOptionsAnimation()
    {
        animator.SetBool("MenuToOptions", true); // go into transition animation
        options.SetActive(false);
        main.SetActive(false);
        yield return new WaitForSeconds(0.3f); // time of animation
        options.SetActive(true);
    }
    IEnumerator OptionsToMenuAnimation()
    {
        animator.SetBool("MenuToOptions", false); // go into transition animation
        options.SetActive(false);
        main.SetActive(false);
        yield return new WaitForSeconds(0.3f); // time of animation
        main.SetActive(true);
    }
}
