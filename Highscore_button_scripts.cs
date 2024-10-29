using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;

public class Highscore_button_scripts: MonoBehaviour
{ 
    /// <summary>
    /// probalby not in use 
    /// </summary>
    // Start is called before the first frame update


    //inserir remover alterar consultar
    //public TextMeshProUGUI slv_tmpinfo_name;
    // public TextMeshProUGUI slv_tmpinfo_id;
    //public TMP_Text slv_tmpinfo_name;
    //public TMP_Text slv_tmpinfo_id;
    public TMP_InputField slv_tmpinfo_name;
    public TMP_InputField slv_tmpinfo_id;

    public GameObject slv_game_points_controler;
    public highscore_play slv_script_holder;

    private Highscore_banco bd;

    public void Start()
    {

        slv_script_holder = slv_game_points_controler.GetComponent<highscore_play>();




        bd = new Highscore_banco();
    }

    public void spf_inserir_highscore(int points)
    {
        bd.inserir(slv_tmpinfo_name.text,slv_script_holder.slv_int_points);
    }
    public void spf_inserir_scalar()
    {
        bd.inserirScalar(slv_tmpinfo_name.text);
    }
    public void spf_read_spf_inserir_highscore()
    {
        bd.consultar();
    }

    public void spf_delete_spf_inserir_highscore()
    {
        print("teste");

        bd.remover(int.Parse(slv_tmpinfo_id.text));
    }

}