using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;

[System.Serializable]
public class SaveItem {
    public string name;
    public Vector3 pos;

    public new string ToString() {
        return name + "," + pos.x + "," + pos.y + "," + pos.z;
    }
}

public class Save : MonoBehaviour {

    public List<SaveItem> items;

    public string runSave() {
        Debug.Log("Save");
        var sb = new StringBuilder();

        var total = items.Count;
        for (var i = 0; i < total; i++) {
            sb.Append(items[i].ToString());
            if (i < total - 1)
                sb.Append(";");
        }

        return sb.ToString();
    }

    public void runLoad(string data) {
        Debug.Log("Load" + data);
        var itemData = data.Split(';');
        items = new List<SaveItem>();
        var total = itemData.Length;

        for (var i = 0; i < total; i++) {
            var values = itemData[i].Split(',');
            var item = new SaveItem();
            item.name = values[0];
            item.pos = new Vector3(Int32.Parse(values[1]), Int32.Parse(values[2]), Int32.Parse(values[3]));
            items.Add(item);

        }
    }

}
