using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private GameObject[] healthIcons;
    [SerializeField] private GameObject player, panel;
    private string scoreHolder;
    private int livesCount;
    AudioSource loseLiveCountAudioSource;
    private void Start()
    {
        loseLiveCountAudioSource = GetComponent<AudioSource>();
        panel.SetActive(false);
        livesCount = 0;
    }
    private void Update()
    {
        if (livesCount > 5) 
        {
            player.SetActive(false);
        }
        if(!player.activeSelf)
        {
            panel.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            healthIcons[livesCount++].SetActive(false);
            loseLiveCountAudioSource.Play();
           /* for (livesCount=0;livesCount<healthIcons.Length;livesCount++)
            {
                healthIcons[livesCount].SetActive(false);
                loseLiveCountAudioSource.Play();
                break;
            }*/
        }
    }

    private void Restart()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            for (livesCount = 0; livesCount < 5; livesCount++)
            {
                healthIcons[livesCount].SetActive(true);
            }
            panel.SetActive(false);
        }
    }
}
