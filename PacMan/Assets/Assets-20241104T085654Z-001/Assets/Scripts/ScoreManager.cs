using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private AudioClip[] audioClip;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject winText;
    private int score;
    private int maxPoints = 3710;
    public string scorePoints;
    private AudioSource coinsAudioSource;
    private void Start()
    {
        score = 0;
        winText.SetActive(false);
        coinsAudioSource = GetComponent<AudioSource>();
    }
    public int Score
    {
        get { return score; }
    }
    private void Update()
    {
        scorePoints = Score.ToString();
        scoreText.text = scorePoints;
        if(score == maxPoints)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].SetActive(false);
                winText.SetActive(true);
            }
        }
    }
    private void PlayAudioOfCoins(int index)
    {
        if (index >= 0 && index < audioClip.Length)
        {
            coinsAudioSource.Stop();
            coinsAudioSource.clip = audioClip[index];
            coinsAudioSource.Play();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            collision.gameObject.SetActive(false);
            PlayAudioOfCoins(0);
            score += 10;
        }
        else if (collision.CompareTag("Bonus"))
        {
            collision.gameObject.SetActive(false);
            PlayAudioOfCoins(1);
            score += 100;
        }
    }
}
