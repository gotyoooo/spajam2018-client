using UnityEngine;
using System.Collections;

public class UnityChanController : MonoBehaviour
{
    [SerializeField]
    private GameObject _mainCamera = null;

    [SerializeField]
    private GameObject _vrCamera = null;

    private Vector3 _targetPos;


    private Animator animator;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        if(_vrCamera.active)
        {
            Debug.Log("===VR===");
            _targetPos = _vrCamera.transform.position;
        }
        else if (_mainCamera.active)
        {
            _targetPos = _mainCamera.transform.position;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

        if (Input.GetKey("down"))
        {
            animator.SetBool("IsTalking", true);
        }
        else
        {
            animator.SetBool("IsTalking", false);
        }
    }

    private void OnAnimatorIK(int layerIndex)
    {
        animator.SetLookAtWeight(1.0f, 0.1f, 50.0f, 100.0f, 50f);
        animator.SetLookAtPosition(_targetPos);
    }

    //Animator animator;
    //Vector3 targetPos;

    //void Start()
    //{
    //    this.animator = GetComponent<Animator>();
    //    this.targetPos = Camera.main.transform.position;
    //}

    //void Update()
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //        Vector3 touchPos = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
    //        touchPos.z = -0.5f;
    //        targetPos = touchPos;
    //    }
    //}


}

