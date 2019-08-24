namespace BabatyeInventory
{
    class Cloth
    {
        private string SKUNumber { get; set; }

        public string SkuNumber(string SKUNum)
        {
            return SKUNum;
        }

        public string ProductColor(string SKUNum)
        {
            SKUNum = SKUNumber;

            if (SKUNum.Substring(7, 8) == "BL")
            {
                return "BLACK";
            }
            else if (SKUNum.Substring(7, 8) == "GR")
            {
                return "GREEN";
            }
            else
            {
                return null;
            }
        }

        public string ProductSize(string SKUNum)
        {
            SKUNum = SKUNumber;

            string Size = SKUNum.Substring(10, 11);

            if (Size == "02")
            {
                return "Small";
            }
            else if (Size == "03")
            {
                return "Medium";
            }
            else if (Size == "04")
            {
                return "Large";
            }
            else
            {
                return null;
            }
        }

        public string ProductName(string SKUNum)
        {
            SKUNum = SKUNumber;

            string Name = SKUNum.Substring(0, 6);

            return Name;
        }
    }
}
