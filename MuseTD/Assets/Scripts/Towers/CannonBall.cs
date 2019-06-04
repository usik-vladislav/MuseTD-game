using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    private CannonBall ball;

    private float speed = 6.0f;

    private float acceleration = 1;

    private float rangeBang = 1.25f;

    private GameObject bang;

    public bool IsLvlUp = false;

    public bool IsFastBang = false;

    public int Damage = 0;

    private Rigidbody2D rb;

    public Vector2 Direction { get; set; }

    public Vector2 Point { get; set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bang = Resources.Load<GameObject>("Bang");
        ball = Resources.Load<CannonBall>("CannonBall");
    }

    private void Start()
    {
        speed = 4 * Point.magnitude / BeatManager.SecPerBeat;
        acceleration = -2 * speed / BeatManager.SecPerBeat;
        rb.AddForce(Direction.normalized * speed, ForceMode2D.Impulse);
    }

    private void Update()
    {
        if (BeatManager.IsBeatFull || (BeatManager.IsBeatD4 && BeatManager.CountBeatD4 % 2 == 0 && IsFastBang))
        {
            Instantiate(bang, transform.position, transform.rotation);

            var colliders = Physics2D.OverlapCircleAll(transform.position, rangeBang);
            for (int i = 0; i < colliders.Length; i++)
            {

                Mob mob = colliders[i].GetComponent<Mob>();
                if (mob)
                {
                    mob.TakeDamage(Damage);
                }
            }

            if (IsLvlUp)
            {
                for (int i = 0; i < 3; i++)
                {
                    var direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                    var newCannonBall = Instantiate(ball, transform.position, transform.rotation);
                    newCannonBall.Direction = direction;
                    newCannonBall.Point = direction;
                    newCannonBall.Damage = Damage / 2;
                    newCannonBall.IsFastBang = true;
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
