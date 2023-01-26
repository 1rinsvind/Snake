using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using JetBrains.Rider.Unity.Editor;

public class Block : MonoBehaviour
{
    public GameObject GameObjectBlock;
    public int HP;
    public TMP_Text hp;
    

    void Start()
    {
        HP = UnityEngine.Random.Range(-50, 0);
        int e = HP * -1; 
        hp.text = $"{e}";
        GetComponent<Renderer>().material.SetFloat("_Gradient", HP);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CreateandDestroy CreateandDestroy))
        { Destroy(GameObjectBlock); }
    }
}
