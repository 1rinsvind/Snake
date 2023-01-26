using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SnakeBody : MonoBehaviour
{
    public CreateandDestroy CreateandDestroyScript;
    public GameObject goal;

    void Update()
    {
        CreateandDestroyScript = GameObject.Find($"Player").GetComponent<CreateandDestroy>();
        int PlayerHP = CreateandDestroyScript.HP;
        GetComponent<Renderer>().material.SetFloat("_Gradient", PlayerHP);
        GetComponent<NavMeshAgent>().destination = goal.GetComponent<Transform>().transform.position;

    }
}
