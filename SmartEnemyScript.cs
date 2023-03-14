using UnityEngine;

public class SmartEnemyScript : MonoBehaviour
{
	[SerializeField] private float _walkSpeed;
	[SerializeField] private Transform _headZone;
	[SerializeField] private Vector2 _boxScale;
	[SerializeField] private LayerMask _playerLayer;
	[SerializeField][Range(0f, 100f)] private float _raycastDistance;
	private bool _faceRight;

	private Rigidbody2D _rigidbody;

	private void Start()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
	}
	private bool DoTakeDamage()
	{
		var touched = Physics2D.OverlapBox(_headZone.position, _boxScale, 0, _playerLayer);
		Debug.Log(touched);
        return touched != null;
	}
	private void Move()
	{
		_rigidbody.velocity = new Vector2(_walkSpeed, _rigidbody.velocity.y);
	}
	private void FixedUpdate()
	{
		if (DoTakeDamage())
		{
			Destroy(gameObject);
		}
		if (Physics2D.Raycast(transform.position, Vector2.right, _raycastDistance) && !_faceRight)
		{
			Flip();
		}
		else if (Physics2D.Raycast(transform.position, Vector2.left, _raycastDistance) && _faceRight)
		{
			Flip();
		}
		Move();
	}
	private void Flip()
	{
		_walkSpeed *= -1;
		_faceRight = !_faceRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
	private void OnCollisionEnter2D(Collision2D collision)
   	{	
		if(collision.gameObject.name == "Player")
		{
			GetComponent<Health>().DoDamage(_enemyDamage);
		}
    	}
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(_headZone.position, _boxScale);
	}
}
