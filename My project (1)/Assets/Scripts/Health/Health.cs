using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    [SerializeField]private AudioClip deathSound;
	private UIManager uiManager;
	
    [Header("Is Player?")]
    [SerializeField] private bool isPlayer;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        uiManager = FindObjectOfType<UIManager>();

    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            SoundManager.instance.PlaySound(deathSound);
            if (!dead)
            {
                anim.SetTrigger("die");
                HandleDeath();
                dead = true;
				
            }

            else 
                Debug.Log("Player DEAD!");
        }
    }

 private void HandleDeath()
    {
        if (isPlayer)
        {
            if (GetComponent<PlayerMovement>() != null)
            {
                GetComponent<PlayerMovement>().enabled = false;
            }
            uiManager.GameOver();
			return;
        }
        else
        {
            // Enemy-specific death logic
            if (GetComponentInParent<EnemyPatrol>() != null)
            {
                GetComponentInParent<EnemyPatrol>().enabled = false;
            }
            if (GetComponent<MeleeEnemy>() != null)
            {
                GetComponent<MeleeEnemy>().enabled = false;
            }
            Destroy(gameObject, 2f);
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
}