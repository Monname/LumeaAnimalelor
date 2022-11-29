using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class charactere : MonoBehaviour
{


    public List<item> yourCharacter = new List<item>();
    public List<item> drag = new List<item>();

    public int slotNum;//1

    public Image[] slot;
    public Sprite[] slotSprite;

    public int[] al;//1
    public int[] bl;//1
    public int a;
    public int b;

    public GameObject[] leu;
    public GameObject[] tigru;
    public GameObject[] pisica;
    public GameObject[] cioara;
    public GameObject[] pinguin;
    public GameObject[] vultur;
    public GameObject[] hpopotam;
    public GameObject[] crocodil;
    public GameObject[] elefant;

    public int viata;
    public int atac;

    public int viataenemy;
    public int atacenemy;

    public Text hptext;
    public Text puteretext;
    
    public Text hptextenemy;
    public Text puteretextenemy;

    public GameObject gameObject1;


    public GameObject win;
    public GameObject lose;

    public int restart;//1
    public int n;
    public int l;
    public int s;
    public int count; 

    public float time;
    public float timeDelay;

    public GameObject gameObject2;
    public GameObject gameObject3;
    public GameObject gameObject4;
    public GameObject gameObject5;
    public GameObject gameObject6;
    public GameObject gameObject7;

    public GameObject Boom1;
    public GameObject Boom2;
    public GameObject Boom3;

    public Text[] detali;
    public GameObject[] imaginiDetali;

    public Text nextlvl;
    public GameObject StartButton;

    public GameObject Next;
    public GameObject rest;

    public int felina;
    void Start()
    {
        rest.SetActive(false);
        Next.SetActive(false);
        count = 1;
        restart = 1;
        for(int i = 0; i < 5; i++)
        {
            imaginiDetali[i].SetActive(false);
        }

        Boom1.SetActive(false);
        Boom2.SetActive(false);
        Boom3.SetActive(false);


        l = 1;
        time = 0f;
        timeDelay = 0.01f;

        

    }
    [System.Obsolete]
    // Update is called once per frame
    void Update()
    {
        //afctivare la buton la restart:
        if (restart==1)
        {
            for (int i = 0; i < slotNum; i++)
            {
                al[i] = Random.Range(1, 10);
            }
            for (int i = 0; i < slotNum; i++)
            {
                for (int j = 0; j < al.Length; j++)
                {
                    if (j == i)
                    {

                    }
                    else if (al[i] == al[j])
                    {
                        j = -1;
                        al[i] = Random.Range(1, 10);
                    }
                    else
                    {

                    }
                }
            }
            for (int i = 0; i < slotNum; i++)
            {
                yourCharacter[i] = database.itemList[al[i]];
                if (i >= 5)
                {
                    yourCharacter[i] = database.itemList[0];
                }
            }
            for (int i = 0; i < 3; i++)
            {
                bl[i] = Random.Range(1, 10);
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < bl.Length; j++)
                {
                    if (j == i)
                    {

                    }
                    else if (bl[i] == bl[j])
                    {
                        j = -1;
                        bl[i] = Random.Range(1, 10);
                    }
                    else
                    {

                    }
                }
            }
            for (int i = 8; i < 11; i++)
            {
                yourCharacter[i] = database.itemList[bl[i - 8]];
            }
            restart = 0;
            
        }



        //Incercare scriere in functie globala:
        for(int i = 0; i < 6; i++)
        {
            afisareCaractere(i);
        }
        


        for (int i = 0; i < slotNum; i++)
        {
            slot[i].sprite = slotSprite[i];
        }
        for (int i = 0; i < slotNum; i++)
        {
            slotSprite[i] = yourCharacter[i].icons;
        }

        if (gameObject1.active == false)
        {
            win.SetActive(false);
            lose.SetActive(false);

            viata = yourCharacter[5].HP + yourCharacter[6].HP + yourCharacter[7].HP;
            atac = yourCharacter[5].Atac + yourCharacter[6].Atac + yourCharacter[7].Atac;
            if (yourCharacter[5].Felina==1&& yourCharacter[6].Felina==1 || yourCharacter[5].Felina == 1 && yourCharacter[7].Felina == 1|| yourCharacter[7].Felina == 1 && yourCharacter[6].Felina == 1)
            {
                viata += 25;
            }
            if(yourCharacter[5].Felina == 1 && yourCharacter[6].Felina == 1&& yourCharacter[7].Felina == 1)
            {
                viata += 15;
            }
            if(yourCharacter[5].A == 1 && yourCharacter[6].A == 1 || yourCharacter[5].A == 1 && yourCharacter[7].A == 1 || yourCharacter[7].A == 1 && yourCharacter[6].A == 1){
                atac += 25;
            }
            if (yourCharacter[5].Giganti == 1 && yourCharacter[6].Giganti == 1 || yourCharacter[5].Giganti == 1 && yourCharacter[7].Giganti == 1 || yourCharacter[7].Giganti == 1 && yourCharacter[6].Giganti == 1)
            {
                viata += 25;
            }
            if (yourCharacter[5].Giganti == 1 && yourCharacter[6].Giganti == 1 && yourCharacter[7].Giganti == 1)
            {
                viata += 15;
            }
            if (yourCharacter[5].B == 1 && yourCharacter[6].B == 1 || yourCharacter[5].B == 1 && yourCharacter[7].B == 1 || yourCharacter[7].B == 1 && yourCharacter[6].B == 1){
                atac += 25;
            }
            if (yourCharacter[5].Pasari == 1 && yourCharacter[6].Pasari == 1 || yourCharacter[5].Pasari == 1 && yourCharacter[7].Pasari == 1 || yourCharacter[7].Pasari == 1 && yourCharacter[6].Pasari == 1)
            {
                atac += 25;
            }
            if (yourCharacter[5].Pasari == 1 && yourCharacter[6].Pasari == 1 && yourCharacter[7].Pasari == 1)
            {
                atac += 15;
            }
            if (yourCharacter[5].C == 1 && yourCharacter[6].C == 1 || yourCharacter[5].C == 1 && yourCharacter[7].C == 1 || yourCharacter[7].C == 1 && yourCharacter[6].C == 1)
            {
                atac += 25;
            }
            if (yourCharacter[5].inferior == 1 && yourCharacter[6].inferior == 1 && yourCharacter[7].inferior == 1)
            {
                atac += 200;
                viata += 200;
            }
            //enemy:
            if (yourCharacter[8].Felina == 1 && yourCharacter[9].Felina == 1 || yourCharacter[8].Felina == 1 && yourCharacter[10].Felina == 1 || yourCharacter[9].Felina == 1 && yourCharacter[10].Felina == 1)
            {
                viataenemy += 25;
            }
            if (yourCharacter[8].Felina == 1 && yourCharacter[9].Felina == 1 && yourCharacter[10].Felina == 1)
            {
                viata += 15;
            }
            if (yourCharacter[8].A == 1 && yourCharacter[9].A == 1 || yourCharacter[8].A == 1 && yourCharacter[10].A == 1 || yourCharacter[9].A == 1 && yourCharacter[10].A == 1)
            {
                atacenemy += 25;
            }
            if (yourCharacter[8].Giganti == 1 && yourCharacter[9].Giganti == 1 || yourCharacter[8].Giganti == 1 && yourCharacter[10].Giganti == 1 || yourCharacter[9].Giganti == 1 && yourCharacter[10].Giganti == 1)
            {
                viataenemy += 25;
            }
            if (yourCharacter[8].Giganti == 1 && yourCharacter[9].Giganti == 1 && yourCharacter[10].Giganti == 1)
            {
                viataenemy += 15;
            }
            if (yourCharacter[8].B == 1 && yourCharacter[9].B == 1 || yourCharacter[8].B == 1 && yourCharacter[10].B == 1 || yourCharacter[10].B == 1 && yourCharacter[9].B == 1)
            {
                atacenemy += 25;
            }
            if (yourCharacter[8].Pasari == 1 && yourCharacter[9].Pasari == 1 || yourCharacter[8].Pasari == 1 && yourCharacter[10].Pasari == 1 || yourCharacter[9].Pasari == 1 && yourCharacter[10].Pasari == 1)
            {
                atacenemy += 25;
            }
            if (yourCharacter[8].Pasari == 1 && yourCharacter[9].Pasari == 1 && yourCharacter[10].Pasari == 1)
            {
                atacenemy += 15;
            }
            if (yourCharacter[8].C == 1 && yourCharacter[9].C == 1 || yourCharacter[8].C == 1 && yourCharacter[10].C == 1 || yourCharacter[9].C == 1 && yourCharacter[10].C == 1)
            {
                atacenemy += 25;
            }
            if(yourCharacter[8].inferior == 1 && yourCharacter[9].inferior == 1 && yourCharacter[10].inferior == 1)
            {
                atacenemy += 200;
                viataenemy += 200;
            }
            hptext.text = viata + " ";
            puteretext.text = atac + " ";


            viataenemy = yourCharacter[8].HP + yourCharacter[9].HP + yourCharacter[10].HP;
            atacenemy = yourCharacter[8].Atac + yourCharacter[9].Atac + yourCharacter[10].Atac;

            hptextenemy.text = viataenemy + " ";
            puteretextenemy.text = atacenemy + " ";
            nextlvl.text = "level " + count;


        }
        else
        {
            win.SetActive(false);
            lose.SetActive(false);

            if(viata > 0 && viataenemy> 0) {
                time = time + 1f * Time.deltaTime;

                if (n == 30 && l == 1)
                {
                    Boom1.SetActive(true);
                }
                if (n == 40 && l == 1)
                {
                    Boom2.SetActive(true);
                }
                if (n == 45 && l == 1)
                {
                    Boom3.SetActive(true);
                }
                if (n == 5 && l == -1)
                {
                    Boom3.SetActive(false);
                }
                if (n == 10 && l == -1)
                {
                    Boom2.SetActive(false);
                }
                if (n == 20 && l == -1)
                {
                    Boom1.SetActive(false);
                }
                //movement
                if (n == 50)
                {
                    l = l * (-1);
                    s = 2 * l;
                    n = 0;
                    if (time >= timeDelay)
                    {
                        time = 0f;
                        gameObject2.transform.position = gameObject2.transform.position + new Vector3(0f, 0f, -s);
                        gameObject3.transform.position = gameObject3.transform.position + new Vector3(0f, 0f, -l);
                        gameObject4.transform.position = gameObject4.transform.position + new Vector3(0f, 0f, -s);
                        gameObject5.transform.position = gameObject5.transform.position + new Vector3(0f, 0f, s);
                        gameObject6.transform.position = gameObject6.transform.position + new Vector3(0f, 0f, l);
                        gameObject7.transform.position = gameObject7.transform.position + new Vector3(0f, 0f, s);

                    }
                    if (l == 1)
                    {
                        viata = viata - atacenemy;
                        hptext.text = viata + " ";
                        viataenemy = viataenemy - atac;
                        hptextenemy.text = viataenemy + " ";
                    }
                }
                else
                {
                    s = 2 * l;
                    if (time >= timeDelay)
                    {
                        time = 0f;
                        gameObject2.transform.position = gameObject2.transform.position + new Vector3(0f, 0f, -s);
                        gameObject3.transform.position = gameObject3.transform.position + new Vector3(0f, 0f, -l);
                        gameObject4.transform.position = gameObject4.transform.position + new Vector3(0f, 0f, -s);
                        gameObject5.transform.position = gameObject5.transform.position + new Vector3(0f, 0f, s);
                        gameObject6.transform.position = gameObject6.transform.position + new Vector3(0f, 0f, l);
                        gameObject7.transform.position = gameObject7.transform.position + new Vector3(0f, 0f, s);

                        n++;
                    }
                }
            }
            else
            {
                Boom1.SetActive(false);
                Boom2.SetActive(false);
                Boom3.SetActive(false);
                if ( viata<= 0&& viata< viataenemy)
                {
                    rest.SetActive(true);
                    lose.SetActive(true);
                }
                else
                {
                    Next.SetActive(true);
                    win.SetActive(true);
                }
            } 
        }
    }
    [System.Obsolete]
    public void StartDrag(Image slotX)
    {

        //print("asta");
        if (gameObject1.active == false)
        {
            for (int i = 0; i < slotNum; i++)
            {
                if (slot[i] == slotX)
                {

                    a = i;
                }
            }
        }
    }

    [System.Obsolete]
    public void Click(Image slotX)
    {
        for (int i = 0; i < 5; i++)
        {
            if (slot[i] == slotX)
            {
                if (imaginiDetali[i].active == false)
                {
                    imaginiDetali[i].SetActive(true);
                    print(i);
                    detali[i].text =" " + yourCharacter[i].name + "\n" + " Viata: " + yourCharacter[i].HP + "\n" + " Atac: " + yourCharacter[i].Atac + "\n" + yourCharacter[i].description;
                }
                else
                {
                    imaginiDetali[i].SetActive(false);
                }
            }
            else
            {
                imaginiDetali[i].SetActive(false);
            }
        }
    }
    [System.Obsolete]
    public void Drop(Image slotX)
    {
        if (gameObject1.active == false) { 
            if (a != b)
            {

                drag[0] = yourCharacter[a];
                yourCharacter[a] = yourCharacter[b];
                yourCharacter[b] = drag[0];
                a = 0;
                b = 0;
            }
        }
    }
    [System.Obsolete]
    public void Enter(Image slotX)
    {
        if (gameObject1.active == false)
        {
            for (int i = 0; i < slotNum; i++)
            {
                if (slot[i] == slotX)
                {
                    b = i;
                }
            }
        }
    }
    [System.Obsolete]
    public void OnButtonPress()
    {
        StartButton.SetActive(false);
        if (gameObject1.active== false)
        {
            gameObject1.SetActive(true);
        }
        else
        {
            gameObject1.SetActive(false);
        }
        
    }
    [System.Obsolete]
    public void OnButtonPress2()
    {
        
        StartButton.SetActive(true);
        if (win.active== true)
        {
            restart = 1;
            count += 1;
           
        }
        Next.SetActive(false);
        rest.SetActive(false);

        if (gameObject1.active == false)
        {
            gameObject1.SetActive(true);
        }
        else
        {
            gameObject1.SetActive(false);
        }
        

    }
    public void LoadSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void afisareCaractere(int i)
    {
        if (yourCharacter[i + 5] != database.itemList[0])
        {
            leu[i].SetActive(false);
            tigru[i].SetActive(false);
            pisica[i].SetActive(false);
            cioara[i].SetActive(false);
            pinguin[i].SetActive(false);
            vultur[i].SetActive(false);
            hpopotam[i].SetActive(false);
            crocodil[i].SetActive(false);
            elefant[i].SetActive(false);
            if (yourCharacter[i + 5].id == 1)
            {
                leu[i].SetActive(true);
            }
            if (yourCharacter[i + 5].id == 2)
            {
                tigru[i].SetActive(true);

            }
            if (yourCharacter[i + 5].id == 3)
            {
                pisica[i].SetActive(true);

            }
            if (yourCharacter[i + 5].id == 4)
            {
                cioara[i].SetActive(true);
            }
            if (yourCharacter[i + 5].id == 5)
            {
                pinguin[i].SetActive(true);
            }
            if (yourCharacter[i + 5].id == 6)
            {
                vultur[i].SetActive(true);
            }
            if (yourCharacter[i + 5].id == 7)
            {
                hpopotam[i].SetActive(true);
            }
            if (yourCharacter[i + 5].id == 8)
            {
                crocodil[i].SetActive(true);
            }
            if (yourCharacter[i + 5].id == 9)
            {
                elefant[i].SetActive(true);
            }

        }
        else
        {
            leu[i].SetActive(false);
            tigru[i].SetActive(false);
            pisica[i].SetActive(false);
            cioara[i].SetActive(false);
            pinguin[i].SetActive(false);
            vultur[i].SetActive(false);
            hpopotam[i].SetActive(false);
            crocodil[i].SetActive(false);
            elefant[i].SetActive(false);
        }
    }
}
