using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace withgeneric
{
    public class GenericSort
    {
        public void SortData<T>(string path) where T : IComparable
        {
            StreamReader reader = new StreamReader("D:\\bfsi\\" + path);
            List<T> dataList = new List<T>();
            while (reader.Peek() != -1)
            {
                T data = (T)Convert.ChangeType(reader.ReadLine(), typeof(T));
                dataList.Add(data);
            }  

            int listLen = dataList.Count;
            for (int i = 0; i < listLen - 1; i++)
            {
                int min_idx = i;
                for (int j = i + 1; j < listLen; j++)
                {
                    int val = dataList[j].CompareTo(dataList[min_idx]);
                    if (val < 0)
                    {
                        min_idx = j;
                    }
                }
                T temp = dataList[i];
                dataList[i] = dataList[min_idx];
                dataList[min_idx] = temp;
            }
            
        }
    }
}