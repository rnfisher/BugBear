using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{
    private static Variables objectInstance;

    public int skinType;
    public GameObject skinUpdate;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (objectInstance == null)
        {
            objectInstance = this;
        }
        else
        {
            DestroyObject(gameObject);
        }
    }
    void Start()
    {

    }
    void Update()
    {
        skinUpdate = GameObject.Find("SkinUpdater");
        if (skinUpdate == null)
        {
            Debug.Log("Cannot find Skin Updater (should only find in home menu)");
        }

        if (skinUpdate != null)
        {
            skinType = skinUpdate.GetComponent<SkinUpdate>().skinType;
        }
    }
}
