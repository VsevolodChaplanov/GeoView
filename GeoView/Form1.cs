using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/// <summary>
/// Libraries for linking OpenGL
/// </summary>
// Access to FreeGlut framework
// Getting access to OpenGl classes:
//  *Gl
//  *Glu
using Tao.OpenGl;
// Getting access to OpenGl classes:
//  *Wgl
//  *GDI
//  *User
using Tao.Platform.Windows;
using System.Runtime.InteropServices;


namespace GeoView
{
    public partial class Form1 : Form
    {
        // Загрузку текстуры
        // Выбрать цвет поверхзности
        // через colordialog
        IntPtr Handle3D;
        IntPtr HDC3D;
        IntPtr HRC3D;
        float r = 10;
        float phi = 30;
        float psi = 30;
        // true - рисование с освещением
        // false - рисование без освещения
        bool lightning_state = false;
        bool coloring_state = false;
        // Using fonts
        int Font3D = 0;
        // Texture
        // uint Texture = LoadTexture(@"D:\Programing\C#\OpenGl\GeoView\GeoView\Grani2.bmp");
        uint Texture = 0;
        string texturefilename;
        string fileName;
        private GVContainer surfaceValues = new GVContainer();

        delegate void PaintDecorator();

        // Scaling factors
        double x_scale_factor = 1;
        double y_scale_factor = 1;
        double z_scale_factor = 1;

        // Origin position
        double x_origin = 0;
        double y_origin = 0;
        double z_origin = 0;

        //
        double x_move = 0;
        double y_move = 0;
        double z_move = 0;

        double view_width;
        double view_height;

        enum drawingStates {
            None,
            Points,
            Rectangles,
            FilledQuads,
            RectsQuads
        };
        double transparancy = 1;

        bool istexture = false;

        drawingStates drawState;

        Color meshcolor = Color.Red;
        Color surfacecolor = Color.Blue;
        Color pointscolor = Color.Black;

        int w;
        int h;

        public Form1()
        {
            InitializeComponent();
            // Use Form to draw in it
            Handle3D = Handle;
            HDC3D = User.GetDC(Handle3D);
            Gdi.PIXELFORMATDESCRIPTOR PFD = new Gdi.PIXELFORMATDESCRIPTOR();
            PFD.nVersion = 1;
            PFD.nSize = (short)Marshal.SizeOf(PFD);
            PFD.dwFlags =
                Gdi.PFD_DRAW_TO_WINDOW |
                Gdi.PFD_SUPPORT_OPENGL |
                Gdi.PFD_DOUBLEBUFFER;
            PFD.iPixelType = Gdi.PFD_TYPE_RGBA;
            PFD.cColorBits = 24;
            PFD.cDepthBits = 32;
            PFD.iLayerType = Gdi.PFD_MAIN_PLANE;
            int nPixelFormat = Gdi.ChoosePixelFormat(HDC3D, ref PFD);
            Gdi.SetPixelFormat(HDC3D, nPixelFormat, ref PFD);
            HRC3D = Wgl.wglCreateContext(HDC3D);
            Wgl.wglMakeCurrent(HDC3D, HRC3D);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            CreateFont3D(Font);
            //Texture = LoadTexture(@"D:\Programing\C#\OpenGl\GeoView\GeoView\dengi.bmp");
            this.trackBarXOriginPos.Maximum = (ClientRectangle.Width - UIPanel.Width) / 2;
            this.trackBarZOriginPos.Maximum = ClientRectangle.Height / 2;
            this.trackBarXOriginPos.Minimum = - (ClientRectangle.Width - UIPanel.Width) / 2;
            this.trackBarZOriginPos.Minimum = - ClientRectangle.Height / 2;
            Form1_Resize(null, null);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            // Properties of the WinForm
            w = ClientRectangle.Width - UIPanel.Width;
            h = ClientRectangle.Height;
            Glu.gluPerspective(30, (double)w / h, 2, 200000);
            Gl.glViewport(0, 0, w, h);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Gl.glClearColor(1.0f, 1.0f, 1.0f, 1); // Dummy zeros
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            // ToDO вычилсить центр поверзхности при знагруджен
            //Gl.glOrtho(surfaceValues.xMin, surfaceValues.xMin, surfaceValues.zMin, surfaceValues.zMax, surfaceValues.yMin, surfaceValues.yMax);
            Gl.glTranslated(x_move, y_move, z_move);
            //r = (float) Math.Sqrt(
            //    (surfaceValues.xMax - surfaceValues.xMin) * (surfaceValues.xMax - surfaceValues.xMin) +
            //    (surfaceValues.yMax - surfaceValues.yMin) * (surfaceValues.yMax - surfaceValues.yMin) +
            //    (surfaceValues.zMax - surfaceValues.zMin) * (surfaceValues.zMax - surfaceValues.zMin)
            //);
            Gl.glTranslatef(0, 0, -r);
            Gl.glRotatef(phi, 1f, 0, 0);
            Gl.glRotatef(psi, 0, 1f, 0);
            Gl.glScaled(x_scale_factor, y_scale_factor, z_scale_factor);
            drawOrigin();
            Gl.glScaled(2 / (surfaceValues.xMax - surfaceValues.xMin), 2 / (surfaceValues.zMax - surfaceValues.zMin), 2 / (surfaceValues.yMax - surfaceValues.yMin));
            Gl.glTranslated(-Math.Abs(x_origin), -Math.Abs(z_origin), -Math.Abs(y_origin));
            DrawScene();
            Gl.glViewport(0, 0, w, h);
            Gl.glFinish();
            Gdi.SwapBuffers(HDC3D);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Wgl.wglMakeCurrent(IntPtr.Zero, IntPtr.Zero);
            Wgl.wglDeleteContext(HRC3D);
            User.ReleaseDC(Handle3D, HDC3D);
            DeleteFont3D();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == GLSettings.WM_ERASEBKGND)
            {
                InvalidateRect();
            }
        }

