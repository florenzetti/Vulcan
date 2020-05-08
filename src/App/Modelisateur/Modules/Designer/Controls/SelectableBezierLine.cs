using Gemini.Framework;
using Gemini.Modules.GraphEditor.Controls;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Modelisateur.Modules.Designer.Controls
{
    //TODO: Pull request to Gemini project to add selected connections to the graph control
    public class SelectableBezierLine : BezierLine
    {
        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register(
        "IsSelected", typeof(bool), typeof(BezierLine),
        new FrameworkPropertyMetadata());
        //
        // Summary:
        //     Gets or sets a value that indicates whether a System.Windows.Controls.ListBoxItem
        //     is selected.
        //
        // Returns:
        //     true if the item is selected; otherwise, false. The default is false.
        [Bindable(true)]
        [Category("Appearance")]
        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        //
        // Summary:
        //     Occurs when a BelzierLine is selected.
        public event RoutedEventHandler Selected;
        //
        // Summary:
        //     Occurs when a BelzierLine is unselected.
        public event RoutedEventHandler Unselected;

        private MouseButtonEventHandler _mouseClickOutsideHandler;
        private GraphControl _parentGraphControl;

        public SelectableBezierLine() : base()
        {
            Unloaded += HandleUnloaded;
        }

        private void HandleUnloaded(object sender, RoutedEventArgs e)
        {
            RemoveClickOutsideHandler();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            IsSelected = true;
            AddClickOutsideHandler();
            //CaptureMouse();

            Selected?.Invoke(this, new RoutedEventArgs());
            //e.Handled = true;
            base.OnMouseLeftButtonDown(e);
        }

        private void HandleClickOutsideOfControl(object sender, MouseButtonEventArgs e)
        {
            IsSelected = false;
            RemoveClickOutsideHandler();
            Unselected?.Invoke(this, new RoutedEventArgs());
            //ReleaseMouseCapture();
        }

        private void AddClickOutsideHandler()
        {
            if (_mouseClickOutsideHandler == null)
            {
                _mouseClickOutsideHandler = new MouseButtonEventHandler(HandleClickOutsideOfControl);
                _parentGraphControl = VisualTreeUtility.FindParent<GraphControl>(this);
                //_window = Window.GetWindow(this);
                _parentGraphControl.AddHandler(MouseDownEvent, _mouseClickOutsideHandler, true);
            }
        }
        private void RemoveClickOutsideHandler()
        {
            if (_mouseClickOutsideHandler != null)
            {
                _parentGraphControl.RemoveHandler(MouseDownEvent, _mouseClickOutsideHandler);
                //_window.RemoveHandler(MouseDownEvent, _mouseClickOutsideHandler);
                _mouseClickOutsideHandler = null;
            }
        }
    }
}