using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explodingScript : MonoBehaviour
{
    public Animator animate; 
    // Start is called before the first frame update
    void Start()
    {
        animate = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animate.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            Destroy(gameObject);
        }
    }
}
