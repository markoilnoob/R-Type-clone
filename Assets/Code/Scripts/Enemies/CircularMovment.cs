using UnityEngine;

public class CircularMovment : EnemyMovment
{
    [Header("Manage hp and damage to take")]
    [SerializeField, Range(1, 127)] private float hp = 3f;
    [SerializeField, Range(0.001f, 255)] private float damage = 1f;
    
    [Header("Point that the tank has to follow")]
    [SerializeField] private GameObject[] points;
    private int counterPoint;
    [SerializeField] private float minDistance = 0.02f;

    public void TakeDamage(float dmg)
    {
        if (dmg <= 0) return;

        hp -= dmg;
    }

    private void Update()
    {
        float distance = Vector2.Distance(this.transform.position, points[counterPoint].transform.position);
        if (distance <= minDistance)
        {
            counterPoint++;
            //check for stackoverflow
            if (counterPoint == points.Length) counterPoint = 0;
            //set new objective
            this.SetNewDirection(points[counterPoint].transform.position);
        }
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            TakeDamage(damage);
            Destroy(collision.gameObject);
            if (hp <= 0) 
                Destroy(this.gameObject);
        }
    }
}
