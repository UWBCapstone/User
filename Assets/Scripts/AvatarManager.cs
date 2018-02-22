using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarManager : MonoBehaviour {

    public GameObject Avatar;
    public GameObject ReplacementAvatar;
    public GameObject AvatarCam;
    public GameObject AvatarFaceCam;
    public GameObject HUD;

    private GameObject activeCam;

	// Use this for initialization
	void Start () {
        Avatar = GameObject.Find("Malcon");
        Debug.Log("Press \"N\" to disable Avatar");
        Debug.Log("Press 1 to toggle Avatar camera");
        Debug.Log("Press 2 to toggle Avatar Face camera");
        Debug.Log("Press 3 to toggle User Face camera");

        activeCam = null;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Avatar.SetActive(!Avatar.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (activeCam != AvatarCam)
            {
                SetActiveCam(AvatarCam);
            }
            else
            {
                AvatarCam.SetActive(false);
                AvatarCam.GetComponent<Camera>().depth = -1;
                activeCam = null;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(activeCam != AvatarFaceCam)
            {
                SetActiveCam(AvatarFaceCam);
            }
            else
            {
                AvatarFaceCam.SetActive(false);
                AvatarFaceCam.GetComponent<Camera>().depth = -1;
                activeCam = null;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if(activeCam != HUD)
            {
                SetActiveCam(HUD);
            }
            else
            {
                HUD.SetActive(false);
                activeCam = null;
            }
        }

        ReplacementAvatar.SetActive(!Avatar.activeSelf);
	}

    private void SetActiveCam(GameObject go)
    {
        AvatarCam.SetActive(false);
        AvatarCam.GetComponent<Camera>().depth = -1;

        AvatarFaceCam.SetActive(false);
        AvatarFaceCam.GetComponent<Camera>().depth = -1;

        HUD.SetActive(false);

        if(go == AvatarCam)
        {
            AvatarCam.SetActive(true);
            AvatarCam.GetComponent<Camera>().depth = 2;
            activeCam = AvatarCam;
        }
        else if(go == AvatarFaceCam)
        {
            AvatarFaceCam.SetActive(true);
            AvatarFaceCam.GetComponent<Camera>().depth = 2;
            activeCam = AvatarFaceCam;
        }
        else if(go == HUD)
        {
            HUD.SetActive(true);
            activeCam = HUD;
        }
    }
}
