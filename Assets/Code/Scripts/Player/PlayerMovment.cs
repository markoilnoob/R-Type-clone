using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private float flightSpeed = 5.0f;

    private Vector2 _direction;

    private void FixedUpdate()
    {
        //get input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        _direction = new Vector2(horizontal, vertical);
        //move player
        this.transform.Translate(flightSpeed * Time.deltaTime * _direction);
    }
}
