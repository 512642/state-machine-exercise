using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    private int maxHealth;
    private int currentHealth;
    [SerializeField]
    private UnityEngine.UI.Slider healthbar;
	// Use this for initialization
	void Start () {
		
	}

    public void SetHealth(int amount)
    {
        currentHealth = maxHealth = amount;
        OnHealthChange();
    }
    
    void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        OnHealthChange();
    }
    void OnHealthChange()
    {
        healthbar.value = (float)currentHealth / (float)maxHealth;
    }

    public IEnumerator TakeDamageDelayed(int amount, float delay)
    {

        yield return new WaitForSeconds(delay);
        currentHealth = Mathf.Max(currentHealth - amount, 0);
        if (currentHealth == 0)
        {
            SetHealth(20);
        }
        OnHealthChange();
    }
}
