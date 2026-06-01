using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider))]
public class KillZ : MonoBehaviour
{
    [SerializeField] private string _playerTag = "Player";

    // Loses game if hit trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == _playerTag)
        {
            GameManager.Instance.LoseGame();
        }
    }
}
