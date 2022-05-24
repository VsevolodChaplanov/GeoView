using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace GeoView
{
    internal class GRDParser
    { 
        // Разделитель
        private string Separator { set; get; }
        // Состояние считывание
        private enum ParserStates
        {
            None,
            Header,
            Values
        };

        public static GVContainer ParseFile(string fileName, char Separator = ' ')
        {
            GVContainer valStore = new GVContainer();
            try
            {
                uint k = 0;
                foreach (string line in File.ReadLines(fileName))
                {
                    try
                    {
                        // Костыль:
                        // В конце массива @values лежит пустой символ
                        string linetoparse = Regex.Replace(line, @"  +", " ");
                        string[] values = linetoparse.Split(Separator);
                        if (k == 0)
                        {
                            k++;
                            continue;
                        }
                        if (k == 1)
                        {
                            valStore.Nx = (int.Parse(values[0]));
                            valStore.Ny = (int.Parse(values[1]));
                            k++;
                            continue;
                        }
                        if (k == 2)
                        {
                            valStore.xMin = (Double.Parse(values[0]));
                            valStore.xMax = (Double.Parse(values[1]));
                            k++;
                            continue;
                        }
                        if (k == 3)
                        {
                            valStore.yMin = (Double.Parse(values[0]));
                            valStore.yMax = (Double.Parse(values[1]));
                            k++;
                            continue;
                        }
                        if (k == 4)
                        {
                            valStore.zMin = (Double.Parse(values[0]));
                            valStore.zMax = (Double.Parse(values[1]));
                            k++;
                            continue;
                        }
                        for (int i = 0; i < values.Length - 1; i++)
                        {
                            valStore.funcValues.Add(Double.Parse(values[i]));
                        }
                        k++;
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            catch (Exception e)
            {
            }
            valStore.calculateNormals();

            return valStore;
        }
    }
}
