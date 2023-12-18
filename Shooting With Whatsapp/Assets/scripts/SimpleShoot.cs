using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Nokobot/Modern Guns/Simple Shoot")]
public class SimpleShoot : MonoBehaviour
{
    [Header("Prefab Refrences")]
    public  GameObject intialbulletPrefab;
    public Color ncolor;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;

    //public TrailRenderer lineRenderer;
    public Material red;
    public Material blue; 
    public Material green;
    public Material white;
    public Material yellow;
    public Material orange;
    public Material purple;
    public Material pink;
    public Material navy;
    public Material black;
    [Header("Location Refrences")]
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private Transform barrelLocation;
    [SerializeField] private Transform casingExitLocation;

    [Header("Settings")]
    [Tooltip("Specify time to destory the casing object")] [SerializeField] private float destroyTimer = 2f;
    [Tooltip("Bullet Speed")] [SerializeField] private float shotPower = 10000f;
    [Tooltip("Casing Ejection Speed")] [SerializeField] private float ejectPower = 1500f;


    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;

        if (gunAnimator == null)
            gunAnimator = GetComponentInChildren<Animator>();

       
    }

   /* void Update()
    {
        //If you want a different input, change it here
        if (Input.GetButtonDown("Fire1"))
        {
            //Calls animation on the gun that has the relevant animation events that will fire
            gunAnimator.SetTrigger("Fire");
        }
    }
   */
   public void StartShoot()
    {
        gunAnimator.SetTrigger("Fire");
    }

    //This function creates the bullet behavior
    void Shoot()
    {
        if (muzzleFlashPrefab)
        {
            //Create the muzzle flash
            GameObject tempFlash;
            tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

            //Destroy the muzzle flash effect
            Destroy(tempFlash, destroyTimer);
        }

        //cancels if there's no bullet prefeb
        if (!intialbulletPrefab)
        { return; }

        // Create a bullet and add force on it in direction of the barrel
        Instantiate(intialbulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);

    }

    //This function creates a casing at the ejection slot
    void CasingRelease()
    {
        //Cancels function if ejection slot hasn't been set or there's no casing
        if (!casingExitLocation || !casingPrefab)
        { return; }

        //Create the casing
        GameObject tempCasing;
        tempCasing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        //Add force on casing to push it out
        tempCasing.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower), (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        //Add torque to make casing spin in random direction
        tempCasing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);

        //Destroy casing after X seconds
        Destroy(tempCasing, destroyTimer);
    }
    public void changetotrail1()
    {

        intialbulletPrefab.GetComponent<TrailRenderer>().material = white;
        intialbulletPrefab.GetComponent<TrailRenderer>().time = 0.05f;
        //TrailRenderer.material = red;

    }
    public void changetotrail2()
    {
        // intialbulletPrefab.GetComponent<TrailRenderer>().material.color = Color.red;
        intialbulletPrefab.GetComponent<TrailRenderer>().material = red;
        intialbulletPrefab.GetComponent<TrailRenderer>().time = 0.005f;
    }
    public void changetotrail3()
    {
        // intialbulletPrefab.GetComponent<TrailRenderer>().material.color = Color.blue;
        intialbulletPrefab.GetComponent<TrailRenderer>().material = green;
        intialbulletPrefab.GetComponent<TrailRenderer>().time = 0.01f;
    }
    public void changetotrail4()
    {
        intialbulletPrefab.GetComponent<TrailRenderer>().material = blue   ;
        intialbulletPrefab.GetComponent<TrailRenderer>().time = 0.001f;
    }
    public void changetotrail5()
    {
        intialbulletPrefab.GetComponent<TrailRenderer>().material = black;
        intialbulletPrefab.GetComponent<TrailRenderer>().time = 0.0001f;
    }
    public void changetotrail6()
    {
        intialbulletPrefab.GetComponent<TrailRenderer>().material = orange;
        intialbulletPrefab.GetComponent<TrailRenderer>().time = 0.05f;
    }
    public void changetotrail7()
    {
        intialbulletPrefab.GetComponent<TrailRenderer>().material = yellow;
        intialbulletPrefab.GetComponent<TrailRenderer>().time = 0.05f;
    }
    public void changetotrail8()
    {
        intialbulletPrefab.GetComponent<TrailRenderer>().material = pink;
        intialbulletPrefab.GetComponent<TrailRenderer>().time = 0.05f;
    }
    public void changetotrail9()
    {
        intialbulletPrefab.GetComponent<TrailRenderer>().material = navy;
        intialbulletPrefab.GetComponent<TrailRenderer>().time = 0.05f;
    }
    public void changetotrail10()
    {
        intialbulletPrefab.GetComponent<TrailRenderer>().material = purple;
        intialbulletPrefab.GetComponent<TrailRenderer>().time = 0.05f;
    }
    public void connectto()
    {
        Application.OpenURL("https://wa.me/9373076931");
    }
    public void sphere()
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3(1, 1, 1);
        sphere.transform.localPosition = new Vector3(0, 1, 2);
        sphere.AddComponent<Rigidbody>();

    }
}
