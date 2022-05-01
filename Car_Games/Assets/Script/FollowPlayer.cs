using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private Vector3 offset = new Vector3(0, 5, -6);


    // Update is called once per frame
    void LateUpdate() // Late = kamera titremelerini ortadan kald�r�r.
    {
        transform.position = player.transform.position + offset; //Oyuncu kamera takip
    }
}
