using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBehavior : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 4f)] float lerpTime;

    private Transform trashPoint;
    private Transform paperPoint;
    private Transform glassPoint;
    private Transform metalPoint;

    private Rigidbody rb;

    private int currentPoint;

    private Animator trashAnimator;
    private Animator paperAnimator;
    private Animator glassAnimator;
    private Animator metalAnimator;

    private TrashSpawnBehavior spawner;

    private UI_Manager uiManager;

    private bool movable;

    //private Vector3 originalposition;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
        rb = GetComponent<Rigidbody>();
        spawner = GameObject.Find("TrashSpawner").GetComponent<TrashSpawnBehavior>();
        //originalposition = transform.position;
        currentPoint = -1;
        movable = true; //Once the trash spawn, you can select a trash can
        GetTrashcansData();
    }

    // Update is called once per frame
    void Update()
    {
        if (movable)
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo))
                {
                    string selectedBin = hitInfo.transform.tag;
                    //Debug.Log(selectedBin);
                    switch (selectedBin)
                    {
                        case "Trashbin":
                            SelectTrashbin(0);
                            break;
                        case "Paperbin":
                            SelectTrashbin(1);
                            break;
                        case "Glassbin":
                            SelectTrashbin(2);
                            break;
                        case "Metalbin":
                            SelectTrashbin(3);
                            break;
                    }
                }
            }
        }
        
        if (currentPoint > -1)
            MoveToTrashCan();
    }

    void GetTrashcansData()
    {
        //Get trashPoints
        trashPoint = GameObject.Find("TrashPoint").transform;
        paperPoint = GameObject.Find("PaperPoint").transform;
        glassPoint = GameObject.Find("GlassPoint").transform;
        metalPoint = GameObject.Find("MetalPoint").transform;

        //Get animators
        trashAnimator = GameObject.Find("BasureroBasura").GetComponent<Animator>();
        paperAnimator = GameObject.Find("BasureroPapel").GetComponent<Animator>();
        glassAnimator = GameObject.Find("BasureroVidrio").GetComponent<Animator>();
        metalAnimator = GameObject.Find("BasureroMetal").GetComponent<Animator>();
    }

    void MoveToTrashCan()
    {
        switch (currentPoint)
        {
            case 0:
                transform.position = Vector3.Lerp(transform.position, trashPoint.position, lerpTime * Time.deltaTime);
                trashAnimator.SetBool("Open", true);
                break;
            case 1:
                transform.position = Vector3.Lerp(transform.position, paperPoint.position, lerpTime * Time.deltaTime);
                paperAnimator.SetBool("Open", true);
                break;
            case 2:
                transform.position = Vector3.Lerp(transform.position, glassPoint.position, lerpTime * Time.deltaTime);
                glassAnimator.SetBool("Open", true);
                break;
            case 3:
                transform.position = Vector3.Lerp(transform.position, metalPoint.position, lerpTime * Time.deltaTime);
                metalAnimator.SetBool("Open", true);
                break;
        }
    }

    public void SelectTrashbin(int selected)
    {
        spawner.ReduceAmount();
        //0 Trash, 1 Paper, 2 Glass, 3 Metal
        movable = false;
        currentPoint = selected;
        StartCoroutine(Drop());
    }

    IEnumerator Drop()
    {
        yield return new WaitForSeconds(1.3f);
        rb.isKinematic = false;
        currentPoint = -1;
        spawner.SpawnNextTrash();
        yield return new WaitForSeconds(0.3f);
        trashAnimator.SetBool("Open", false);
        paperAnimator.SetBool("Open", false);
        glassAnimator.SetBool("Open", false);
        metalAnimator.SetBool("Open", false);

        yield return new WaitForSeconds(1f);
        // spawner.SpawnNextTrash();
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Trashbin"))
        {
            if(transform.CompareTag("Trash"))
            {
                Debug.Log("BIEN! Soy " + transform.tag + " y me tiraron en " + other.transform.tag);
                spawner.PlaySoundEffect(true);
                uiManager.GainOrLoss(true);
            }
            else
            {
                Debug.Log("MAL HECHO! Soy " + transform.tag + " y me tiraron donde no es.");
                spawner.PlaySoundEffect(false);
                uiManager.GainOrLoss(false);
            }    
        }
        if (other.transform.CompareTag("Paperbin"))
        {
            if (transform.CompareTag("Paper"))
            {
                Debug.Log("BIEN! Soy " + transform.tag + " y me tiraron en " + other.transform.tag);
                spawner.PlaySoundEffect(true);
                uiManager.GainOrLoss(true);
            }
            else
            {
                Debug.Log("MAL HECHO! Soy " + transform.tag + " y me tiraron donde no es.");
                spawner.PlaySoundEffect(false);
                uiManager.GainOrLoss(false);
            }
        }
        if (other.transform.CompareTag("Glassbin"))
        {
            if (transform.CompareTag("Glass"))
            {
                Debug.Log("BIEN! Soy " + transform.tag + " y me tiraron en " + other.transform.tag);
                spawner.PlaySoundEffect(true);
                uiManager.GainOrLoss(true);
            }
            else
            {
                Debug.Log("MAL HECHO! Soy " + transform.tag + " y me tiraron donde no es.");
                spawner.PlaySoundEffect(false);
                uiManager.GainOrLoss(false);
            }
        }
        if (other.transform.CompareTag("Metalbin"))
        {
            if (transform.CompareTag("Metal"))
            {
                Debug.Log("BIEN! Soy " + transform.tag + " y me tiraron en " + other.transform.tag);
                spawner.PlaySoundEffect(true);
                uiManager.GainOrLoss(true);
            }
            else
            {
                Debug.Log("MAL HECHO! Soy " + transform.tag + " y me tiraron donde no es.");
                spawner.PlaySoundEffect(false);
                uiManager.GainOrLoss(false);
            }
        }
    }

}
