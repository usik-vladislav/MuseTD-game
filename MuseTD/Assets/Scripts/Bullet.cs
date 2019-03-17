using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 6.0f;

    public Vector3 Direction { get; set; }

    private void Start()
    {
        //Destroy(gameObject, 1.5f);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Ball mob = collider.GetComponent<Ball>();
        if (mob)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + Direction, speed * Time.deltaTime);
    }
}
