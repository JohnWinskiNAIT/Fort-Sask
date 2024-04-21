using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PressureMeterManager : MonoBehaviour
{
    [Header("Object References")]
    public GameObject pressureNeedle;
    public GameObject mercuryBar;
    public TMP_Text endScreen;

    [Header("Script References")]
    public WheelDragMotion wdm;

    float rotationSpeed = 40f;
    float maxRotationAngle = 89f;
    float targetAngle = 0f;

    public int boxKept;

    void Start()
    {
        boxKept = 3;
    }

    void Update()
    {
        PressureNeedleMover();

        MercuryBarMover();

        boxKept = Mathf.Clamp(boxKept, 0, 3);

        SwitchTexts();
    }

    private void PressureNeedleMover()
    {
        float rotationDirection = wdm.usingWheel ? 1f : -1f;

        targetAngle += rotationDirection * rotationSpeed * Time.deltaTime;

        targetAngle = Mathf.Clamp(targetAngle, -maxRotationAngle, maxRotationAngle);

        pressureNeedle.transform.rotation = Quaternion.Euler(0, 0, targetAngle);
    }

    private void MercuryBarMover()
    {
        if (targetAngle >= 45f || targetAngle <= -45f)
        {
            Vector3 currentScale = mercuryBar.transform.localScale;
            currentScale.x += 0.5f * Time.deltaTime;

            currentScale.x = Mathf.Clamp(currentScale.x, 0f, 4f);

            mercuryBar.transform.localScale = currentScale;
        }

        if (mercuryBar.transform.localScale.x >= 4)
        {
            wdm.controlledWheel = false;
        }
    }

    private void SwitchTexts()
    {
        switch(boxKept)
        {
            case 0:
                endScreen.text = "But you lost all of them...";
                break;
            case 1:
                endScreen.text = "But you lost 2 crates";
                break;
            case 2:
                endScreen.text = "But you lost a crate";
                break;
            default:
                endScreen.text = "All in one piece, too!";
                break;
        }
    }
}
