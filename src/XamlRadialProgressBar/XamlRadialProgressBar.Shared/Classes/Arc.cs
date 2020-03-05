using System;
using System.Collections.Generic;
#if WINDOWS_UWP
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml;
#else
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
#endif

namespace XamlRadialProgressBar
{
    public class Arc : Shape
    {

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
            DependencyProperty.Register("ShapeRotationAdjustment", typeof(double), typeof(Arc),
                new UIPropertyMetadata(0d, UpdateArc));
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
            DependencyProperty.Register("ShapeModeUseFade", typeof(bool), typeof(Arc),
                new UIPropertyMetadata(true, UpdateArc));
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
            DependencyProperty.Register("ShapeModeShape", typeof(ArcShape), typeof(Arc),
                new UIPropertyMetadata(ArcShape.Rectangle, UpdateArc));
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
            DependencyProperty.Register("ShapeModeWidth", typeof(double), typeof(Arc),
                new UIPropertyMetadata(1d, UpdateArc));
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
            DependencyProperty.Register("ShapeModeStep", typeof(int), typeof(Arc),
                new UIPropertyMetadata(3, UpdateArc));
        #endregion

        #region ArcMode
        public static readonly DependencyProperty ArcModeProperty =
            DependencyProperty.Register("ArcMode", typeof(ArcMode), typeof(Arc),
                new UIPropertyMetadata(ArcMode.Fill, UpdateArc));

        /// <summary>
        /// Gets or sets the mode of the progress bar
        /// </summary>
        public ArcMode ArcMode
        {
            get => (ArcMode)GetValue(ArcModeProperty);
            set => SetValue(ArcModeProperty, value);
        }
        #endregion

        #region ProgressBorderThickness
        public static readonly DependencyProperty ProgressBorderThicknessProperty =
            DependencyProperty.Register("ProgressBorderThickness", typeof(Thickness), typeof(Arc),
                new UIPropertyMetadata(new Thickness(0), UpdatePen));

        /// <summary>
        /// Gets or sets the thickness of the fill border
        /// </summary>
        public Thickness ProgressBorderThickness
        {
            get => (Thickness)GetValue(ProgressBorderThicknessProperty);
            set => SetValue(ProgressBorderThicknessProperty, value);
        }
        #endregion

        #region ProgressFillBrush
        public static readonly DependencyProperty ProgressFillBrushProperty =
            DependencyProperty.Register("ProgressFillBrush", typeof(Brush), typeof(Arc),
                new UIPropertyMetadata(Brushes.White, UpdateFillBrush));

        /// <summary>
        /// Gets or sets the brush for the fill part
        /// </summary>
        public Brush ProgressFillBrush
        {
            get => (Brush)GetValue(ProgressFillBrushProperty);
            set => SetValue(ProgressFillBrushProperty, value);
        }
        #endregion

        #region ProgressBackgroundBrush
        public static readonly DependencyProperty ProgressBackgroundBrushProperty =
            DependencyProperty.Register("ProgressBackgroundBrush", typeof(Brush), typeof(Arc),
                new UIPropertyMetadata(Brushes.Transparent, UpdateArc));

        /// <summary>
        /// Gets or sets the brush for the fill part
        /// </summary>
        public Brush ProgressBackgroundBrush
        {
            get => (Brush)GetValue(ProgressBackgroundBrushProperty);
            set => SetValue(ProgressBackgroundBrushProperty, value);
        }
        #endregion

        #region ProgressBorderBrush
        public static readonly DependencyProperty ProgressBorderBrushProperty =
            DependencyProperty.Register("ProgressBorderBrush", typeof(Brush), typeof(Arc),
                new UIPropertyMetadata(Brushes.Transparent, UpdatePen));

        private static void UpdatePen(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((Arc)d).UpdatePen();
            UpdateArc(d, e);
        }

        /// <summary>
        /// Gets or set the fill border brush
        /// </summary>
        public Brush ProgressBorderBrush
        {
            get => (Brush)GetValue(ProgressBorderBrushProperty);
            set => SetValue(ProgressBorderBrushProperty, value);
        }
        #endregion

        #region Start/End angles
        public double StartAngle
        {
            get => (double) GetValue(StartAngleProperty);
            set => SetValue(StartAngleProperty, value);
        }

        // Using a DependencyProperty as the backing store for StartAngle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StartAngleProperty =
            DependencyProperty.Register("StartAngle", typeof(double), typeof(Arc),
                new UIPropertyMetadata(0.0, UpdateArc));

