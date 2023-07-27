using UnityEngine;
using UnityEditor;

internal enum TypeMove { StandartMove, CellMove }
[RequireComponent(typeof(Rigidbody2D))]
public class Move : MonoBehaviour
{
	private Rigidbody2D _rb;
	[SerializeField] internal TypeMove TypeMove;

	#region CellMove
	[SerializeField] internal Vector2 CellSize;
	[SerializeField] internal float SmoothTime;
	[SerializeField] internal LayerMask WallLayer;
	#endregion

	#region StandarMove
	[SerializeField] internal float Speed;
	[SerializeField] internal float JumpForce;
	[SerializeField] internal GameObject GroundBox;
	[SerializeField] internal Vector2 BoxSize;
	[SerializeField] internal LayerMask GroundLayer;
	private float InputX;
	private float InputY;
	#endregion
	private void Awake()
	{
		_rb = GetComponent<Rigidbody2D>();
	}

	private void CellMove()
	{
		_rb.bodyType = RigidbodyType2D.Static;
		if (Input.GetKeyDown(KeyCode.D) && !Physics2D.Raycast(transform.position, Vector2.right, 1f, WallLayer))
		{
			transform.position = new Vector2(transform.position.x + CellSize.x, transform.position.y);
		}
		if (Input.GetKeyDown(KeyCode.A) && !Physics2D.Raycast(transform.position, Vector2.left, 1f, WallLayer))
		{
			transform.position = new Vector2(transform.position.x - CellSize.x, transform.position.y);
		}
		if (Input.GetKeyDown(KeyCode.W) && !Physics2D.Raycast(transform.position, Vector2.up, 1f, WallLayer))
		{
			transform.position = new Vector2(transform.position.x, transform.position.y + CellSize.y);
		}
		if (Input.GetKeyDown(KeyCode.S) && !Physics2D.Raycast(transform.position, Vector2.down,1f,WallLayer))
		{
			transform.position = new Vector2(transform.position.x, transform.position.y - CellSize.y);
		}
	}
	private void StandartMove()
	{
		Moving();
		if (Input.GetButton("Jump") && DoGrounded())
		{
			Jump();
		}
	}
	private bool DoMove(Vector2 dir)
	{
		Debug.DrawLine(transform.localPosition, dir, Color.green);

		if (Physics2D.Raycast(transform.position, dir).transform.gameObject.layer == WallLayer.value)
		{
			return false;
		}
		return true;
	}
	private bool DoGrounded()
	{
		return Physics2D.OverlapBox(GroundBox.transform.position, BoxSize, 0, GroundLayer) != null;
	}
    private void Moving()
	{
        _rb.velocity = new Vector2(Speed * InputX, _rb.velocity.y);
    }
	private void InputHandler()
	{
		InputX = Input.GetAxis("Horizontal");
		InputY = Input.GetAxis("Vertical");
	}
	
	private void Jump()
	{
		_rb.velocity = new Vector2(_rb.velocity.x,JumpForce);
	}
    private void Update()
    {
        if (TypeMove == TypeMove.CellMove)
        {
			CellMove();
        }
        if (TypeMove == TypeMove.StandartMove)
        {
            if (_rb.bodyType == RigidbodyType2D.Static) _rb.bodyType = RigidbodyType2D.Dynamic;
            StandartMove();
        }
        InputHandler();
    }
    internal string[] GetLayerNames()
    {
        int maxLayers = 32;

        string[] layerNames = new string[maxLayers];

        for (int i = 0; i < maxLayers; i++)
        {
            string layerName = LayerMask.LayerToName(i);
			if (layerName != "\r\n") { layerNames[i] = layerName; }
        }

        return layerNames;
    }
    private void OnDrawGizmosSelected()
    {
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(GroundBox.transform.position, BoxSize);
    }
}

[CustomEditor(typeof(Move)), CanEditMultipleObjects]
public class MoveEditor: Editor
{
	public override void OnInspectorGUI()
	{
		var move = (Move)target;
        string[] options = move.GetLayerNames();
        move.TypeMove = (TypeMove)EditorGUILayout.EnumPopup("Select type move", move.TypeMove);
		switch (move.TypeMove)
		{
			case TypeMove.StandartMove:
				move.Speed = EditorGUILayout.Slider("Speed", move.Speed, 1f, 20f);
				move.JumpForce = EditorGUILayout.Slider("Jump Force", move.JumpForce, 1f, 20f);
                if (move.GroundBox == null)
                    move.GroundBox = new GameObject("Ground Box");
                move.GroundLayer= (LayerMask)EditorGUILayout.MaskField("Ground Layer", move.GroundLayer, options);
                move.GroundBox = (GameObject)EditorGUILayout.ObjectField(move.GroundBox, typeof(GameObject), true);
                move.BoxSize = EditorGUILayout.Vector2Field("Ground Box Size", move.BoxSize);
				break;

			case TypeMove.CellMove:
				move.CellSize = EditorGUILayout.Vector2Field("Cell Size", move.CellSize);
				move.SmoothTime = EditorGUILayout.Slider("Smooth Time", move.SmoothTime, 0f, 1f);
                move.WallLayer = (LayerMask)EditorGUILayout.MaskField("Wall Layer", move.WallLayer, options);
                break;
		}
	}
}
