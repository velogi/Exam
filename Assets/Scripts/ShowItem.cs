using UnityEngine;
using System.Collections;
using Mono.Data.SqliteClient;
using System.Data;
using System;
using UnityEngine.UI;
public class ShowItem : MonoBehaviour
{
    public Text PlayerDataTxt;

    void Start()
    {
        SelectItem();
    }
    public void SelectItem()
    {
        string connectionString = "URI=file:" + Application.dataPath + "/myDatabase.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(connectionString);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "select * from Account";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        PlayerDataTxt.text = "";
        while (reader.Read())
        {
            string userName = reader.GetString(1);
            string passWord = reader.GetString(2);
            int age = reader.GetInt32(3);
            PlayerDataTxt.text += userName + "-" + passWord + "-" + age + "\n";
        }
        //reader.Close(); reader = null;
        dbcmd.Dispose(); dbcmd = null;
        dbconn.Close(); dbconn = null;
    }
}