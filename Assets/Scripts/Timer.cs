using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Image timerBar;
    float timer;
    public int timerWave = 1;

    [Header("Other Scripts")]
    [SerializeField] private EnemyInstantiation enemyInstantiation;
    // Start is called before the first frame update
    void Start()
    {
        timer = 10f;
        timerBar.fillAmount = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
            timerBar.fillAmount = (timerBar.fillAmount - Time.deltaTime * 0.1f);
        }
        else
        {
            timer = 10;
            timerBar.fillAmount = 1;
            enemyInstantiation.nextWave = false;
            timerWave++;
        }
        
    }
}
