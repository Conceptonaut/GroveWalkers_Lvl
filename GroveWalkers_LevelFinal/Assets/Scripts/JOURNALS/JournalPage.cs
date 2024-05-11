using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalPage : Interactable
{
    public static JournalPage Instance;

    public float fadeTime = 0.1f;
    public float bounceTime = .1f;

    private bool canToggleJournal = true;
    private CanvasGroup canvasGroup;
    public GameObject journalScreen;
    public Sprite entryNumber;

    public AudioSource journalAudio;

    Sequence sequence;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        sequence = DOTween.Sequence();
        journalScreen.transform.localScale = Vector3.zero;
        canvasGroup = journalScreen.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0f;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void Interact()
    {
        base.Interact();
        ToggleJournalScreen();
        journalAudio.Play();

        
        //this.transform.rotation = 
    }

    public void ToggleJournalScreen()
    {
        if (canToggleJournal == true)
        {
            journalScreen.transform.DOKill();
            UnlockMouse();

            sequence.Kill();
            sequence = DOTween.Sequence();
            

            if (journalScreen.transform.localScale == Vector3.zero)
            {

                sequence.Append(journalScreen.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), fadeTime));
                sequence.Append(journalScreen.transform.DOScale(Vector3.one, bounceTime));
                sequence.Insert(0f, canvasGroup.DOFade(1f, fadeTime));

                sequence.Play();

            }
            else
            {
                journalScreen.transform.DOScale(Vector3.zero, fadeTime);
                canvasGroup.DOFade(0f, fadeTime);
                Player.instance.FPScontroller.cameraCanMove = true;
                LockMouse();

            }
            StartCoroutine(WaitForPauseMenu());
        }
    }

    private IEnumerator WaitForPauseMenu()
    {
        yield return new WaitForSeconds(fadeTime);
        canToggleJournal = true;
    }

    public void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
