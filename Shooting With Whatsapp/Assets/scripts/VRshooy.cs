using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRshooy : MonoBehaviour
{
    // Start is called before the first frame update
    public SimpleShoot simpleshoot;
    public OVRInput.Button shootButton;
    private OVRGrabbable grabbable;
    private AudioSource audio;

    void Start()
    {
        grabbable = GetComponent<OVRGrabbable>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(grabbable.isGrabbed && OVRInput.GetDown(shootButton, grabbable.grabbedBy.GetController()))
        {
            simpleshoot.StartShoot();
            audio.Play();
        }
    }
}
