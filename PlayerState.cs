using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour
{
    // ���״̬ // 1����  2����  3����  4�Ҹ�  5����
    public int playerState = 1;
    private int health;
    private int energy;
    public int healthMax;
    public int energyMax;
    public float hitCdTime;
    private float totalHealthTime = 0;
    private float totalHungerTime = 0;
    public float flashTime;

    private SpriteRenderer sr;
    private Color originalColor;
    public GameObject blood;
    public CapsuleCollider2D cc2d;
    private Animator anim;
    private Rigidbody2D rb;

    void Start()
    {
        StatefulSystem.HealthMax = healthMax;
        StatefulSystem.HealthCurrent = healthMax;
        health = healthMax;
        StatefulSystem.EnergyMax = energyMax;
        StatefulSystem.EnergyCurrent = energyMax;
        energy = energyMax;

        cc2d = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        UpdateEnergy();
        UpdateHealth();
    }

    void UpdateEnergy()//���¼���ֵ
    {
        // 24����    1440��
        totalHungerTime += Time.fixedDeltaTime;
        if (totalHungerTime >= 14.4)
        {
            if (energy > 0)
            {
                energy -= 1;
                StatefulSystem.EnergyCurrent = energy;
            }
            totalHungerTime = 0;
        }
    }

    void UpdateHealth()//��������ֵ
    {
        totalHealthTime += Time.fixedDeltaTime;
        if (totalHealthTime >= 1)
        {
            if (health > 0)
            {
                if (energy <= 10)
                {
                    health -= 1;
                    StatefulSystem.HealthCurrent = health;
                }
                else if(energy >= 80)
                {
                    health += 1;
                    StatefulSystem.HealthCurrent = health;
                }
            }
            else
            {
                StatefulSystem.HealthCurrent = 0;
                Die();
            }
            totalHealthTime = 0;
        }
    }

    public void TreatPlayer(int num)//�ظ�����ֵ
    {
        health += num;
        if(health > healthMax)
        {
            health = healthMax;
        }
        StatefulSystem.HealthCurrent = health;
    }

    public void FeedPlayer(int num)//�ظ�����ֵ
    {
        energy += num;
        if (energy > energyMax)
        {
            energy = energyMax;
        }
        StatefulSystem.EnergyCurrent = energy;
    }

    public void DamagePlayer(int damage)//����
    {
        health -= damage;
        StatefulSystem.HealthCurrent = health;
        FlashColor(flashTime);//����
        //��Ѫ��Ч
        //Instantiate(blood, transform.position, Quaternion.identity);
        cc2d.enabled = false;
        StartCoroutine(ShowHit());//�����˺�
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        Destroy(gameObject, 1f);
        anim.SetTrigger("Die");
    }

    void FlashColor(float time)
    {
        sr.color = Color.red;
        Invoke("ResetColor", time);
    }

    void ResetColor()
    {
        sr.color = originalColor;
    }

    public void Lose()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(2);
    }

    IEnumerator ShowHit()
    {
        yield return new WaitForSeconds(hitCdTime);
        cc2d.enabled = true;
    }
}
