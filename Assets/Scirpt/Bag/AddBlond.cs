using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AddBlond : MonoBehaviour
{
    // Start is called before the first frame update
    Iventory iventory;

    private void Awake()
    {
        iventory = GetComponent<Iventory>();

    }
    // Update is called once per frame
    void Update()
    {
        if (iventory.isUse)
        {
            playerController.AddBlond(10);
            iventory.isUse = false;

        }
    }
}
