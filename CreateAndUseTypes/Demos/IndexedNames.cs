namespace CreateAndUseTypes.Demos
{
    class IndexedNames
    {
        // Barking store
        private string[] namelist = new string[size];
        static public int size = 10;

        public IndexedNames()
        {
            for (int i = 0; i < size; i++)
                namelist[i] = "N. A.";
        }

        // THIS is invoked for each type instance.
        public string this[int index]
        {
            get
            {
                string tmp;

                // Loop from 0 to 9.
                if (index >= 0 && index <= size - 1)
                {
                    tmp = namelist[index];
                }
                else
                {
                    tmp = "";
                }

                return (tmp);
            }
            set
            {
                if (index >= 0 && index <= size - 1)
                {
                    namelist[index] = value;
                }
            }
        }
    }
}
