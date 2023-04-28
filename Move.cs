using TMPro;
using UnityEngine;

public class Move : MonoBehaviour
{
	[Header("Move")]
	[SerializeField] private float _speed;
	[SerializeField] private float _jumpForce;
    [SerializeField][HideInInspector] private Rigidbody2D _rigidbody;
	private float _inputX;
	[Space(1)]
	[Header("Score")]
	[SerializeField] private Transform _scoreText;
	[SerializeField][HideInInspector] private int _score;
	[SerializeField][HideInInspector] private TextMeshProUGUI _scoreCounter;
	[Space(1)]
	[Header("Ground Check")]
	[SerializeField] private Vector2 _boxScale;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundCheck;
    [Space(1)]
	[Header("Climbing Check")]
    [SerializeField] private LayerMask _wallLayer;
	[SerializeField, HideInInspector] private bool _facingRight;
	[SerializeField, HideInInspector] private bool _wallClimbing;

	[SerializeField, HideInInspector] private Animator _animator;


	private void Awake()
	{
		_scoreCounter = _scoreText.GetComponent<TextMeshProUGUI>();
		_rigidbody = GetComponent<Rigidbody2D>();
		_animator = GetComponent<Animator>();
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
		_scoreCounter.text = "Score: " + _score.ToString();
	}
    private void DoMove()
    {
		if (!_wallClimbing)
		{
            GetComponent<SpriteRenderer>().flipX = _inputX < 0;
        }
        _facingRight = _inputX > 0;
        _rigidbody.velocity = new Vector2(_speed * _inputX, _rigidbody.velocity.y);
    }

    void CaptureInput()
	{
		_inputX = Input.GetAxis("Horizontal");
		_animator.SetFloat("Run", Mathf.Abs(_inputX));
	}
	private void DoJump() // Прыжок
	{
		if (Grounded())
		{
			_animator.SetTrigger("Jump");
			_rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce); // Установка вектора прыжка
		}
	}
	private bool Grounded() // Проверка на поверхность
	{
		var _ground = Physics2D.OverlapBox(_groundCheck.position, new Vector2(_boxScale.x, _boxScale.y), 0, _groundLayer); // Проверка всех колидиров с маской _groundLayer 
		_animator.SetBool("Grounded", _ground != null);
		return _ground != null;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var hit = Physics2D.OverlapBox(transform.position, transform.localScale, 0, _wallLayer);
        _wallClimbing = hit != null;
        if (hit) 
		{
            Debug.Log("I touch a wall");
            WallClimbing(collision.transform.position);
		}
    }

    private void WallClimbing(Vector3 wallPosition)
    {
		var heading = wallPosition - transform.position;

        print(heading.x);
		if (!_facingRight && heading.x < 0)
		{
			print("Меня повернуло в право");
			GetComponent<SpriteRenderer>().flipX = false;
        }
		if (_facingRight && heading.x > 0)
		{
            print("Меня повернуло в лево");
            GetComponent<SpriteRenderer>().flipX = true;
        }
		_animator.SetTrigger("WallClimbing");
    }
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(_groundCheck.position, new Vector2(_boxScale.x, _boxScale.y)); // Зона проверки земли
	}
}