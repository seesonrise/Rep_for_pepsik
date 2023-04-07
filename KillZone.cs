using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _playerLayer)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
