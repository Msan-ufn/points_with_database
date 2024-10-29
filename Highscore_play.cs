using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class highscore_play : MonoBehaviour
{
    // Start is called before the first frame update

    public TMP_InputField slv_nome_input;
    public TMP_InputField slv_id_input;
    public GameObject slv_button_read;
    public GameObject slv_button_gravar;
    public GameObject slv_button_excluir;
    public TMP_Text slv_text_mesh;
    public int slv_int_points = 0;
    public bool slv_is_playing = true;


    // Start is called before the first frame update


    //inserir remover alterar consultar
    //public TextMeshProUGUI slv_tmpinfo_name;
    // public TextMeshProUGUI slv_tmpinfo_id;
    //public TMP_Text slv_tmpinfo_name;
    //public TMP_Text slv_tmpinfo_id;   
    

    //private Highscore_banco bd;

    void Start()
    {   
        slv_nome_input.gameObject.SetActive ( false);
        slv_id_input.gameObject.SetActive(false);
        slv_button_read.gameObject.SetActive(false);
        slv_button_gravar.gameObject.SetActive(false);
        slv_button_excluir.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (slv_is_playing)
        {
            slv_int_points++;
        }


        if (Input.GetMouseButtonDown(0))
        {
            slv_nome_input.gameObject.SetActive(true);
            slv_id_input.gameObject.SetActive(true);
            slv_button_read.gameObject.SetActive(true);
            slv_button_gravar.gameObject.SetActive(true);
            slv_button_excluir.gameObject.SetActive(true);

            slv_text_mesh.text = "congratulations you got : " + slv_int_points.ToString() + " points!";

            slv_is_playing = false;

            //Debug.Log("clicked");
        }
        else
        {
            //Debug.Log("Not held");
        }
        // /\ get once 

        // \/ get always 
        /*
        if (Input.GetMouseButton(0))
            print("Pressed");
        else
            print("Not pressed");
        */


    }






    /// <summary>
    /// inserir no banco com pontos 
    /// 
    /// usar slv_tmpinfo_name.text para o nome 
    /// slv_int_points para pontos 
    /// 
    /// alterar highscore_banco para usar o sql e adicionar os pontos ao sqlquerry 
    /// </summary>

   /* public void spf_inserir_highscore()
    {
        bd = new Highscore_banco();
        bd.inserir(slv_tmpinfo_name.text, slv_int_points);
    }
    
    public void spf_read_highscore()
    {
        bd.consultar();
    }

    public void spf_delete_highscore()
    {
        print("teste");

        bd.remover(int.Parse(slv_tmpinfo_id.text));
    }
   */
}

