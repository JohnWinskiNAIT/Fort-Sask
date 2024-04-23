using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WheelDragMotion : MonoBehaviour
{
    [Header("Internal References")]
    public InputAction mouseClicked;
    public InputAction mouseTracker;
    public Camera cam;

    [Header("Object References")]
    public GameObject ferryWheel;
    public GameObject pbr;

    Vector2 screenMousePos;
    Vector3 worldPos;
    Vector3 savedLocation;

    int fullSpinsCount = 0;

    public bool controlledWheel = true;
    public bool usingWheel = false;
    bool fullSpun = false;
    bool spunDown = false;

    bool wheelSound = false;

    void Start()
    {
        controlledWheel = true;
    }

    void Update()
    {
        #region Wheel Controller
        //screenMousePos = mouseTracker.ReadValue<Vector2>();
        worldPos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));
        worldPos.z = 0f;

        if (controlledWheel)
        {
            if (Input.GetMouseButtonDown(0))
            {
                savedLocation = worldPos;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                savedLocation = Vector3.zero;
            }

            if (savedLocation != Vector3.zero)
            {
                if (worldPos.x < savedLocation.x || worldPos.y < savedLocation.y)
                {
                    usingWheel = true;

                    if (!wheelSound)
                    {
                        FindObjectOfType<AudioManager>().Play("WheelTurn");
                        wheelSound = true;
                    }

                    ferryWheel.transform.Rotate(Vector3.forward, 60f * Time.deltaTime);
                    if (Mathf.Abs(ferryWheel.transform.eulerAngles.z - 360f) <= 1f)
                    {
                        if (!fullSpun)
                        {
                            if (fullSpinsCount < 2)
                            {
                                fullSpinsCount = 2;
                            }
                            else
                            {
                                fullSpinsCount++;
                            }
                            fullSpun = !fullSpun;
                        }
                        ferryWheel.transform.rotation = Quaternion.Euler(ferryWheel.transform.eulerAngles.x, ferryWheel.transform.eulerAngles.y, ferryWheel.transform.eulerAngles.z - 360f);
                    }
                    else
                    {
                        fullSpun = false;
                    }
                }
            }
            else
            {
                usingWheel = false;
                FindObjectOfType<AudioManager>().Pause("WheelTurn");
                wheelSound = false;

                if (fullSpinsCount > 0)
                {
                    float rotateAmount = 90f * Time.deltaTime * (fullSpinsCount * 1.5f);
                    ferryWheel.transform.Rotate(Vector3.forward, -rotateAmount);

                    if (Mathf.Abs(ferryWheel.transform.eulerAngles.z) <= 1f)
                    {
                        if (!spunDown)
                        {
                            fullSpinsCount--;
                            spunDown = !fullSpun;
                        }
                    }
                    else
                    {
                        spunDown = false;
                    }
                }
                else
                {
                    if (Mathf.Abs(ferryWheel.transform.eulerAngles.z) > 1f)
                    {
                        float rotateAmount = 60f * Time.deltaTime;
                        ferryWheel.transform.Rotate(Vector3.forward, -rotateAmount);
                    }
                    else
                    {
                        ferryWheel.transform.rotation = Quaternion.identity;
                    }
                }
            }
        }
        #endregion

        #region PBR Controller
        
        if (usingWheel)
        {
            Vector3 clampedPosition = pbr.transform.localPosition;
            clampedPosition.y += 1f * Time.deltaTime;
            clampedPosition.y = Mathf.Clamp(clampedPosition.y, Mathf.NegativeInfinity, 2.5f);
            pbr.transform.localPosition = clampedPosition;
        }
        else
        {
            Vector3 clampedPosition = pbr.transform.localPosition;
            clampedPosition.y -= 2f * Time.deltaTime;
            clampedPosition.y = Mathf.Clamp(clampedPosition.y, 0f, Mathf.Infinity);
            pbr.transform.localPosition = clampedPosition;
        }
        #endregion


    }

    private void OnEnable()
    {
        mouseClicked.Enable();
        mouseTracker.Enable();
    }
    private void OnDisable()
    {
        mouseClicked.Disable();
        mouseTracker.Disable();
    }
}
