using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RGR.Models
{
    public class XML_Saver : ICollectionSaver
    {
        public void Save(Class_Project project, string path)
        {
            XDocument xDocument = new XDocument();
            XElement xProject = new XElement("project");
            XElement xNameProject = new XElement("NameProject", project.NameProject);
            xProject.Add(xNameProject);

            foreach (Class_Circuit circuit in project.Circuits)
            {
                XElement xCircuit = new XElement("circuit");
                XElement xNameCircuit = new XElement("NameCircuit", circuit.NameCircuit);
                xCircuit.Add(xNameCircuit);

                foreach (Full_Elements element in circuit.Elements)
                {
                    if (element is Class_And and_element)
                    {
                        XElement xElementClass = new XElement("and_element");
                        XElement xElementStart = new XElement("start", and_element.Main_Point);
                        XElement xElementName = new XElement("name", and_element.Name);
                        XElement xElementPower = new XElement("power", and_element.Power);
                        XElement xElementOUTPUT = new XElement("OUTPUT", and_element.OUTPUT);

                        for (int i = 0; i < 8; i++)
                        {
                            XElement xElementInput = new XElement("input" + i.ToString(), and_element.Inputs[i]);
                            XElement xElementOutput = new XElement("output" + i.ToString(), and_element.Outputs[i]);
                            
                            if (and_element.InElements[i] is Class_ArrayElement arrayElement1)
                            {
                                XElement xElementIndex = new XElement("InElementIndex" + i.ToString(), arrayElement1.Index);
                                
                                if (arrayElement1.Element is Full_Elements fullElement)
                                {
                                    XElement xElementInElementName = new XElement("InElementName" + i.ToString(), arrayElement1.Element.Name);
                                    xElementClass.Add(xElementInElementName);
                                }

                                xElementClass.Add(xElementIndex);
                            }

                            if (and_element.OutElements[i] is Class_ArrayElement arrayElement2)
                            {
                                XElement xElementIndex = new XElement("OutElementIndex" + i.ToString(), arrayElement2.Index);

                                if (arrayElement2.Element is Full_Elements fullElement)
                                {
                                    XElement xElementOutElementName = new XElement("OutElementName" + i.ToString(), arrayElement2.Element.Name);
                                    xElementClass.Add(xElementOutElementName);
                                }

                                xElementClass.Add(xElementIndex);
                            }

                            xElementClass.Add(xElementInput);
                            xElementClass.Add(xElementOutput);
                        }

                        xElementClass.Add(xElementStart);
                        xElementClass.Add(xElementName);
                        xElementClass.Add(xElementPower);
                        xElementClass.Add(xElementOUTPUT);
                        xCircuit.Add(xElementClass);
                    }
                    else if (element is Class_In in_element)
                    {
                        XElement xElementClass = new XElement("in_element");
                        XElement xElementStart = new XElement("start", in_element.Main_Point);
                        XElement xElementName = new XElement("name", in_element.Name);
                        XElement xElementPower = new XElement("power", in_element.Power);
                        XElement xElementOUTPUT = new XElement("OUTPUT", in_element.OUTPUT);

                        for (int i = 0; i < 8; i++)
                        {
                            XElement xElementInput = new XElement("input" + i.ToString(), in_element.Inputs[i]);
                            XElement xElementOutput = new XElement("output" + i.ToString(), in_element.Outputs[i]);
                            
                            if (in_element.InElements[i] is Class_ArrayElement arrayElement1)
                            {
                                XElement xElementIndex = new XElement("InElementIndex" + i.ToString(), arrayElement1.Index);
                                
                                if (arrayElement1.Element is Full_Elements fullElement)
                                {
                                    XElement xElementInElementName = new XElement("InElementName" + i.ToString(), arrayElement1.Element.Name);
                                    xElementClass.Add(xElementInElementName);
                                }

                                xElementClass.Add(xElementIndex);
                            }

                            if (in_element.OutElements[i] is Class_ArrayElement arrayElement2)
                            {
                                XElement xElementIndex = new XElement("OutElementIndex" + i.ToString(), arrayElement2.Index);

                                if (arrayElement2.Element is Full_Elements fullElement)
                                {
                                    XElement xElementOutElementName = new XElement("OutElementName" + i.ToString(), arrayElement2.Element.Name);
                                    xElementClass.Add(xElementOutElementName);
                                }

                                xElementClass.Add(xElementIndex);
                            }

                            xElementClass.Add(xElementInput);
                            xElementClass.Add(xElementOutput);
                        }

                        xElementClass.Add(xElementStart);
                        xElementClass.Add(xElementName);
                        xElementClass.Add(xElementPower);
                        xElementClass.Add(xElementOUTPUT);
                        xCircuit.Add(xElementClass);
                    }
                    else if (element is Class_HalfSum halfsum_element)
                    {
                        XElement xElementClass = new XElement("halfsum_element");
                        XElement xElementStart = new XElement("start", halfsum_element.Main_Point);
                        XElement xElementName = new XElement("name", halfsum_element.Name);
                        XElement xElementPower = new XElement("power", halfsum_element.Power);
                        XElement xElementOUTPUT = new XElement("OUTPUT", halfsum_element.OUTPUT);

                        for (int i = 0; i < 8; i++)
                        {
                            XElement xElementInput = new XElement("input" + i.ToString(), halfsum_element.Inputs[i]);
                            XElement xElementOutput = new XElement("output" + i.ToString(), halfsum_element.Outputs[i]);
                            
                            if (halfsum_element.InElements[i] is Class_ArrayElement arrayElement1)
                            {
                                XElement xElementIndex = new XElement("InElementIndex" + i.ToString(), arrayElement1.Index);
                                
                                if (arrayElement1.Element is Full_Elements fullElement)
                                {
                                    XElement xElementInElementName = new XElement("InElementName" + i.ToString(), arrayElement1.Element.Name);
                                    xElementClass.Add(xElementInElementName);
                                }

                                xElementClass.Add(xElementIndex);
                            }

                            if (halfsum_element.OutElements[i] is Class_ArrayElement arrayElement2)
                            {
                                XElement xElementIndex = new XElement("OutElementIndex" + i.ToString(), arrayElement2.Index);

                                if (arrayElement2.Element is Full_Elements fullElement)
                                {
                                    XElement xElementOutElementName = new XElement("OutElementName" + i.ToString(), arrayElement2.Element.Name);
                                    xElementClass.Add(xElementOutElementName);
                                }

                                xElementClass.Add(xElementIndex);
                            }

                            xElementClass.Add(xElementInput);
                            xElementClass.Add(xElementOutput);
                        }

                        xElementClass.Add(xElementStart);
                        xElementClass.Add(xElementName);
                        xElementClass.Add(xElementPower);
                        xElementClass.Add(xElementOUTPUT);
                        xCircuit.Add(xElementClass);
                    }
                    else if (element is Class_Sum sum_element)
                    {
                        XElement xElementClass = new XElement("sum_element");
                        XElement xElementStart = new XElement("start", sum_element.Main_Point);
                        XElement xElementName = new XElement("name", sum_element.Name);
                        XElement xElementPower = new XElement("power", sum_element.Power);
                        XElement xElementOUTPUT = new XElement("OUTPUT", sum_element.OUTPUT);

                        for (int i = 0; i < 8; i++)
                        {
                            XElement xElementInput = new XElement("input" + i.ToString(), sum_element.Inputs[i]);
                            XElement xElementOutput = new XElement("output" + i.ToString(), sum_element.Outputs[i]);
                            
                            if (sum_element.InElements[i] is Class_ArrayElement arrayElement1)
                            {
                                XElement xElementIndex = new XElement("InElementIndex" + i.ToString(), arrayElement1.Index);
                                
                                if (arrayElement1.Element is Full_Elements fullElement)
                                {
                                    XElement xElementInElementName = new XElement("InElementName" + i.ToString(), arrayElement1.Element.Name);
                                    xElementClass.Add(xElementInElementName);
                                }

                                xElementClass.Add(xElementIndex);
                            }

                            if (sum_element.OutElements[i] is Class_ArrayElement arrayElement2)
                            {
                                XElement xElementIndex = new XElement("OutElementIndex" + i.ToString(), arrayElement2.Index);

                                if (arrayElement2.Element is Full_Elements fullElement)
                                {
                                    XElement xElementOutElementName = new XElement("OutElementName" + i.ToString(), arrayElement2.Element.Name);
                                    xElementClass.Add(xElementOutElementName);
                                }

                                xElementClass.Add(xElementIndex);
                            }

                            xElementClass.Add(xElementInput);
                            xElementClass.Add(xElementOutput);
                        }

                        xElementClass.Add(xElementStart);
                        xElementClass.Add(xElementName);
                        xElementClass.Add(xElementPower);
                        xElementClass.Add(xElementOUTPUT);
                        xCircuit.Add(xElementClass);
                    }
                    else if (element is Class_DC dc_element)
                    {
                        XElement xElementClass = new XElement("dc_element");
                        XElement xElementStart = new XElement("start", dc_element.Main_Point);
                        XElement xElementName = new XElement("name", dc_element.Name);
                        XElement xElementPower = new XElement("power", dc_element.Power);
                        XElement xElementOUTPUT = new XElement("OUTPUT", dc_element.OUTPUT);

                        for (int i = 0; i < 8; i++)
                        {
                            XElement xElementInput = new XElement("input" + i.ToString(), dc_element.Inputs[i]);
                            XElement xElementOutput = new XElement("output" + i.ToString(), dc_element.Outputs[i]);
                            
                            if (dc_element.InElements[i] is Class_ArrayElement arrayElement1)
                            {
                                XElement xElementIndex = new XElement("InElementIndex" + i.ToString(), arrayElement1.Index);
                                
                                if (arrayElement1.Element is Full_Elements fullElement)
                                {
                                    XElement xElementInElementName = new XElement("InElementName" + i.ToString(), arrayElement1.Element.Name);
                                    xElementClass.Add(xElementInElementName);
                                }

                                xElementClass.Add(xElementIndex);
                            }

                            if (dc_element.OutElements[i] is Class_ArrayElement arrayElement2)
                            {
                                XElement xElementIndex = new XElement("OutElementIndex" + i.ToString(), arrayElement2.Index);

                                if (arrayElement2.Element is Full_Elements fullElement)
                                {
                                    XElement xElementOutElementName = new XElement("OutElementName" + i.ToString(), arrayElement2.Element.Name);
                                    xElementClass.Add(xElementOutElementName);
                                }

                                xElementClass.Add(xElementIndex);
                            }

                            xElementClass.Add(xElementInput);
                            xElementClass.Add(xElementOutput);
                        }

                        xElementClass.Add(xElementStart);
                        xElementClass.Add(xElementName);
                        xElementClass.Add(xElementPower);
                        xElementClass.Add(xElementOUTPUT);
                        xCircuit.Add(xElementClass);
                    }
                    else if (element is Class_CD cd_element)
                    {
                        XElement xElementClass = new XElement("cd_element");
                        XElement xElementStart = new XElement("start", cd_element.Main_Point);
                        XElement xElementName = new XElement("name", cd_element.Name);
                        XElement xElementPower = new XElement("power", cd_element.Power);
                        XElement xElementOUTPUT = new XElement("OUTPUT", cd_element.OUTPUT);

                        for (int i = 0; i < 8; i++)
                        {
                            XElement xElementInput = new XElement("input" + i.ToString(), cd_element.Inputs[i]);
                            XElement xElementOutput = new XElement("output" + i.ToString(), cd_element.Outputs[i]);
                            
                            if (cd_element.InElements[i] is Class_ArrayElement arrayElement1)
                            {
                                XElement xElementIndex = new XElement("InElementIndex" + i.ToString(), arrayElement1.Index);
                                
                                if (arrayElement1.Element is Full_Elements fullElement)
                                {
                                    XElement xElementInElementName = new XElement("InElementName" + i.ToString(), arrayElement1.Element.Name);
                                    xElementClass.Add(xElementInElementName);
                                }

                                xElementClass.Add(xElementIndex);
                            }

                            if (cd_element.OutElements[i] is Class_ArrayElement arrayElement2)
                            {
                                XElement xElementIndex = new XElement("OutElementIndex" + i.ToString(), arrayElement2.Index);

                                if (arrayElement2.Element is Full_Elements fullElement)
                                {
                                    XElement xElementOutElementName = new XElement("OutElementName" + i.ToString(), arrayElement2.Element.Name);
                                    xElementClass.Add(xElementOutElementName);
                                }

                                xElementClass.Add(xElementIndex);
                            }

                            xElementClass.Add(xElementInput);
                            xElementClass.Add(xElementOutput);
                        }

                        xElementClass.Add(xElementStart);
                        xElementClass.Add(xElementName);
                        xElementClass.Add(xElementPower);
                        xElementClass.Add(xElementOUTPUT);
                        xCircuit.Add(xElementClass);
                    }
                    else if (element is Class_Not not_element)
                    {
                        XElement xElementClass = new XElement("not_element");
                        XElement xElementStart = new XElement("start", not_element.Main_Point);
                        XElement xElementName = new XElement("name", not_element.Name);
                        XElement xElementPower = new XElement("power", not_element.Power);
                        XElement xElementOUTPUT = new XElement("OUTPUT", not_element.OUTPUT);

                        for (int i = 0; i < 8; i++)
                        {
                            XElement xElementInput = new XElement("input" + i.ToString(), not_element.Inputs[i]);
                            XElement xElementOutput = new XElement("output" + i.ToString(), not_element.Outputs[i]);
                            
                            if (not_element.InElements[i] is Class_ArrayElement arrayElement1)
                            {
                                XElement xElementIndex = new XElement("InElementIndex" + i.ToString(), arrayElement1.Index);
                                
                                if (arrayElement1.Element is Full_Elements fullElement)
                                {
                                    XElement xElementInElementName = new XElement("InElementName" + i.ToString(), arrayElement1.Element.Name);
                                    xElementClass.Add(xElementInElementName);
                                }

                                xElementClass.Add(xElementIndex);
                            }

                            if (not_element.OutElements[i] is Class_ArrayElement arrayElement2)
                            {
                                XElement xElementIndex = new XElement("OutElementIndex" + i.ToString(), arrayElement2.Index);

                                if (arrayElement2.Element is Full_Elements fullElement)
                                {
                                    XElement xElementOutElementName = new XElement("OutElementName" + i.ToString(), arrayElement2.Element.Name);
                                    xElementClass.Add(xElementOutElementName);
                                }

                                xElementClass.Add(xElementIndex);
                            }

                            xElementClass.Add(xElementInput);
                            xElementClass.Add(xElementOutput);
                        }

                        xElementClass.Add(xElementStart);
                        xElementClass.Add(xElementName);
                        xElementClass.Add(xElementPower);
                        xElementClass.Add(xElementOUTPUT);
                        xCircuit.Add(xElementClass);                
                    }
                    else if (element is Class_Or or_element)
                    {
                        XElement xElementClass = new XElement("or_element");
                        XElement xElementStart = new XElement("start", or_element.Main_Point);
                        XElement xElementName = new XElement("name", or_element.Name);
                        XElement xElementPower = new XElement("power", or_element.Power);
                        XElement xElementOUTPUT = new XElement("OUTPUT", or_element.OUTPUT);

                        for (int i = 0; i < 8; i++)
                        {
                            XElement xElementInput = new XElement("input" + i.ToString(), or_element.Inputs[i]);
                            XElement xElementOutput = new XElement("output" + i.ToString(), or_element.Outputs[i]);
                            
                            if (or_element.InElements[i] is Class_ArrayElement arrayElement1)
                            {
                                XElement xElementIndex = new XElement("InElementIndex" + i.ToString(), arrayElement1.Index);
                                
                                if (arrayElement1.Element is Full_Elements fullElement)
                                {
                                    XElement xElementInElementName = new XElement("InElementName" + i.ToString(), arrayElement1.Element.Name);
                                    xElementClass.Add(xElementInElementName);
                                }

                                xElementClass.Add(xElementIndex);
                            }

                            if (or_element.OutElements[i] is Class_ArrayElement arrayElement2)
                            {
                                XElement xElementIndex = new XElement("OutElementIndex" + i.ToString(), arrayElement2.Index);

                                if (arrayElement2.Element is Full_Elements fullElement)
                                {
                                    XElement xElementOutElementName = new XElement("OutElementName" + i.ToString(), arrayElement2.Element.Name);
                                    xElementClass.Add(xElementOutElementName);
                                }

                                xElementClass.Add(xElementIndex);
                            }

                            xElementClass.Add(xElementInput);
                            xElementClass.Add(xElementOutput);
                        }

                        xElementClass.Add(xElementStart);
                        xElementClass.Add(xElementName);
                        xElementClass.Add(xElementPower);
                        xElementClass.Add(xElementOUTPUT);
                        xCircuit.Add(xElementClass);
                    }
                    else if (element is Class_Out out_element)
                    {
                        XElement xElementClass = new XElement("out_element");
                        XElement xElementStart = new XElement("start", out_element.Main_Point);
                        XElement xElementName = new XElement("name", out_element.Name);
                        XElement xElementPower = new XElement("power", out_element.Power);
                        XElement xElementOUTPUT = new XElement("OUTPUT", out_element.OUTPUT);

                        for (int i = 0; i < 8; i++)
                        {
                            XElement xElementInput = new XElement("input" + i.ToString(), out_element.Inputs[i]);
                            XElement xElementOutput = new XElement("output" + i.ToString(), out_element.Outputs[i]);
                            
                            if (out_element.InElements[i] is Class_ArrayElement arrayElement1)
                            {
                                XElement xElementIndex = new XElement("InElementIndex" + i.ToString(), arrayElement1.Index);
                                
                                if (arrayElement1.Element is Full_Elements fullElement)
                                {
                                    XElement xElementInElementName = new XElement("InElementName" + i.ToString(), arrayElement1.Element.Name);
                                    xElementClass.Add(xElementInElementName);
                                }

                                xElementClass.Add(xElementIndex);
                            }

                            if (out_element.OutElements[i] is Class_ArrayElement arrayElement2)
                            {
                                XElement xElementIndex = new XElement("OutElementIndex" + i.ToString(), arrayElement2.Index);

                                if (arrayElement2.Element is Full_Elements fullElement)
                                {
                                    XElement xElementOutElementName = new XElement("OutElementName" + i.ToString(), arrayElement2.Element.Name);
                                    xElementClass.Add(xElementOutElementName);
                                }

                                xElementClass.Add(xElementIndex);
                            }

                            xElementClass.Add(xElementInput);
                            xElementClass.Add(xElementOutput);
                        }

                        xElementClass.Add(xElementStart);
                        xElementClass.Add(xElementName);
                        xElementClass.Add(xElementPower);
                        xElementClass.Add(xElementOUTPUT);
                        xCircuit.Add(xElementClass);
                    }
                    else if (element is Class_XoR xor_element)
                    {
                        XElement xElementClass = new XElement("xor_element");
                        XElement xElementStart = new XElement("start", xor_element.Main_Point);
                        XElement xElementName = new XElement("name", xor_element.Name);
                        XElement xElementPower = new XElement("power", xor_element.Power);
                        XElement xElementOUTPUT = new XElement("OUTPUT", xor_element.OUTPUT);

                        for (int i = 0; i < 8; i++)
                        {
                            XElement xElementInput = new XElement("input" + i.ToString(), xor_element.Inputs[i]);
                            XElement xElementOutput = new XElement("output" + i.ToString(), xor_element.Outputs[i]);
                            
                            if (xor_element.InElements[i] is Class_ArrayElement arrayElement1)
                            {
                                XElement xElementIndex = new XElement("InElementIndex" + i.ToString(), arrayElement1.Index);
                                
                                if (arrayElement1.Element is Full_Elements fullElement)
                                {
                                    XElement xElementInElementName = new XElement("InElementName" + i.ToString(), arrayElement1.Element.Name);
                                    xElementClass.Add(xElementInElementName);
                                }

                                xElementClass.Add(xElementIndex);
                            }

                            if (xor_element.OutElements[i] is Class_ArrayElement arrayElement2)
                            {
                                XElement xElementIndex = new XElement("OutElementIndex" + i.ToString(), arrayElement2.Index);

                                if (arrayElement2.Element is Full_Elements fullElement)
                                {
                                    XElement xElementOutElementName = new XElement("OutElementName" + i.ToString(), arrayElement2.Element.Name);
                                    xElementClass.Add(xElementOutElementName);
                                }

                                xElementClass.Add(xElementIndex);
                            }

                            xElementClass.Add(xElementInput);
                            xElementClass.Add(xElementOutput);
                        }

                        xElementClass.Add(xElementStart);
                        xElementClass.Add(xElementName);
                        xElementClass.Add(xElementPower);
                        xElementClass.Add(xElementOUTPUT);
                        xCircuit.Add(xElementClass);
                    }
                    else if (element is Class_Line line_element)
                    {
                        XElement xElementLine = new XElement("line_element");
                        XElement xElementStart = new XElement("start", line_element.StartPoint);
                        XElement xElementEnd = new XElement("end", line_element.EndPoint);
                        XElement xElement1 = new XElement("firstElement", line_element.FirstElement.Name);
                        XElement xElement2 = new XElement("secondElement", line_element.SecondElement.Name);
                        XElement xElement1_Name = new XElement("name1", line_element.FirstElement.Name);
                        XElement xElement2_Name = new XElement("name2", line_element.SecondElement.Name);

                        for (int i = 0; i < 8; i++)
                        {
                            XElement xElementInput = new XElement("input" + i.ToString(), line_element.Inputs[i]);
                            XElement xElementOutput = new XElement("output" + i.ToString(), line_element.Outputs[i]);
                            
                            if (line_element.InElements[i] is Class_ArrayElement arrayElement1)
                            {
                                XElement xElementIndex = new XElement("InElementIndex" + i.ToString(), arrayElement1.Index);
                                
                                if (arrayElement1.Element is Full_Elements fullElement)
                                {
                                    XElement xElementInElementName = new XElement("InElementName" + i.ToString(), arrayElement1.Element.Name);
                                    xElementLine.Add(xElementInElementName);
                                }

                                xElementLine.Add(xElementIndex);
                            }

                            if (line_element.OutElements[i] is Class_ArrayElement arrayElement2)
                            {
                                XElement xElementIndex = new XElement("OutElementIndex" + i.ToString(), arrayElement2.Index);

                                if (arrayElement2.Element is Full_Elements fullElement)
                                {
                                    XElement xElementOutElementName = new XElement("OutElementName" + i.ToString(), arrayElement2.Element.Name);
                                    xElementLine.Add(xElementOutElementName);
                                }

                                xElementLine.Add(xElementIndex);
                            }

                            xElementLine.Add(xElementInput);
                            xElementLine.Add(xElementOutput);
                        }

                        xElementLine.Add(xElementStart);
                        xElementLine.Add(xElementEnd);
                        xElementLine.Add(xElement1);
                        xElementLine.Add(xElement2);
                        xElementLine.Add(xElement1_Name);
                        xElementLine.Add(xElement2_Name);
                        xCircuit.Add(xElementLine);
                    }
                }

                xProject.Add(xCircuit);
            }

            xDocument.Add(xProject);
            xDocument.Save(path);
        }
    }
}
