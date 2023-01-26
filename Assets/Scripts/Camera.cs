using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject Player;
    public Vector3 PlayerToCameraOffset;
    public float Speed;

    void Update()
    {
        Vector3 position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z) + PlayerToCameraOffset;
        transform.position = Vector3.MoveTowards(transform.position, position, Speed * Time.deltaTime);
    }
}
