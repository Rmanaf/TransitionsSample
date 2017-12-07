using Divankits.Transitions;
using System;
using System.Windows;
using System.Windows.Media;

namespace TransitionsSample
{

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();


            // CompositionTarget as timer to render frames
            CompositionTarget.Rendering += CompositionTarget_Rendering;


            // define and assign transform object
            TranslateTransform EllipseTransform = new TranslateTransform();
            EllipseTarget.RenderTransform = EllipseTransform;
            EllipseTransform.X = -100;

            // tween
            TransitionFactory.Transform(EllipseTransform, "X", Divankits.Transitions.Easing.Elastic.EaseInOut, EllipseTransform.X, 100, 2.5)
                .OnFinished += (s, evt) => { (s as Tween).Yoyo(); };


        }

        // frame update method
        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {

            TransitionFactory.Update();

        }


    }
}
