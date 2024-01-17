using UnityEngine;
using UnityEngine.Tilemaps;

public class CellMove : MonoBehaviour
{
	[SerializeField] private float moveSpeed;
	[SerializeField] private Vector2Int CellSize;
	[SerializeField] private Tilemap map;
	[SerializeField] private float nextMove;

	private bool CheckToCell(Vector3Int pos)
	{
		return !map.HasTile(pos);
	}

	private void Moving()
	{
        if (Input.GetKey(KeyCode.D) && CheckToCell(new Vector3Int(Mathf.RoundToInt(transform.position.x) + 1, Mathf.RoundToInt(transform.position.y))))
		{
			transform.position = new Vector2(transform.position.x + CellSize.x, transform.position.y);
		}
		if (Input.GetKey(KeyCode.A) && CheckToCell(new Vector3Int(Mathf.RoundToInt(transform.position.x) - 1, Mathf.RoundToInt(transform.position.y))))
		{
			transform.position = new Vector2(transform.position.x - CellSize.x, transform.position.y);
		}
		if (Input.GetKey(KeyCode.W) && CheckToCell(new Vector3Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y) + 1)))
		{
			transform.position = new Vector2(transform.position.x, transform.position.y + CellSize.y);
		}
		if (Input.GetKey(KeyCode.S) && CheckToCell(new Vector3Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y) - 1)))
		{
			transform.position = new Vector2(transform.position.x, transform.position.y - CellSize.y);
		}
	}
	private void FixedUpdate()
	{
		if ((Input.GetAxis("Horizontal") != 0  || Input.GetAxis("Vertical") != 0 ) && Time.time > nextMove )
		{
            Moving();
			nextMove = Time.time + moveSpeed;
        }
	}
}
