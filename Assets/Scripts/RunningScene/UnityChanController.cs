using UnityEngine;
using System.Collections;

public class UnityChanController : MonoBehaviour
{
    [SerializeField]
    private GameObject _mainCamera = null;

    [SerializeField]
    private GameObject _vrCamera = null;

    [SerializeField]
    public AudioSource _source = null;

    [SerializeField]
    public RunningSceneController _runningSceneController = null;

    [SerializeField]
    private float _runningSpeed = 0.1f;

    [SerializeField]
    private float _walkingSpeed = 0.1f;

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
        if (_runningSceneController.CurrentPhase == RunningSceneController.Phase.Goal)
        {
            animator.SetBool("IsGoal", true);
            transform.position += transform.forward * _walkingSpeed * Time.deltaTime;
        }

        if (_runningSceneController.CurrentPhase == RunningSceneController.Phase.Run)
        {
            animator.SetBool("IsRunning", true);
            transform.position += transform.forward * _runningSpeed * Time.deltaTime;
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

        animator.SetBool("IsTalking", _source.isPlaying);
    }

    private void OnAnimatorIK(int layerIndex)
    {
        animator.SetLookAtWeight(1.0f, 0.1f, 50.0f, 100.0f, 50f);
        animator.SetLookAtPosition(_targetPos);
    }
}

