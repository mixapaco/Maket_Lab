using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maket_Lab.CodecsWork
{
     
    class IterativeCodec
    {
        //private bool[,] Matrix;
        private Int32 MaxX = 5;
        private Int32 MaxY = 5;

        public IterativeCodec()
        { 
        }

        


        public List<bool> CodeBits(List<bool> bits)
        {
            List<List<bool>> matrix = BinWork.Matrix.CreateMatrix(bits,MaxX,MaxY);

            for (int y = 0; y < MaxY; y++)
            {
                matrix[y].Add(BinWork.BinWorker.CountMod2(BinWork.Matrix.GetRow(matrix, y)));

            }
            List<bool> buf = new List<bool>();
            for (int x = 0; x < MaxX; x++)
            {
                buf.Add(BinWork.BinWorker.CountMod2(BinWork.Matrix.GetColumn(matrix, x)));

            }
            matrix.Add(buf);

            buf.Add(BinWork.BinWorker.CountMod2(BinWork.Matrix.GetRow(matrix, MaxX)));
            
            return BinWork.Matrix.CreateArr(matrix);
        }









    }


}
