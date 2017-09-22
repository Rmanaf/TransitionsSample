using Divankits.Transitions;
using System;
using System.Timers;
using System.Windows;
using System.Windows.Media;

namespace TransitionsSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        private static Timer _timer = null;
        private TranslateTransform EllipseTransform = new TranslateTransform();

        public MainWindow()
        {
            InitializeComponent();

            TransitionFactory.FPS = 120;

            if (_timer == null)
            {

                _timer = new Timer(1);

                _timer.Elapsed += _timer_Elapsed;

                _timer.AutoReset = true;

                _timer.Enabled = true;

            }

            Activated += MainWindow_Activated;

            EllipseTarget.RenderTransform = EllipseTransform;

            EllipseTransform.X = -100;

        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {

            Action UpdateTransitionFactory = () =>
            {

                TransitionFactory.Update();

            };

            if (Dispatcher.CheckAccess())

            {
                UpdateTransitionFactory();

            }
            else
            {

                Dispatcher.Invoke(UpdateTransitionFactory);

            }

        }


        private void MainWindow_Activated(object sender, EventArgs e)
        {

            var tween = TransitionFactory.Transform(EllipseTransform, "X", Divankits.Transitions.Easing.Elastic.EaseInOut, EllipseTransform.X, 100, 2.5);

            tween.OnFinished += (s, evt) =>
            {

                tween.Yoyo();


            };

        }

    }
}
