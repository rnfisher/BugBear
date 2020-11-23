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
    public GameObject customize;

    void Start()
    {
        //main = GameObject.Find("Main");
        //options = GameObject.Find("OptionsMenu");
        //customize = GameObject.Find("CustomizeMenu");
    }

    public void MenuToOptions()
    {
        StartCoroutine(MenuToOptionsAnimation());
    }
    public void OptionsToMenu()
    {
        StartCoroutine(OptionsToMenuAnimation());
    }

    public void MenuToCustomize()
    {
        StartCoroutine(MenuToCustomizeAnimation());
    }
    public void CustomizeToMenu()
    {
        StartCoroutine(CustomizeToMenuAnimation());
    }


    IEnumerator MenuToOptionsAnimation()
    {
        animator.SetBool("MenuToOptions", true); // go into transition animation
        customize.SetActive(false);
        options.SetActive(false);
        main.SetActive(false);
        yield return new WaitForSeconds(0.3f); // time of animation
        options.SetActive(true);
    }
    IEnumerator OptionsToMenuAnimation()
    {
        animator.SetBool("MenuToOptions", false); // go into transition animation
        customize.SetActive(false);
        options.SetActive(false);
        main.SetActive(false);
        yield return new WaitForSeconds(0.3f); // time of animation
        main.SetActive(true);
    }

    IEnumerator MenuToCustomizeAnimation()
    {
        animator.SetBool("MenuToCustomize", true); // go into transition animation
        customize.SetActive(false);
        options.SetActive(false);
        main.SetActive(false);
        yield return new WaitForSeconds(0.3f); // time of animation
        customize.SetActive(true);
    }
    IEnumerator CustomizeToMenuAnimation()
    {
        animator.SetBool("MenuToCustomize", false); // go into transition animation
        customize.SetActive(false);
        options.SetActive(false);
        main.SetActive(false);
        yield return new WaitForSeconds(0.3f); // time of animation
        main.SetActive(true);
    }
}
