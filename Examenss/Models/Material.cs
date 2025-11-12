namespace Examenss.Models
{
    public class Material
    {
        /// <summary>
        /// Код материала 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Намиенование материала 
        /// </summary>
        public string Names { get; set; }
        /// <summary>
        /// Характеристики материала
        /// </summary>
        public string Haracteristiki { get; set; }
        /// <summary>
        /// Производитель материала
        /// </summary>
        public string Proizvoditel { get; set; }

    }
}
