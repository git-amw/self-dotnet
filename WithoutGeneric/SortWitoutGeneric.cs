using System;
using System.Collections;
using System.IO;

namespace WithoutGeneric
{
    public class SortWitoutGeneric
    {
        public void SortData(string path) 
        {
            StreamReader reader = new StreamReader("D:\\bfsi\\" + path);
            ArrayList arrList = new ArrayList();
            while (reader.Peek() != -1)
            {
                object data = reader.ReadLine();
                arrList.Add(data);
            }
            int listLen = arrList.Count;
            for (int i = 0; i < listLen - 1; i++)
            {
                int min_idx = i;
                for (int j = i + 1; j < listLen; j++)
                {
                    dynamic obja = arrList[j];
                    dynamic objb = arrList[min_idx];
                    int val = obja.CompareTo(objb);
                    if (val < 0)
                    {
                        min_idx = j;
                    }
                }
                object temp = arrList[i];
                arrList[i] = arrList[min_idx];
                arrList[min_idx] = temp;
            }
        }
    }
}