using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]
    private readonly float range = 4.0f;

    private CircleCollider2D circleCollider;

    private AudioSource audioSource;

    private List<Ball> enemys;

    private Vector3 direction;

    private Bullet bullet;

    public bool IsBuilding { get; set; }

    private Ball target = null;

    private void Awake()
    {
        IsBuilding = true;
        audioSource = GetComponent<AudioSource>();
        circleCollider = GetComponent<CircleCollider2D>();
        bullet = Resources.Load<Bullet>("Bullet");
        circleCollider.radius = range;
        enemys = new List<Ball>();
        direction = Vector3.left;
    }

    private void Update()
    {
        if (IsBuilding)
        {
            CheckEnemy();
            Shoot();
            Rotate();
        }
        else
        {
            SetPos();
            if (Input.GetMouseButtonDown(0) && CheckPos())
            {
                IsBuilding = true;
            }
        }
    }

    private bool CheckPos()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, 1);
        colliders.Where(x => x.name == "Tower");
        return (colliders.Length < 2) ? true : false;
    }

    private void SetPos()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = mousePos;
    }

    private void Shoot()
    {
        if (SongManager.IsBeatFull && target)
        {
            audioSource.Play();
            var newBullet = Instantiate(bullet, transform.position + direction.normalized * 1.5f, transform.rotation);
            newBullet.Direction = direction;
        }
    }

    private void Rotate()
    {
        if (target)
        {
            var newDirection = target.transform.position - transform.position;
            transform.rotation *= Quaternion.FromToRotation(direction, newDirection);
            direction = newDirection;
        }
    }

    private void CheckEnemy()
    {
        if (enemys.Count > 0)
        {
            var maxPassedWay = enemys.Max(x => x.passedWay);
            for (int i = 0; i < enemys.Count; i++)
            {
                if (enemys[i].passedWay == maxPassedWay)
                {
                    target = enemys[i];
                    return;
                }
            }
        }
        else
        {
            target = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Ball enemy = collider.GetComponent<Ball>();
        if (enemy)
        {
            enemys.Add(enemy);
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        Ball enemy = collider.GetComponent<Ball>();
        if (enemy)
        {
            enemys.Remove(enemy);
        }
    }
}
