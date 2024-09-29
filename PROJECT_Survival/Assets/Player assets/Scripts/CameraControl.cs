using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    [SerializeField]
    Camera characterCamera;

    [SerializeField]
    float lookSpeed = 5.0f;
    float rotation = 0f;

    [SerializeField]
    TextMeshProUGUI interactionText;

    Transform obj;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        while (obj == null) 
        {
            obj = transform.Find("HUD/InteractionText");
            Debug.Log("ESYEUYSH");
        }

        if(obj != null)
        {
            interactionText = obj.GetComponent<TextMeshProUGUI>();
        }

        //Mouse movement
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * lookSpeed;

        rotation -= mouseY;
        rotation = Mathf.Clamp(rotation, -90f, 90f);

        if (!GetComponentInParent<PlayerControl>().isInInventory)
        {
            transform.rotation *= Quaternion.Euler(0, mouseX, 0);
            characterCamera.transform.localRotation = Quaternion.Euler(rotation, 0, 0);
        }

        //Raycasting
        RaycastHit hit;
        Ray ray = new Ray(characterCamera.transform.position, characterCamera.transform.forward);

        if (Physics.Raycast(ray, out hit, 20))
        {
            if (hit.collider != null)
            {
                GameObject gameObject = hit.collider.gameObject;
                if (gameObject.GetComponent<ItemManager>())
                {
                    interactionText.text = gameObject.GetComponent<ItemManager>().itemName + "\n <size=50%>Press F to pickup";
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        GetComponentInParent<PlayerInventory>().AddItem(gameObject.GetComponent<ItemManager>().GetScriptObj());
                        Destroy(gameObject);
                    }
                    interactionText.GetComponent<TextMeshProUGUI>().enabled = true;
                }
                else
                {
                    interactionText.GetComponent<TextMeshProUGUI>().enabled = false;
                }
            }
        }
    }
}

