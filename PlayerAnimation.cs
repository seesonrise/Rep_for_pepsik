using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>(); // ��������� ���������
    }
    private void ChangingAnimation()
    {
        animator.SetBool("Run", !animator.GetBool("Run")); // ��������� � ��������� bool � ��������� �� �������� �������� (���� True �� False ��� �� ������)
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.R)) // ����� ������ �� ������� R
        {
            ChangingAnimation();
        }
    }
}
