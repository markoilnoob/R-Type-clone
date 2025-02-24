using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    //[Header("Interaction")]
    private Rigidbody2D _rigidbody2d;

    [Header("Movment")]
    [SerializeField, Range(0, 15f)] private float speed;
    [SerializeField] private Vector2 direction = Vector2.up;

    private void Awake() => _rigidbody2d = GetComponent<Rigidbody2D>();

    private void FixedUpdate()
    {
        _rigidbody2d.linearVelocity = speed * direction.normalized;
    }

    public void SetNewDirection(Vector2 newDirection)
    {
        direction = newDirection.normalized;
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
