using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayName : MonoBehaviour
{
    public GameObject npcName;
    public Text label;

    public bool male;
    public bool female;
    public bool police;
    public bool developer;

    private string name;

    string[] females = { "Lucía", "Sofía", "Martina", "María", "Mariana", "Emma", "Jimena", "Valeria", "Valentina", "Lola", "Raquel", "Sara", "Eva", "Ana",
        "Juana", "Belén", "Diana", "Alicia", "Amy", "Charlotte", "Emily", "Daniela", "Camila", "Ariana", "Celia", "Amanda", "Blanca", "Elena", "Angélica", 
        "Beatriz", "Carla", "Estefanía", "Ingrid", "Jennifer", "Laura", "Natalia" };
    string[] males = { "Adán", "Arturo", "Adrián", "Alberto", "Bruno", "Carlos", "Cristian", "Daniel", "Emilio", "Ernesto", "Felipe", "Francisco", "Gabriel",
        "Hugo", "Ignacio", "Javier", "Juan", "Lucas", "Manuel", "Marcos", "Nelson", "Omar", "Pablo", "Pedro", "Rafael", "Ricardo", "Samuel", "Tito", "Victor",
        "William", "Rodolfo", "Alejandro", "Tomás", "Alvaro", "Diego", "Mario", "Jorge", "Miguel", "Gustavo", "Jonathan" };

    // Start is called before the first frame update
    void Start()
    {
        if (male)
            name = males[Random.Range(0, males.Length)];
        if (female)
            name = females[Random.Range(0, females.Length)];
        if(!police && !developer)
            label.text = "Hola, soy " + name;
        npcName.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (!police)
        {
            transform.LookAt(Camera.main.transform);
            transform.Rotate(0, 180, 0);
        }  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            npcName.SetActive(true);
            if (developer)
            {
                GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
                gm.MeetDeveloper(transform.parent.name);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            npcName.SetActive(false);
        }
    }
}
