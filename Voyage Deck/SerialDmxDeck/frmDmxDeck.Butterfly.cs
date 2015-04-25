using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinFormsGraphicsDevice.Device3D;

namespace SerialDmxDeck
{
    partial class frmDmxDeck
    {

        private int[] Butterfly_Heights = new[] { 115, 100, 85, 75, 70, 70, 70, 85, 100, 115, 135, 155, 170, 180, 185, 180, 175, 165, 150, 135, 125, 115, 115, 115, 120, 125, 130, 135, 140, 135, 145, 135, 115, 100, 80, 70, 60, 60, 65, 75, 90, 110, 125, 145, 155, 160, 165, 160, 155, 145, 135, 130, 125, 125, 130, 135, 145, 155, 160, 160, 160, 145, 125, 105, 90, 75, 70, 65, 70, 80, 95, 110, 120, 130, 140, 140, 140, 135, 125, 120, 115, 115, 120, 125, 135, 150, 165, 175, 180, 180, 190, 180, 170, 155, 135, 115, 100, 90, 85, 85, 90, 100, 110, 115, 125, 125, 125, 120, 115, 105, 100, 95, 90, 95, 105, 120, 135, 155, 170, 180, 185, 180, 165, 150, 140, 125, 115, 110, 110, 115, 120, 125, 130, 135, 135, 130, 120, 110, 95, 85, 75, 70, 70, 80, 90, 110, 130, 145, 165, 175, 165, 170, 165, 160, 150, 140, 135, 125, 125, 125, 130, 140, 145, 155, 155, 155, 150, 140, 125, 110, 90, 75, 65, 60, 60, 70, 85, 100, 120, 135 };

        private void button5_Click(object sender, EventArgs e)
        {
            _Meshes.Clear();
            AmsterdamSettings();
            _MeshesStatus = bControl.SetModelList(ref _Meshes);
            bControl.ZoomAll();
        }

        private void AmsterdamSettings()
        {
            int[] v = new int[15];
            
            // fist universe

            Array.ConstrainedCopy(Butterfly_Heights, 0, v, 0, 15);
            AddButterflyLine(1, 1, v, 0, 0, 80, 0);
            Array.ConstrainedCopy(Butterfly_Heights, 30, v, 0, 15);
            AddButterflyLine(1, 16, v, 0, 80, 80, 0);

            Array.ConstrainedCopy(Butterfly_Heights, 60, v, 0, 15);
            AddButterflyLine(1, 31, v, 160, 160, 80, 0);
            Array.ConstrainedCopy(Butterfly_Heights, 90, v, 0, 15);
            AddButterflyLine(1, 46, v, 160, 240, 80, 0);

            Array.ConstrainedCopy(Butterfly_Heights, 120, v, 0, 15);
            AddButterflyLine(1, 61, v, 320, 320, 80, 0);
            Array.ConstrainedCopy(Butterfly_Heights, 150, v, 0, 15);
            AddButterflyLine(1, 76, v, 320, 400, 80, 0);


            Array.ConstrainedCopy(Butterfly_Heights, 15, v, 0, 15);
            AddButterflyLine(2, 1, v, 1200, 0, 80, 0);
            Array.ConstrainedCopy(Butterfly_Heights, 45, v, 0, 15);
            AddButterflyLine(2, 16, v, 1200, 80, 80, 0);

            Array.ConstrainedCopy(Butterfly_Heights, 75, v, 0, 15);
            AddButterflyLine(2, 31, v, 1360, 160, 80, 0);
            Array.ConstrainedCopy(Butterfly_Heights, 105, v, 0, 15);
            AddButterflyLine(2, 46, v, 1360, 240, 80, 0);

            Array.ConstrainedCopy(Butterfly_Heights, 135, v, 0, 15);
            AddButterflyLine(2, 61, v, 1520, 320, 80, 0);
            Array.ConstrainedCopy(Butterfly_Heights, 165, v, 0, 15);
            AddButterflyLine(2, 76, v, 1520, 400, 80, 0);

        }

        private void AddButterflyLine(int universeNumber, int initialUniverseAddress, int[] heights, float initialPositionX, float initialPositionY, float deltaX, float deltaY)
        {
            float px = initialPositionX;
            float py = initialPositionY;

            foreach (var height in heights)
            {
                var b = MakeButterfly(px, py, height);
                px += deltaX;
                py += deltaY;
            }
            Debug.WriteLine("px:" + px);
        }


        private class BFSystem
        {
            public double pipeLen = double.NaN;
            public double cableLen;

            public string toExcelCell()
            {
                if (double.IsNaN(pipeLen))
                    return "Nan\t";
                return pipeLen.ToString() + "\t";
            }
        }

        private BFSystem MakeButterfly(float x, float y, float z)
        {
            float posX = x;
            float posY = y;

            var s = new BFSystem() { pipeLen = z };
            
            // tube
            var m = new MeshXNA("BF" + x + "_" + y) { ColorXna = new Color(new Vector4(200, 0, 0, 100)) };
            m.AddPrimitiveCylinder(1.0f, z, Matrix.CreateTranslation(posX, posY, z / 2));

            // wings
            var points = new Vector3[] {
                new Vector3(0,0,0), //0
                new Vector3(-25,25,0),
                new Vector3(0,35,0),
                new Vector3(10,30,0), //3
                new Vector3(15,0,0), // 4
                new Vector3(25,20,0), //5
                new Vector3(5,12,0), //6
            };

            var indices = new ushort[]
            {
                0, 1, 2, 
                0, 2, 3,
                0, 3, 4,
                6, 5, 4
            };

            var MT = Matrix.CreateTranslation(posX, posY, z);
            var M1 = Matrix.CreateRotationX((float)(Math.PI / 2 - 1.0f));
            var M2 = Matrix.CreateRotationX((float)(Math.PI / 2 + 1.0f));

            var mi3d1 = new MeshIndexed3D(points, indices);
            // var mi3d2 = new MeshIndexed3D(points, indices);
            //m.ColorXna = Color.Blue;
            m.AddIndexedMesh(mi3d1, M1 * MT);
            m.AddIndexedMesh(mi3d1, M2 * MT);

            _Meshes.Add(m);
            return s;
        }

        private List<MeshXNA> _Meshes = new List<MeshXNA>();
        private List<MeshXNAStatus> _MeshesStatus = new List<MeshXNAStatus>();
    }
}
