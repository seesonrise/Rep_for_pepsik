using TMPro;
using UnityEngine;

public class TeleportDoor : MonoBehaviour
{
    private GameObject _player;
    [SerializeField] private Vector2 _offSet;
    private Transform _textObject;
    private TextMeshPro _text;

    private void Awake()
    {
        _textObject = transform.Find("Text");
        _text = _textObject.GetComponent<TextMeshPro>();
        _text.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;
        _text.enabled = true;
        _player = collision.gameObject;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _player = null;
        _text.enabled = false;
    }
    private void FixedUpdate()
    {
        if (_player == null) return;
        if (Input.GetButton("Use"))
        {
            _player.transform.position = new Vector2(transform.position.x + _offSet.x , transform.position.y + _offSet.y);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(new Vector2(transform.position.x + _offSet.x, transform.position.y + _offSet.y), new Vector2(1f,1f));
    }
}
