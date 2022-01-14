using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open : MonoBehaviour
{
    [SerializeField] private string playerTag;
    [SerializeField] private string closeTrigger;
    [SerializeField] private string openTrigger;

    private Animator animator;
    private bool inTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.G)) && inTrigger )
        {
            animator.SetTrigger(openTrigger);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("In here");
        if(other.tag == playerTag)
        {
            inTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exiting here");
        if (other.tag == playerTag)
        {
            inTrigger = false;
            animator.SetTrigger(closeTrigger);
        }
    }
}
