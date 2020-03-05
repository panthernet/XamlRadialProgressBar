using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace XamlRadialProgressBar
{
    public class RadialProgressBar: ProgressBar
    {
        #region InnerBackgroundBrush
        /// <summary>
        /// Gets or sets progress bar fill direction
        /// </summary>
        public Brush InnerBackgroundBrush
        {
            get => (Brush)GetValue(InnerBackgroundBrushProperty);
            set => SetValue(InnerBackgroundBrushProperty, value);
        }

        public static readonly DependencyProperty InnerBackgroundBrushProperty =
            DependencyProperty.Register("InnerBackgroundBrush", typeof(Brush), typeof(RadialProgressBar),
                new UIPropertyMetadata(Brushes.Transparent));
        #endregion

        #region OuterBackgroundBrush
        /// <summary>
        /// Gets or sets progress bar fill direction
        /// </summary>
        public Brush OuterBackgroundBrush
        {
            get => (Brush)GetValue(OuterBackgroundBrushProperty);
            set => SetValue(OuterBackgroundBrushProperty, value);
        }

        public static readonly DependencyProperty OuterBackgroundBrushProperty =
            DependencyProperty.Register("OuterBackgroundBrush", typeof(Brush), typeof(RadialProgressBar),
                new UIPropertyMetadata(Brushes.Transparent));
        #endregion

        #region ArcWidth
        /// <summary>
        /// Gets or sets progress bar fill direction
        /// </summary>
        public double ArcWidth
        {
            get => (double)GetValue(ArcWidthProperty);
            set => SetValue(ArcWidthProperty, value);
        }

        public static readonly DependencyProperty ArcWidthProperty =
            DependencyProperty.Register("ArcWidth", typeof(double), typeof(RadialProgressBar),
                new UIPropertyMetadata(10d));
        #endregion

        #region ArcRotationDegrees
        /// <summary>
        /// Gets or sets arc rotation in degrees. 270 - clockwise top, 90 - counterclockwise top
        /// </summary>
        public double ArcRotationDegree
        {
            get => (double)GetValue(ArcRotationDegreeProperty);
            set => SetValue(ArcRotationDegreeProperty, value);
        }

        public static readonly DependencyProperty ArcRotationDegreeProperty =
            DependencyProperty.Register("ArcRotationDegree", typeof(double), typeof(RadialProgressBar),
                new UIPropertyMetadata(270d));
        #endregion

        #region ArcMode
        public static readonly DependencyProperty ArcModeProperty =
            DependencyProperty.Register("ArcMode", typeof(ArcMode), typeof(RadialProgressBar),
                new UIPropertyMetadata(ArcMode.Fill));

        /// <summary>
        /// Gets or sets the mode of the progress bar
        /// </summary>
        public ArcMode ArcMode
        {
            get => (ArcMode)GetValue(ArcModeProperty);
            set => SetValue(ArcModeProperty, value);
        }
        #endregion

        #region ArcDirection
        /// <summary>
        /// Gets or sets progress bar fill direction
        /// </summary>
        public SweepDirection ArcDirection
        {
            get => (SweepDirection)GetValue(ArcDirectionProperty);
            set => SetValue(ArcDirectionProperty, value);
        }

        public static readonly DependencyProperty ArcDirectionProperty =
            DependencyProperty.Register("ArcDirection", typeof(SweepDirection), typeof(RadialProgressBar),
                new UIPropertyMetadata(SweepDirection.Clockwise));
        #endregion

        #region ShapeModeWidth
        /// <summary>
        /// Gets or sets shape width for Shape mode. Default value is 1d.
        /// </summary>
        public double ShapeModeWidth
        {
            get => (double)GetValue(ShapeModeWidthProperty);
            set => SetValue(ShapeModeWidthProperty, value);
        }

        public static readonly DependencyProperty ShapeModeWidthProperty =
            DependencyProperty.Register("ShapeModeWidth", typeof(double), typeof(RadialProgressBar),
                new UIPropertyMetadata(1d));
        #endregion

        #region ShapeModeStep
        /// <summary>
        /// Gets or sets step in degrees for Shape mode. Degree range is 0 - 360. Default step is 3.
        /// </summary>
        public int ShapeModeStep
        {
            get => (int)GetValue(ShapeModeStepProperty);
            set => SetValue(ShapeModeStepProperty, value);
        }

        public static readonly DependencyProperty ShapeModeStepProperty =
            DependencyProperty.Register("ShapeModeStep", typeof(int), typeof(RadialProgressBar),
                new UIPropertyMetadata(3));
        #endregion

        #region ShapeModeShape
        /// <summary>
        /// Gets or sets default shape for Shape mode. Default value is Rectangle.
        /// </summary>
        public ArcShape ShapeModeShape
        {
            get => (ArcShape)GetValue(ShapeModeShapeProperty);
            set => SetValue(ShapeModeShapeProperty, value);
        }

        public static readonly DependencyProperty ShapeModeShapeProperty =
            DependencyProperty.Register("ShapeModeShape", typeof(ArcShape), typeof(RadialProgressBar),
                new UIPropertyMetadata(ArcShape.Rectangle));
        #endregion

        #region ShapeModeUseFade
        /// <summary>
        /// Gets or sets shape fading effect for Shape mode. Default value is True.
        /// </summary>
        public bool ShapeModeUseFade
        {
            get => (bool)GetValue(ShapeModeUseFadeProperty);
            set => SetValue(ShapeModeUseFadeProperty, value);
        }

        public static readonly DependencyProperty ShapeModeUseFadeProperty =
            DependencyProperty.Register("ShapeModeUseFade", typeof(bool), typeof(RadialProgressBar),
                new UIPropertyMetadata(true));
        #endregion

        #region ShapeRotationAdjustment
        /// <summary>
        /// Gets or sets additional shape rotation adjustment in degrees for Shape mode. Default value is 0d.
        /// </summary>
        public double ShapeRotationAdjustment
        {
            get => (double)GetValue(ShapeRotationAdjustmentProperty);
            set => SetValue(ShapeRotationAdjustmentProperty, value);
        }

        public static readonly DependencyProperty ShapeRotationAdjustmentProperty =
            DependencyProperty.Register("ShapeRotationAdjustment", typeof(double), typeof(RadialProgressBar),
                new UIPropertyMetadata(0d));
        #endregion

        private Arc _arc;

        public RadialProgressBar()
        {
            DefaultStyleKey = typeof(RadialProgressBar);
            // UseLayoutRounding = true;
            //SnapsToDevicePixels = true;
            SizeChanged += RadialProgressBar_SizeChanged;
        }

        private void RadialProgressBar_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if(_arc == null) return;
            if(_arc.ArcMode == ArcMode.Shape)
                _arc.RecalculateShapes();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _arc = (Arc)Template.FindName("PART_Arc", this);
        }
    }
}
