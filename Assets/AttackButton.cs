using UnityEngine;

public class AttackButton : MonoBehaviour
{
    public Animator swordAnimator;

    // Start is called before the first frame update
    void Start()
    {
        swordAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            swordAnimator.SetTrigger("Attack");
        }
    }
}
