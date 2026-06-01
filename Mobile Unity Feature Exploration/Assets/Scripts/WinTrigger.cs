using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] private string _playerTag = "Player";

    // Wins game when hit trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == _playerTag)
        {
            GameManager.Instance.WinGame();
        }
    }
}
