using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlatform : MonoBehaviour
{
    [SerializeField] private string _playerTag = "Player";

    private void OnCollisionEnter(Collision collision)
    {
        // Lose game 
        if (collision.gameObject.tag == _playerTag)
        {
            GameManager.Instance.LoseGame();
        }
    }
}
