using System.Text;

namespace SimpleLife
{
    public class Genome
    {
        private int[] genes = new int[Config.GENOME_SIZE];
        private int cursor = 0;
        private Unit unit;

        public Genome(Unit unit)
        {
            InitRandom();
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

        public void SaveToFile(string path)
        {

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                string strGenes = string.Join(" ", genes);

                fs.Write(Encoding.Default.GetBytes(strGenes));
            }
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
