using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public static HealthBar healthBar;
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] Ulti _ulti;

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
    private float heal;

    private bool _isReTakeDamage = false;

    public float pv;

    [SerializeField] ParticleSystem _lastChanceParticules;
    [SerializeField] ParticleSystem _lastChanceParticules2;

    private void Awake()
    {
         hb1_life.SetActive(true);
        hb2_life.SetActive(true);
        hb3_life.SetActive(true);
        hb4_life.SetActive(true);
        
    }
    void Start()
    {
        
    }

    void Update()
    {
        pv = playerHealth.m_currentHealth;

        if (_ulti.isRevived)
        {
            hA1 = 1;
            hA2 = 1;
            hA3 = 1;
            hA4 = 1;
            hb1_life.SetActive(true);
            hb2_life.SetActive(true);
            hb3_life.SetActive(true);
            hb4_life.SetActive(true);
            UpdateHB();
            UpdateHB2();
            UpdateHB3();
            UpdateHB4();
            _ulti.isRevived = false;
            _lastChanceParticules.Stop();
            _lastChanceParticules2.Stop();
        }

    }

    public void UpdateHB() { hb1.value = hA1 / 1; }
    public void UpdateHB2() { hb2.value = hA2 / 1; }
    public void UpdateHB3() { hb3.value = hA3 / 1; }
    public void UpdateHB4() { hb4.value = hA4 / 1; }

    public void TakeDamageUI()
    {
        if (playerHealth.m_currentHealth == 5)
        {
            hb1.value = 1;
            hb2.value = 1;
            hb3.value = 1;
            hb4.value = 1;
            hb1_life.SetActive(true);
            hb2_life.SetActive(true);
            hb3_life.SetActive(true);
            hb4_life.SetActive(true);

        }
        else if (playerHealth.m_currentHealth == 4)
        {
            hb1.value = 0;
            UpdateHB();
            hb1_life.SetActive(false);


        }
        else if (playerHealth.m_currentHealth == 3)
        {
            hb1.value = 0;
            hb2.value = 0;
            UpdateHB2();
            hb1_life.SetActive(false);
            hb2_life.SetActive(false);

        }
        else if (playerHealth.m_currentHealth == 2)
        {
            hb1.value = 0;
            hb2.value = 0;
            hb3.value = 0;
            UpdateHB3();
            hb1_life.SetActive(false);
            hb2_life.SetActive(false);
            hb3_life.SetActive(false);

        }
        else if(playerHealth.m_currentHealth == 1)
        {
            hb1.value = 0;
            hb2.value = 0;
            hb3.value = 0;
            hb4.value = 0;
            UpdateHB4();
            hb1_life.SetActive(false);
            hb2_life.SetActive(false);
            hb3_life.SetActive(false);
            hb4_life.SetActive(false);
            _lastChanceParticules.Play();
            _lastChanceParticules2.Play();

        }

    }





    #region OldHealthBarSystemeFunctions
    public void NotUnder0()
    {
        if (hA1 < 0)
        {
            float _damage = damage - hA1 * (-1);
            damage = _damage;
            hA1 = 0;
            _isReTakeDamage = true;
        }
        if (hA2 < 0)
        {
            float _damage = damage - hA2 * (-1);
            damage = _damage;
            hA2 = 0;
            _isReTakeDamage = true;
        }
        if (hA3 < 0)
        {
            float _damage = damage - hA3 * (-1);
            damage = _damage;
            hA3 = 0;
            _isReTakeDamage = true;
        }
        if (hA4 < 0)
        {
            float _damage = damage - hA4 * (-1);
            damage = _damage;
            hA4 = 0;
            _isReTakeDamage = true;
        }

        if (hA1 > 35) { hA1 = 35; }
        if (hA2 > 15) { hA2 = 15; }
        if (hA3 > 35) { hA3 = 35; }
        if (hA4 > 15) { hA4 = 15; }

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
    #endregion
}
