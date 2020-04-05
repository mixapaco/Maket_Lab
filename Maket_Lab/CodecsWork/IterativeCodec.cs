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

        public List<bool> DeCodeLineBits(List<bool> bits)
        {
            List<bool> buf = new List<bool>();
            List<bool> res = new List<bool>();

            for (int i = 1, k = 0; k < bits.Count; i++)
            {
                for (; k < i * ((MaxX+1) * (MaxY+1)); k++)
                {
                    if (bits.Count == k)
                    {
                        break;
                    }
                    buf.Add(bits[k]);
                }
                if (buf.Count > 0)
                {
                    buf = DeCodeBits(buf);
                    res.AddRange(buf);
                }
                buf.Clear();
            }

            return res;
        }

        public List<bool> CodeLineBits(List<bool> bits)
        {
            List<bool> buf = new List<bool>();
            List<bool> res = new List<bool>();

            for (int i = 1,k = 0; k < bits.Count; i++ )
            {
                for (; k < i * (MaxX * MaxY); k++)
                {
                    if(bits.Count == k)
                    {
                        break;
                    }
                    buf.Add(bits[k]);
                }
                if (buf.Count > 0)
                {
                    buf = CodeBits(buf);
                    res.AddRange(buf);
                }
                buf.Clear();
            }

            return res;
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

            buf.Add(BinWork.BinWorker.CountMod2(BinWork.Matrix.GetRow(matrix, MaxY)));
            
            return BinWork.Matrix.CreateArr(matrix);
        }



        public List<bool> DeCodeBits(List<bool> bits)
        {
            List<List<bool>> matrix = BinWork.Matrix.CreateMatrix(bits, MaxX+1, MaxY+1);



            for (int y = 0; y < MaxY+1; y++)
            {
                matrix[y].Add(BinWork.BinWorker.CountMod2(BinWork.Matrix.GetRow(matrix, y)));

            }
            List<bool> buf = new List<bool>();
            for (int x = 0; x < MaxX+1; x++)
            {
                buf.Add(BinWork.BinWorker.CountMod2(BinWork.Matrix.GetColumn(matrix, x)));

            }
            matrix.Add(buf);

            FixErrors(matrix);
            BinWork.Matrix.RemoveColumn(matrix, MaxX + 2);
            BinWork.Matrix.RemoveColumn(matrix, MaxX + 1);
            matrix.RemoveAt(matrix.Count - 2);
            matrix.RemoveAt(matrix.Count - 1);
            return BinWork.Matrix.CreateArr(matrix);
        }


        public List<List<bool>> FixErrors(List<List<bool>> bits)
        {
            foreach (var bitl in bits)
            {
                if (bitl.Count != bits[0].Count)
                    break;

                if(bitl.Last())
                {
                    int last = bits.Count-1;
                    for (int i = 0; i < bits[last].Count; i++)
                    {
                        if(bits[last][i])
                        {
                            bitl[i] = BinWork.BinWorker.Reverse(bitl[i]);
                            bits[last][i] = BinWork.BinWorker.Reverse(bits[last][i]);
                            break;
                        }
                    }
                }
            }
            return bits;
        }




    }


}
