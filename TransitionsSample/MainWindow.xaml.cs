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




            /* Sample 1 :
                Transform one property
            */

            //(TransitionFactory.Transform(EllipseTransform, "X", Divankits.Transitions.Easing.Elastic.EaseInOut, EllipseTransform.X, 100, 2.5) as Tween)
            //    .OnFinished += (s, evt) => { (s as Tween).Yoyo(); };





            /* Sample 2 :
                Transform multiple properties using one transformation method
            */

            //var motion = (TransitionFactory.Transform(EllipseTransform,
            //    new string[] { "X", "Y" },
            //    Divankits.Transitions.Easing.Elastic.EaseInOut,
            //    new double[] { EllipseTransform.X, EllipseTransform.Y },
            //    new double[] { 100, 80 },
            //    new double[] { 2.5, 4 }) as Motion);

            //motion.GetLongestTransform().OnFinished += (s, evt) => motion.Yoyo();






            /* Sample 3 :
                Transform multiple properties
            */

            var motion = (TransitionFactory.Transform(EllipseTransform,
                new string[] { "X", "Y" },
                new TransitionParameters.Method<double, double, double, double, double>[] {
                    Divankits.Transitions.Easing.Elastic.EaseInOut,
                    Divankits.Transitions.Easing.Bounce.EaseOut,
                },
                new double[] { EllipseTransform.X, EllipseTransform.Y },
                new double[] { 100, 80 },
                new double[] { 2.5, 4 }) as Motion);

            motion.GetLongestTransform().OnFinished += (s, evt) => motion.Yoyo();




        }

        // frame update method
        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {

            TransitionFactory.Update();

        }


    }
}