        public double EndAngle
        {
            get => (double) GetValue(EndAngleProperty);
            set => SetValue(EndAngleProperty, value);
        }

        // Using a DependencyProperty as the backing store for EndAngle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EndAngleProperty =
            DependencyProperty.Register("EndAngle", typeof(double), typeof(Arc),
                new UIPropertyMetadata(90.0, UpdateArc));
        #endregion

        #region Direction
        /// <summary>
        /// Gets or sets progress bar fill direction
        /// </summary>
        public SweepDirection Direction
        {
            get => (SweepDirection) GetValue(DirectionProperty);
            set => SetValue(DirectionProperty, value);
        }

        public static readonly DependencyProperty DirectionProperty =
            DependencyProperty.Register("Direction", typeof(SweepDirection), typeof(Arc),
                new UIPropertyMetadata(SweepDirection.Clockwise));
        #endregion

        #region OriginRotationDegrees
        /// <summary>
        /// Gets or sets the initial rotation of the arc a certain number of degree in the direction. 270 - clockwise, 90 - counterclockwise.
        /// </summary>
        public double OriginRotationDegrees
        {
            get => (double) GetValue(OriginRotationDegreesProperty);
            set => SetValue(OriginRotationDegreesProperty, value);
        }

        public static readonly DependencyProperty OriginRotationDegreesProperty =
            DependencyProperty.Register("OriginRotationDegrees", typeof(double), typeof(Arc),
                new UIPropertyMetadata(270d, UpdateArc));

        protected static void UpdateArc(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((Arc) d)?.InvalidateVisual();
        }
        #endregion

        protected override Geometry DefiningGeometry => GetArcGeometry();

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (_pen == null)
                UpdatePen();
            if (ArcMode == ArcMode.Fill || ArcMode == ArcMode.Pie)
            {
                var radiusX = RenderSize.Width / 2;
                var radiusY = RenderSize.Height / 2;
                var centerPoint = new Point(radiusX, radiusY);

                if (ProgressBackgroundBrush != Brushes.Transparent)
                {
                    var clipb = GetArcGeometry(true).GetWidenedPathGeometry(
                        _clipPen);
                    clipb.Freeze();

                    drawingContext.PushClip(clipb);
                    drawingContext.DrawEllipse(ProgressBackgroundBrush, null, centerPoint, radiusX, radiusY);
                    drawingContext.Pop();
                }

                // the outlines of the "original" Arc geometry
                var clip = GetArcGeometry().GetWidenedPathGeometry(
                    _clipPen);
                clip.Freeze();

                // draw only in the area of the original arc
                drawingContext.PushClip(clip);
                drawingContext.DrawEllipse(ProgressFillBrush, null, centerPoint, radiusX, radiusY);
                if(ProgressBorderBrush != Brushes.Transparent && ProgressBorderThickness.Top > 0)
                    drawingContext.DrawGeometry(null, _pen, clip);
                drawingContext.Pop();
            }
            else
            {
                if (_semiBrush1 == null)
                    UpdateInternalBrushes();
                //var minAngle = Math.Min(StartAngle, EndAngle);
                var maxAngle = Math.Max(StartAngle, EndAngle);
                var max = Math.Round(maxAngle / ShapeModeStep);
                _data = _data ?? GetAngleData(ShapeModeStep);
                //_data = GetAngleData(ShapeModeStep);
                for (int i = 0; i < max; i++)
                {
                    var data = _data[i];
                    ///////////////////////////
                   /* drawingContext.DrawEllipse(Brushes.Red, _pen, data.StartPoint, 2,2);
                    var radiusX = RenderSize.Width / 2;
                    var radiusY = RenderSize.Height / 2;
                    var centerPoint = new Point(radiusX, radiusY);
                    drawingContext.DrawEllipse(Brushes.Red, _pen, centerPoint, 2,2);*/
                    ///////////////////////////////////

                    var half = ShapeModeWidth * .5;
                    var rect = new Rect(data.StartPoint.X - half, data.StartPoint.Y, ShapeModeWidth, StrokeThickness);
                    drawingContext.PushTransform(new RotateTransform(data.Angle, data.StartPoint.X, data.StartPoint.Y));
                    var brush = ProgressFillBrush;
                    if (ShapeModeUseFade)
                    {
                        if (i == max - 2)
                            brush = _semiBrush1;
                        if (i == max - 1)
                            brush = _semiBrush2;
                        else if (i == max)
                            brush = _semiBrush3;
                    }

                    drawingContext.DrawRectangle(brush, _pen, rect);
                    drawingContext.Pop();
                }
            }
        }

