using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public float fadeTime = 0.1f;
    public float bounceTime = .1f;

    private bool canTogglePause = true;
    private CanvasGroup canvasGroup;

    Sequence sequence;
    // Start is called before the first frame update
    void Start()
    {
        sequence = DOTween.Sequence();
        this.transform.localScale = Vector3.zero;
        canvasGroup = this.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            TogglePauseScreen();
        }
    }

    public void TogglePauseScreen()
    {
        if(canTogglePause == true)
        {
            this.transform.DOKill();

            sequence.Kill();
            sequence = DOTween.Sequence();

            if (this.transform.localScale == Vector3.zero)
            {
               
                sequence.Append(this.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), fadeTime));
                sequence.Append(this.transform.DOScale(Vector3.one, bounceTime));
                sequence.Insert(0f, canvasGroup.DOFade(1f, fadeTime));

                sequence.Play();
                
            }
            else
            {
                this.transform.DOScale(Vector3.zero, fadeTime);
                canvasGroup.DOFade(0f, fadeTime);
            }
            
            StartCoroutine(WaitForPauseMenu());
        }
    }

    private IEnumerator WaitForPauseMenu()
    {
        yield return new WaitForSeconds(fadeTime);
        canTogglePause = true;
    }
}
