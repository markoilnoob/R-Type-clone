using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float lifeTime = 10f;

    private SpriteRenderer _spriteRenderer;

    private Rigidbody2D _rigidbody;
    private Vector2 _direction = Vector2.zero;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start() => Destroy(gameObject, lifeTime);

    public void SetVelocity(Vector2 direction)
    {
        _direction = new Vector2(-direction.x, 0);

        _spriteRenderer.flipX = direction.x < 0;
    }

    private void FixedUpdate() => _rigidbody.linearVelocity = _direction * speed;

    private void OnCollisionEnter2D(Collision2D other) => Destroy(gameObject);
}
