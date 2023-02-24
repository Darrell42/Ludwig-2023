using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private bool ignoreLayer;

    public bool check = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int layerBitShift = 1 << collision.gameObject.layer;

        if (!ignoreLayer)
        {
            if (layerBitShift == layerMask)
                check = true;
        }
        else
        {
            if (layerBitShift != layerMask)
                check = true;
        }




    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        int layerBitShift = 1 << collision.gameObject.layer;

        if (!ignoreLayer)
        {
            if (layerBitShift == layerMask)
                check = false;
        }
        else
        {
            if (layerBitShift != layerMask)
                check = false;
        }
    }
}
