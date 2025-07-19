using SimpleLife.Common;
using System.Text;

namespace SimpleLife.Units
{
    public class Genome
    {
        private int[] genes = new int[Config.GENOME_SIZE];
        private int cursor = 0;
        private Unit unit;

        public void SetUnit(Unit unit)
        {
            this.unit = unit;
        }


        public void InitRandom()
        {
            Random random = new Random();
            for (int i = 0; i < Config.GENOME_SIZE; i++)
            {
                genes[i] = random.Next(128);
            }
        }

        public static void SaveToFile(Genome genome, string path)
        {

            using (StreamWriter sw = new StreamWriter(path))
            {
                string strGenes = string.Join(" ", genome.genes);
                sw.Write(strGenes);
            }
        }


        public static Genome CreateFromFile(string path)
        {

            Genome genome = new Genome();
            using (StreamReader sr = new StreamReader(path))
            {
                string text = sr.ReadToEnd();
                string[] genes = text.Split(' ');

                if (genes.Length != Config.GENOME_SIZE) throw new Exception("Ошибка чтения генома");

                for (int i = 0; i < Config.GENOME_SIZE; i++)
                {
                    genome.genes[i] = int.Parse(genes[i]);
                }

            }
            return genome;
        }


        public bool ReadNextCommand()
        {
            int geneValue = genes[cursor];

            if(geneValue >= 0 && geneValue <= 7)
            {
                int h = unit.Move(geneValue);
                moveCursor(h + 1);
                return false;
            }
            else if (geneValue > 7 && geneValue <= 15)
            {
                int h = unit.Grab(geneValue - 7);
                moveCursor(h + 1);
                return false;
            }
            else if (geneValue > 15 && geneValue <= 23)
            {
                int h = unit.CheckThere(geneValue - 15);
                moveCursor(h + 1);
                return true;
            }
            else if (geneValue > 23 && geneValue <= 31)
            {
                unit.Rotate(geneValue - 23);
                moveCursor(1);
                return true;
            }
            else
            {
                moveCursor(geneValue);
                return true;
            }
        }

        private void moveCursor(int value)
        {
            cursor += value;
            cursor %= Config.GENOME_SIZE;
        }
    }
}
