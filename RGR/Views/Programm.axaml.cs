using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.VisualTree;
using System.Linq;
using RGR.Models;
using RGR.ViewModels;
using System;
using System.Collections.ObjectModel;
using RGR.Views.Elements;

namespace RGR.Views
{
	public partial class Programm : Window
	{
		public Point pointPointerPressed;
		public Point pointerPositionIntoElement;
		public Point startPoint;
		public Point endPoint;
		
		public Programm()
		{
			InitializeComponent();
			DataContext = new ProgrammViewModel();
		}

        public object InElements { get; private set; }

        public ProgrammViewModel GetProgrammViewModel()
        {
        	return (ProgrammViewModel)DataContext;
        }

        public void ButtonClick(object sender, RoutedEventArgs eventArgs)
		{
			if (DataContext is ProgrammViewModel viewModel)
			{
				if (sender is Button button)
				{
					viewModel.Take_Button_Name(button.Name);
				}
			}
		}

        public void CreateCurcuit(object sender, RoutedEventArgs eventArgs)
		{
			if (DataContext is ProgrammViewModel viewModel)
			{
				viewModel.Project.Circuits.Add(new Class_Circuit());
			}
		}

        public void DeleteCurcuit(object sender, RoutedEventArgs eventArgs)
		{
			if (DataContext is ProgrammViewModel viewModel)
			{
				if (viewModel.Project.Circuits.Count > 0)
				{
					viewModel.Project.Circuits.RemoveAt(viewModel.SelectedCircuit);
				}
			}
		}

		public void PointerPressedOnCanvas(object? sender, PointerPressedEventArgs pointerPressedEventArgs)
		{
			pointPointerPressed = pointerPressedEventArgs.GetPosition(this.GetVisualDescendants().OfType<Canvas>().FirstOrDefault());

			if (DataContext is ProgrammViewModel viewModel)
			{
				if (viewModel.Project.Circuits.Count == 0)
				{
					return;
				}

				if (viewModel.Button_Number == 1)
				{
					viewModel.Project.Circuits[viewModel.SelectedCircuit].Elements.Add(new Class_And { Main_Point = pointPointerPressed });
				}
				else if (viewModel.Button_Number == 2)
				{
					viewModel.Project.Circuits[viewModel.SelectedCircuit].Elements.Add(new Class_Or { Main_Point = pointPointerPressed });
				}
				else if (viewModel.Button_Number == 3)
				{
					viewModel.Project.Circuits[viewModel.SelectedCircuit].Elements.Add(new Class_Not { Main_Point = pointPointerPressed });
				}
				else if (viewModel.Button_Number == 4)
				{
					viewModel.Project.Circuits[viewModel.SelectedCircuit].Elements.Add(new Class_XoR { Main_Point = pointPointerPressed });
				}
				else if (viewModel.Button_Number == 5)
				{
					viewModel.Project.Circuits[viewModel.SelectedCircuit].Elements.Add(new Class_In { Main_Point = pointPointerPressed });
				}
				else if (viewModel.Button_Number == 6)
				{
					viewModel.Project.Circuits[viewModel.SelectedCircuit].Elements.Add(new Class_Out { Main_Point = pointPointerPressed });
				}
				else if (viewModel.Button_Number == 7)
				{
                    // viewModel.Project.Circuits[viewModel.SelectedCircuit].Elements.Add(new Class_HalfSum { Main_Point = pointPointerPressed });
                    viewModel.Project.Circuits[viewModel.SelectedCircuit].Elements.Add(new Class_Sum { Main_Point = pointPointerPressed });
                    // viewModel.Project.Circuits[viewModel.SelectedCircuit].Elements.Add(new Class_DC { Main_Point = pointPointerPressed });
                    // viewModel.Project.Circuits[viewModel.SelectedCircuit].Elements.Add(new Class_CD { Main_Point = pointPointerPressed });
                }
                else if (viewModel.Button_Number == 0)
				{

					if (pointerPressedEventArgs.Source is Path shape)
					{
						if (shape.DataContext is Full_Elements element)
						{
							viewModel.Selected_Element = element;
						}
						pointerPositionIntoElement = pointerPressedEventArgs.GetPosition(shape);
						this.PointerMoved += PointerMoveDragElement;
						this.PointerReleased += PointerPressedReleasedDragElement;
					}
					else if (pointerPressedEventArgs.Source is Polygon shape1)
					{
						if (shape1.DataContext is Full_Elements element)
						{
							viewModel.Selected_Element = element;
						}
						pointerPositionIntoElement = pointerPressedEventArgs.GetPosition(shape1);
						this.PointerMoved += PointerMoveDragElement;
						this.PointerReleased += PointerPressedReleasedDragElement;
					}
					else if (pointerPressedEventArgs.Source is Rectangle shape2)
					{
						if (shape2.DataContext is Full_Elements element)
						{
							viewModel.Selected_Element = element;
						}
						pointerPositionIntoElement = pointerPressedEventArgs.GetPosition(shape2);
						this.PointerMoved += PointerMoveDragElement;
						this.PointerReleased += PointerPressedReleasedDragElement;
					}
					else if (pointerPressedEventArgs.Source is Line line)
					{
						if (line.DataContext is Full_Elements element)
						{
							viewModel.Selected_Element = element;
						}
					}
					else if (pointerPressedEventArgs.Source is Ellipse ellipse)
					{
                        int index = (int)Char.GetNumericValue(ellipse.Name[ellipse.Name.Length - 1]);
						startPoint = pointerPressedEventArgs.GetPosition(this.GetVisualDescendants().OfType<Canvas>().FirstOrDefault());

						if (ellipse.Name.Contains("out"))
						{
							Class_Line l = new Class_Line {
								StartPoint = startPoint,
								EndPoint = startPoint,
								FirstElement = ellipse.DataContext as Full_Elements,
								SecondElement = null,
							};

							l.InElements[index] = new Class_ArrayElement { Element = ellipse.DataContext as Full_Elements };

							viewModel.Project.Circuits[viewModel.SelectedCircuit].Elements.Add(l);
                        }
						else
						{
							Class_Line l = new Class_Line {
								StartPoint = startPoint,
								EndPoint = startPoint,
								FirstElement = ellipse.DataContext as Full_Elements,
								SecondElement = null,
							};
							
							l.OutElements[index] = new Class_ArrayElement { Element = ellipse.DataContext as Full_Elements };

							viewModel.Project.Circuits[viewModel.SelectedCircuit].Elements.Add(l);
						}

						this.PointerMoved += PointerMoveDrawLine;
						this.PointerReleased += PointerPressedReleasedDrawLine;
					}
				}
			}
		}

