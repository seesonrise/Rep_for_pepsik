using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneWarpTeleportDoor : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_sceneName != null)
        {
            SceneManager.LoadScene(_sceneName);
        }
        else
        {
            Debug.Log("Нету данной сценны");
        }
    }
}