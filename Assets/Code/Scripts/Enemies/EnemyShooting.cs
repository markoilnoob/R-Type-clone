using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private Transform muzzlePos;
    [SerializeField] private EnemyBullet _bulletToSpawn;

    [Header("---Fire Rate---")]
    [SerializeField] private float fireRate;
    private float ReadyForNextShot;

    Vector2 _position = Vector2.right;

    private void Update()
    {
        if (!_bulletToSpawn) return;

        if (Time.time > ReadyForNextShot)
        {
            ReadyForNextShot = Time.time + 1 / fireRate;
            Shoot(_position);
        }
    }

    private void Shoot(Vector2 position)
    {
        EnemyBullet bullet = Instantiate(_bulletToSpawn, muzzlePos.position, Quaternion.identity);
        bullet.SetVelocity(position);
    }

    public void SetObjectToSpawn(EnemyBullet go) => _bulletToSpawn = go;
}
