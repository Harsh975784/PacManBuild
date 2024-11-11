using System.Collections;
using UnityEngine;

public class PlayAnimationClipsForStartScreen : MonoBehaviour
{
    [SerializeField] private GameObject[] animationClips;
    private bool animStarted;
    private int i, j;
    private Animator animator;
    private void Awake()
    {
        animStarted = false;
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        StartCoroutine(PlayClip());
    }
    private IEnumerator PlayClip()
    {
        for (i = 0; i < animationClips.Length; i++)
        {
            animationClips[i].SetActive(true);
            yield return new WaitForSeconds(1.3f);
            animStarted = true;
            if (animStarted)
            {
                for (j = 0; j < i + 1; j++)
                {
                    animationClips[j].SetActive(false);
                    yield return new WaitForSeconds(0.2f);
                    animStarted = false;
                }
            }
        }
    }
}
