using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private KeyCode shootingKey = KeyCode.Space;
    [SerializeField] private Transform muzzlePos;
    [SerializeField] private Bullet _bulletToSpawn;

    [Header("---Fire Rate---")]
    [SerializeField] private float fireRate;
    private float ReadyForNextShot;

    Vector2 _position = Vector2.right;

    private void Update()
    {
        if (!_bulletToSpawn) return;
        
        if (Input.GetKey(shootingKey))
        {
            if (Time.time > ReadyForNextShot)
            {
                ReadyForNextShot = Time.time + 1 / fireRate;
                Shoot(_position);
            }
        }
    }

    private void Shoot(Vector2 position)
    {
        Bullet bullet = Instantiate(_bulletToSpawn, muzzlePos.position, Quaternion.identity);
        bullet.SetVelocity(position);
    }

    public void SetObjectToSpawn(Bullet go) => _bulletToSpawn = go;
}
