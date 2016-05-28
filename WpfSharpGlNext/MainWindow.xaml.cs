using SharpGL;
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
using WpfSharpGlNext.BL;
using WpfSharpGlNext.BL.Diagrammers;
namespace WpfSharpGlNext
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        
      //  GraphAsicsParams gp = new GraphAsicsParams();
        SimpleDiagrammer gp = new SimpleDiagrammer();

        public MainWindow()
        {
            InitializeComponent();
            gp = new SimpleDiagrammer(OpenGlControl1.OpenGL);
        }


        private void OpenGLControl_Loaded_1(object sender, RoutedEventArgs e)
        {

        }

        private void OpenGLControl_OpenGLDraw_1(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
           
           //Control.MousePosition
            
            var gl = this.OpenGlControl1.OpenGL;
           
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);//Цвет
            gl.LoadIdentity();//Система коардинат

            
            gp.DrawAsix();
           // gp.PointsTriangleGenerateMethod();
            if (gp.listflag)
                gp.DrawPoints();// DrawMyPointsArray();

            gl.Flush();
        }

        private void OpenGlControl1_Resized(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {

            //  получаем ссылку на окно OpenGL 
            OpenGL gl = OpenGlControl1.OpenGL;

            //  Задаем матрицу вида 
            gl.MatrixMode(OpenGL.GL_PROJECTION);

            //  загружаем нулевую матрицу сцены
            gl.LoadIdentity();

            //  подгоняем окно просмотра под размеры окна OpenGL в форме  gp.mainProportion*3
            gl.Perspective(50f, (double)Width / (double)Height, 10.00, 100.0);

            //  Задаем координаты камеры куда она будет смотреть
            gl.LookAt(-30, gp.mainProportion / 2, 0, -30, 0, 0, 0, 0, gp.mainProportion);//Глаз, куда смотрим, где вверх

            //  задаем матрицу вида мдели 
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }

        private void OpenGlControl1_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                gp.scale += 0.1f;
            }
            else
            {
                gp.scale -= 0.1f;
            }
        }

        private void OpenGlControl1_MouseMove(object sender, MouseEventArgs e)
        {
           
            //if e.LeftButton;
            //if (e.LeftButton.ToString() == "Pressed")
            //{
            //    var new_point = this.OpenGlControl1.PointFromScreen(new Point(e.GetPosition(this.OpenGlControl1).X,e.GetPosition(this.OpenGlControl1).Y));
            //    gp.eyeX = (float)(new_point.X/Width);
            //    gp.eyeZ = (float)(new_point.Y/Height);
            //}
            
        }



        private void Window_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                gp.xRotate++;
            }
            else if (e.Key == Key.Down)
            {
                gp.xRotate--;
            }
            else if (e.Key == Key.Left)
            {
                gp.zRotate--;
            }
            else if (e.Key == Key.Right)
            {
                gp.zRotate++;
            }
            else if (e.Key == Key.Z)
            {
                gp.yRotate--;
            }
            else if (e.Key == Key.X)
            {
                gp.yRotate++; 
            }
        }
       
        #region Zoom
        /// <summary>
        /// Zoom changed +
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            gp.scale += 0.1f;
        }
        /// <summary>
        /// Zoom changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            gp.scale -= 0.1f;
        }
        #endregion

        #region Rotation
        /// <summary>
        /// X Rotate +
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RotateXButtonPlus_Click(object sender, RoutedEventArgs e)
        {
            gp.xRotate++;
        }


       
        /// <summary>
        /// X Rotate Minus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RotateXButtonMinus_Click(object sender, RoutedEventArgs e)
        {
            gp.xRotate--;
        }

        /// <summary>
        /// Y Rotate Plus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RotateYButtonPlus_Click(object sender, RoutedEventArgs e)
        {
            gp.yRotate++;
        }
        /// <summary>
        /// Y Rotate Minus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RotateYButtonMinus_Click(object sender, RoutedEventArgs e)
        {
            gp.yRotate--;
        }
        /// <summary>
        /// Z Rotate Plus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RotateZButtonPlus_Click(object sender, RoutedEventArgs e)
        {
            gp.zRotate++;
        }
        /// <summary>
        /// Z Rotate Minus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RotateZButtonMinus_Click(object sender, RoutedEventArgs e)
        {
            gp.zRotate--;
        }
        #endregion

        #region Position
        private void xPositionSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            gp.eyeX = (float)xPositionSlider.Value;
        }

        private void yPositionSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            gp.eyeY = (float)yPositionSlider.Value;
        }

        private void zPositionSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            gp.eyeZ = (float)zPositionSlider.Value;
        }
        #endregion


        /// <summary>
        /// Parser txt to list Points
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".txt";
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                gp.listflag = false; 
                string filename = dlg.FileName;
                FilePathTextBox.Text = filename;
                gp.Parse(filename);
                    xPositionSlider.Maximum = gp.list.Max(x => x.fieldX);
                    xPositionSlider.Minimum = gp.list.Min(x => x.fieldX);
                    xPositionSlider.Value = 0;

                    yPositionSlider.Maximum = gp.list.Max(x => x.fieldY);
                    yPositionSlider.Minimum = gp.list.Min(x => x.fieldY);
                    yPositionSlider.Value = 0;//yPositionSlider.Maximum/2
                    gp.eyeY = 0;//(float)yPositionSlider.Maximum/2

                    zPositionSlider.Maximum = gp.list.Max(x => x.fieldZ);
                    zPositionSlider.Minimum = gp.list.Min(x => x.fieldZ);
                    zPositionSlider.Value = 0;
            }
        }

        private void OpenGlControl1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (!gp.flag1)
            {
                var mousePosition = e.GetPosition(OpenGlControl1);
                //   OpenGlControl1.
                var newp = OpenGlControl1.PointFromScreen(e.GetPosition(OpenGlControl1));

                var gl = this.OpenGlControl1.OpenGL;

                gp.flag1Point = this.OpenGlControl1.PointFromScreen(
                    new Point(e.GetPosition(OpenGlControl1).X, e.GetPosition(OpenGlControl1).Y)
                    );
                gp.flag1 = true;
               
            }
            else
            {
                gp.flag1 = false;
            }
        }


        private void OpenGlControl1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void OpenGlControl1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void OpenGlControl1_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }
       
    }
}
