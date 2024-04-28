using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanForPlayer : MonoBehaviour
{
    public Vector2 getPlayerPosition;

    void Start()
    {
        getPlayerPosition = this.transform.position;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            getPlayerPosition = other.transform.position;
            Debug.Log(other.transform.position);
        }
    }
}
