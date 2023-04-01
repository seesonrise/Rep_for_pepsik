using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    private Rigidbody2D _rigidbody;
    private float _inputX;
    [SerializeField] private Vector2 _boxScale;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundCheck;

    private void DoMove() => _rigidbody.velocity = new Vector2(_speed * _inputX, _rigidbody.velocity.y);

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        CaptureInput();
        if (_inputX != 0)
        {
            DoMove();
        }
        if (Input.GetButton("Jump"))
        {
            DoJump();
        }
    }
    void CaptureInput()
    {
        _inputX = Input.GetAxis("Horizontal");
    }
    public void DoJump() // Прыжок
    {
        if (Grounded())
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce); // Установка вектора прыжка
        }
    }
    private bool Grounded() // Проверка на поверхность
    {
        var _ground = Physics2D.OverlapBox(_groundCheck.position, new Vector2(_boxScale.x, _boxScale.y), 0, _groundLayer); // Проверка всех колидиров с маской _groundLayer 
        return _ground != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(_groundCheck.position, new Vector2(_boxScale.x, _boxScale.y)); // Зона проверки земли
    }
}