﻿using ReactiveUI;
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
        private Full_Elements selectedElement;
        private ObservableCollection<Full_Elements> all_elements;

        public ProgrammViewModel()
        {
            all_elements = new ObservableCollection<Full_Elements>();
        }
        
        public int Button_Number
        {
            get => button_number;
            set => this.RaiseAndSetIfChanged(ref button_number, value);
        }

        public ObservableCollection<Full_Elements> All_Elements
        {
            get => all_elements;
            set => this.RaiseAndSetIfChanged(ref all_elements, value);
        }

        public Full_Elements SelectedElement
        {
            get => selectedElement;
            set => this.RaiseAndSetIfChanged(ref selectedElement, value);
        }

        public void Take_Button_Name(string name)
        {
            if(name == "button1")
            {
                if(Button_Number == 1)
                {
                    Button_Number = 0;
                }
                else if(Button_Number != 1)
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
            System.Diagnostics.Debug.WriteLine(123123);
            ObservableCollection<Full_Elements> tempCollection = this.All_Elements;

            for (int i = tempCollection.Count - 1; i >= 0; i--)
            {
                if (tempCollection[i] == this.SelectedElement)
                {
                    this.All_Elements.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
