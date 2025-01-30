using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class TextDisplay : MonoBehaviour
{
    [SerializeField] MapProgressionScript mapProg;

    [SerializeField] InputAction onClick;

    [SerializeField] private TMP_Text historyInfo;

    [SerializeField][TextArea(5, 50)] private List<string> testText;

    private int cVIndex;
    private Coroutine typewriterCoroutine;

    private WaitForSeconds sDelay;
    private WaitForSeconds iPDelay;
    private WaitForSeconds iPDelay2;

    [SerializeField] public float charactersPerSecond = 30.0f;
    [SerializeField] public float interepunctuationDelay = 0.5f;
    [SerializeField] public float interepunctuationDelay2 = 0.25f;

    public bool CurrentlySkipping { get; private set; }
    private WaitForSeconds skipDelay;
    [SerializeField] private bool quickSkip;
    [SerializeField] private int skipSpeedup = 5;

    private void Awake()
    {
        sDelay = new WaitForSeconds(1 / charactersPerSecond);
        iPDelay = new WaitForSeconds(interepunctuationDelay);
        iPDelay2 = new WaitForSeconds(interepunctuationDelay2);

        skipDelay = new WaitForSeconds(1 / (charactersPerSecond * skipSpeedup));
    }

    void Start()
    {

    }

    void Update()
    {
        if (mapProg.textRunning)
        {
            SetText(testText[GameProgress.gpInstance.locationCount]);
            mapProg.textRunning = false;
        }
        
        if (onClick.WasPressedThisFrame() && mapProg.textLaidOut)
        {
            if (historyInfo.maxVisibleCharacters != historyInfo.textInfo.characterCount - 1)
            {
                SkipText();
            }
        }

        if (historyInfo.maxVisibleCharacters == historyInfo.textInfo.characterCount - 1)
        {
            mapProg.textLaidOut = false;
            GameProgress.gpInstance.played = true;
        }
    }

    /*
     * Speeds up the display of the texts.
     */
    void SkipText()
    {
        if (CurrentlySkipping)
            return;

        CurrentlySkipping = true;

        if (!quickSkip)
        {
            StartCoroutine(SkipSpeedupReset());
            return;
        }

        if (historyInfo.maxVisibleCharacters == historyInfo.textInfo.characterCount)
        {
            mapProg.textLaidOut = false;
        }
    }

    private IEnumerator SkipSpeedupReset()
    {
        yield return new WaitUntil(() => historyInfo.maxVisibleCharacters == historyInfo.textInfo.characterCount);
        CurrentlySkipping = false;
    }

    public void SetText(string text)
    {
        if (typewriterCoroutine != null)
        {
            StopCoroutine(typewriterCoroutine);
        }

        historyInfo.text = text;
        historyInfo.maxVisibleCharacters = 0;
        cVIndex = 0;

        typewriterCoroutine = StartCoroutine(Typewriter());
    }

    private IEnumerator Typewriter()
    {
        TMP_TextInfo textInfo = historyInfo.textInfo;

        while (cVIndex < textInfo.characterCount)
        {


            char character = textInfo.characterInfo[cVIndex].character;

            historyInfo.maxVisibleCharacters++;

            if (character == '?' || character == '.' || character == '!')
            {
                yield return iPDelay;
            }
            else if (character == '-' || character == ',' || character == ';')
            {
                yield return iPDelay2;
            }
            else
            {
                yield return CurrentlySkipping ? skipDelay : sDelay;
            }

            cVIndex++;
        }
    }

    private void OnEnable()
    {
        onClick.Enable();
    }
    private void OnDisable()
    {
        onClick.Disable();
    }
}
