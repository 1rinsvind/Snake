using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public GameObject Player;
   
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 position = Player.transform.position;
            Player.transform.position = position + new Vector3(0, 0, 2f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 position = Player.transform.position;
            Player.transform.position = position + new Vector3(0, 0, -2f);
        }
    }
}
