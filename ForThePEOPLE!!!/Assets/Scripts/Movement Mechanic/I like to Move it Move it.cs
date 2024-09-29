using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
/////////////////////////////////////////////////////////////////////////////////////////
    private bool isWalking = false;      private bool isSideRightWalk = false;
    private bool isRunning = false;      private bool isSideRightRun = false;
    private bool isBackWalk = false;     private bool isSideLeftWalk = false;
    private bool isBackRun = false;      private bool isSideLeftRun = false;
    private bool isForwardRightWalk = false;    private bool isForwardLeftWalk = false;
    private bool isForwardRightRun = false;     private bool isForwardLeftRun = false;
/////////////////////////////////////////////////////////////////////////////////////////

    void Update()
    {
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool backwardPressed = Input.GetKey(KeyCode.S);
        bool leftPressed = Input.GetKey(KeyCode.A);
        bool rightPressed = Input.GetKey(KeyCode.D);
        bool shiftPressed = Input.GetKey(KeyCode.LeftShift);

        
        ResetAllAnimations();
/////////////////////////////////////////////////////////////////////////////////////////
        //FORWARD
        if(forwardPressed)
        {
            if (shiftPressed)
            {
                isRunning = true;
                animator.SetBool("isRunning", true);
            }
            else
            {
                isWalking = true;
                animator.SetBool("isWalking", true);
            }
        }
/////////////////////////////////////////////////////////////////////////////////////////
        //RETREAT
        if(backwardPressed)
        {
            if (shiftPressed)
            {
                isBackRun = true;
                animator.SetBool("isBackRun", true);
                //Debug.Log("BACKRUN");
            }
            else
            {
                isBackWalk = true;
                animator.SetBool("isBackWalk", true);
            }
        }
/////////////////////////////////////////////////////////////////////////////////////////
        //GO LEFT
        if(leftPressed)
        {
            if (shiftPressed)
            {
                isSideLeftRun = true;
                animator.SetBool("isSideLeftRun", true);
            }
            else
            {
                isSideLeftWalk = true;
                animator.SetBool("isSideLeftWalk", true);
            }
        }
/////////////////////////////////////////////////////////////////////////////////////////
        //GO RIGHT
        if(rightPressed)
        {
            if (shiftPressed)
            {
                isSideRightRun = true;
                animator.SetBool("isSideRightRun", true);
            }
            else
            {
                isSideRightWalk = true;
                animator.SetBool("isSideRightWalk", true);
            }
        }
/////////////////////////////////////////////////////////////////////////////////////////
        //GO FOWARD RIGHT
        if(forwardPressed && rightPressed)
        {
            if (shiftPressed)
            {
                isForwardRightRun = true;
                animator.SetBool("isForwardRightRun", true);
            }
            else
            {
                isForwardRightWalk = true;
                animator.SetBool("isForwardRightWalk", true);
            }            
        }
/////////////////////////////////////////////////////////////////////////////////////////
        //GO FOWARD LEFT
        if(forwardPressed && leftPressed)
        {
            if (shiftPressed)
            {
                isForwardLeftRun = true;
                animator.SetBool("isForwardLeftRun", true);
            }
            else
            {
                isForwardLeftWalk = true;
                animator.SetBool("isForwardLeftWalk", true);
            }            
        }        
/////////////////////////////////////////////////////////////////////////////////////////
        // Update animator parameters to reflect movement
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isBackWalk", isBackWalk);
        animator.SetBool("isBackRun", isBackRun);
        animator.SetBool("isSideLeftWalk", isSideLeftWalk);
        animator.SetBool("isSideLeftRun", isSideLeftRun);
        animator.SetBool("isSideRightWalk", isSideRightWalk);
        animator.SetBool("isSideRightRun", isSideRightRun);
        animator.SetBool("isForwardRightWalk", isForwardRightWalk);
        animator.SetBool("isForwardRightRun", isForwardRightRun);
        animator.SetBool("isForwardLeftWalk", isForwardLeftWalk);
        animator.SetBool("isForwardLeftRun", isForwardLeftRun);
    }
/////////////////////////////////////////////////////////////////////////////////////////
    private void ResetAllAnimations()
    {
        isWalking = false;
        isRunning = false;
        isBackWalk = false;
        isBackRun = false;
        isSideLeftWalk = false;
        isSideLeftRun = false;
        isSideRightWalk = false;
        isSideRightRun = false;
        isForwardLeftWalk = false;
        isForwardLeftRun = false;
        isForwardRightWalk = false;
        isForwardRightRun = false;
    /////////////////////////////////////////////////////////
        animator.SetBool("isWalking", false);
        animator.SetBool("isRunning", false);
        animator.SetBool("isBackWalk", false);
        animator.SetBool("isBackRun", false);
        animator.SetBool("isSideLeftWalk", false);
        animator.SetBool("isSideLeftRun", false);
        animator.SetBool("isSideRightWalk", false);
        animator.SetBool("isSideRightRun", false);
    }
}
