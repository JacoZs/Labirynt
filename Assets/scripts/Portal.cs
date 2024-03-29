using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] Portal otherPortal;
    [SerializeField] Material material;

    public Camera myCamera;

    public Transform renderSurface;
    public Transform portalCollider;

    GameObject player;
    PortalTeleport portalTeleport;
    PortalCamera portalCamera;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        portalTeleport = portalCollider.GetComponent<PortalTeleport>();
        portalTeleport.player = player.transform;
        portalTeleport.receiver = otherPortal.portalCollider;

        portalCamera = myCamera.GetComponent<PortalCamera>();
        portalCamera.playerCamera = player.transform.GetChild(0).transform;
        portalCamera.portal = transform;
        portalCamera.otherPortal = otherPortal.transform;

        renderSurface.GetComponent<Renderer>().material = Instantiate(material);
        if (myCamera.targetTexture != null)
            myCamera.targetTexture.Release();
        myCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
    }
    private void Start()
    {
        renderSurface.GetComponent<Renderer>().material.mainTexture = otherPortal.myCamera.targetTexture;
    }
}
