using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;

public class ButtonFunctions : MonoBehaviour
{
    // Start is called before the first frame update


    //inserir remover alterar consultar
    //public TextMeshProUGUI slv_tmpinfo_name;
   // public TextMeshProUGUI slv_tmpinfo_id;
    //public TMP_Text slv_tmpinfo_name;
    //public TMP_Text slv_tmpinfo_id;
    public TMP_InputField slv_tmpinfo_name;
    public TMP_InputField slv_tmpinfo_id;

    private Banco bd;

    public void Start()
    {
        bd = new Banco();
    }

    public void spf_inserir()
    {   
        bd.inserir(slv_tmpinfo_name.text );
    }
    public void spf_inserir_scalar()
    {
        bd.inserirScalar(slv_tmpinfo_name.text);
    }
    public void spf_read()
    {
        bd.consultar();
    }

    public void spf_delete()
    {
        print("teste");
       
        bd.remover(int.Parse(slv_tmpinfo_id.text));
    }

}
