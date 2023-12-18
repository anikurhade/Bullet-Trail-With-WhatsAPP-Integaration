using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Buttonscenecescript : MonoBehaviour
{
    public GameObject button;
    public UnityEvent Onpress;
    public UnityEvent OnRelease;
    GameObject presser;
    bool isPressed;

    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            button.transform.localPosition = new Vector3(0,0.02f,0);
            presser = other.gameObject;
            Onpress.Invoke();
            isPressed = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other == presser)
        {
            button.transform.localPosition = new Vector3(0,1.02f,0);
            OnRelease.Invoke();
            isPressed = true;
        }
    }

    public void changebulletprefab()
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3(1, 1, 1);
        sphere.transform.localPosition = new Vector3(0.00400000019f, 1.70299995f, 0.762000024f);
        sphere.AddComponent<Rigidbody>();
    }
}