        private List<AngleData> _data;
        private Pen _pen;
        private Pen _clipPen;
        private Brush _semiBrush1;
        private Brush _semiBrush2;
        private Brush _semiBrush3;

        private static void UpdateFillBrush(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var arc = d as Arc;
            arc?.UpdateInternalBrushes();
            UpdateArc(d,e);
        }

        internal void UpdateInternalBrushes()
        {
            if (ShapeModeUseFade)
            {
                _semiBrush1 = ProgressFillBrush.Clone();
                _semiBrush1.Opacity = .7;
                _semiBrush1.Freeze();
                _semiBrush2 = ProgressFillBrush.Clone();
                _semiBrush2.Opacity = .5;
                _semiBrush2.Freeze();
                _semiBrush3 = ProgressFillBrush.Clone();
                _semiBrush3.Opacity = .3;
                _semiBrush3.Freeze();
            }
        }

        internal void UpdatePen()
        {
            var width = ArcMode == ArcMode.Pie ? RenderSize.Width * .5 : StrokeThickness;

            var m = PresentationSource.FromVisual(this)
                .CompositionTarget.TransformToDevice;
            var dpiFactor = 1 / m.M11;
            _pen = new Pen(ProgressBorderBrush, ProgressBorderThickness.Top * dpiFactor);
            _pen.Freeze();
            _clipPen = new Pen(Brushes.White, width * dpiFactor);
            _clipPen.Freeze();
        }

        private List<AngleData> GetAngleData(int step)
        {
            var minAngle = Math.Min(StartAngle, EndAngle);
            var maxAngle = 359.9;

            var dic = new List<AngleData>();
            var startAngle = minAngle;
            var radiusX = RenderSize.Width / 2;
            var radiusY = RenderSize.Height / 2;
            var centerPoint = new Point(radiusX, radiusY);

            while (true)
            {
                if (startAngle > maxAngle)
                    break;
                var a = (Direction == SweepDirection.Clockwise ? -1 : 1) * (startAngle + OriginRotationDegrees) * (Math.PI / 180);

                var pt = new Point();
                pt.Y = centerPoint.Y - radiusY * Math.Sin(a);
                pt.X = centerPoint.X + radiusX * Math.Cos(a);
                var a2 = GetAngleBetweenPoints(pt, centerPoint);
                dic.Add(new AngleData { StartPoint = pt, Angle = a2});
                startAngle += step;

            }

            return dic;
        }

        private class AngleData
        {
            public Point StartPoint;
            public double Angle;
        }

        private double GetAngleBetweenPoints(Point one, Point two)
        {
            var xDiff = two.X - one.X;
            var yDiff = two.Y - one.Y;
            var angle = Math.Atan2(yDiff, xDiff) * 180.0 / Math.PI;
            return angle + ShapeRotationAdjustment - 90;
        }

        private Geometry GetArcGeometry(bool full = false)
        {
            var width = ArcMode == ArcMode.Pie ? RenderSize.Width * .5 : StrokeThickness;
            var startPoint = PointAtAngle(full ? 0d : Math.Min(StartAngle, EndAngle), Direction);
            var endPoint = PointAtAngle(full ? 359.9d : Math.Max(StartAngle, EndAngle), Direction);

            var arcSize = new Size(Math.Max(0, (RenderSize.Width - width) / 2),
                Math.Max(0, (RenderSize.Height - width) / 2));
            var isLargeArc = full || Math.Abs(EndAngle - StartAngle) > 180;

            var geom = new StreamGeometry();
            using (var context = geom.Open())
            {
                context.BeginFigure(startPoint, false, false);
                context.ArcTo(endPoint, arcSize, 0, isLargeArc, Direction, true, false);
            }

            geom.Transform = new TranslateTransform(width / 2, width / 2);
            return geom;
        }

        private Point PointAtAngle(double angle, SweepDirection sweep)
        {
            var width = ArcMode == ArcMode.Pie ? RenderSize.Width * .5 : StrokeThickness;

            var translatedAngle = angle + OriginRotationDegrees;
            var radAngle = translatedAngle * (Math.PI / 180);
            var xr = (RenderSize.Width - width) / 2;
            var yr = (RenderSize.Height - width) / 2;

            var x = xr + xr * Math.Cos(radAngle);
            var y = yr * Math.Sin(radAngle);

            if (sweep == SweepDirection.Counterclockwise)
            {
                y = yr - y;
            }
            else
            {
                y = yr + y;
            }

            return new Point(x, y);
        }
    }
}
