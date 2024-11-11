using System.Collections;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int speed = 3;
    [SerializeField] private AudioClip[] audioClip;
    [SerializeField] private GameObject[] toggleComponents;
    private float movex, movey;
    private bool isMovementNotActive, isMovingAudioActivated, isMoveSoundPlaying;
    Rigidbody2D rb;
    AudioSource audioSource;
    Animator animator;
    SpriteRenderer spriteRenderer;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource.Play();
        isMovementNotActive = true;
        isMovingAudioActivated = false;
        isMoveSoundPlaying = false;
        toggleComponents[0].SetActive(true);
        toggleComponents[1].SetActive(false);
        StartCoroutine(Timer(5));
    }
    private void Update()
    {
        if (isMovingAudioActivated && !isMoveSoundPlaying)
        {
            PlayAudio(1);
            isMoveSoundPlaying = true;
        }
        if (!isMovementNotActive)
        {
            if ((Input.GetKeyDown(KeyCode.A)) || (Input.GetKeyDown(KeyCode.LeftArrow)))
            {
                //animator.SetTrigger("RightToLeft");
                spriteRenderer.flipX = false;
                animator.SetBool("UpToDown", false);
                animator.SetBool("DownToUp", false);
            }
            else if ((Input.GetKeyDown(KeyCode.D)) || (Input.GetKeyDown(KeyCode.RightArrow)))
            {
                //animator.SetTrigger("LeftToRight");
                spriteRenderer.flipX = true;
                animator.SetBool("UpToDown", false);
                animator.SetBool("DownToUp", false);
            }
            else if ((Input.GetKeyDown(KeyCode.S)) || (Input.GetKeyDown(KeyCode.DownArrow)))
            {
                animator.SetBool("UpToDown", true);
                animator.SetTrigger("Down");
            }
            else if ((Input.GetKeyDown(KeyCode.W)) || (Input.GetKeyDown(KeyCode.UpArrow)))
            {
                animator.SetBool("DownToUp", true);
                animator.SetTrigger("Up");
            }
        }
    }
    private void FixedUpdate()
    {
        if (!isMovementNotActive)
        {
            movex = Input.GetAxis("Horizontal");
            movey = Input.GetAxis("Vertical");
            Vector2 move = new(movex, movey);
            rb.velocity = speed * Time.fixedDeltaTime * move;
        }
    }
    private void PlayAudio(int index)
    {
        if (index >= 0 && index < 2)
        {
            audioSource.clip = audioClip[index];
            audioSource.loop = (index == 1);
            audioSource.Play();
        }
    }
    private IEnumerator Timer(int time)
    {
        yield return new WaitForSeconds(time);
        isMovementNotActive = false;
        toggleComponents[0].SetActive(false);
        toggleComponents[1].SetActive(true);
        isMovingAudioActivated = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            collision.gameObject.SetActive(false);
        }
        else if (collision.CompareTag("Bonus"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
