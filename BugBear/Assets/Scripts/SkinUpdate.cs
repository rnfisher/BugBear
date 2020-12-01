using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinUpdate : MonoBehaviour
{
    public GameObject VariableHolder;

    public GameObject original;
    public GameObject tophat;
    public GameObject swimsuit;

    public int skinType;

    // Start is called before the first frame update

    void Start()
    {
        skinType = 1;
        original = GameObject.Find("Sprite_Original");
        tophat = GameObject.Find("Sprite_TopHat");
        swimsuit = GameObject.Find("Sprite_Swim");

        if (original == null)
        {
            Debug.Log("Cannot find Original Skin");
        }
        if (tophat == null)
        {
            Debug.Log("Cannot find TopHat Skin");
        }
        if (swimsuit == null)
        {
            Debug.Log("Cannot find Swimsuit Skin");
        }
    }
    void OnEnable()
    {
        VariableHolder = GameObject.Find("VariableHolder");
        if (VariableHolder == null)
        {
            Debug.Log("Cannot find VariableHolder");
        }

        if (VariableHolder != null)
        {
            skinType = VariableHolder.GetComponent<Variables>().skinType;
        }
    }
    void Update()
    {
        
        if (skinType == 1) //original
        {
            original.SetActive(true);
            tophat.SetActive(false);
            swimsuit.SetActive(false);
        }
        if (skinType == 2) //tophat
        {
            original.SetActive(false);
            tophat.SetActive(true);
            swimsuit.SetActive(false);
        }
        if (skinType == 3) //swim
        {
            original.SetActive(false);
            tophat.SetActive(false);
            swimsuit.SetActive(true);
        }

    }
    public void SkinOriginal()
    {
        skinType = 1;
    }
    public void SkinTopHat()
    {   
        skinType = 2;
    }
    public void SkinSwim()
    {
    
        skinType = 3;
    }
}
