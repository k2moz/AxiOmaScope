using SharpGL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfSharpGlNext.BL.Diagrammers
{
    public class SimpleDiagrammer : IDiagrammerBaseLogic
    {
        #region Params
        public float mainProportion = 100;//Главная пропорция
        /*Масштаб*/
        public float scale = 1;
        /*Вращение*/
        //public float angle = 0;
        public float xRotate = 0;
        public float yRotate = 0;
        public float zRotate = 0;
        /*Перемещение*/
        public float xTrans = 0;
        public float yTrans = 0;
        public float zTrans = 0;

        public bool listflag = false;//Загружены ли точки

        /*Камера*/
        public float eyeX = 0;
        public float eyeY = 0;//MainProportion
        public float eyeZ = 0;

        /*Red Pointer*/
        public bool flag1 = false;
        public Point flag1Point;

        /// <summary>
        /// Generate TestTriangle
        /// </summary>
        public void PointsTriangleGenerateMethod()
        {
            if (list.Count <= 0)
            {

                list.AddRange(
                    new myPoint3[]{
                    new myPoint3(-10,0,0),
                    new myPoint3(0,0,10),
                    new myPoint3(10,0,0),
                    new myPoint3(0,10,0),
                     new myPoint3(-10,0,0)
                    }
                    );
            }
            // return list;
        }

            
        public List<myPoint3> list = new List<myPoint3>();//Коллекция точек

        OpenGL gl;

        public SimpleDiagrammer()
        {

        }
        public SimpleDiagrammer(OpenGL GL)
        {
            gl = GL;
        }

        #endregion
        public void DrawAsix()
        {
            //OpenGL gl = this.OpenGlControl1.OpenGL;
            // gl.Perspective(scale, (double)Width / (double)Height, 0.01, 100.0);
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);//Цвет

            gl.LoadIdentity();//Система коардинат
            gl.LineWidth(1.0f);
            //gl.PointSize(10.0f);


            gl.Scale(scale, scale, scale);//Масштаб
            gl.Rotate(xRotate, yRotate, zRotate);

            // gl.Perspective(1f, (double)Width / (double)Height, 1, mainProportion);
            gl.LookAt(eyeX, eyeY, eyeZ, eyeX, eyeY - 10, eyeZ, eyeX, eyeY, mainProportion);
            //gl.Rotate(angle, xRotate, yRotate, zRotate);


            #region //Asix X
            gl.Begin(OpenGL.GL_LINE_STRIP);
            for (float i = -mainProportion; i < mainProportion; i = i + 0.1f)
            {
                gl.Color(1.0f, 0.0f, 0.0f); //задает цвет 
                gl.Vertex(i, 0, 0);

            }
            gl.End();
            //X-Y
            gl.Begin(OpenGL.GL_LINES);
            for (float i = -mainProportion; i < mainProportion; i = i + mainProportion / 100)
            {
                gl.Color(1.0f, 0.0f, 0.0f);
                gl.Vertex(i, 0.1f, 0);
                gl.Vertex(i, -0.1f, 0);
            }
            gl.End();
            //X-Z
            gl.Begin(OpenGL.GL_LINES);
            for (float i = -mainProportion; i < mainProportion; i = i + mainProportion / 100)
            {
                gl.Color(1.0f, 0.0f, 0.0f);
                gl.Vertex(i, 0, 0.1f);
                gl.Vertex(i, 0, -0.1f);
            }
            gl.End();

            #endregion
            #region//Asix Y
            gl.Begin(OpenGL.GL_LINE_STRIP);
            for (float i = -mainProportion; i < mainProportion; i = i + 0.1f)
            {
                gl.Color(0f, 1.0f, 0.0f); //задает цвет 
                gl.Vertex(0, i, 0);

            }
            gl.End();
            //Y-X
            gl.Begin(OpenGL.GL_LINES);
            for (float i = -mainProportion; i < mainProportion; i = i + mainProportion / 100)
            {
                gl.Color(0f, 1.0f, 0.0f); //задает цвет 
                gl.Vertex(0.1f, i, 0);
                gl.Vertex(-0.1f, i, 0);
            }
            gl.End();
            //Y-Z
            gl.Begin(OpenGL.GL_LINES);
            for (float i = -mainProportion; i < mainProportion; i = i + mainProportion / 100)
            {
                gl.Color(0f, 1.0f, 0.0f); //задает цвет 
                gl.Vertex(0, i, 0.1f);
                gl.Vertex(0, i, -0.1f);
            }
            gl.End();
            #endregion
            #region//Asix Z
            gl.Begin(OpenGL.GL_LINE_STRIP);
            for (float i = -mainProportion; i < mainProportion; i = i + 0.1f)
            {
                gl.Color(0.0f, 0.0f, 1.0f); //задает цвет 
                gl.Vertex(0, 0, i);

            }
            gl.End();
            //Z-Y
            gl.Begin(OpenGL.GL_LINES);
            for (float i = -mainProportion; i < mainProportion; i = i + mainProportion / 100)
            {
                gl.Color(0.0f, 0.0f, 1.0f); //задает цвет 
                gl.Vertex(0, 0.1f, i);
                gl.Vertex(0, -0.1f, i);
            }
            gl.End();
            //Z-X
            gl.Begin(OpenGL.GL_LINES);
            for (float i = -mainProportion; i < mainProportion; i = i + mainProportion / 100)
            {
                gl.Color(0.0f, 0.0f, 1.0f); //задает цвет 
                gl.Vertex(0.1f, 0, i);
                gl.Vertex(-0.1f, 0, i);
            }
            gl.End();
            #endregion




            //gl.Flush();
        }

        public void DrawPoints()
        {
           // var gl = this.OpenGlControl1.OpenGL;

            gl.Begin(OpenGL.GL_LINE_STRIP);
            /*First Line*/
            gl.Color(1.0f, 1.0f, 1.0f); //задает цвет 
            foreach (var item in list)
            {
                gl.Vertex(item.fieldX, item.fieldY, item.fieldZ);
            }
            gl.End();

            /*SecondLine*/
            gl.Begin(OpenGL.GL_LINE_STRIP);

            gl.Color(0.5f, 0.5f, 0.5f); //задает цвет 
            foreach (var item in list)
            {
                gl.Vertex(item.fieldX + 1, item.fieldY - 1, item.fieldZ + 0.2);
            }
            gl.End();

            /*Delta*/



            foreach (var item in list)
            {
                gl.Begin(OpenGL.GL_LINE_STRIP);
                gl.Color(1.0f, 0.5f, 0.5f);
                gl.Vertex(item.fieldX, item.fieldY, item.fieldZ);//point from
                gl.Vertex(item.fieldX + 1, item.fieldY - 1, item.fieldZ + 0.2);//point to
                gl.End();
                /**/
                gl.DrawText((int)item.fieldX, (int)item.fieldY, 1.0f, 0.2f, 0.2f, "Arial", 12, (item.fieldX - item.fieldX + 1).ToString());

            }

            /*1 Flag*/
            if (flag1)
            {
                gl.Begin(OpenGL.GL_LINE_STRIP);

                gl.Color(0.0f, 1.0f, 0.0f); //задает цвет 

                gl.Vertex(flag1Point.X / 100, flag1Point.Y / 100, mainProportion);
                gl.Vertex(flag1Point.X / 100, flag1Point.Y / 100, -mainProportion);

                gl.End();
            }


           
        }

        public void SetCamera()
        {
            throw new NotImplementedException();
        }

        public void SetRotate()
        {
            throw new NotImplementedException();
        }

        public void SetZoom()
        {
            throw new NotImplementedException();
        }


        public void Parse(string patch)
        {
            using (StreamReader sr = File.OpenText(patch))
            {
                list.Clear();
                var context = sr.ReadToEnd();
                foreach (string item in context.Split('\n'))
                {
                    var sub_item = item.Split('\t');
                    var secretX = sub_item[0];
                    var secretY = sub_item[1];
                    var secretZ = sub_item[2];
                    list.Add(
                        new myPoint3((float)Convert.ToDouble(sub_item[0]), (float)Convert.ToDouble(sub_item[1]), (float)Convert.ToDouble(sub_item[2]))
                        );
                    //  MessageBox.Show(list.Count().ToString());
                    // DrawMyPointsArray();

                    listflag = true;
                }
                if (list.Max(x => x.fieldX) >= list.Max(x => x.fieldY))
                {
                    mainProportion = list.Max(x => x.fieldX) + 10;
                }
                else if (list.Max(x => x.fieldY >= x.fieldZ))
                {
                    mainProportion = list.Max(x => x.fieldY) + 10;
                }
                else
                {
                    mainProportion = list.Max(x => x.fieldZ) + 10;
                }
              
            }
        }
    }
}
