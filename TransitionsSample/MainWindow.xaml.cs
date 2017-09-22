using Divankits.Transitions;
using System;
using System.Windows;
using System.Windows.Media;

namespace TransitionsSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        private TranslateTransform EllipseTransform = new TranslateTransform();

        public MainWindow()
        {
            InitializeComponent();

            CompositionTarget.Rendering += CompositionTarget_Rendering;

            TranslateTransform EllipseTransform = new TranslateTransform();
            EllipseTarget.RenderTransform = EllipseTransform;
            EllipseTransform.X = -100;

            TransitionFactory.Transform(EllipseTransform, "X", Divankits.Transitions.Easing.Elastic.EaseInOut, EllipseTransform.X, 100, 2.5)
                .OnFinished += (s, evt) => { (s as Tween).Yoyo(); };


        }

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {

            TransitionFactory.Update();

        }


    }
}
