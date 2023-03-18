using UnityEngine;

public class SmoothCameraMove : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField][Range(.1f, 100f)] float _smoothTime;

    private void FixedUpdate()
    {
        Vector3 _targetPos = _target.position + _offset;
        transform.position = Vector3.Lerp(transform.position, _targetPos, _smoothTime);
    }
}
