using PcNcCommon;
using SharpGL;
using SharpGL.SceneGraph;
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
        public List<myPoint3> list2 = new List<myPoint3>();//Коллекция точек2
        public OpenGL gl;

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

           // gl.LoadIdentity();//Система коардинат
       
            gl.LineWidth(0.3f);
            //gl.PointSize(10.0f);


            gl.Scale(scale, scale, scale);//Масштаб
           // gl.Rotate(xRotate, yRotate, zRotate);

            // gl.Perspective(1f, (double)Width / (double)Height, 1, mainProportion);
            gl.Perspective(20f, 1.0, 0.1, 200.0);
            gl.LookAt(eyeX, eyeY, mainProportion,
                         eyeX, eyeY, 0,
                         eyeX, eyeY, 0);
         /*   gl.LookAt(
                //eyeX, eyeY, eyeZ,
                eyeX, eyeY+10, 0,
               // eyeX, eyeY - 10, eyeZ,
                eyeX, eyeY, 0,
               // eyeX, eyeY, mainProportion
                eyeX, eyeY, mainProportion
                );*/
            //gl.Rotate(angle, xRotate, yRotate, zRotate);

            #region //Asix X
            gl.Begin(OpenGL.GL_LINE_STRIP);
            for (float i = -mainProportion; i < mainProportion; i = i + 0.1f)
            {
                gl.Color(1.0f, 0.0f, 0.0f); //задает цвет 
                gl.Vertex(i, 0, 0);
            }
            gl.End();

            //for (float i = -mainProportion; i < mainProportion; i = i + 0.1f)
            //{
            //    //  загружает нулевую матрицу мировых координат
            //    gl.LoadIdentity();
            //   // gl.RasterPos(i,i);
            //    gl.DrawText((int)i, 0, 1.0f, 0, 0, "Tahoma", 16.0f, "Hellow WORLD");
            //    gl.Flush();

            //}


            //X-Y
            gl.Begin(OpenGL.GL_LINES);
            for (float i = -mainProportion; i < mainProportion; i = i + 0.1f)
            {
                gl.Color(1.0f, 0.0f, 0.0f);
                gl.Vertex(i, 0.1f, 0);
                gl.Vertex(i, -0.1f, 0);
            }
            gl.End();
            //X-Z
            gl.Begin(OpenGL.GL_LINES);
            for (float i = -mainProportion; i < mainProportion; i = i + 0.1f)
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
            for (float i = -mainProportion; i < mainProportion; i = i + 0.1f)
            {
                gl.Color(0f, 1.0f, 0.0f); //задает цвет 
                gl.Vertex(0.1f, i, 0);
                gl.Vertex(-0.1f, i, 0);
            }
            gl.End();
            //Y-Z
            gl.Begin(OpenGL.GL_LINES);
            for (float i = -mainProportion; i < mainProportion; i = i + 0.1f)
            {
                gl.Color(0f, 1.0f, 0.0f); //задает цвет 
                gl.Vertex(0, i, 0.1f);
                gl.Vertex(0, i, -0.1f);
            }
            gl.End();
            #endregion

            //#region//Asix Z
            //gl.Begin(OpenGL.GL_LINE_STRIP);
            //for (float i = -mainProportion; i < mainProportion; i = i + 0.1f)
            //{
            //    gl.Color(0.0f, 0.0f, 1.0f); //задает цвет 
            //    gl.Vertex(0, 0, i);

            //}
            //gl.End();
            ////Z-Y
            //gl.Begin(OpenGL.GL_LINES);
            //for (float i = -mainProportion; i < mainProportion; i = i + mainProportion / 100)
            //{
            //    gl.Color(0.0f, 0.0f, 1.0f); //задает цвет 
            //    gl.Vertex(0, 0.1f, i);
            //    gl.Vertex(0, -0.1f, i);
            //}
            //gl.End();
            ////Z-X
            //gl.Begin(OpenGL.GL_LINES);
            //for (float i = -mainProportion; i < mainProportion; i = i + mainProportion / 100)
            //{
            //    gl.Color(0.0f, 0.0f, 1.0f); //задает цвет 
            //    gl.Vertex(0.1f, 0, i);
            //    gl.Vertex(-0.1f, 0, i);
            //}
            //gl.End();
            //#endregion



         
            for (float i = -mainProportion; i < mainProportion; i = i + 0.1f)
            {
                gl.DrawText((int)i, (int)10, 1.0f, 0, 0, "Tahoma", 24.0f, i.ToString());

            }
            //gl.Flush();
        }

        public void DrawPoints()
        {
            // var gl = this.OpenGlControl1.OpenGL;
           // gl.LoadIdentity();//Система коардинат
            gl.Begin(OpenGL.GL_LINE_STRIP);
            /*First Line*/
            gl.Color(1.0f, 0.0f, 0.0f); //задает цвет 
            foreach (var item in list)
            {
                gl.Vertex(item.fieldX, item.fieldY, item.fieldZ);
            }
            gl.End();

            ///*SecondLine*/
            gl.Begin(OpenGL.GL_LINE_STRIP);

            gl.Color(0.0f, 0.0f, 1.0f); //задает цвет 
            foreach (var item in list2)
            {
                gl.Vertex(item.fieldX, item.fieldY, item.fieldZ);
            }
            gl.End();

            gl.Begin(OpenGL.GL_LINE_STRIP);
            gl.Color(0.0f, 1.0f, 0.0f);

            //Delta
            for (int i = 0; i < list.Count; i++)
            {
                var r0 = Math.Sqrt(list2[i].fieldX * list2[i].fieldX + list2[i].fieldY * list2[i].fieldY);
                var r1 = Math.Sqrt(list[i].fieldX * list[i].fieldX + list[i].fieldY * list[i].fieldY);
                var deltar = r1 - r0;

                var r = r0 + deltar * 400;
                var sina = list2[i].fieldY / r0;
                var cosa = list2[i].fieldX / r0;

                var x = r * cosa;
                var y = r * sina;

                //var deltax = list2[i].fieldX - list[i].fieldX;
                //var deltay = list2[i].fieldY - list[i].fieldY;
                //gl.Vertex(list[i].fieldX, list[i].fieldY, list[i].fieldZ);//point from
                gl.Vertex(x, y, 0);//point to   
            }

            gl.End();


            ///*1 Flag*/
            //if (flag1)
            //{
            //    gl.Begin(OpenGL.GL_LINE_STRIP);

            //    gl.Color(0.0f, 1.0f, 0.0f); //задает цвет 

            //    gl.Vertex(flag1Point.X / 100, flag1Point.Y / 100, mainProportion);
            //    gl.Vertex(flag1Point.X / 100, flag1Point.Y / 100, -mainProportion);

            //    gl.End();
            //}



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

        public List<myPoint3> cmdSignal = new List<myPoint3>();
        public List<myPoint3> realSignal = new List<myPoint3>();

        public void Parse(string patch)
        {
            #region 1
            NcMeasure ncMeasure = new NcMeasure();
            if (ncMeasure == null)
                return;

            if (ncMeasure.ReadRawData(patch, null) != ErrorCodes.NoError)
                return;

            AbstractMeasure measure = new AbstractMeasure();
            measure.LoadData(ncMeasure.PointsList);
            list.Clear();

            cmdSignal.Clear();
            realSignal.Clear();

            for (int i = 0; i < ncMeasure.PointsList.Count()/* - (ncMeasure.PointsList.Count()-1000);*/; i++)
            {
                if (i + 5 > ncMeasure.PointsList.Count() /*- (ncMeasure.PointsList.Count() - 1000)*/)
                    break;
                else
                {
                    myPoint3 currentDrPoint = new myPoint3(0, 0, 0);
                    int j = i;
                    while (ncMeasure.PointsList[j].ax_data.axIndex != 0)
                    {
                        j++;
                        continue;
                    }
                    currentDrPoint.fieldX = (float)(ncMeasure.PointsList[j].ax_data.axDrPos * ncMeasure.PointsList[j].ax_data.pos_discr);
                    int k = i;
                    while (ncMeasure.PointsList[k].ax_data.axIndex != 1)
                    {
                        k++;
                        continue;
                    }
                    currentDrPoint.fieldY = (float)(ncMeasure.PointsList[k].ax_data.axDrPos * ncMeasure.PointsList[k].ax_data.pos_discr);
                    list.Add(currentDrPoint);

                    myPoint3 currentCmdPoint = new myPoint3(0, 0, 0);
                    int j2 = i;
                    while (ncMeasure.PointsList[j2].ax_data.axIndex != 0)
                    {
                        j2++;
                        continue;
                    }
                    currentCmdPoint.fieldX = (float)(ncMeasure.PointsList[j2].ax_data.cmd_dr_pos * ncMeasure.PointsList[j2].ax_data.pos_discr);
                    int k2 = i;
                    while (ncMeasure.PointsList[k2].ax_data.axIndex != 1)
                    {
                        k2++;
                        continue;
                    }
                    currentCmdPoint.fieldY = (float)(ncMeasure.PointsList[k2].ax_data.cmd_dr_pos * ncMeasure.PointsList[k2].ax_data.pos_discr);
                    list2.Add(currentCmdPoint);
                }
            }
            listflag = true;


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
            MessageBox.Show(list.Max(x => x.fieldX).ToString());
            MessageBox.Show(list2.Max(x => x.fieldX).ToString());
            #endregion
            #region 2
            //using (StreamReader sr = File.OpenText(patch))
            //{
            //    list.Clear();
            //    var context = sr.ReadToEnd();
            //    foreach (string item in context.Split('\n'))
            //    {
            //        var sub_item = item.Split('\t');
            //        var secretX = sub_item[0];
            //        var secretY = sub_item[1];
            //        var secretZ = sub_item[2];
            //        list.Add(
            //            new myPoint3((float)Convert.ToDouble(sub_item[0]), (float)Convert.ToDouble(sub_item[1]), (float)Convert.ToDouble(sub_item[2]))
            //            );
            //        //  MessageBox.Show(list.Count().ToString());
            //        // DrawMyPointsArray();

            //        listflag = true;
            //    }
            //    if (list.Max(x => x.fieldX) >= list.Max(x => x.fieldY))
            //    {
            //        mainProportion = list.Max(x => x.fieldX) + 10;
            //    }
            //    else if (list.Max(x => x.fieldY >= x.fieldZ))
            //    {
            //        mainProportion = list.Max(x => x.fieldY) + 10;
            //    }
            //    else
            //    {
            //        mainProportion = list.Max(x => x.fieldZ) + 10;
            //    }

            //}
            #endregion
        }
    }
}
