using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    
    DecalManager DecalM;
    GameObject tempDecal;

    public GameObject DecalHandler;
    //if(Input.GetKey("RightArrow"))
    //    {
    //        transform.location = Transform.location + 1
    //    }
    private void Start()
    {
        DecalM = DecalHandler.GetComponent<DecalManager>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
            Debug.Log("FIRE");

        }

    }
    private void Fire()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 500f))
        {
            tempDecal = DecalM.GetInactiveDecal();
            tempDecal.SetActive(true);
            tempDecal.transform.position = hitInfo.point + ((hitInfo.normal)* 0.01f);
            tempDecal.transform.rotation = Quaternion.FromToRotation(Vector3.back, hitInfo.normal);
            //Instantiate(DecalPrefab, hitInfo.point + (hitInfo.normal * 0.01f), Quaternion.FromToRotation(Vector3.back, hitInfo.normal));
        }


    }

    




}
