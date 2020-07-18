using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health3Controller : MonoBehaviour
{
    // reference to animator
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void triggerHealthLoss() {
        animator.SetTrigger("LoseHealth");
    }
}
