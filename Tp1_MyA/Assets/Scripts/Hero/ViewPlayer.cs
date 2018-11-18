using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewPlayer : MonoBehaviour
{
    public void ActivateGuns(GameObject pSideGunL, GameObject pSideGunR)
    {
        var sideGunL = pSideGunL;
        var sideGunR = pSideGunR;
        sideGunL.SetActive(true);
        sideGunR.SetActive(true);
    }

    public void DeActivateGuns(GameObject pSideGunL, GameObject pSideGunR)
    {
        var sideGunL = pSideGunL;
        var sideGunR = pSideGunR;
        sideGunL.SetActive(false);
        sideGunR.SetActive(false);
    }
}
