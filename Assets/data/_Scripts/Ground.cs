using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ShiWu")
        {
            Destroy(other.transform.parent.gameObject);
        }
    }
}
