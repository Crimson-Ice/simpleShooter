using UnityEngine;

public class Initvague : MonoBehaviour
{
    int count = -1, pos, WaveNb = 0;
    public Transform Spider; //Prefab spider
    public Transform Wall_spider; //Prefab wallspider
    public Transform Demon; //Prefab demon

    public Transform[] Wave_1;
    public Transform[] Wave_2;
    public Transform[] Wave_3;
    public Transform[,] Wave = new Transform[3,10];
    int l = 0;

    public bool vagueActif = false;
    float printCD = 0f;

    public Animator animator;
    GUIStyle style = new GUIStyle(); //style du text

    void Start()
    {
        style.fontSize = 30;

        int k = 3;
        for (int i = 0; i < k; i++)
        {
            Wave[0,i] = Wave_1[i];
        }
        
        k = 5;
        for (int h = 0; h < k; h++)
        {
            Wave[1,h] = Wave_2[h];
        }
        
        k = 8;
        for (int j = 0; j < k; j++)
        {
            Wave[2,j] = Wave_3[j];
        } 
    }

    public void enleveNbEnnemie()
    {
        count = count - 1; // si l'ennemie meurt alors retire 1 au nombre d'ennmie actif
    }

    void Update()
    {
        buttonClicker button = GetComponent<buttonClicker>();
        if (vagueActif == false) //si la vague est inactif
        {
            if (button.appuyer) //si le button est appuyer
            {
                spawnEnnemie(); //fait spawn les ennemie
            }
        
        }
        if (count == 0) //fait ce relever le button si il n'y a plus d'ennemie
        {
            vagueActif = false;

            button.appuyer = false;
            animator.SetBool("appuyer", button.appuyer);
        }
        if(printCD > 1)
        {
            printCD -= Time.deltaTime;
        }
    }

    void spawnEnnemie()
    {
        
        int[] vague = new int[3] { 3, 5, 8 }; //nombre d'ennemie par vague
        count = vague[WaveNb];

        for (int h = 0; h < count; h++)
        {
            if (Wave[l,h].name == "spider")
            {
                var PrefabSpider = Instantiate(Spider) as Transform; //cree un transform spider dans la scene
                PrefabSpider.position = Wave[l,h].position; // Met l'ennemie a son point de spawn
            }
            else if (Wave[l,h].name == "wall_spider")
            {
                var PrefabWallSpider = Instantiate(Wall_spider) as Transform; //cree un transform spider dans la scene
                PrefabWallSpider.position = Wave[l,h].position; // Met l'ennemie a son point de spawn
                PrefabWallSpider.name = Wall_spider.name;

                GameObject hero = GameObject.Find("Hero");

                if(hero.transform.position.x < Wave[l, h].position.x)
                {
                    Vector3 v = new Vector3(PrefabWallSpider.rotation.x, PrefabWallSpider.rotation.y, 90);
                    Quaternion q = Quaternion.Euler(v);
                    PrefabWallSpider.rotation = q;
                }
            }
            else if (Wave[l,h].name == "Demon")
            {
                var PrefabDemon = Instantiate(Demon) as Transform; //cree un transform Demon dans la scene
                PrefabDemon.position = Wave[l,h].position; // Met l'ennemie a son point de spawn
            }
        }
        vagueActif = true;

        l = l + 1;
        WaveNb = WaveNb + 1; // nb vague + 1
    }

    void OnGUI() //affichage des vagues
    {
        if (count > 0)
        {
            if(printCD == 0f)
            {
                printCD = 4;
            }
        }
        else
        {
            printCD = 0f;
        }

        if (printCD > 1f)
        {
            GUI.Label(new Rect((Screen.width/2)-40, (Screen.height/2)-100, Screen.width, Screen.height), "vague : "+ WaveNb.ToString(), style);
        }
    }
}
