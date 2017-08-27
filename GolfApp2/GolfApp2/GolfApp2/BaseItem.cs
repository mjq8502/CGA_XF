using SQLite;

namespace GolfApp2
{
    public class BaseItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
    }
}
