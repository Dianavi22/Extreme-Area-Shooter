using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public static HealthBar healthBar;
    [SerializeField] PlayerHealth playerHealth;

    [SerializeField] Slider hb1;
    [SerializeField] Slider hb2;
    [SerializeField] Slider hb3;
    [SerializeField] Slider hb4;

    [SerializeField] GameObject hb1_life;
    [SerializeField] GameObject hb2_life;
    [SerializeField] GameObject hb3_life;
    [SerializeField] GameObject hb4_life;


    [SerializeField] float hA1 = 35;
    [SerializeField] float hA2 = 15;
    [SerializeField] float hA3 = 35;
    [SerializeField] float hA4 = 15;



    public float damage;
    public float heal;

    public bool connard = false;
    // Start is called before the first frame update
    void Start()
    {
       // playerHealth.m_currentHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {

            TakeDamageUI();
            if (connard)
            {
                print("TakeDamage x2");

                TakeDamageUI();
                connard = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeHealUI();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {

            damage = 3;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {

            damage = 13;
        }

        if (!playerHealth.isAlive)
        {
            hb4_life.SetActive(false);
        }

    }

    public void UpdateHB()
    {
        hb1.value = hA1 / 35;
    }
    public void UpdateHB2()
    {
        hb2.value = hA2 / 15;
    }
    public void UpdateHB3()
    {
        hb3.value = hA3 / 35;
    }
    public void UpdateHB4()
    {
        hb4.value = hA4 / 15;
    }

    public void TakeDamageUI()
    {
        NotUnder0();
        if (hA1 >= 0 && playerHealth.m_currentHealth >= 65)
        {
            print("hA1 case 1 : " + hA1);

            hA1 -= damage;
            NotUnder0();
            UpdateHB();
            SetActivSlider();
            print("lifeBar case 1 : " + playerHealth.m_currentHealth);
        }
        else if (hA2 >= 0 && playerHealth.m_currentHealth < 65 && playerHealth.m_currentHealth >= 50)
        {
            print("hA2 case 2 : " + hA2);

            hA2 -= damage;
            NotUnder0();
            UpdateHB2();
            SetActivSlider();
            print("lifeBar case 2 : " + playerHealth.m_currentHealth);
        }
        else if (hA3 >= 0 && playerHealth.m_currentHealth < 50 && playerHealth.m_currentHealth >= 15)
        {
            print("hA3 case 3 : " + hA3);

            hA3 -= damage;
            NotUnder0();
            UpdateHB3();
            SetActivSlider();
            print("lifeBar case 3 : " + playerHealth.m_currentHealth);
        }
        else
        {
            print("hA1 case 4 : " + hA4);

            hA4 -= damage;
            NotUnder0();
            UpdateHB4();
            SetActivSlider();
            print("lifeBar case 4 : " + playerHealth.m_currentHealth);
        }
        //playerHealth.m_currentHealth -= damage;

    }

    public void TakeHealUI()
    {
        NotUnder0();
        print("lifeBar : " + playerHealth.m_currentHealth);
        if (hA1 >= 0 && playerHealth.m_currentHealth > 65)
        {
            hA1 += heal;
            NotUnder0();
            UpdateHB();
            SetActivSlider();
            print("lifeBar case 1 : " + playerHealth.m_currentHealth);
        }
        else if (hA2 >= 0 && playerHealth.m_currentHealth <= 65 && playerHealth.m_currentHealth > 50)
        {
            hA2 += heal;
            NotUnder0();
            UpdateHB2();
            SetActivSlider();
            print("lifeBar case 2 : " + playerHealth.m_currentHealth);
        }
        else if (hA3 >= 0 && playerHealth.m_currentHealth <= 50 && playerHealth.m_currentHealth > 15)
        {
            hA3 += heal;
            NotUnder0();
            UpdateHB3();
            SetActivSlider();
            print("lifeBar case 3 : " + playerHealth.m_currentHealth);
        }
        else
        {
            hA4 += heal;
            UpdateHB4();
            SetActivSlider();
            print("lifeBar case 4 : " + playerHealth.m_currentHealth);
        }
    }

    public void NotUnder0()
    {
        if (hA4 < 0)
        {
            float _damage = damage - hA4 * (-1);
            print("Damage dif : " + _damage + " / hA4 " + hA4 + "  damage : " + damage);
            damage = _damage;

            hA4 = 0;
            connard = true;

        }
        if (hA3 < 0)
        {
            float _damage = damage - hA3 * (-1);
            print("Damage dif : " + _damage + " / hA3 " + hA3 + "  damage : " + damage);

            damage = _damage;

            hA3 = 0;
            connard = true;

        }
        if (hA2 < 0)
        {
            float _damage = damage - hA2 * (-1);
            print("Damage dif : " + _damage + " / hA2 " + hA2 + "  damage : " + damage);

            damage = _damage;

            hA2 = 0;
            connard = true;

        }
        if (hA1 < 0)
        {
            float _damage = damage - hA1 * (-1);
            print("Damage dif : " + _damage  + " / damage : " + damage + " hA1 : " + hA1);

            damage = _damage;

            hA1 = 0;
            connard = true;
        }

        if (hA4 > 15) { hA4 = 15; }
        if (hA3 > 35) { hA3 = 35; }
        if (hA2 > 15) { hA2 = 15; }
        if (hA1 > 35) { hA1 = 35; }


        return;
    }

    public void SetActivSlider()
    {
        if (hA1 > 0) { hb1_life.SetActive(true); }
        else { hb1_life.SetActive(false); }

        if (hA2 > 0) { hb2_life.SetActive(true); }
        else { hb2_life.SetActive(false); }

        if (hA3 > 0) { hb3_life.SetActive(true); }
        else { hb3_life.SetActive(false); }

        if (hA4 > 0) { hb4_life.SetActive(true); }
        else { hb4_life.SetActive(false); }
    }

}
