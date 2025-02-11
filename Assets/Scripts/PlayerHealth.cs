using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public static PlayerHealth instance;
    public string sceneName;
    public Healthbar healthbar;

    public float immortalTime;
    private float immortalCounter;

    private SpriteRenderer sr;

    private void Awake()
    {
        instance = this;
    }
   
   
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        sr=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(immortalCounter > 0)
        {
            immortalCounter -= Time.deltaTime;
            if(immortalCounter <= 0)
            {
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f);
            }
        }
    }

    public void DealDamage()
    {
        if(immortalCounter <= 0)
        {
            currentHealth--;
            healthbar.SetHealth(currentHealth);

            if (currentHealth < -0)
            {
                SceneManager.LoadScene(sceneName);
                gameObject.SetActive(false);
            }
            else
            {
                immortalCounter = immortalTime;
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f);
            }
        }
    }





    
}
