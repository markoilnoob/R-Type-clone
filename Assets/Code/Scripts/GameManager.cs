using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Scripts to disable")]
    [SerializeField] private PlayerMovment playerMovment;
    [SerializeField] private PlayerShooting playerShooting;

    public void GameOver()
    {
        if (playerMovment != null) playerMovment.enabled = false;
        if (playerShooting != null) playerShooting.enabled = false;
    }
}
