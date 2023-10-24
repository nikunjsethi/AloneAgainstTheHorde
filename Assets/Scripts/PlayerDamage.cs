using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class PlayerDamage : MonoBehaviour
{
    public GameObject Player;
    [Header("UIs and Audio")]
    public Image healthHurt;
    public Image healthBar;
    bool gameFinished = false;
    public TextMeshProUGUI gameOverText;
    public AudioSource _playerInjuredAudio;

    [Header("Post Processing")]
    public Volume m_Volume;
    MotionBlur m_MotionBlurr;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        healthHurt = GameObject.Find("InjuredEffect").GetComponent<Image>();
        healthBar = GameObject.Find("HealthBar").GetComponent<Image>();
        gameOverText = GameObject.Find("GameOverText").GetComponent<TextMeshProUGUI>();
        _playerInjuredAudio = GameObject.FindGameObjectWithTag("PlayerBody").GetComponent<AudioSource>();
        m_Volume = GameObject.Find("Global Volume").GetComponent<Volume>();
        m_Volume.profile.TryGet(out m_MotionBlurr);
    }

    private void Update()
    {
        if (gameFinished == false)
        {
            if(healthBar.fillAmount<0.5f)
            {
                m_MotionBlurr.active = true;
            }
            if (healthBar.fillAmount == 0)
            {
                gameOverText.text = "game over";
                gameFinished = true;
                healthHurt.enabled = true;
                //Player.SetActive(false);
                Time.timeScale = 0;
                this.enabled = false;
            }
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PlayerBody"))
        {
            StartCoroutine(PlayerHurt());
        }
    }

    IEnumerator PlayerHurt()
    {
        healthHurt.enabled = true;
        _playerInjuredAudio.Play();
        healthBar.fillAmount = healthBar.fillAmount - 0.001f;         //the max health is 1f
        yield return new WaitForSeconds(3f);
        healthHurt.enabled = false;
    }
}
