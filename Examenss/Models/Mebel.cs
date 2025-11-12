namespace Examenss.Models
{
    public class Mebel
    {
        /// <summary>
        /// Код мебели
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование мебели
        /// </summary>
        public string Names { get; set; }
        /// <summary>
        /// Описание мебели 
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Материал мебели 
        /// </summary>
        public string Material { get; set; }
        /// <summary>
        /// Вес мебели
        /// </summary>
        public int Ves { get; set; }
        /// <summary>
        /// Размер мебели
        /// </summary>
        public int Size { get; set; }
        /// <summary>
        /// Стоимость мебели
        /// </summary>
        public int Price { get; set; }

    }
}
