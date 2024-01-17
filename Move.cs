using UnityEngine;


public class Move : MonoBehaviour
{
	private Rigidbody2D rb;

	#region Player_Settings
	[Header("Player Settings")]
	[SerializeField] private float speed;
	[SerializeField] private float jumpForce;
	#endregion
	#region GroundCheck
	[Header("GroundCheck Settings")]
	[SerializeField] private GameObject GroundCheck;
	[SerializeField] private Vector2 GrounbCheckSize;
	[SerializeField] private LayerMask GroundLayer;
	#endregion


	private void Awake()
	{
		if (GroundCheck == null) 
		{
			GroundCheck = new GameObject("Ground Check");
			GroundCheck.transform.parent = transform; 
		}
		rb = GetComponent<Rigidbody2D>();
	}

	private bool DoJump() { return Physics2D.OverlapBox(GroundCheck.transform.position, GrounbCheckSize, 0, GroundLayer) != null; }
	private void Jump() { rb.velocity = new Vector2(rb.velocity.x, jumpForce); }
	private void Moving() { rb.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), rb.velocity.y); }
	private void FixedUpdate()
	{
		if (Input.GetButton("Jump") && DoJump())
		{
			Jump();
		}
		if(Input.GetAxis("Horizontal") != 0)
		{
			Moving();
		}
	}
}
