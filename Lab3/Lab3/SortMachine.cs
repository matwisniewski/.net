using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class SortMachine
    {
        private int[] Table;

        public SortMachine(int[] table)
        {
            this.Table = table;
        }

        public int[] RandomTable()
        {
            Random rand = new Random();
            for (int i = 0; i < Table.Length; i++)
            {
                Table[i] = rand.Next(10);
            }
            
            return Table;
        }

        public void Sort()
        {
            for (int i = 0; i < Table.Length; i++)
            {
                for (int j = 0; j < Table.Length - 1; j++)
                {
                    if (Table[j] < Table[j + 1])
                    {
                        var tmp = Table[j];
                        Table[j] = Table[j + 1];
                        Table[j + 1] = tmp;
                    }
                }
            }
        }

        public void ParallelSort()
        {
            Parallel.For(0, Table.Length, i =>
            {
                for (int j = 0; j < Table.Length - 1; j++)
                {
                    if (Table[j] < Table[j + 1])
                    {
                        var tmp = Table[j];
                        Table[j] = Table[j + 1];
                        Table[j + 1] = tmp;
                    }
                }
            });
        }
    }
}
