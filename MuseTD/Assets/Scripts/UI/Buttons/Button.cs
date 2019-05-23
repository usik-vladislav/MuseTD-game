using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private Transform myTransform;

    public void Awake()
    {
        myTransform = GetComponent<Transform>();
    }

    private void OnMouseEnter()
    {
        myTransform.localScale *= 1.1f;
    }
    private void OnMouseExit()
    {
        myTransform.localScale /= 1.1f; 
    }
}
