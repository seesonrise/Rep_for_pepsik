using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>(); // Êîìïîíåíò Àíèìàòîðà
    }
    private void ChangingAnimation()
    {
        animator.SetBool("Run", !animator.GetBool("Run")); // Îáðàùåíèÿ ê ïàðàìåòðó bool è óñòâíîâêà íà îáðàòíîå çíà÷åíèÿ (Åñëè True òî False èëè íà îáîðîò)
    }
    private void FixedUpdate()
    {
        if (Input.GetButton("Horizontal")) // Âûçîâ ìåòîäà íà êëàâèøó R
        {
            ChangingAnimation();
        }
    }
}
