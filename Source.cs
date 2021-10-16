namespace Arrays
    {
        public static class Arrays
        {
            public static string ToString<T>(T[] array, bool brackets=true)
            {
                string s = "";
                if (brackets) { s += "[ "; }
                for(int i=0; i<array.Length; i++)
                {
                    string e = "";
                    if (array[i].GetType() == typeof(string))
                    {
                        e = "\"" + array[i].ToString() + "\"";
                    }
                    else if(array[i].GetType() == typeof(float))
                    {
                        e = array[i].ToString().Replace(',', '.') + "f";
                    }
                    else if (array[i].GetType() == typeof(double))
                    {
                        e = array[i].ToString().Replace(',', '.') + "d";
                    }
                    else if (array[i].GetType().IsArray)
                    {
                        Type elementType = array[i].GetType().GetElementType();
                        Array a = Array.CreateInstance(elementType, (array[i] as Array).Length);
                        (array[i] as Array).CopyTo(a, 0);
                        object[] obj = new object[a.Length];
                        for(int j=0; j<a.Length; j++)
                        {
                            obj[j] = a.GetValue(j);
                        }
                        e = array[i].ToString() + " { " + ToString<object>(obj, false) + " }";
                    }
                    else
                    {
                        e = array[i].ToString();
                    }
                    if (i < array.Length - 1)
                    {
                        s += e + ", ";
                    }
                    else
                    {
                        s += e;
                    }
                }
                if (brackets) { s += " ]"; }
                return s;
            }
        }
    }