		private void DoubleTapOnCanvas(object sender, RoutedEventArgs e)
		{
			if (DataContext is ProgrammViewModel viewModel)
			{
				var src = e.Source;
				if (src == null) return;

				if (src is Rectangle rect)
				{
					if (rect.DataContext is Class_In element)
					{
						element.Outputs[0] ^= 1;
						element.OUTPUT ^= 1;

						viewModel.PowerCalculate(element);
					}
				}
			}
		}

		public void DoubleTapOnCanvas2(object? sender, RoutedEventArgs e)
		{
			if (DataContext is ProgrammViewModel viewModel)
			{
				if (e.Source is TextBlock textBlock)
				{
					System.Diagnostics.Debug.WriteLine(1);
					if (textBlock.DataContext is Class_Circuit circuit)
					{
						Class_Circuit? circuitPtr = circuit;
                        Element_ChangeName? changeNameWindow = new Element_ChangeName(circuitPtr);
                        changeNameWindow.ShowDialog(this);
					}
					else if (textBlock.DataContext is Class_Project project)
					{
						System.Diagnostics.Debug.WriteLine(2);
						Class_Project? projectPtr = project;
                        Element_ChangeName? changeNameWindow = new Element_ChangeName(projectPtr);
                        changeNameWindow.ShowDialog(this);
					}
				}
			}
		}

		public void PointerMoveDragElement(object? sender, PointerEventArgs pointerEventArgs)
		{
			if (pointerEventArgs.Source is Shape shape)
			{
				Point currentPointPosition = pointerEventArgs.GetPosition(this.GetVisualDescendants().OfType<Canvas>().FirstOrDefault());

				if (shape.DataContext is Full_Elements element)
				{
					element.Main_Point = new Point(
						currentPointPosition.X - pointerPositionIntoElement.X,
						currentPointPosition.Y - pointerPositionIntoElement.Y
					);
				}
			}
		}