        /// <summary>
        /// Работа с текстами и шрифтами
        /// </summary>
        void CreateFont3D(Font font)
        {
            Gdi.SelectObject(HDC3D, font.ToHfont());
            Font3D = Gl.glGenLists(256);
            Wgl.wglUseFontBitmapsA(HDC3D, 0, 256, Font3D);
        }

        void outText3D(float x, float y, float z, string text)
        {
            Gl.glRasterPos3f(x, y, z);
            Gl.glPushAttrib(Gl.GL_LIST_BIT);
            Gl.glListBase(Font3D);
            byte[] bText = GLSettings.RussianEncoding.GetBytes(text);
            Gl.glCallLists(text.Length, Gl.GL_UNSIGNED_BYTE, bText);
            Gl.glPopAttrib();
        }
        
        void DeleteFont3D()
        {
            if (Font3D != 0)
            {
                Gl.glDeleteLists(Font3D, 256);
            }
        }

        /// <summary>
        /// Функции рисования сцен
        /// </summary>
        /// 
        private void InvalidateRect()
        {
            GLSettings.InvalidateRect(Handle, IntPtr.Zero, false);
        }

        private void DrawScene()
        {
            Gl.glEnable(Gl.GL_BLEND);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
            if (fileName == null)
            {
                return;
            }
            if (lightning_state)
            {
                // ----------- Включаем освещенность объектов -----------
                Gl.glEnable(Gl.GL_LIGHTING);
                Gl.glEnable(Gl.GL_LIGHT0);
                // ------------------------------------------------------
                // ----------- Включаем коррекцию нормалей для рисования с освещением -----------
                Gl.glEnable(Gl.GL_NORMALIZE);
                // ----------- Олучшаем собсвтенный цвет объектов в освещении -----------
                Gl.glEnable(Gl.GL_COLOR_MATERIAL);
                // ----------- Модель освещения -----------
                Gl.glLightModeli(Gl.GL_LIGHT_MODEL_TWO_SIDE, 1);
                // -----------------------------------------------------------------------------
            }
            if (Texture != 0 && istexture)
            {
                Gl.glEnable(Gl.GL_TEXTURE_2D);
                Gl.glTexEnvf(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_DECAL);
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, Texture);
            }
            if (drawState == drawingStates.Points)
            {
                Gl.glColor4d((double)pointscolor.R / 255, (double)pointscolor.G / 255, (double) pointscolor.B / 255, transparancy);
                drawSurfacePoints();
            }
            if (drawState == drawingStates.Rectangles || drawState == drawingStates.RectsQuads)
            {
                Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_LINE);
                Gl.glEnable(Gl.GL_POLYGON_OFFSET_FILL);
                Gl.glPolygonOffset(1.0f, 1.0f);
                Gl.glColor4d((double)meshcolor.R / 255, (double)meshcolor.G / 255, (double)meshcolor.B / 255, transparancy);
                drawSurface();
                Gl.glDisable(Gl.GL_POLYGON_OFFSET_FILL);
            }
            if (drawState == drawingStates.FilledQuads || drawState == drawingStates.RectsQuads)
            {
                Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL);
                Gl.glColor4d((double)surfacecolor.R / 255, (double)surfacecolor.G / 255, (double)surfacecolor.B / 255, transparancy);
                Gl.glEnable(Gl.GL_POLYGON_OFFSET_FILL);
                drawSurface();
                Gl.glDisable(Gl.GL_BLEND);
                Gl.glDisable(Gl.GL_POLYGON_OFFSET_FILL);
            }
            if (lightning_state)
            {
                // ----------- Отключение освещения -----------
                Gl.glDisable(Gl.GL_LIGHT0);
                Gl.glDisable(Gl.GL_LIGHTING);
                Gl.glDisable(Gl.GL_COLOR_MATERIAL);
                // --------------------------------------------
            }
            if (istexture)
            {
                Gl.glDisable(Gl.GL_TEXTURE_2D);
            }
            Gl.glDisable(Gl.GL_BLEND);
        }

        private void drawSurface()
        {
            if (fileName == null)
            {
                return;
            }
            double hx = (surfaceValues.xMax - surfaceValues.xMin) / (surfaceValues.Nx - 1);
            double hy = (surfaceValues.yMax - surfaceValues.yMin) / (surfaceValues.Ny - 1);

            for (int j = 0; j < surfaceValues.Ny - 1; j++)
            {
                for (int i = 0; i < surfaceValues.Nx - 1; i++)
                {
                    double x_init = (surfaceValues.xMin + i * hx);
                    double y_init = (surfaceValues.yMin + j * hy);

                    double x_init_1 = x_init + hx;
                    double y_init_1 = y_init + hy;

                    double lrx = 1 - (double)(i + 1) / (surfaceValues.Nx - 1);
                    double lry = (double) j / (surfaceValues.Ny - 1);

                    double llx = 1 - (double) (i) / (surfaceValues.Nx - 1);
                    double lly = (double) j / (surfaceValues.Ny - 1);

                    double ulx = 1 - (double) (i) / (surfaceValues.Nx - 1);
                    double uly = (double) (j + 1) / (surfaceValues.Ny - 1);

                    double urx = 1 - (double) (i + 1) / (surfaceValues.Nx - 1);
                    double ury = (double) (j + 1) / (surfaceValues.Ny - 1);

                    double z1 = surfaceValues.funcValues[Index(i, j)];
                    double z2 = surfaceValues.funcValues[Index(i + 1, j)];
                    double z3 = surfaceValues.funcValues[Index(i + 1, j + 1)];
                    double z4 = surfaceValues.funcValues[Index(i, j + 1)];

                    List<double> normals_1 = surfaceValues.derivatives[Index(i, j)];
                    List<double> normals_2 = surfaceValues.derivatives[Index(i + 1, j)];
                    List<double> normals_3 = surfaceValues.derivatives[Index(i + 1, j + 1)];
                    List<double> normals_4 = surfaceValues.derivatives[Index(i, j + 1)];

                    Gl.glBegin(Gl.GL_QUADS);

                    setGlColor(z1);
                    Gl.glTexCoord2d(llx, lly); // ulx uly
                    Gl.glNormal3d(
                        normals_1[0],
                        normals_1[1],
                        normals_1[2]
                        );
                    Gl.glVertex3d(
                        x_init,
                        z1,
                        y_init
                        );

                    setGlColor(z4);
                    Gl.glTexCoord2d(ulx, uly); // llx, lly
                    Gl.glNormal3d(
                        normals_4[0],
                        normals_4[1],
                        normals_4[2]
                        );
                    Gl.glVertex3d(
                        x_init,
                        z4,
                        y_init_1
                        );

                    setGlColor(z3);
                    Gl.glTexCoord2d(urx, ury); //lrx, lry
                    Gl.glNormal3d(
                        normals_3[0],
                        normals_3[1],
                        normals_3[2]
                        );
                    Gl.glVertex3d(
                        x_init_1,
                        z3,
                        y_init_1
                        );

                    setGlColor(z2);
                    Gl.glTexCoord2d(lrx, lry); // urx, ury
                    Gl.glNormal3d(
                        normals_2[0],
                        normals_2[1],
                        normals_2[2]
                        );
                    Gl.glVertex3d(
                        x_init_1,
                        z2,
                        y_init
                        );

                    Gl.glEnd();
                }
            }

            Gl.glDisable(Gl.GL_TEXTURE_2D);
        }

        private void drawOrigin()
        {
            //// ------------ Оси координат -------------
            Gl.glLineWidth(1);
            Gl.glBegin(Gl.GL_LINES);
            Gl.glColor3f(1, 0, 0);
            Gl.glVertex3d(0, 0, 0); // Ось х
            Gl.glVertex3d(1, 0, 0);
            Gl.glColor3f(0, 1, 0);
            Gl.glVertex3d(0, 0, 0); // Ось z
            Gl.glVertex3d(0, 1, 0);
            Gl.glColor3f(0, 0, 1);
            Gl.glVertex3d(0, 0, 0); // Ось y
            Gl.glVertex3d(0, 0, 1);
            Gl.glEnd();
            outText3D(1, 0, 0, "x");
            outText3D(0, 1, 0, "z");
            outText3D(0, 0, 1, "y");
            //// ----------------------------------------
        }

        private void drawSurfacePoints()
        {
            double hx = (surfaceValues.xMax - surfaceValues.xMin) / (surfaceValues.Nx - 1);
            double hy = (surfaceValues.yMax - surfaceValues.yMin) / (surfaceValues.Ny - 1);

            if (fileName == null)
            {
                return;
            }

            for (int i = 0; i < surfaceValues.Nx; i++)
            {
                for (int j = 0; j < surfaceValues.Ny; j++)
                {
                    double x = (surfaceValues.xMin + i * hx);
                    double y = (surfaceValues.yMin + j * hy);
                    double z = (surfaceValues.funcValues[Index(i, j)]);

                    List<double> normal = surfaceValues.derivatives[Index(i, j)];
                    Gl.glBegin(Gl.GL_POINTS);
                    Gl.glPointSize(3);
                    setGlColor(z);
                    Gl.glNormal3d(
                       normal[0],
                       normal[1],
                       normal[2]
                       );
                    Gl.glVertex3d(
                        x,
                        z,
                        y);
                    Gl.glEnd();
                }
            }
        }

        private int Index(int i, int j)
        {
            int result = i + j * surfaceValues.Nx;
            return result;
        }

        private void trackBarR_Scroll(object sender, EventArgs e)
        {
            this.r = trackBarR.Value;
            InvalidateRect();
        }

        private void trackBarPhi_Scroll(object sender, EventArgs e)
        {
            this.phi = trackBarPhi.Value;
            InvalidateRect();
        }

        private void trackBarPsi_Scroll(object sender, EventArgs e)
        {
            this.psi = trackBarPsi.Value;
            InvalidateRect();
        }

        private void Parse()
        {
            this.surfaceValues = GRDParser.ParseFile(fileName);
            x_origin = (surfaceValues.xMax + surfaceValues.xMin) / 2;
            y_origin = (surfaceValues.yMax + surfaceValues.yMin) / 2;
            z_origin = (surfaceValues.zMax + surfaceValues.zMin) / 2;
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
            }
            Parse();
        }

        private void DrawSurface_button_Click_1(object sender, EventArgs e)
        {
            InvalidateRect();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)comboBox1.SelectedItem == "Points")
            {
                drawState = drawingStates.Points;
            }
            if ((string)comboBox1.SelectedItem == "Mesh")
            {
                drawState = drawingStates.Rectangles;
            }
            if ((string)comboBox1.SelectedItem == "Surface")
            {
                drawState = drawingStates.FilledQuads;
            }
            if ((string)comboBox1.SelectedItem == "Surface and mesh")
            {
                drawState = drawingStates.RectsQuads;
            }
            InvalidateRect();
        }

        private void trackBarXScale_Scroll(object sender, EventArgs e)
        {
            this.x_scale_factor = trackBarXScale.Value / 10.0f;
            InvalidateRect();
        }

        private void trackBarYScale_Scroll(object sender, EventArgs e)
        {
            this.z_scale_factor = trackBarYScale.Value / 10.0f;
            InvalidateRect();
        }

        private void trackBarZScale_Scroll(object sender, EventArgs e)
        {
            this.y_scale_factor = trackBarZScale.Value / 10.0;
            InvalidateRect();
        }

        private void checkBox_lightning_CheckedChanged(object sender, EventArgs e)
        {
            lightning_state = checkBox_lightning.Checked;
            InvalidateRect();
        }

        private void trackBarXOriginPos_Scroll(object sender, EventArgs e)
        {
            x_move = trackBarXOriginPos.Value / 10.0f;
            InvalidateRect();
        }

        private void trackBarYOriginPos_Scroll(object sender, EventArgs e)
        {
            z_move = trackBarYOriginPos.Value / 10.0f;
            InvalidateRect();
        }

        private void trackBarZOriginPos_Scroll(object sender, EventArgs e)
        {
            y_move = trackBarZOriginPos.Value / 10.0f;
            InvalidateRect();
        }

        private void checkBoxColoring_CheckedChanged(object sender, EventArgs e)
        {
            coloring_state = checkBoxColoring.Checked;
            InvalidateRect();
        }

        private void setGlColor(double z)
        {
            if (coloring_state)
            {
                // От синего к красному
                double deltaz = surfaceValues.zMax - surfaceValues.zMin;
                double red_color = (z - surfaceValues.zMin) / deltaz;
                double blue_color = 1 - (z - surfaceValues.zMin) / deltaz;
                Gl.glColor4d(red_color, 0, blue_color, transparancy);
            }
        }

        private void trackBarTransparency_Scroll(object sender, EventArgs e)
        {
            transparancy = trackBarTransparency.Value / 10.0;
            InvalidateRect();
        }

        static uint LoadTexture(string filename)
        {
            uint texObject = 0;
            try
            {
                Bitmap bmp = new Bitmap(filename);
                bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
                BitmapData bmpdata = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                texObject = MakeGlTexture(bmpdata.Scan0, bmp.Width, bmp.Height);
                bmp.UnlockBits(bmpdata);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return texObject;
        }

        static uint MakeGlTexture(IntPtr pixels, int w, int h)
        {
            // Identificator of texture object
            uint texObject = 0;
            // Generating text object
            Gl.glGenTextures(1 /*Objects number*/, out texObject);
            // Setting pixel packing mode
            Gl.glPixelStorei(Gl.GL_UNPACK_ALIGNMENT, 1);
            // Binding to created texture
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texObject);
            // Setting texture filtration mode
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_NEAREST);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_NEAREST);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGB, w, h, 0, Gl.GL_BGR, Gl.GL_UNSIGNED_BYTE, pixels);
            return texObject;
        }

        //private void checkBoxTexture_CheckedChanged(object sender, EventArgs e)
        //{
        //    istexture = checkBoxTexture.Checked;
        //    InvalidateRect();
        //}

        private void PointsColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.pointscolor = colorDialog.Color;
            }
            InvalidateRect();
        }

        private void MeshColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.meshcolor = colorDialog.Color;
            }
            InvalidateRect();
        }

        private void SurfaceColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.surfacecolor = colorDialog.Color;
            }
            InvalidateRect();
        }

        private void TextureLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                texturefilename = openFileDialog1.FileName;
            }
            Texture = LoadTexture(texturefilename);
            InvalidateRect();
        }

        private void checkBoxTexture_CheckedChanged(object sender, EventArgs e)
        {
            istexture = checkBoxTexture.Checked;
            InvalidateRect();
        }
    }
}

