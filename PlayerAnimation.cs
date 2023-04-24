using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>(); // Компонент Аниматора
    }
    private void ChangingAnimation()
    {
        animator.SetBool("Run", !animator.GetBool("Run")); // Обращения к параметру bool и уствновка на обратное значения (Если True то False или на оборот)
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.R)) // Вызов метода на клавишу R
        {
            ChangingAnimation();
        }
    }
}
