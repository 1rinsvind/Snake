using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Food : MonoBehaviour
{
    public GameObject GameObjectFood;
    public int HP;
    public TMP_Text hp;

    void Start()
    {
        HP = UnityEngine.Random.Range(1, 21);
        hp.text = $"{HP}";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CreateandDestroy CreateandDestroy))
        { Destroy(GameObjectFood); }
    }   
}
