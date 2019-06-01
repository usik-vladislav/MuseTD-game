using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    private float speed = 6.0f;

    private float acceleration = 1;

    private float rangeBang = 1.25f;

    private GameObject bang;

    [SerializeField]
    private int damage = 1;

    private Rigidbody2D rb;

    public Vector2 Direction { get; set; }

    public Vector2 Point { get; set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bang = Resources.Load<GameObject>("Bang");
    }

    private void Start()
    {
        speed = 4 * Point.magnitude / BeatManager.SecPerBeat;
        acceleration = -2 * speed / BeatManager.SecPerBeat;
        rb.velocity = Direction.normalized * speed;
    }

    private void Update()
    {
        if (BeatManager.IsBeatFull)
        {
            Instantiate(bang, transform.position, transform.rotation);

            var colliders = Physics2D.OverlapCircleAll(transform.position, rangeBang);
            for (int i = 0; i < colliders.Length; i++)
            {

                Mob mob = colliders[i].GetComponent<Mob>();
                if (mob)
                {
                    mob.TakeDamage(damage);
                }
            }

            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (rb.velocity.magnitude > 0.3)
        {
            rb.AddForce(Direction.normalized * acceleration);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
}
