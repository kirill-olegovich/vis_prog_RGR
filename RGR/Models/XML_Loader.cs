using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace RGR.Models
{
    public class XML_Loader : ICollectionLoader
    {
        public IEnumerable<Full_Elements> Load(string path)
        {
            XDocument xDocument = XDocument.Load(path);
            XElement? collection = xDocument.Element("collection");
            if (collection is not null)
            {
                ObservableCollection<Full_Elements> loadCollection = new ObservableCollection<Full_Elements>();
                foreach (XElement classElement in collection.Elements("and_element"))
                {
                    var nameElement = classElement.Element("name");
                    Class_And classElementCollection = (Class_And)FindElement(loadCollection, (string)nameElement.Value);
                    int found = 1;
                    int foundIn = 1;
                    int foundOut = 1;

                    if (classElementCollection == null)
                    {
                        found = 0;
                        classElementCollection = new Class_And();
                    }

                    var point = classElement.Element("start");
                    var power = classElement.Element("power");
                    var OUTPUT = classElement.Element("OUTPUT");

                    classElementCollection.Main_Point = Avalonia.Point.Parse(point.Value);
                    classElementCollection.Name = nameElement.Value;
                    classElementCollection.Power = (int)power;
                    classElementCollection.OUTPUT = (int)OUTPUT;

                    for (int i = 0; i < 8; i++)
                    {
                        var input = classElement.Element("input" + i.ToString());
                        var output = classElement.Element("output" + i.ToString());
                        var inElementIndex = classElement.Element("InElementIndex" + i.ToString());
                        var inElementName = classElement.Element("InElementName" + i.ToString());
                        var outElementIndex = classElement.Element("OutElementIndex" + i.ToString());
                        var outElementName = classElement.Element("OutElementName" + i.ToString());

                        classElementCollection.Inputs[i] = (int)input;
                        classElementCollection.Outputs[i] = (int)output;

                        if (inElementIndex != null && inElementName != null)
                        {
                            classElementCollection.InElements[i] = new Class_ArrayElement();
                            classElementCollection.InElements[i].Index = (int)inElementIndex;

                            object inElement = FindElement(loadCollection, (string)inElementName.Value);

                            if (inElement == null)
                            {
                                inElement = NameToClass((string)inElementName.Value);
                                foundIn = 0;
                            }

                            classElementCollection.InElements[i].Element = (Full_Elements)inElement;
                            classElementCollection.InElements[i].Element.Name = inElementName.Value;

                            if (foundIn == 0)
                            {
                                loadCollection.Add(classElementCollection.InElements[i].Element);
                            }
                        }
                        if (outElementIndex != null && outElementName != null)
                        {
                            classElementCollection.OutElements[i] = new Class_ArrayElement();
                            classElementCollection.OutElements[i].Index = (int)outElementIndex;

                            object outElement = FindElement(loadCollection, (string)outElementName.Value);

                            if (outElement == null)
                            {
                                outElement = NameToClass((string)outElementName.Value);
                                foundOut = 0;
                            }

                            classElementCollection.OutElements[i].Element = (Full_Elements)outElement;
                            classElementCollection.OutElements[i].Element.Name = outElementName.Value;
                            
                            if (foundOut == 0)
                            {
                                loadCollection.Add(classElementCollection.OutElements[i].Element);
                            }
                        }
                    }

                    if (found == 0)
                    {
                        loadCollection.Add(classElementCollection);
                    }
                }
                foreach (XElement classElement in collection.Elements("in_element"))
                {
                    var nameElement = classElement.Element("name");
                    Class_In classElementCollection = (Class_In)FindElement(loadCollection, (string)nameElement.Value);
                    int found = 1;
                    int foundIn = 1;
                    int foundOut = 1;

                    if (classElementCollection == null)
                    {
                        found = 0;
                        classElementCollection = new Class_In();
                    }

                    var point = classElement.Element("start");
                    var power = classElement.Element("power");
                    var OUTPUT = classElement.Element("OUTPUT");

                    classElementCollection.Main_Point = Avalonia.Point.Parse(point.Value);
                    classElementCollection.Name = nameElement.Value;
                    classElementCollection.Power = (int)power;
                    classElementCollection.OUTPUT = (int)OUTPUT;

                    for (int i = 0; i < 8; i++)
                    {
                        var input = classElement.Element("input" + i.ToString());
                        var output = classElement.Element("output" + i.ToString());
                        var inElementIndex = classElement.Element("InElementIndex" + i.ToString());
                        var inElementName = classElement.Element("InElementName" + i.ToString());
                        var outElementIndex = classElement.Element("OutElementIndex" + i.ToString());
                        var outElementName = classElement.Element("OutElementName" + i.ToString());

                        classElementCollection.Inputs[i] = (int)input;
                        classElementCollection.Outputs[i] = (int)output;

                        if (inElementIndex != null && inElementName != null)
                        {
                            classElementCollection.InElements[i] = new Class_ArrayElement();
                            classElementCollection.InElements[i].Index = (int)inElementIndex;

                            object inElement = FindElement(loadCollection, (string)inElementName.Value);

                            if (inElement == null)
                            {
                                inElement = NameToClass((string)inElementName.Value);
                                foundIn = 0;
                            }

                            classElementCollection.InElements[i].Element = (Full_Elements)inElement;
                            classElementCollection.InElements[i].Element.Name = inElementName.Value;

                            if (foundIn == 0)
                            {
                                loadCollection.Add(classElementCollection.InElements[i].Element);
                            }
                        }
                        if (outElementIndex != null && outElementName != null)
                        {
                            classElementCollection.OutElements[i] = new Class_ArrayElement();
                            classElementCollection.OutElements[i].Index = (int)outElementIndex;

                            object outElement = FindElement(loadCollection, (string)outElementName.Value);

                            if (outElement == null)
                            {
                                outElement = NameToClass((string)outElementName.Value);
                                foundOut = 0;
                            }

                            classElementCollection.OutElements[i].Element = (Full_Elements)outElement;
                            classElementCollection.OutElements[i].Element.Name = outElementName.Value;
                            
                            if (foundOut == 0)
                            {
                                loadCollection.Add(classElementCollection.OutElements[i].Element);
                            }
                        }
                    }

                    if (found == 0)
                    {
                        loadCollection.Add(classElementCollection);
                    }
                }
                foreach (XElement classElement in collection.Elements("halfsum_element"))
                {
                    var nameElement = classElement.Element("name");
                    Class_HalfSum classElementCollection = (Class_HalfSum)FindElement(loadCollection, (string)nameElement.Value);
                    int found = 1;
                    int foundIn = 1;
                    int foundOut = 1;

                    if (classElementCollection == null)
                    {
                        found = 0;
                        classElementCollection = new Class_HalfSum();
                    }

                    var point = classElement.Element("start");
                    var power = classElement.Element("power");
                    var OUTPUT = classElement.Element("OUTPUT");

                    classElementCollection.Main_Point = Avalonia.Point.Parse(point.Value);
                    classElementCollection.Name = nameElement.Value;
                    classElementCollection.Power = (int)power;
                    classElementCollection.OUTPUT = (int)OUTPUT;

                    for (int i = 0; i < 8; i++)
                    {
                        var input = classElement.Element("input" + i.ToString());
                        var output = classElement.Element("output" + i.ToString());
                        var inElementIndex = classElement.Element("InElementIndex" + i.ToString());
                        var inElementName = classElement.Element("InElementName" + i.ToString());
                        var outElementIndex = classElement.Element("OutElementIndex" + i.ToString());
                        var outElementName = classElement.Element("OutElementName" + i.ToString());

                        classElementCollection.Inputs[i] = (int)input;
                        classElementCollection.Outputs[i] = (int)output;

                        if (inElementIndex != null && inElementName != null)
                        {
                            classElementCollection.InElements[i] = new Class_ArrayElement();
                            classElementCollection.InElements[i].Index = (int)inElementIndex;

                            object inElement = FindElement(loadCollection, (string)inElementName.Value);

                            if (inElement == null)
                            {
                                inElement = NameToClass((string)inElementName.Value);
                                foundIn = 0;
                            }

                            classElementCollection.InElements[i].Element = (Full_Elements)inElement;
                            classElementCollection.InElements[i].Element.Name = inElementName.Value;

                            if (foundIn == 0)
                            {
                                loadCollection.Add(classElementCollection.InElements[i].Element);
                            }
                        }
                        if (outElementIndex != null && outElementName != null)
                        {
                            classElementCollection.OutElements[i] = new Class_ArrayElement();
                            classElementCollection.OutElements[i].Index = (int)outElementIndex;

                            object outElement = FindElement(loadCollection, (string)outElementName.Value);

                            if (outElement == null)
                            {
                                outElement = NameToClass((string)outElementName.Value);
                                foundOut = 0;
                            }

                            classElementCollection.OutElements[i].Element = (Full_Elements)outElement;
                            classElementCollection.OutElements[i].Element.Name = outElementName.Value;
                            
                            if (foundOut == 0)
                            {
                                loadCollection.Add(classElementCollection.OutElements[i].Element);
                            }
                        }
                    }

                    if (found == 0)
                    {
                        loadCollection.Add(classElementCollection);
                    }
                }
                foreach (XElement classElement in collection.Elements("sum_element"))
                {
                    var nameElement = classElement.Element("name");
                    Class_Sum classElementCollection = (Class_Sum)FindElement(loadCollection, (string)nameElement.Value);
                    int found = 1;
                    int foundIn = 1;
                    int foundOut = 1;

                    if (classElementCollection == null)
                    {
                        found = 0;
                        classElementCollection = new Class_Sum();
                    }

                    var point = classElement.Element("start");
                    var power = classElement.Element("power");
                    var OUTPUT = classElement.Element("OUTPUT");

                    classElementCollection.Main_Point = Avalonia.Point.Parse(point.Value);
                    classElementCollection.Name = nameElement.Value;
                    classElementCollection.Power = (int)power;
                    classElementCollection.OUTPUT = (int)OUTPUT;

                    for (int i = 0; i < 8; i++)
                    {
                        var input = classElement.Element("input" + i.ToString());
                        var output = classElement.Element("output" + i.ToString());
                        var inElementIndex = classElement.Element("InElementIndex" + i.ToString());
                        var inElementName = classElement.Element("InElementName" + i.ToString());
                        var outElementIndex = classElement.Element("OutElementIndex" + i.ToString());
                        var outElementName = classElement.Element("OutElementName" + i.ToString());

                        classElementCollection.Inputs[i] = (int)input;
                        classElementCollection.Outputs[i] = (int)output;

                        if (inElementIndex != null && inElementName != null)
                        {
                            classElementCollection.InElements[i] = new Class_ArrayElement();
                            classElementCollection.InElements[i].Index = (int)inElementIndex;

                            object inElement = FindElement(loadCollection, (string)inElementName.Value);

                            if (inElement == null)
                            {
                                inElement = NameToClass((string)inElementName.Value);
                                foundIn = 0;
                            }

                            classElementCollection.InElements[i].Element = (Full_Elements)inElement;
                            classElementCollection.InElements[i].Element.Name = inElementName.Value;

                            if (foundIn == 0)
                            {
                                loadCollection.Add(classElementCollection.InElements[i].Element);
                            }
                        }
                        if (outElementIndex != null && outElementName != null)
                        {
                            classElementCollection.OutElements[i] = new Class_ArrayElement();
                            classElementCollection.OutElements[i].Index = (int)outElementIndex;

                            object outElement = FindElement(loadCollection, (string)outElementName.Value);

                            if (outElement == null)
                            {
                                outElement = NameToClass((string)outElementName.Value);
                                foundOut = 0;
                            }

                            classElementCollection.OutElements[i].Element = (Full_Elements)outElement;
                            classElementCollection.OutElements[i].Element.Name = outElementName.Value;
                            
                            if (foundOut == 0)
                            {
                                loadCollection.Add(classElementCollection.OutElements[i].Element);
                            }
                        }
                    }

                    if (found == 0)
                    {
                        loadCollection.Add(classElementCollection);
                    }
                }
                foreach (XElement classElement in collection.Elements("dc_element"))
                {
                    var nameElement = classElement.Element("name");
                    Class_DC classElementCollection = (Class_DC)FindElement(loadCollection, (string)nameElement.Value);
                    int found = 1;
                    int foundIn = 1;
                    int foundOut = 1;

                    if (classElementCollection == null)
                    {
                        found = 0;
                        classElementCollection = new Class_DC();
                    }

                    var point = classElement.Element("start");
                    var power = classElement.Element("power");
                    var OUTPUT = classElement.Element("OUTPUT");

                    classElementCollection.Main_Point = Avalonia.Point.Parse(point.Value);
                    classElementCollection.Name = nameElement.Value;
                    classElementCollection.Power = (int)power;
                    classElementCollection.OUTPUT = (int)OUTPUT;

                    for (int i = 0; i < 8; i++)
                    {
                        var input = classElement.Element("input" + i.ToString());
                        var output = classElement.Element("output" + i.ToString());
                        var inElementIndex = classElement.Element("InElementIndex" + i.ToString());
                        var inElementName = classElement.Element("InElementName" + i.ToString());
                        var outElementIndex = classElement.Element("OutElementIndex" + i.ToString());
                        var outElementName = classElement.Element("OutElementName" + i.ToString());

                        classElementCollection.Inputs[i] = (int)input;
                        classElementCollection.Outputs[i] = (int)output;

                        if (inElementIndex != null && inElementName != null)
                        {
                            classElementCollection.InElements[i] = new Class_ArrayElement();
                            classElementCollection.InElements[i].Index = (int)inElementIndex;

                            object inElement = FindElement(loadCollection, (string)inElementName.Value);

                            if (inElement == null)
                            {
                                inElement = NameToClass((string)inElementName.Value);
                                foundIn = 0;
                            }

                            classElementCollection.InElements[i].Element = (Full_Elements)inElement;
                            classElementCollection.InElements[i].Element.Name = inElementName.Value;

                            if (foundIn == 0)
                            {
                                loadCollection.Add(classElementCollection.InElements[i].Element);
                            }
                        }
                        if (outElementIndex != null && outElementName != null)
                        {
                            classElementCollection.OutElements[i] = new Class_ArrayElement();
                            classElementCollection.OutElements[i].Index = (int)outElementIndex;

                            object outElement = FindElement(loadCollection, (string)outElementName.Value);

                            if (outElement == null)
                            {
                                outElement = NameToClass((string)outElementName.Value);
                                foundOut = 0;
                            }

                            classElementCollection.OutElements[i].Element = (Full_Elements)outElement;
                            classElementCollection.OutElements[i].Element.Name = outElementName.Value;
                            
                            if (foundOut == 0)
                            {
                                loadCollection.Add(classElementCollection.OutElements[i].Element);
                            }
                        }
                    }

                    if (found == 0)
                    {
                        loadCollection.Add(classElementCollection);
                    }
                }
                foreach (XElement classElement in collection.Elements("cd_element"))
                {
                    var nameElement = classElement.Element("name");
                    Class_CD classElementCollection = (Class_CD)FindElement(loadCollection, (string)nameElement.Value);
                    int found = 1;
                    int foundIn = 1;
                    int foundOut = 1;

                    if (classElementCollection == null)
                    {
                        found = 0;
                        classElementCollection = new Class_CD();
                    }

                    var point = classElement.Element("start");
                    var power = classElement.Element("power");
                    var OUTPUT = classElement.Element("OUTPUT");

                    classElementCollection.Main_Point = Avalonia.Point.Parse(point.Value);
                    classElementCollection.Name = nameElement.Value;
                    classElementCollection.Power = (int)power;
                    classElementCollection.OUTPUT = (int)OUTPUT;

                    for (int i = 0; i < 8; i++)
                    {
                        var input = classElement.Element("input" + i.ToString());
                        var output = classElement.Element("output" + i.ToString());
                        var inElementIndex = classElement.Element("InElementIndex" + i.ToString());
                        var inElementName = classElement.Element("InElementName" + i.ToString());
                        var outElementIndex = classElement.Element("OutElementIndex" + i.ToString());
                        var outElementName = classElement.Element("OutElementName" + i.ToString());

                        classElementCollection.Inputs[i] = (int)input;
                        classElementCollection.Outputs[i] = (int)output;

                        if (inElementIndex != null && inElementName != null)
                        {
                            classElementCollection.InElements[i] = new Class_ArrayElement();
                            classElementCollection.InElements[i].Index = (int)inElementIndex;

                            object inElement = FindElement(loadCollection, (string)inElementName.Value);

                            if (inElement == null)
                            {
                                inElement = NameToClass((string)inElementName.Value);
                                foundIn = 0;
                            }

                            classElementCollection.InElements[i].Element = (Full_Elements)inElement;
                            classElementCollection.InElements[i].Element.Name = inElementName.Value;

                            if (foundIn == 0)
                            {
                                loadCollection.Add(classElementCollection.InElements[i].Element);
                            }
                        }
                        if (outElementIndex != null && outElementName != null)
                        {
                            classElementCollection.OutElements[i] = new Class_ArrayElement();
                            classElementCollection.OutElements[i].Index = (int)outElementIndex;

                            object outElement = FindElement(loadCollection, (string)outElementName.Value);

                            if (outElement == null)
                            {
                                outElement = NameToClass((string)outElementName.Value);
                                foundOut = 0;
                            }

                            classElementCollection.OutElements[i].Element = (Full_Elements)outElement;
                            classElementCollection.OutElements[i].Element.Name = outElementName.Value;
                            
                            if (foundOut == 0)
                            {
                                loadCollection.Add(classElementCollection.OutElements[i].Element);
                            }
                        }
                    }

                    if (found == 0)
                    {
                        loadCollection.Add(classElementCollection);
                    }
                }
                foreach (XElement classElement in collection.Elements("not_element"))
                {
                    var nameElement = classElement.Element("name");
                    Class_Not classElementCollection = (Class_Not)FindElement(loadCollection, (string)nameElement.Value);
                    int found = 1;
                    int foundIn = 1;
                    int foundOut = 1;

                    if (classElementCollection == null)
                    {
                        found = 0;
                        classElementCollection = new Class_Not();
                    }

                    var point = classElement.Element("start");
                    var power = classElement.Element("power");
                    var OUTPUT = classElement.Element("OUTPUT");

                    classElementCollection.Main_Point = Avalonia.Point.Parse(point.Value);
                    classElementCollection.Name = nameElement.Value;
                    classElementCollection.Power = (int)power;
                    classElementCollection.OUTPUT = (int)OUTPUT;

                    for (int i = 0; i < 8; i++)
                    {
                        var input = classElement.Element("input" + i.ToString());
                        var output = classElement.Element("output" + i.ToString());
                        var inElementIndex = classElement.Element("InElementIndex" + i.ToString());
                        var inElementName = classElement.Element("InElementName" + i.ToString());
                        var outElementIndex = classElement.Element("OutElementIndex" + i.ToString());
                        var outElementName = classElement.Element("OutElementName" + i.ToString());

                        classElementCollection.Inputs[i] = (int)input;
                        classElementCollection.Outputs[i] = (int)output;

                        if (inElementIndex != null && inElementName != null)
                        {
                            classElementCollection.InElements[i] = new Class_ArrayElement();
                            classElementCollection.InElements[i].Index = (int)inElementIndex;

                            object inElement = FindElement(loadCollection, (string)inElementName.Value);

                            if (inElement == null)
                            {
                                inElement = NameToClass((string)inElementName.Value);
                                foundIn = 0;
                            }

                            classElementCollection.InElements[i].Element = (Full_Elements)inElement;
                            classElementCollection.InElements[i].Element.Name = inElementName.Value;

                            if (foundIn == 0)
                            {
                                loadCollection.Add(classElementCollection.InElements[i].Element);
                            }
                        }
                        if (outElementIndex != null && outElementName != null)
                        {
                            classElementCollection.OutElements[i] = new Class_ArrayElement();
                            classElementCollection.OutElements[i].Index = (int)outElementIndex;

                            object outElement = FindElement(loadCollection, (string)outElementName.Value);

                            if (outElement == null)
                            {
                                outElement = NameToClass((string)outElementName.Value);
                                foundOut = 0;
                            }

                            classElementCollection.OutElements[i].Element = (Full_Elements)outElement;
                            classElementCollection.OutElements[i].Element.Name = outElementName.Value;
                            
                            if (foundOut == 0)
                            {
                                loadCollection.Add(classElementCollection.OutElements[i].Element);
                            }
                        }
                    }

                    if (found == 0)
                    {
                        loadCollection.Add(classElementCollection);
                    }
                }
                foreach (XElement classElement in collection.Elements("or_element"))
                {
                    var nameElement = classElement.Element("name");
                    Class_Or classElementCollection = (Class_Or)FindElement(loadCollection, (string)nameElement.Value);
                    int found = 1;
                    int foundIn = 1;
                    int foundOut = 1;

                    if (classElementCollection == null)
                    {
                        found = 0;
                        classElementCollection = new Class_Or();
                    }

                    var point = classElement.Element("start");
                    var power = classElement.Element("power");
                    var OUTPUT = classElement.Element("OUTPUT");

                    classElementCollection.Main_Point = Avalonia.Point.Parse(point.Value);
                    classElementCollection.Name = nameElement.Value;
                    classElementCollection.Power = (int)power;
                    classElementCollection.OUTPUT = (int)OUTPUT;

                    for (int i = 0; i < 8; i++)
                    {
                        var input = classElement.Element("input" + i.ToString());
                        var output = classElement.Element("output" + i.ToString());
                        var inElementIndex = classElement.Element("InElementIndex" + i.ToString());
                        var inElementName = classElement.Element("InElementName" + i.ToString());
                        var outElementIndex = classElement.Element("OutElementIndex" + i.ToString());
                        var outElementName = classElement.Element("OutElementName" + i.ToString());

                        classElementCollection.Inputs[i] = (int)input;
                        classElementCollection.Outputs[i] = (int)output;

                        if (inElementIndex != null && inElementName != null)
                        {
                            classElementCollection.InElements[i] = new Class_ArrayElement();
                            classElementCollection.InElements[i].Index = (int)inElementIndex;

                            object inElement = FindElement(loadCollection, (string)inElementName.Value);

                            if (inElement == null)
                            {
                                inElement = NameToClass((string)inElementName.Value);
                                foundIn = 0;
                            }

                            classElementCollection.InElements[i].Element = (Full_Elements)inElement;
                            classElementCollection.InElements[i].Element.Name = inElementName.Value;

                            if (foundIn == 0)
                            {
                                loadCollection.Add(classElementCollection.InElements[i].Element);
                            }
                        }
                        if (outElementIndex != null && outElementName != null)
                        {
                            classElementCollection.OutElements[i] = new Class_ArrayElement();
                            classElementCollection.OutElements[i].Index = (int)outElementIndex;

                            object outElement = FindElement(loadCollection, (string)outElementName.Value);

                            if (outElement == null)
                            {
                                outElement = NameToClass((string)outElementName.Value);
                                foundOut = 0;
                            }

                            classElementCollection.OutElements[i].Element = (Full_Elements)outElement;
                            classElementCollection.OutElements[i].Element.Name = outElementName.Value;
                            
                            if (foundOut == 0)
                            {
                                loadCollection.Add(classElementCollection.OutElements[i].Element);
                            }
                        }
                    }

                    if (found == 0)
                    {
                        loadCollection.Add(classElementCollection);
                    }
                }
                foreach (XElement classElement in collection.Elements("out_element"))
                {
                    var nameElement = classElement.Element("name");
                    Class_Out classElementCollection = (Class_Out)FindElement(loadCollection, (string)nameElement.Value);
                    int found = 1;
                    int foundIn = 1;
                    int foundOut = 1;

                    if (classElementCollection == null)
                    {
                        found = 0;
                        classElementCollection = new Class_Out();
                    }

                    var point = classElement.Element("start");
                    var power = classElement.Element("power");
                    var OUTPUT = classElement.Element("OUTPUT");

                    classElementCollection.Main_Point = Avalonia.Point.Parse(point.Value);
                    classElementCollection.Name = nameElement.Value;
                    classElementCollection.Power = (int)power;
                    classElementCollection.OUTPUT = (int)OUTPUT;

                    for (int i = 0; i < 8; i++)
                    {
                        var input = classElement.Element("input" + i.ToString());
                        var output = classElement.Element("output" + i.ToString());
                        var inElementIndex = classElement.Element("InElementIndex" + i.ToString());
                        var inElementName = classElement.Element("InElementName" + i.ToString());
                        var outElementIndex = classElement.Element("OutElementIndex" + i.ToString());
                        var outElementName = classElement.Element("OutElementName" + i.ToString());

                        classElementCollection.Inputs[i] = (int)input;
                        classElementCollection.Outputs[i] = (int)output;

                        if (inElementIndex != null && inElementName != null)
                        {
                            classElementCollection.InElements[i] = new Class_ArrayElement();
                            classElementCollection.InElements[i].Index = (int)inElementIndex;

                            object inElement = FindElement(loadCollection, (string)inElementName.Value);

                            if (inElement == null)
                            {
                                inElement = NameToClass((string)inElementName.Value);
                                foundIn = 0;
                            }

                            classElementCollection.InElements[i].Element = (Full_Elements)inElement;
                            classElementCollection.InElements[i].Element.Name = inElementName.Value;

                            if (foundIn == 0)
                            {
                                loadCollection.Add(classElementCollection.InElements[i].Element);
                            }
                        }
                        if (outElementIndex != null && outElementName != null)
                        {
                            classElementCollection.OutElements[i] = new Class_ArrayElement();
                            classElementCollection.OutElements[i].Index = (int)outElementIndex;

                            object outElement = FindElement(loadCollection, (string)outElementName.Value);

                            if (outElement == null)
                            {
                                outElement = NameToClass((string)outElementName.Value);
                                foundOut = 0;
                            }

                            classElementCollection.OutElements[i].Element = (Full_Elements)outElement;
                            classElementCollection.OutElements[i].Element.Name = outElementName.Value;
                            
                            if (foundOut == 0)
                            {
                                loadCollection.Add(classElementCollection.OutElements[i].Element);
                            }
                        }
                    }

                    if (found == 0)
                    {
                        loadCollection.Add(classElementCollection);
                    }
                }
                foreach (XElement classElement in collection.Elements("xor_element"))
                {
                    var nameElement = classElement.Element("name");
                    Class_XoR classElementCollection = (Class_XoR)FindElement(loadCollection, (string)nameElement.Value);
                    int found = 1;
                    int foundIn = 1;
                    int foundOut = 1;

                    if (classElementCollection == null)
                    {
                        found = 0;
                        classElementCollection = new Class_XoR();
                    }

                    var point = classElement.Element("start");
                    var power = classElement.Element("power");
                    var OUTPUT = classElement.Element("OUTPUT");

                    classElementCollection.Main_Point = Avalonia.Point.Parse(point.Value);
                    classElementCollection.Name = nameElement.Value;
                    classElementCollection.Power = (int)power;
                    classElementCollection.OUTPUT = (int)OUTPUT;

                    for (int i = 0; i < 8; i++)
                    {
                        var input = classElement.Element("input" + i.ToString());
                        var output = classElement.Element("output" + i.ToString());
                        var inElementIndex = classElement.Element("InElementIndex" + i.ToString());
                        var inElementName = classElement.Element("InElementName" + i.ToString());
                        var outElementIndex = classElement.Element("OutElementIndex" + i.ToString());
                        var outElementName = classElement.Element("OutElementName" + i.ToString());

                        classElementCollection.Inputs[i] = (int)input;
                        classElementCollection.Outputs[i] = (int)output;

                        if (inElementIndex != null && inElementName != null)
                        {
                            classElementCollection.InElements[i] = new Class_ArrayElement();
                            classElementCollection.InElements[i].Index = (int)inElementIndex;

                            object inElement = FindElement(loadCollection, (string)inElementName.Value);

                            if (inElement == null)
                            {
                                inElement = NameToClass((string)inElementName.Value);
                                foundIn = 0;
                            }

                            classElementCollection.InElements[i].Element = (Full_Elements)inElement;
                            classElementCollection.InElements[i].Element.Name = inElementName.Value;

                            if (foundIn == 0)
                            {
                                loadCollection.Add(classElementCollection.InElements[i].Element);
                            }
                        }
                        if (outElementIndex != null && outElementName != null)
                        {
                            classElementCollection.OutElements[i] = new Class_ArrayElement();
                            classElementCollection.OutElements[i].Index = (int)outElementIndex;

                            object outElement = FindElement(loadCollection, (string)outElementName.Value);

                            if (outElement == null)
                            {
                                outElement = NameToClass((string)outElementName.Value);
                                foundOut = 0;
                            }

                            classElementCollection.OutElements[i].Element = (Full_Elements)outElement;
                            classElementCollection.OutElements[i].Element.Name = outElementName.Value;
                            
                            if (foundOut == 0)
                            {
                                loadCollection.Add(classElementCollection.OutElements[i].Element);
                            }
                        }
                    }

                    if (found == 0)
                    {
                        loadCollection.Add(classElementCollection);
                    }
                }
                foreach (XElement lineElement in collection.Elements("line_element"))
                {
                    Class_Line lineElementCollection = new Class_Line();
                    int foundIn = 1;
                    int foundOut = 1;
                    var lineStart = lineElement.Element("start");
                    var lineEnd = lineElement.Element("end");
                    var firstElementName = lineElement.Element("firstElement");
                    var secondElementName = lineElement.Element("secondElement");
                    var name1 = lineElement.Element("name1");
                    var name2 = lineElement.Element("name2");
                    
                    lineElementCollection.StartPoint = Avalonia.Point.Parse(lineStart.Value);
                    lineElementCollection.EndPoint = Avalonia.Point.Parse(lineEnd.Value);
 
                    object firstElement = FindElement(loadCollection, (string)firstElementName.Value);

                    if (firstElement == null)
                    {
                        firstElement = NameToClass((string)firstElementName.Value);
                        loadCollection.Add((Full_Elements)firstElement);
                    }

                    object secondElement = FindElement(loadCollection, (string)secondElementName.Value);

                    if (secondElement == null)
                    {
                        secondElement = NameToClass((string)secondElementName.Value);
                        loadCollection.Add((Full_Elements)secondElement);
                    }

                    lineElementCollection.FirstElement = (Full_Elements)firstElement;
                    lineElementCollection.SecondElement = (Full_Elements)secondElement;
                    lineElementCollection.Name1 = name1.Value;
                    lineElementCollection.Name2 = name2.Value;

                    for (int i = 0; i < 8; i++)
                    {
                        var input = lineElement.Element("input" + i.ToString());
                        var output = lineElement.Element("output" + i.ToString());
                        var inElementIndex = lineElement.Element("InElementIndex" + i.ToString());
                        var inElementName = lineElement.Element("InElementName" + i.ToString());
                        var outElementIndex = lineElement.Element("OutElementIndex" + i.ToString());
                        var outElementName = lineElement.Element("OutElementName" + i.ToString());

                        lineElementCollection.Inputs[i] = (int)input;
                        lineElementCollection.Outputs[i] = (int)output;

                        if (inElementIndex != null && inElementName != null)
                        {
                            lineElementCollection.InElements[i] = new Class_ArrayElement();
                            lineElementCollection.InElements[i].Index = (int)inElementIndex;

                            object inElement = FindElement(loadCollection, (string)inElementName.Value);

                            if (inElement == null)
                            {
                                inElement = NameToClass((string)inElementName.Value);
                                foundIn = 0;
                            }

                            lineElementCollection.InElements[i].Element = (Full_Elements)inElement;
                            lineElementCollection.InElements[i].Element.Name = inElementName.Value;

                            if (foundIn == 0)
                            {
                                loadCollection.Add(lineElementCollection.InElements[i].Element);
                            }
                        }
                        if (outElementIndex != null && outElementName != null)
                        {
                            lineElementCollection.OutElements[i] = new Class_ArrayElement();
                            lineElementCollection.OutElements[i].Index = (int)outElementIndex;

                            object outElement = FindElement(loadCollection, (string)outElementName.Value);

                            if (outElement == null)
                            {
                                outElement = NameToClass((string)outElementName.Value);
                                foundOut = 0;
                            }

                            lineElementCollection.OutElements[i].Element = (Full_Elements)outElement;
                            lineElementCollection.OutElements[i].Element.Name = outElementName.Value;
                            
                            if (foundOut == 0)
                            {
                                loadCollection.Add(lineElementCollection.OutElements[i].Element);
                            }
                        }
                    }

                    loadCollection.Add(lineElementCollection);
                }
                if (loadCollection != null)
                {
                    return loadCollection;
                }
                else return new ObservableCollection<Full_Elements>();
            }
            return new ObservableCollection<Full_Elements>();
        }

        private Full_Elements FindElement(ObservableCollection<Full_Elements> collection, string name)
        {
            if (collection == null || name == null)
            {
                return null;
            }

            for (int i = collection.Count - 1; i >= 0; i--)
            {   
                if (collection[i] is Full_Elements element)
                {
                    if (element.Name == name)
                    {
                        return element;
                    }
                }
            }

            return null;
        }

        private object NameToClass(string name)
        {
            if (name.Contains("element_and"))
            {
                return new Class_And();
            }
            else if (name.Contains("element_or"))
            {
                return new Class_Or();
            }
            else if (name.Contains("element_xor"))
            {
                return new Class_XoR();
            }
            else if (name.Contains("element_not"))
            {
                return new Class_Not();
            }
            else if (name.Contains("element_dc"))
            {
                return new Class_DC();
            }
            else if (name.Contains("element_cd"))
            {
                return new Class_CD();
            }
            else if (name.Contains("element_halfsum"))
            {
                return new Class_HalfSum();
            }
            else if (name.Contains("element_sum"))
            {
                return new Class_Sum();
            }
            else if (name.Contains("element_in"))
            {
                return new Class_In();
            }
            else if (name.Contains("element_out"))
            {
                return new Class_Out();
            }
            else
            {
                return null;
            }
        }
    }
}
