using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using TMPro;
using System;
using System.Text.RegularExpressions;

public class Banco : MonoBehaviour
{
    private IDbConnection conec;
    private IDbCommand command;
    private IDataReader reader;

    
    private string stringConexao = "URI=file:Assets/StreamingAssets/meuBanco.db";

    //==============================================
    private bool conectar ()
    {
        try
        {
            conec = new SqliteConnection(stringConexao);
            command = conec.CreateCommand();
            conec.Open();


            command.CommandText = "PRAGMA foreign_key = ON; CREATE TABLE IF NOT EXISTS USUARIOS" +
                    "(ID INTEGER PRIMARY KEY AUTOINCREMENT, NOME VARCHAR(50));";
            // /\ command preparation 

            command.ExecuteNonQuery(); //execute on db

            return true;

        }
        catch (System.Exception ex)
        {
            print(ex.Message);
            return false;
        }
    }
    //====================================================
    public bool inserir(string nome)
    {
        try
        {
            //print(conec.State);
            conectar();
            //print(conec.State);

            //string comandoSql = "INSERT INTO USUARIOS(NOME) VALUES ($nome);";
            string comandoSql = "INSERT INTO USUARIOS(NOME) VALUES ('" + nome + "');";

            command.CommandText = comandoSql;
            //command.Parameters.Add(nome);
            command.ExecuteNonQuery();
            print("done");
            return true;
        }
        catch (System.Exception ex)
        {
            print("faild" + ex.Message);
            
            return false;
        }
        finally
        {
            //conec.Close();
        }
    }
    //==============================================

    public bool inserirScalar(string nome)
    {
        try
        {
            conectar();

            //command.CommandText = "INSERT INTO USUARIO (NOME) VALUES ($nome);";
            //command.Parameters.Add(nome);
            //// /\ should work but doesnt
            ///
            long idInserido;

            string comandoSql
             = "INSERT INTO USUARIOS (NOME) VALUES ('" + nome + "');" +
                "SELECT LAST_INSERT_ROWID ()";//CAST(scope_identity() AS int)";

            command.CommandText= comandoSql;

            command.ExecuteNonQuery ();

            idInserido = Convert.ToInt32( (long)command.ExecuteScalar());

            return true;
        }
        catch(System.Exception ex) 
        {
            print (ex.Message); 
            return false;
        }
        finally //execute before returns (both try or catch 
        {
            conec.Close(); 
        }
    }

    //==============================================
    public bool consultar()
    {
        try
        {
            conectar();

            string comandoSql = "SELECT * FROM USUARIOS;";

            command.CommandText = comandoSql;
            reader = command.ExecuteReader();

            int cont = 0;

            while (reader.Read())
            {
                print("ID: " + reader.GetInt32(0));
                print("NOME: " + reader.GetString(1));

                cont++;
            }

            print("Total de Registros: " + cont);

            return true;
        }
        catch (System.Exception ex)
        {
            print(ex.Message);
            return false;
        }
        finally
        {
            conec.Close();
        }
    }
    //==============================================
    public bool alterar(int id, string nome)
    {
        try
        {
            conectar();

            string comandoSql = "UPDATE USUARIOS SET NOME = '" + nome + "' " +
                "WHERE ID = " + id + ";";
            //string comandoSql = "UPDATE USUARIOS SET NOME = $nome WHERE ID = $id;";

            command.CommandText = comandoSql;

            //command.Parameters.Add(nome);
            //command.Parameters.Add(id);

            command.ExecuteNonQuery();

            return true;
        }
        catch (System.Exception ex)
        {
            print(ex.Message);
            return false;
        }
        finally
        {
            conec.Close();
        }
    }
    //==============================================
    public bool remover(int id)
    {
       // string x = Regex.Match(id, @"\d+", RegexOptions.ECMAScript).Value;
       
        try
        {
            conectar();
            //print("insideremover" + x);
            //float value = float.Parse(x);
            //print("floated" + x);
            //long varint = Convert.ToInt32(id.Trim());
            //print("insideremoverpars" + x);
            string comandoSql = "DELETE FROM USUARIOS WHERE ID = " + id + ";";
                //string comandoSql = "DELETE FROM USUARIOS WHERE ID = $id;";
                print(comandoSql);
                command.CommandText = comandoSql;

                //command.Parameters.Add(id);

                command.ExecuteNonQuery();
            
                return true;
            }
            catch (System.Exception ex)
            {
                print(ex.Message);
                return false;
            }
            finally
            {
                conec.Close();
            }
            
            
    }
       

    //==============================================

}
