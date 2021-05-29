using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UWB_SP_TO_SOCKET.form
{
    /// <summary>
    /// UwbMapControl.xaml 的交互逻辑
    /// </summary>
    public partial class UwbMapControl : UserControl
    {
        #region <常量>
        /// <summary>
        /// 线条颜色
        /// </summary>
        private Color _lineColor = Color.FromArgb(0xFF, 0x66, 0x66, 0x66);
        private Color _lineRedColor = Color.FromArgb(0xFF, 0xff, 0x21, 0x21);
        /// <summary>
        /// 背景颜色
        /// </summary>
        private Color _backgroundColor = Color.FromArgb(0xFF, 0x33, 0x33, 0x33);
        /// <summary>
        /// 地图大小
        /// </summary>
        public int Size = 10000;
        #endregion <常量>

        #region <变量>
        /// <summary>
        /// 设置关闭时间，修复设置点击两次
        /// </summary>
        long openSettingTime;
        /// <summary>
        /// 是否启用点击
        /// </summary>
        private bool isEnable = true;

        private Ellipse ellipseAnchor1;
        private Ellipse ellipseAnchor2;
        private Ellipse ellipseAnchor3;

        private Ellipse ellipseTag1;

        /// <summary>
        /// 变换组
        /// </summary>
        TransformGroup transformGroup;

        /// <summary>
        /// 缩放变换
        /// </summary>
        ScaleTransform scaleTransform;
        /// <summary>
        /// 平移变换
        /// </summary>
        TranslateTransform translateTransform;
        /// <summary>
        /// 原始变换
        /// </summary>
        MatrixTransform matrixTransform;

        /// <summary>
        /// 鼠标上次的位置
        /// </summary>
        private Point mouseInitialPoint;

        /// <summary>
        /// 锚点坐标1
        /// </summary>
        private Point m_anchor1;
        /// <summary>
        /// 锚点坐标2
        /// </summary>
        private Point m_anchor2;
        /// <summary>
        /// 锚点坐标3
        /// </summary>
        private Point m_anchor3;
        /// <summary>
        /// 目标点坐标
        /// </summary>
        private Point m_tag1;
        /// <summary>
        /// 缩放等级
        /// </summary>
        private double m_scale;
        /// <summary>
        /// 鼠标坐标
        /// </summary>
        private Point m_mouseCoordinate;
        /// <summary>
        /// 地图坐标
        /// </summary>
        private Point m_mapCoordinate;


        /// <summary>
        /// 地图画布
        /// </summary>
        public Canvas CanvasMap { get { return cvMap; } }
        /// <summary>
        /// 重置按钮
        /// </summary>
        public Button ButtonReset { get { return btnReset; } }
        /// <summary>
        /// 设置按钮
        /// </summary>
        public Button ButtonSetting { get { return btnSetting; } }
        /// <summary>
        /// 地图位置标签
        /// </summary>
        public Label LabelMapPosition { get { return lbMapPosition; } }
        /// <summary>
        /// 鼠标位置标签
        /// </summary>
        public Label LabelMousePosition { get { return lbMousePosition; } }
        /// <summary>
        /// 缩放等级标签
        /// </summary>
        public Label LabelZoomLevel { get { return lbZoomLevel; } }
        /// <summary>
        /// 锚点1信息标签
        /// </summary>
        public Label LabelAnchorPoint1 { get { return lbAnchorPoint1; } }
        /// <summary>
        /// 锚点2信息标签
        /// </summary>
        public Label LabelAnchorPoint2 { get { return lbAnchorPoint2; } }
        /// <summary>
        /// 锚点3信息标签
        /// </summary>
        public Label LabelAnchorPoint3 { get { return lbAnchorPoint3; } }
        /// <summary>
        /// 目标1信息标签
        /// </summary>
        public Label LabelTagPoint1 { get { return lbTagPoint1; } }

        /// <summary>
        /// 锚点1标签
        /// </summary>
        public Label LbAnchorPoint1;
        /// <summary>
        /// 锚点2标签
        /// </summary>
        public Label LbAnchorPoint2;
        /// <summary>
        /// 锚点3标签
        /// </summary>
        public Label LbAnchorPoint3;
        /// <summary>
        /// 目标1标签
        /// </summary>
        public Label LbTagPoint1;

        /// <summary>
        /// 目标点1是否显示
        /// </summary>
        bool isShowTag1 = true;
        /// <summary>
        /// 锚点3是否显示
        /// </summary>
        bool isShowAnchor3 = true;
        /// <summary>
        /// 锚点2是否显示
        /// </summary>
        bool isShowAnchor2 = true;
        /// <summary>
        /// 锚点1是否显示
        /// </summary>
        bool isShowAnchor1 = true;
        #endregion <变量>

        #region <属性>
        /// <summary>
        /// 目标点1是否显示
        /// </summary>
        public bool IsShowTag1
        {
            get
            {
                return isShowTag1;
            }
            set
            {
                isShowTag1 = value;

                if (ellipseTag1 == null)
                {
                    return;
                }

                if (isShowTag1)
                {
                    ellipseTag1.Visibility = Visibility.Visible;
                }
                else
                {
                    ellipseTag1.Visibility = Visibility.Collapsed;
                }

                if (LbTagPoint1 == null)
                {
                    return;
                }
                LbTagPoint1.Visibility = ellipseTag1.Visibility;
            }
        }
        /// <summary>
        /// 锚点3是否显示
        /// </summary>
        public bool IsShowAnchor3
        {
            get
            {
                return isShowAnchor3;
            }
            set
            {
                isShowAnchor3 = value;

                if (ellipseAnchor3 == null)
                {
                    return;
                }

                if (isShowAnchor3)
                {
                    ellipseAnchor3.Visibility = Visibility.Visible;
                }
                else
                {
                    ellipseAnchor3.Visibility = Visibility.Collapsed;
                }

                if (LbAnchorPoint3 == null)
                {
                    return;
                }
                LbAnchorPoint3.Visibility = ellipseAnchor3.Visibility;
            }
        }
        /// <summary>
        /// 锚点2是否显示
        /// </summary>
        public bool IsShowAnchor2
        {
            get
            {
                return isShowAnchor2;
            }
            set
            {
                isShowAnchor2 = value;

                if (ellipseAnchor2 == null)
                {
                    return;
                }

                if (isShowAnchor2)
                {
                    ellipseAnchor2.Visibility = Visibility.Visible;
                }
                else
                {
                    ellipseAnchor2.Visibility = Visibility.Collapsed;
                }

                if (LbAnchorPoint2 == null)
                {
                    return;
                }
                LbAnchorPoint2.Visibility = ellipseAnchor2.Visibility;
            }
        }

        /// <summary>
        /// 锚点1是否显示
        /// </summary>
        public bool IsShowAnchor1
        {
            get
            {
                return isShowAnchor1;
            }
            set
            {
                isShowAnchor1 = value;

                if (ellipseAnchor1 == null)
                {
                    return;
                }

                if (isShowAnchor1)
                {
                    ellipseAnchor1.Visibility = Visibility.Visible;
                }
                else
                {
                    ellipseAnchor1.Visibility = Visibility.Collapsed;
                }

                if (LbAnchorPoint1 == null)
                {
                    return;
                }
                LbAnchorPoint1.Visibility = ellipseAnchor1.Visibility;
            }
        }

        /// <summary>
        /// 地图坐标
        /// </summary>
        public Point MapCoordinate
        {
            get
            {
                if (m_mapCoordinate == null)
                {
                    m_mapCoordinate = new Point();
                }
                return m_mapCoordinate;
            }
            private set
            {
                if (value != null)
                {
                    if (m_mapCoordinate != value)
                    {
                        MapMove(value.X, value.Y);
                    }
                    this.m_mapCoordinate = value;
                }
            }
        }

        /// <summary>
        /// 鼠标坐标
        /// </summary>
        public Point MouseCoordinate
        {
            get
            {
                if (m_mouseCoordinate == null)
                {
                    m_mouseCoordinate = new Point();
                }
                return m_mouseCoordinate;
            }
            private set
            {
                if (value != null)
                {
                    if (m_mouseCoordinate != value)
                    {
                        PointerMove(value.X, value.Y);
                    }
                    this.m_mouseCoordinate = value;
                }
            }
        }


        /// <summary>
        /// 缩放等级
        /// </summary>
        public double Scale
        {
            get
            {
                if (double.IsNaN(m_scale) || m_scale == 0)
                {
                    m_scale = 1;
                }
                return m_scale;
            }
            private set
            {
                if (m_scale != value)
                {
                    MapScale(value);
                }
                this.m_scale = value;
            }
        }


        /// <summary>
        /// 锚点坐标1
        /// </summary>
        public Point Anchor1
        {
            get
            {
                if (m_anchor1 == null)
                {
                    m_anchor1 = new Point();
                }
                return m_anchor1;
            }
            private set
            {
                if (value != null)
                {
                    if (m_anchor1 != value)
                    {
                        AnchorBuild(1, value.X, value.Y);
                    }
                    this.m_anchor1 = value;
                }
            }
        }


        /// <summary>
        /// 锚点坐标2
        /// </summary>
        public Point Anchor2
        {
            get
            {
                if (m_anchor2 == null)
                {
                    m_anchor2 = new Point();
                }
                return m_anchor2;
            }
            private set
            {
                if (value != null)
                {
                    if (m_anchor2 != value)
                    {
                        AnchorBuild(2, value.X, value.Y);
                    }
                    this.m_anchor2 = value;
                }
            }
        }


        /// <summary>
        /// 锚点坐标3
        /// </summary>
        public Point Anchor3
        {
            get
            {
                if (m_anchor3 == null)
                {
                    m_anchor3 = new Point();
                }
                return m_anchor3;
            }
            private set
            {
                if (value != null)
                {
                    if (m_anchor3 != value)
                    {
                        AnchorBuild(3, value.X, value.Y);
                    }
                    this.m_anchor3 = value;
                }
            }
        }


        /// <summary>
        /// 目标点坐标
        /// </summary>
        public Point Tag1
        {
            get
            {
                if (m_tag1 == null)
                {
                    m_tag1 = new Point();
                }
                return m_tag1;
            }
            private set
            {
                if (value != null)
                {
                    if (m_tag1 != value)
                    {
                        TagBuild(1, value.X, value.Y);
                    }
                    this.m_tag1 = value;
                }
            }
        }
        #endregion <属性>

        #region <构造方法和析构方法>
        public UwbMapControl()
        {
            InitializeComponent();

            InitMap();

            SetAnchor1(50, 10);
            SetAnchor2(10, 50);
            SetAnchor3(50, 50);
            SetTag1(10, 10);
        }
        /// <summary>
        /// 初始化画布变换
        /// </summary>
        private void InitTransform()
        {
            transformGroup = new TransformGroup();
            CanvasMap.RenderTransform = transformGroup;

            scaleTransform = new ScaleTransform();
            translateTransform = new TranslateTransform();
            matrixTransform = new MatrixTransform();

            CanvasMap.Width = Size;
            CanvasMap.Height = Size;

            transformGroup.Children.Add(scaleTransform);
            transformGroup.Children.Add(translateTransform);
            transformGroup.Children.Add(matrixTransform);
        }

        private void InitEvent()
        {
            CanvasMap.MouseMove += Canvas_MouseMove;
            CanvasMap.MouseWheel += Canvas_MouseWheel;
            ButtonSetting.Click += Button_Click;
            ButtonReset.Click += Button_Click;
        }
        private void InitUwbPoint(Ellipse ellipse)
        {

            ellipse.Width = 10;
            ellipse.Height = 10;

            ellipse.Stroke = Brushes.White;
            ellipse.Fill = Brushes.White;

            Canvas.SetZIndex(ellipse, 9999);

            SetPoint(ellipse, 0, 0);
        }
        /// <summary>
        /// 初始化UWB
        /// </summary>
        private void InitUwb()
        {
            ellipseAnchor1 = new Ellipse();
            ellipseAnchor2 = new Ellipse();
            ellipseAnchor3 = new Ellipse();
            ellipseTag1 = new Ellipse();

            LbAnchorPoint1 = new Label();
            LbAnchorPoint1.Content = "A 1";
            LbAnchorPoint1.Foreground = Brushes.White;
            LbAnchorPoint2 = new Label();
            LbAnchorPoint2.Content = "A 2";
            LbAnchorPoint2.Foreground = Brushes.White;
            LbAnchorPoint3 = new Label();
            LbAnchorPoint3.Content = "A 3";
            LbAnchorPoint3.Foreground = Brushes.White;
            LbTagPoint1 = new Label();
            LbTagPoint1.Content = "T 1";
            LbTagPoint1.Foreground = Brushes.White;


            CanvasMap.Children.Add(ellipseAnchor1);
            CanvasMap.Children.Add(ellipseAnchor2);
            CanvasMap.Children.Add(ellipseAnchor3);
            CanvasMap.Children.Add(ellipseTag1);

            CanvasMap.Children.Add(LbAnchorPoint1);
            CanvasMap.Children.Add(LbAnchorPoint2);
            CanvasMap.Children.Add(LbAnchorPoint3);
            CanvasMap.Children.Add(LbTagPoint1);

            InitUwbPoint(ellipseAnchor1);
            InitUwbPoint(ellipseAnchor2);
            InitUwbPoint(ellipseAnchor3);
            InitUwbPoint(ellipseTag1);

            ellipseTag1.Stroke = Brushes.Lime;
            ellipseTag1.Fill = Brushes.Lime;

        }

        private void InitMap()
        {
            InitTransform();
            InitEvent();
            CanvasMap.Background = new SolidColorBrush(_backgroundColor);
            InitGrid();
            InitUwb();

            InitImg();
        }

        Image ImageReset
        {
            get
            {
                return imReset;
            }
        }

        Image ImageSetting
        {
            get
            {
                return imSetting;
            }
        }
        /// <summary>
        /// 初始化图片按钮
        /// </summary>
        private void InitImg()
        {
            string base64_reset = "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";
            string base64_setting = "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";
            try
            {
                byte[] byte_reset = Convert.FromBase64String(base64_reset);

                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = new MemoryStream(byte_reset);
                bi.EndInit();
                ImageReset.Source = bi;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                byte[] byte_setting = Convert.FromBase64String(base64_setting);
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = new MemoryStream(byte_setting);
                bi.EndInit();
                ImageSetting.Source = bi;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void InitGrid()
        {
            int begin = 0;
            // draw lines
            for (int x = begin; x <= Size; x += 100)
            {
                bool isCrude = false;
                var stroke = new SolidColorBrush(_lineColor);
                if (x == Size / 2)
                {
                    isCrude = true;
                    stroke = new SolidColorBrush(_lineRedColor);
                }
                Line verticalLine = new Line
                {
                    Stroke = stroke,
                    X1 = x,
                    Y1 = begin,
                    X2 = x,
                    Y2 = Size
                };

                if (x % 1000 == 0)
                {
                    verticalLine.StrokeThickness = 3;

                    if (isCrude)
                    {
                        verticalLine.StrokeThickness = 2;
                    }
                }
                else
                {
                    verticalLine.StrokeThickness = 1;
                }

                CanvasMap.Children.Add(verticalLine);
            }

            for (int y = begin; y <= Size; y += 100)
            {
                bool isCrude = false;
                var stroke = new SolidColorBrush(_lineColor);
                if (y == Size / 2)
                {
                    isCrude = true;
                    stroke = new SolidColorBrush(_lineRedColor);
                }
                Line horizontalLine = new Line
                {
                    Stroke = stroke,
                    X1 = begin,
                    Y1 = y,
                    X2 = Size,
                    Y2 = y
                };

                if (y % 1000 == 0)
                {
                    horizontalLine.StrokeThickness = 3;

                    if (isCrude)
                    {
                        horizontalLine.StrokeThickness = 2;
                    }
                }
                else
                {
                    horizontalLine.StrokeThickness = 1;
                }

                CanvasMap.Children.Add(horizontalLine);
            }
        }
        #endregion <构造方法和析构方法>

        #region <方法>
        /// <summary>
        /// 设置锚点1坐标
        /// </summary>
        /// <param name="x">坐标x值</param>
        /// <param name="y">坐标y值</param>
        public void SetAnchor1(double x, double y)
        {
            SetPoint(ellipseAnchor1, x, y);
            SetPoint(LbAnchorPoint1, x, y);
            Anchor1 = new Point(x, y);
        }
        /// <summary>
        /// 设置锚点2坐标
        /// </summary>
        /// <param name="x">坐标x值</param>
        /// <param name="y">坐标y值</param>
        public void SetAnchor2(double x, double y)
        {
            SetPoint(ellipseAnchor2, x, y);
            SetPoint(LbAnchorPoint2, x, y);
            Anchor2 = new Point(x, y);
        }
        /// <summary>
        /// 设置锚点3坐标
        /// </summary>
        /// <param name="x">坐标x值</param>
        /// <param name="y">坐标y值</param>
        public void SetAnchor3(double x, double y)
        {
            SetPoint(ellipseAnchor3, x, y);
            SetPoint(LbAnchorPoint3, x, y);
            Anchor3 = new Point(x, y);
        }
        /// <summary>
        /// 设置目标点坐标
        /// </summary>
        /// <param name="x">坐标x值</param>
        /// <param name="y">坐标y值</param>
        public void SetTag1(double x, double y)
        {
            SetPoint(ellipseTag1, x, y);
            SetPoint(LbTagPoint1, x, y);
            Tag1 = new Point(x, y);
        }
        /// <summary>
        /// 设置控件在Canvas上的位置
        /// </summary>
        /// <param name="element">控件</param>
        /// <param name="x">X坐标</param>
        /// <param name="y">Y坐标</param>
        private void SetPoint(Ellipse element, double x, double y)
        {
            element.SetValue(Canvas.TopProperty, CoordinateTransform(x, y).X - (element.Height / 2));
            element.SetValue(Canvas.LeftProperty, CoordinateTransform(x, y).Y - (element.Width / 2));
        }
        /// <summary>
        /// 设置控件在Canvas上的位置
        /// </summary>
        /// <param name="element">控件</param>
        /// <param name="x">X坐标</param>
        /// <param name="y">Y坐标</param>
        private void SetPoint(Label element, double x, double y)
        {
            element.SetValue(Canvas.TopProperty, CoordinateTransform(x, y).X - 12.5);
            element.SetValue(Canvas.LeftProperty, CoordinateTransform(x, y).Y + 7);
        }
        /// <summary>
        /// 把实际坐标转换成Canvas坐标
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>返回转换后的坐标点</returns>
        private Point CoordinateTransform(double x, double y)
        {
            Point cvP = new Point();
            cvP.X = (Size / 2) - y;
            cvP.Y = x + (Size / 2);
            return cvP;
        }
        /// <summary>
        /// 相对缩放
        /// </summary>
        /// <param name="scale">相对缩放值</param>
        /// <param name="centerX">缩放中心x坐标</param>
        /// <param name="centerY">缩放中心y坐标</param>
        private void ScaleAtPrepend(double scale, double centerX, double centerY)
        {
            double new_scale = Scale * scale;
            if (new_scale < 0.15)
            {
                isEnable = false;
                MessageBox.Show("已缩放到最小值", "警告");
                isEnable = true;
                return;
            }
            else if (new_scale > 100)
            {
                isEnable = false;
                MessageBox.Show("已缩放到最大值", "警告");
                isEnable = true;
                return;
            }


            var matrix = matrixTransform.Matrix;
            matrix.ScaleAtPrepend(scale, scale, centerX, centerY);
            matrixTransform.Matrix = matrix;


            Scale = new_scale;
        }
        /// <summary>
        /// 获取时间戳的长整型，例如1599745856900
        /// </summary>
        /// <returns></returns>
        public static long GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds);
        }
        #endregion <方法>

        #region <事件>
        /// <summary>
        /// 按钮点击事件
        /// </summary>
        /// <param name="sender">事件发送者</param>
        /// <param name="e">事件内容</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!isEnable)
            {
                return;
            }

            if (sender == ButtonReset)
            {
                InitTransform();
            }
            else if (sender == ButtonSetting)
            {
                if (GetTimeStamp() - openSettingTime < 1000)
                {
                    return;
                }
                new MapSettingForm(this).ShowDialog();
                openSettingTime = GetTimeStamp();
            }
        }
        /// <summary>
        /// 鼠标滚轮事件
        /// </summary>
        /// <param name="sender">事件发送者</param>
        /// <param name="e">事件内容</param>
        private void Canvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (!isEnable)
            {
                return;
            }

            var element = sender as UIElement;
            var position = e.GetPosition(element);

            var scale = e.Delta >= 0 ? 1.1 : (1.0 / 1.1); // choose appropriate scaling factor

            ScaleAtPrepend(scale, position.X, position.Y);
        }
        /// <summary>
        /// 鼠标移动事件
        /// </summary>
        /// <param name="sender">事件发送者</param>
        /// <param name="e">事件内容</param>
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            Point p;
            if (e.MouseDevice.LeftButton == MouseButtonState.Pressed && isEnable)
            {
                var matrix = matrixTransform.Matrix;

                var xOffset = e.GetPosition(this).X - mouseInitialPoint.X;
                var yOffset = e.GetPosition(this).Y - mouseInitialPoint.Y;
                matrix.Translate(xOffset, yOffset);
                matrixTransform.Matrix = matrix;

                p = new Point(MapCoordinate.X + yOffset, MapCoordinate.Y + xOffset);
                MapCoordinate = p;
            }

            mouseInitialPoint = Mouse.GetPosition(this);

            p = new Point(mouseInitialPoint.X, mouseInitialPoint.Y);
            MouseCoordinate = p;
        }

        /// <summary>
        /// 锚点变动事件
        /// </summary>
        /// <param name="id">锚点ID</param>
        /// <param name="x">锚点X坐标</param>
        /// <param name="y">锚点Y坐标</param>
        private void AnchorBuild(int id, double x, double y)
        {
            AnchorBuildEvent?.Invoke(this, id, x, y);

            string str = "锚点" + id + "：" + x.ToString("0.0") + "," + y.ToString("0.0");
            switch (id)
            {
                case 1:
                    LabelAnchorPoint1.Content = str;
                    break;
                case 2:
                    LabelAnchorPoint2.Content = str;
                    break;
                case 3:
                    LabelAnchorPoint3.Content = str;
                    break;
            }
        }
        // 锚点产生
        public delegate void AnchorBuildHandler(object sender, int id, double x, double y);
        public event AnchorBuildHandler AnchorBuildEvent;
        /// <summary>
        /// 目标点产生
        /// </summary>
        /// <param name="id">目标点ID</param>
        /// <param name="x">目标点X坐标</param>
        /// <param name="y">目标点Y坐标</param>
        private void TagBuild(int id, double x, double y)
        {
            TagBuildEvent?.Invoke(this, id, x, y);

            string str = "目标" + id + "：" + x.ToString("0.0") + "," + y.ToString("0.0");
            switch (id)
            {
                case 1:
                    LabelTagPoint1.Content = str;
                    break;
            }
        }
        // 目标点坐标产生事件
        public delegate void TagBuildHandler(object sender, int id, double x, double y);
        public event TagBuildHandler TagBuildEvent;
        /// <summary>
        /// 发送鼠标移动事件
        /// </summary>
        /// <param name="x">当前鼠标X坐标</param>
        /// <param name="y">当前鼠标y坐标</param>
        private void PointerMove(double x, double y)
        {
            PointerMoveEvent?.Invoke(this, x, y);

            string str = "鼠标位置：" + x.ToString("0.0") + "," + y.ToString("0.0");
            LabelMousePosition.Dispatcher.BeginInvoke((Action)delegate
            {
                LabelMousePosition.Content = str;
            });
        }
        // 鼠标坐标变动
        public delegate void PointerMoveHandler(object sender, double x, double y);
        public event PointerMoveHandler PointerMoveEvent;
        /// <summary>
        /// 发送地图移动事件
        /// </summary>
        /// <param name="x">当前地图X坐标</param>
        /// <param name="y">当前地图y坐标</param>
        private void MapMove(double x, double y)
        {
            CanvasLoaclEvent?.Invoke(this, x, y);

            string str = "地图坐标：" + x.ToString("0.0") + "," + y.ToString("0.0");
            LabelMapPosition.Dispatcher.BeginInvoke((Action)delegate
            {
                LabelMapPosition.Content = str;
            });
        }
        // 地图坐标变动
        public delegate void CanvasLoaclHandler(object sender, double x, double y);
        public event CanvasLoaclHandler CanvasLoaclEvent;
        /// <summary>
        /// 发送地图缩放事件
        /// </summary>
        /// <param name="scale">地图当前缩放比例</param>
        private void MapScale(double scale)
        {
            ScaleChangeEvent?.Invoke(this, scale);

            string str = "缩放等级：" + scale.ToString("0.000");
            LabelZoomLevel.Dispatcher.BeginInvoke((Action)delegate
            {
                LabelZoomLevel.Content = str;
            });
        }
        // 地图缩放变化
        public delegate void ScaleChangeHandler(object sender, double scale);
        public event ScaleChangeHandler ScaleChangeEvent;
        #endregion <事件>
    }
}
