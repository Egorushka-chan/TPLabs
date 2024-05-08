namespace Lab5.Models
{
    public static class TableArrayExtension
    {
        /// <summary>
        /// Создаёт новый экземпляр массива, который расширен на одну таблицу
        /// </summary>
        public static Table[] Extend(this Table[] tables, Table appendingTable)
        {
            Table[] newArray = new Table[tables.Length+1];
            foreach (int i in Enumerable.Range(0, tables.Length))
            {
                newArray[i] = tables[i];
            }
            newArray[newArray.Length-1] = appendingTable;

            return newArray;
        } 
    }
}
