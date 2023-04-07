using TMPro;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _scoreText;
    [SerializeField][HideInInspector] private int _score;
    [SerializeField][HideInInspector] private TextMeshProUGUI _scoreCounter;
    [SerializeField][HideInInspector] private Rigidbody2D _rigidbody;
    private float _inputX;
    [SerializeField] private Vector2 _boxScale;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundCheck;

    private void DoMove() => _rigidbody.velocity = new Vector2(_speed * _inputX, _rigidbody.velocity.y);

    private void Awake()
    {
        _scoreCounter = _scoreText.GetComponent<TextMeshProUGUI>();
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
    public void AddScore(int score) 
    {
        _score += score;
        _scoreCounter.text = "Score: "+_score.ToString();
    }
    void CaptureInput()
    {
        _inputX = Input.GetAxis("Horizontal");
    }
    public void DoJump() // ������
    {
        if (Grounded())
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce); // ��������� ������� ������
        }
    }
    private bool Grounded() // �������� �� �����������
    {
        var _ground = Physics2D.OverlapBox(_groundCheck.position, new Vector2(_boxScale.x, _boxScale.y), 0, _groundLayer); // �������� ���� ��������� � ������ _groundLayer 
        return _ground != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(_groundCheck.position, new Vector2(_boxScale.x, _boxScale.y)); // ���� �������� �����
    }
}