		public void PointerPressedReleasedDragElement(object? sender, PointerReleasedEventArgs poiterEventArgs)
		{
			this.PointerMoved -= PointerMoveDragElement;
			this.PointerReleased -= PointerPressedReleasedDragElement;
		}

		public void Exit_programm(object sender, RoutedEventArgs eventArgs)
		{
			this.Close();
		}

		private void PointerMoveDrawLine(object? sender, PointerEventArgs pointerEventArgs)
		{
			if (DataContext is ProgrammViewModel viewModel)
			{
				Class_Line connector = viewModel.Project.Circuits[viewModel.SelectedCircuit].Elements[viewModel.Project.Circuits[viewModel.SelectedCircuit].Elements.Count - 1] as Class_Line;
				Point currentPointerPosition = pointerEventArgs.GetPosition(this.GetVisualDescendants().OfType<Canvas>().FirstOrDefault());

				connector.EndPoint = new Point(
						currentPointerPosition.X - 1,
						currentPointerPosition.Y - 1);
			}
		}

		private void PointerPressedReleasedDrawLine(object? sender, PointerReleasedEventArgs pointerReleasedEventArgs)
		{
			this.PointerMoved -= PointerMoveDrawLine;
			this.PointerReleased -= PointerPressedReleasedDrawLine;

			var canvas = this.GetVisualDescendants().OfType<Canvas>().FirstOrDefault(canvas => string.IsNullOrEmpty(canvas.Name) == false && canvas.Name.Equals("Holst"));
			var coords = pointerReleasedEventArgs.GetPosition(canvas);
			var shape = canvas.InputHitTest(coords);
			
			if (DataContext is ProgrammViewModel viewModel)
			{
				if (shape is Ellipse ellipse)
				{
					if (ellipse.DataContext is Full_Elements element)
					{
						if (viewModel.Project.Circuits[viewModel.SelectedCircuit].Elements[viewModel.Project.Circuits[viewModel.SelectedCircuit].Elements.Count - 1] is Class_Line line)
						{
							if (line.FirstElement != element)
							{
								int index2 = (int)Char.GetNumericValue(ellipse.Name[ellipse.Name.Length - 1]);
								int hasElement = 0;

								line.SecondElement = element;

								for (int i = 0; i < 8; i++)
								{
									if (line.InElements[i] != null)
									{
										hasElement = 1;
										break;
									}
								}

								if (hasElement != 0)
								{
									for (int index1 = 0; index1 < 8; index1++)
									{
										if (line.InElements[index1] != null)
										{
											line.InElements[index1].Index = index2;										
											line.OutElements[index2] = new Class_ArrayElement { Element = element, Index = index1 };

											line.InElements[index1].Element.OutElements[index1] = new Class_ArrayElement { Element = element, Index = index2 };
											line.OutElements[index2].Element.InElements[index2] = new Class_ArrayElement { Element = line.InElements[index1].Element, Index = index1 };

											viewModel.PowerCalculate(line.InElements[index1].Element);

											break;
										}
									}
								}
								else
								{
									for (int index1 = 0; index1 < 8; index1++)
									{
										if (line.OutElements[index1] != null)
										{
											line.OutElements[index1].Index = index2;										
											line.InElements[index2] = new Class_ArrayElement { Element = element, Index = index1 };

											line.OutElements[index1].Element.InElements[index1] = new Class_ArrayElement { Element = element, Index = index2 };
											line.InElements[index2].Element.OutElements[index2] = new Class_ArrayElement { Element = line.OutElements[index1].Element, Index = index1 };
											
											viewModel.PowerCalculate(line.InElements[index2].Element);

											break;
										}
									}
								}

								return;
							}
						}
					}
				}

				viewModel.Project.Circuits[viewModel.SelectedCircuit].Elements.RemoveAt(viewModel.Project.Circuits[viewModel.SelectedCircuit].Elements.Count - 1);
			}
		}
	}
}
