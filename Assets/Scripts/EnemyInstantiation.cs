using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class EnemyInstantiation : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject Player;
    GameObject[] enemyInstantiations = new GameObject[300];
    public Transform[] instantiatingPoints;
    public TextMeshProUGUI waveNo;
    public TextMeshProUGUI winText;
    public bool nextWave = false;
    [Header("Other Scripts")]
    [SerializeField] private Timer timer;

    [Header("Post Processing")]
    public Volume m_Volume;
    ColorAdjustments m_ColorAdjust;
    // Start is called before the first frame update
    void Start()
    {
        GameObject enemy = Instantiate(enemies[Random.Range(0,enemies.Length)], instantiatingPoints[Random.Range(0,instantiatingPoints.Length)]);
        waveNo.text = "Wave 1";
        m_Volume.profile.TryGet(out m_ColorAdjust);
    }

    // Update is called once per frame
    void Update()
    {
        switch(timer.timerWave)
        {
            case 2:
                if (nextWave == false)
                {
                    waveNo.text = "Wave 2";
                    for (int i = 0; i < 2; i++)
                        enemyInstantiations[i] = Instantiate(enemies[Random.Range(0, enemies.Length)], instantiatingPoints[Random.Range(0, instantiatingPoints.Length)]);
                    nextWave = true;
                }
                break;

            //case 3:
            //    if (nextWave == false)
            //    {
            //        m_ColorAdjust.active = true;
            //        waveNo.text = "Wave 3";
            //        for (int i = 0; i < 2; i++)
            //            enemyInstantiations[i] = Instantiate(enemies[Random.Range(0, enemies.Length)], instantiatingPoints[Random.Range(0, instantiatingPoints.Length)]);
            //        nextWave = true;
            //    }
            //    break;

            //case 4:
            //    if (nextWave == false)
            //    {
            //        waveNo.text = "Wave 4";
            //        for (int i = 0; i < 3; i++)
            //            enemyInstantiations[i] = Instantiate(enemies[Random.Range(0, enemies.Length)], instantiatingPoints[Random.Range(0, instantiatingPoints.Length)]);
            //        nextWave = true;
            //    }
            //    break;

            //case 5:
            //    if (nextWave == false)
            //    {
            //        waveNo.text = "Wave 5";
            //        for (int i = 0; i < 4; i++)
            //            enemyInstantiations[i] = Instantiate(enemies[Random.Range(0, enemies.Length)], instantiatingPoints[Random.Range(0, instantiatingPoints.Length)]);
            //        nextWave = true;
            //    }
            //    break;

            //case 6:
            //    if (nextWave == false)
            //    {
            //        waveNo.text = "Wave 6";
            //        for (int i = 0; i < 5; i++)
            //            enemyInstantiations[i] = Instantiate(enemies[Random.Range(0, enemies.Length)], instantiatingPoints[Random.Range(0, instantiatingPoints.Length)]);
            //        nextWave = true;
            //    }
            //    break;

            //case 7:
            //    if (nextWave == false)
            //    {
            //        waveNo.text = "Wave 7";
            //        for (int i = 0; i < 6; i++)
            //            enemyInstantiations[i] = Instantiate(enemies[Random.Range(0, enemies.Length)], instantiatingPoints[Random.Range(0, instantiatingPoints.Length)]);
            //        nextWave = true;
            //    }
            //    break;

            //case 8:
            //    if (nextWave == false)
            //    {
            //        waveNo.text = "Wave 8";
            //        for (int i = 0; i < 7; i++)
            //            enemyInstantiations[i] = Instantiate(enemies[Random.Range(0, enemies.Length)], instantiatingPoints[Random.Range(0, instantiatingPoints.Length)]);
            //        nextWave = true;
            //    }
            //    break;
        }
        if(GameObject.FindGameObjectWithTag("Enemy")==null)
        {
            Player.SetActive(false);
            StartCoroutine(WeWon());
        }
    }

    IEnumerator WeWon()
    {
        yield return new WaitForSeconds(3f);
        winText.text = "victory!";
        Time.timeScale = 0;
        this.enabled = false;
    }


}
