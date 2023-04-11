using UnityEngine;

public class Health : MonoBehaviour
{
	[SerializeField][HideInInspector] protected float _maxHealth = 100f;
	[SerializeField][HideInInspector] protected float _health = 100f;

	[SerializeField] public float health
	{
		get => _health;
		set { if (value <= _maxHealth && value >= 0) _health = value; }
	}
	[SerializeField] public void DoDamage(float Damage)
	{
		if (Damage >= _maxHealth)
		{
			_health = 0;
		}
		else
		{
			_health -= Damage;
		}
	}
	[SerializeField] public float maxhealth
	{
		get => _maxHealth;
		set => _maxHealth = value;
	}
}
