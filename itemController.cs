using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemController : MonoBehaviour
{
    private BoxCollider2D objectCollider;
    // Start is called before the first frame update
    void Start()
    {
        objectCollider = GetComponent<BoxCollider2D>();
        SetObjectActive(false);
        SetObjectTrigger(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetObjectActive(bool isAct)
    {
        gameObject.SetActive(isAct);
    }

    public void SetObjectTrigger(bool isTri)
    {
        objectCollider.enabled = isTri;
    }
}
