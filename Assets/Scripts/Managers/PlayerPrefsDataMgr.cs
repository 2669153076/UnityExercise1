using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using static UnityEditor.LightingExplorerTableColumn;

public class PlayerPrefsDataMgr
{
    private static PlayerPrefsDataMgr instance = new PlayerPrefsDataMgr();

    public static PlayerPrefsDataMgr Instance { get { return instance; } }

    private PlayerPrefsDataMgr() { }

    public void SaveData(object data,string keyName)
    {
        Type dataType = data.GetType();
        FieldInfo[] fieldInfos = dataType.GetFields();
        string saveKeyName = "";
        for (int i = 0; i < fieldInfos.Length; i++)
        {
            saveKeyName = keyName + "_" + dataType.Name + "_" + fieldInfos[i].FieldType.Name + "_" + fieldInfos[i].Name;
            SaveValue(fieldInfos[i].GetValue(data), saveKeyName);
        }
        PlayerPrefs.Save();
    }

    private void SaveValue(object value,string keyName)
    {
        Type fieldType = value.GetType();

        if (fieldType == typeof(int))
        {
            PlayerPrefs.SetInt(keyName, (int)value);
        }
        else if (fieldType == typeof(float))
        {
            PlayerPrefs.SetFloat(keyName, (float)value);
        }
        else if(fieldType == typeof(string))
        {
            PlayerPrefs.SetString(keyName, value.ToString());
        }
        else if(fieldType == typeof(bool))
        {
            PlayerPrefs.SetInt(keyName, (bool)value ? 1 : 0);
        }
        else if (typeof(IList).IsAssignableFrom(fieldType))
        {
            IList list = value as IList;
            PlayerPrefs.SetInt(keyName + "_Count",list.Count);
            int index = 0;
            foreach (object item in list)
            {
                SaveValue(item, keyName+"_"+index);
                index++;
            }
        }
        else if (typeof(IDictionary).IsAssignableFrom(fieldType))
        {
            IDictionary dictionary = value as IDictionary;
            PlayerPrefs.SetInt(keyName+"_Count",dictionary.Count);
            int index = 0;
            foreach(var key in dictionary.Keys)
            {
                SaveValue(key, keyName+"_Key_"+index);
                SaveValue(dictionary[key], keyName+"_Value_"+index);
                ++index;
            }
        }else
        {
            SaveData(value, keyName);
        }
    }

    public object LoadData(Type type,string keyName)
    {
        object data = Activator.CreateInstance(type);
        FieldInfo[] fieldInfos = type.GetFields();
        string loadKeyName = "";
        for (int i = 0; i < fieldInfos.Length; i++)
        {
            loadKeyName = keyName + "_" + type.Name + "_" + fieldInfos[i].FieldType.Name + "_" + fieldInfos[i].Name;
            fieldInfos[i].SetValue(data, LoadValue(fieldInfos[i].FieldType, loadKeyName));
        }

        return data;
    }

    private object LoadValue(Type fieldType,string keyName)
    {
        if(fieldType == typeof(int))
        {
            return PlayerPrefs.GetInt(keyName);
        }
        else if(fieldType == typeof(float))
        {
            return PlayerPrefs.GetFloat(keyName);
        }
        else if(fieldType==typeof(string))
        {
            return PlayerPrefs.GetString(keyName);
        }
        else if(fieldType == typeof(bool))
        {
            return PlayerPrefs.GetInt(keyName) == 1 ? true : false;
        }
        else if(typeof(IList).IsAssignableFrom(fieldType))
        {
            IList list = Activator.CreateInstance(fieldType) as IList;
            int count = PlayerPrefs.GetInt(keyName+"_Count");
            for (int i = 0; i < count; i++)
            {
                list.Add(LoadValue(fieldType.GetGenericArguments()[0], keyName + "_" + i));
            }
            return list;
        }
        else if (typeof(IDictionary).IsAssignableFrom(fieldType))
        {
            IDictionary dictionary = Activator.CreateInstance(fieldType) as IDictionary;
            int count = PlayerPrefs.GetInt(keyName + "_Count");
            for (int i = 0; i < count; i++)
            {
                dictionary.Add(LoadValue(fieldType.GetGenericArguments()[0], keyName + "_Key_" + i), LoadValue(fieldType.GetGenericArguments()[1], keyName + "_Value_" + i));
            }
            return dictionary;
        }
        else
        {
            return LoadData(fieldType, keyName);
        }
    }
}
