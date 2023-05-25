using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RGR.Models;

namespace RGR.ViewModels
{
    public class ProgrammViewModel : ViewModelBase
    {
        private int button_number;
        private ObservableCollection<Full_Elements> all_elements;
        private Full_Elements selected_element;

        public int Button_Number
        {
            get => button_number;
            set => this.RaiseAndSetIfChanged(ref button_number, value);
        }
        public ProgrammViewModel()
        {
            all_elements = new ObservableCollection<Full_Elements>();
        }

        public ObservableCollection<Full_Elements> All_Elements
        {
            get => all_elements;
            set => this.RaiseAndSetIfChanged(ref all_elements, value);
        }

        public Full_Elements Selected_Element
        {
            get => selected_element;
            set => this.RaiseAndSetIfChanged(ref selected_element, value);
        }


        public void Take_Button_Name(string name)
        {
            if (name == "button1")
            {
                if (Button_Number == 1)
                {
                    Button_Number = 0;
                }
                else if (Button_Number != 1)
                {
                    Button_Number = 1;
                }
            }
            else if (name == "button2")
            {
                if (Button_Number == 2)
                {
                    Button_Number = 0;
                }
                else if (Button_Number != 2)
                {
                    Button_Number = 2;
                }
            }
            else if (name == "button3")
            {
                if (Button_Number == 3)
                {
                    Button_Number = 0;
                }
                else if (Button_Number != 3)
                {
                    Button_Number = 3;
                }
            }
            else if (name == "button4")
            {
                if (Button_Number == 4)
                {
                    Button_Number = 0;
                }
                else if (Button_Number != 4)
                {
                    Button_Number = 4;
                }
            }
            else if (name == "button5")
            {
                if (Button_Number == 5)
                {
                    Button_Number = 0;
                }
                else if (Button_Number != 5)
                {
                    Button_Number = 5;
                }
            }
            else if (name == "button6")
            {
                if (Button_Number == 6)
                {
                    Button_Number = 0;
                }
                else if (Button_Number != 6)
                {
                    Button_Number = 6;
                }
            }
            else if (name == "button7")
            {
                if (Button_Number == 7)
                {
                    Button_Number = 0;
                }
                else if (Button_Number != 7)
                {
                    Button_Number = 7;
                }
            }
        }

        public void DeleteElement()
        {
            ObservableCollection<Full_Elements> tempCollection = All_Elements;

            for (int i = tempCollection.Count - 1; i >= 0; i--)
            {   
                if (tempCollection[i] is Full_Elements tempElement)
                {
                    if (tempElement is Class_Line tempLine)
                    {
                        if (tempLine == Selected_Element)
                        {
                            int index1 = 0, index2 = 0;

                            for (int j = 0; j < 8; j++)
                            {
                                if (tempLine.InElements[j] != null)
                                {
                                    // System.Diagnostics.Debug.WriteLine("InElements");
                                    // System.Diagnostics.Debug.WriteLine(j);
                                    // System.Diagnostics.Debug.WriteLine(tempLine.InElements[j].Index);
                                    tempLine.InElements[j].Element.OutElements[j] = null;
                                    index1 = j;
                                }
                                
                                if (tempLine.OutElements[j] != null)
                                {
                                    // System.Diagnostics.Debug.WriteLine("OutElements");
                                    // System.Diagnostics.Debug.WriteLine(j);
                                    // System.Diagnostics.Debug.WriteLine(tempLine.OutElements[j].Index);
                                    tempLine.OutElements[j].Element.InElements[j] = null;
                                    index2 = j;
                                }
                            }

                            // System.Diagnostics.Debug.WriteLine("index1 " + index1.ToString());
                            // System.Diagnostics.Debug.WriteLine("index2 " + index2.ToString());
                            PowerCalculate(tempLine.OutElements[index2].Element);
                            tempLine.InElements[index1] = null;
                            tempLine.OutElements[index2] = null;
                            All_Elements.RemoveAt(i);
                            break;
                        }
                        else
                        {
                            if (tempLine.FirstElement == Selected_Element || tempLine.SecondElement == Selected_Element)
                            {
                                for (int j = 0; j < 8; j++)
                                {
                                    if (tempLine.InElements[j] != null)
                                    {
                                        tempLine.InElements[j] = null;
                                    }
                                    
                                    if (tempLine.OutElements[j] != null)
                                    {
                                        tempLine.OutElements[j] = null;
                                    }
                                }

                                All_Elements.RemoveAt(i);
                            }
                        }
                    }
                    else
                    {
                        if (tempElement == Selected_Element)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (tempElement.InElements[j] != null)
                                {
                                    tempElement.InElements[j].Element.OutElements[tempElement.InElements[j].Index] = null;
                                    tempElement.InElements[j] = null;
                                }
                                
                                if (tempElement.OutElements[j] != null)
                                {
                                    tempElement.OutElements[j].Element.InElements[tempElement.OutElements[j].Index] = null;
                                    PowerCalculate(tempElement.OutElements[j].Element);
                                    tempElement.OutElements[j] = null;
                                }
                            }

                            All_Elements.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
        }

        public void PowerCalculate(Full_Elements element)
        {
            System.Diagnostics.Debug.WriteLine("PowerCalculate START");
            
            element.Calculate();
            
            for (int i = 0; i < 8; i++)
            {
                if (element.OutElements[i] != null)
                {
                    PowerCalculate(element.OutElements[i].Element);
                }
            }
            
            System.Diagnostics.Debug.WriteLine("PowerCalculate END");
        }
    }
}
